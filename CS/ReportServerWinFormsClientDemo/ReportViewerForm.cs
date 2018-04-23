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

using System.Windows.Forms;
using DevExpress.ReportServer.Printing;
using DevExpress.ReportServer.ServiceModel.ConnectionProviders;
using DevExpress.ReportServer.ServiceModel.DataContracts;

namespace ReportServerWinFormsClientDemo {
    public partial class ReportViewerForm : Form {
        readonly ConnectionProvider serverConnection;

        public ReportViewerForm(int reportId, ConnectionProvider serverConnection) {
            InitializeComponent();
            this.serverConnection = serverConnection;
            remoteDocumentSource1.ReportIdentity = new ReportIdentity(reportId);
            remoteDocumentSource1.ReportServiceClientDemanded += remoteDocumentSource1_ReportServiceClientDemanded;
        }

        void remoteDocumentSource1_ReportServiceClientDemanded(object sender, ReportServiceClientDemandedEventArgs e) {
            e.Client = serverConnection.CreateClient();
        }
    }
}
