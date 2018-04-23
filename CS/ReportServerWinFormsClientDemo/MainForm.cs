using DevExpress.Data.Utils.ServiceModel;
using DevExpress.ReportServer.ServiceModel.Client;
using DevExpress.ReportServer.ServiceModel.DataContracts;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportServerWinFormsClientDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew<bool>(Login)
                .ContinueWith(LoginCompleted, new CancellationToken(), TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void reportListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showReportButton.Enabled = reportListBox.SelectedItem != null;
        }

        private void showReportButton_Click(object sender, EventArgs e)
        {
            ReportListBoxItem selectedItem = (ReportListBoxItem)reportListBox.SelectedItem;
            ReportViewerForm form = new ReportViewerForm(selectedItem.Id) { Owner = this };
            form.ShowDialog();
        }

        bool Login()
        {
            splashScreenManager1.ShowWaitForm();

            ChannelFactory<IAuthenticationService> channelFactory = new ChannelFactory<IAuthenticationService>("ReportServer_Authentication");
            IAuthenticationService client = channelFactory.CreateChannel();
            return client.Login(null, null);
        }

        void LoginCompleted(Task<bool> task)
        {
            if (task.IsFaulted)
            {
                splashScreenManager1.CloseWaitForm();
                MessageBox.Show(task.Exception.InnerException.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!task.Result)
            {
                splashScreenManager1.CloseWaitForm();
                MessageBox.Show("Access denied", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FillReportListBox();
        }

        private void FillReportListBox()
        {
            ReportServerClientFactory factory = new ReportServerClientFactory("ReportServer");
            IReportServerClient client = factory.Create();
            client.GetReports(null, GetReportsCompletedCallback);
        }

        private void GetReportsCompletedCallback(ScalarOperationCompletedEventArgs<IEnumerable<ReportCatalogItemDto>> args)
        {
            splashScreenManager1.CloseWaitForm();

            if (args.Error != null)
            {
                MessageBox.Show(args.Error.Message);
                return;
            }

            foreach (var reportDto in args.Result)
            {
                ReportListBoxItem listBoxItem = new ReportListBoxItem() { DisplayName = reportDto.Name, Id = reportDto.Id };
                reportListBox.Items.Add(listBoxItem);
            }
        }
    }
}
