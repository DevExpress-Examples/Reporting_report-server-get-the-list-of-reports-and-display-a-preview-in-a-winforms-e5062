using DevExpress.ReportServer.Printing;
using DevExpress.ReportServer.ServiceModel.DataContracts;
using System.Windows.Forms;

namespace ReportServerWinFormsClientDemo
{
    public partial class ReportViewerForm : Form
    {
        public ReportViewerForm(int reportId)
        {
            InitializeComponent();
            remoteDocumentSource1.ReportIdentity = new ReportIdentity(reportId);
            remoteDocumentSource1.ReportServerCredentialsDemanded += remoteDocumentSource1_ReportServerCredentialsDemanded; // B250735 workaround
        }

        void remoteDocumentSource1_ReportServerCredentialsDemanded(object sender, CredentialsEventArgs e)
        {
            e.Handled = true;
        }
    }
}
