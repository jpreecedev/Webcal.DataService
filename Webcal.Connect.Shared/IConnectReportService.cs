namespace Connect.Shared
{
    using System.ServiceModel;
    using Models;

    public partial interface IConnectService
    {
        [OperationContract]
        void AutoUploadQCReport(QCReport report);

        [OperationContract]
        void AutoUploadQCReport6Month(QCReport6Month report);

        [OperationContract]
        void UploadQCReport(QCReport report);

        [OperationContract]
        void UploadQCReport6Month(QCReport6Month report);

        [OperationContract]
        void UploadTechnician(Technician technician);
        
        [OperationContract]
        void UploadWorkshopSettings(WorkshopSettings workshopSettings);
    }
}