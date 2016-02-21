namespace Connect.Shared
{
    using System.ServiceModel;
    using Models;

    public partial interface IConnectService
    {
        [OperationContract]
        void AutoUploadQCReport(QCReport report);

        [OperationContract]
        void AutoUploadQCReport3Month(QCReport3Month report);

        [OperationContract]
        void UploadQCReport(QCReport report);

        [OperationContract]
        void UploadQCReport3Month(QCReport3Month report);
    }
}