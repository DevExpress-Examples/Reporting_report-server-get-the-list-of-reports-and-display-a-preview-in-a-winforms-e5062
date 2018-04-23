// Developer Express Code Central Example:
// How to get the list of available reports, export to PDF and display a report preview in a Windows Forms application
// 
// The sample demonstrates how to use the Report Server WCF API in a Windows Forms
// application.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E5062

// Developer Express Code Central Example:
// How to connect to a Report Server from a Windows Forms application
// 
// The sample demonstrates how to use the Report Server WCF API in a Windows Forms
// application.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E5062

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.DocumentServices.ServiceModel;
using DevExpress.ReportServer.ServiceModel.Client;
using DevExpress.ReportServer.ServiceModel.ConnectionProviders;
using DevExpress.ReportServer.ServiceModel.DataContracts;
using DevExpress.XtraPrinting;

namespace ReportServerWinFormsClientDemo {
    public partial class MainForm : Form {
        const string ServerAddress = "https://reportserver.devexpress.com";
        readonly ConnectionProvider serverConnection = new GuestConnectionProvider(ServerAddress);

        public MainForm() {
            InitializeComponent();
        }

        void MainForm_Load(object sender, EventArgs e) {
            SynchronizationContext uiContext = SynchronizationContext.Current;
            splashScreenManager1.ShowWaitForm();

            serverConnection
                .ConnectAsync()
                .ContinueWith(task => {
                    IReportServerClient client = task.Result;
                    client.SetSynchronizationContext(uiContext);
                    return client.GetReportsAsync(null);
                }).Unwrap()
                .ContinueWith(task => {
                    splashScreenManager1.CloseWaitForm();
                    if(task.IsFaulted) {
                        MessageBox.Show(task.Exception.Flatten().InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else {
                        FillReportListBox(task.Result);
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        void FillReportListBox(IEnumerable<ReportCatalogItemDto> reports) {
            foreach(var reportDto in reports) {
                ReportListBoxItem listBoxItem = new ReportListBoxItem() { DisplayName = reportDto.Name, Id = reportDto.Id };
                reportListBox.Items.Add(listBoxItem);
            }
        }

        void reportListBox_SelectedIndexChanged(object sender, EventArgs e) {
            showReportButton.Enabled = reportListBox.SelectedItem != null;
            export2PDFReportButton.Enabled = reportListBox.SelectedItem != null;
        }

        void showReportButton_Click(object sender, EventArgs e) {
            ReportListBoxItem selectedItem = (ReportListBoxItem)reportListBox.SelectedItem;
            ReportViewerForm form = new ReportViewerForm(selectedItem.Id, serverConnection) { Owner = this };
            form.ShowDialog();
        }

        void ExportToPdf(ConnectionProvider serverConnection, string fileName, int reportId) {
            splashScreenManager1.ShowWaitForm();
            Task.Factory.ExportReportAsync(serverConnection.CreateClient(), new ReportIdentity(reportId), new PdfExportOptions(), null, null)
                .ContinueWith(task => {
                    splashScreenManager1.CloseWaitForm();
                    try {
                        if(task.IsFaulted) {
                            throw new Exception(task.Exception.Flatten().InnerException.Message);
                        }
                        File.WriteAllBytes(fileName, task.Result);
                    } catch(Exception e) {
                        MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());   
        }

        private void export2PDFReportButton_Click(object sender, EventArgs e) {
            if(saveFileDialog1.ShowDialog() != DialogResult.OK) {
                return;
            }
            ExportToPdf(serverConnection, saveFileDialog1.FileName, ((ReportListBoxItem)reportListBox.SelectedItem).Id);
        }
    }
}
