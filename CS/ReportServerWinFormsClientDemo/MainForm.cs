using DevExpress.Data.Utils.ServiceModel;
using DevExpress.ReportServer.ServiceModel.Client;
using DevExpress.ReportServer.ServiceModel.DataContracts;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportServerWinFormsClientDemo {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        void MainForm_Load(object sender, EventArgs e) {
            Login();
        }

        void Login() {
            splashScreenManager1.ShowWaitForm();
            AuthenticationServiceClientFactory authenticationClientFactory = new AuthenticationServiceClientFactory("ReportServer_Authentication");
            var authenticationClient = authenticationClientFactory.Create();
            authenticationClient.Login(null, null, null, LoginCompleted);
        }

        void LoginCompleted(ScalarOperationCompletedEventArgs<bool> args) {
            splashScreenManager1.CloseWaitForm();
            if(args.Error != null) {
                MessageBox.Show(args.Error.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!args.Result) {
                MessageBox.Show("Access denied", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FillReportListBox();
        }

        void FillReportListBox() {
            splashScreenManager1.ShowWaitForm();
            ReportServerClientFactory factory = new ReportServerClientFactory("ReportServer");
            IReportServerClient client = factory.Create();
            client.GetReports(null, GetReportsCompletedCallback);
        }

        void GetReportsCompletedCallback(ScalarOperationCompletedEventArgs<IEnumerable<ReportCatalogItemDto>> args) {
            splashScreenManager1.CloseWaitForm();

            if(args.Error != null) {
                MessageBox.Show(args.Error.Message);
                return;
            }

            foreach(var reportDto in args.Result) {
                ReportListBoxItem listBoxItem = new ReportListBoxItem() { DisplayName = reportDto.Name, Id = reportDto.Id };
                reportListBox.Items.Add(listBoxItem);
            }
        }

        void reportListBox_SelectedIndexChanged(object sender, EventArgs e) {
            showReportButton.Enabled = reportListBox.SelectedItem != null;
        }

        void showReportButton_Click(object sender, EventArgs e) {
            ReportListBoxItem selectedItem = (ReportListBoxItem)reportListBox.SelectedItem;
            ReportViewerForm form = new ReportViewerForm(selectedItem.Id) { Owner = this };
            form.ShowDialog();
        }
    }
}
