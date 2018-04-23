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
        }
    }
}
