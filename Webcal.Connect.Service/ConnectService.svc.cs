namespace Webcal.Connect.Service
{
    using System.Data.Entity;
    using System.Linq;
    using System.ServiceModel;
    using Data;
    using Shared;
    using Shared.Models;

    public class ConnectService : BaseConnectService, IConnectService
    {
        public string Echo()
        {
            return "Echo";
        }

        public void UploadTachographDocument(TachographDocument tachographDocument)
        {
            UploadDocument(tachographDocument);
        }

        public void UploadUndownloadabilityDocument(UndownloadabilityDocument undownloadabilityDocument)
        {
            UploadDocument(undownloadabilityDocument);
        }

        public void UploadLetterForDecommissioningDocument(LetterForDecommissioningDocument letterForDecommissioningDocument)
        {
            UploadDocument(letterForDecommissioningDocument);
        }

        public object Find(string registrationNumber, DocumentType documentType)
        {
            if (string.IsNullOrEmpty(registrationNumber))
            {
                throw new FaultException("Registration number was not supplied");
            }

            registrationNumber = registrationNumber.ToUpper();

            string companyKey = FetchClaimValue(ConnectConstants.ConnectCompanyKeyClaim);

            using (var context = new ConnectContext())
            {
                if ((documentType & DocumentType.Tachograph) == DocumentType.Tachograph)
                {
                    var tachographDocument = FindDocument<TachographDocument>(context, registrationNumber, companyKey);
                    if (tachographDocument != null)
                    {
                        return tachographDocument;
                    }
                }

                if ((documentType & DocumentType.Undownloadability) == DocumentType.Undownloadability)
                {
                    var undownloadabilityDocument = FindDocument<UndownloadabilityDocument>(context, registrationNumber, companyKey);
                    if (undownloadabilityDocument != null)
                    {
                        return undownloadabilityDocument;
                    }
                }

                if ((documentType & DocumentType.LetterForDecommissioning) == DocumentType.LetterForDecommissioning)
                {
                    var letterForDecommissioningDocument = FindDocument<LetterForDecommissioningDocument>(context, registrationNumber, companyKey);
                    if (letterForDecommissioningDocument != null)
                    {
                        return letterForDecommissioningDocument;
                    }
                }

                throw new FaultException("Given type is not supported");
            }
        }

        private void UploadDocument<T>(T document) where T : Document
        {
            using (var context = new ConnectContext())
            {
                document.User = User;
                context.Set<T>().Add(document);

                context.SaveChanges();
            }
        }

        private static Document FindDocument<T>(DbContext context, string registrationNumber, string companyKey) where T : Document
        {
            return context.Set<T>().Where(c => c.RegistrationNumber == registrationNumber && c.User != null && c.User.CompanyKey == companyKey)
                                   .OrderByDescending(c => c.Created)
                                   .FirstOrDefault();
        }
    }
}