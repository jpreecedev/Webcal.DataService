namespace Connect.Service
{
    using System.Linq;
    using System.ServiceModel;
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
                document.UserId = UserNode.ConnectUser.Id;
                context.Set<T>().Add(document);

                context.SaveChanges();
            }
        }

        private static Document FindDocument<T>(ConnectContext context, string registrationNumber, string companyKey) where T : Document
        {
            return context.Set<T>()
                          .Where(doc => doc.RegistrationNumber == registrationNumber)
                          .OrderByDescending(doc => doc.Created)
                          .Join(context.UserNodes, doc => doc.UserId, user => user.Id, (doc, user) => new
                          {
                              user.CompanyKey,
                              Document = doc
                          })
                          .Where(b => b.CompanyKey == companyKey)
                          .Select(a => a.Document)
                          .FirstOrDefault();
        }
    }
}