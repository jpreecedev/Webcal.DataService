namespace Connect.Service
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Reflection;
    using System.ServiceModel;
    using Shared;
    using Shared.Models;

    public partial class ConnectService
    {
        public void AutoUploadTachographDocument(TachographDocument tachographDocument)
        {
            AutoUploadDocument(tachographDocument);
        }

        public void AutoUploadUndownloadabilityDocument(UndownloadabilityDocument undownloadabilityDocument)
        {
            AutoUploadDocument(undownloadabilityDocument);
        }

        public void AutoUploadLetterForDecommissioningDocument(LetterForDecommissioningDocument letterForDecommissioningDocument)
        {
            AutoUploadDocument(letterForDecommissioningDocument);
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

        public void UpdateTachographDocument(TachographDocument tachographDocument)
        {
            UpdateDocument(tachographDocument);
        }

        public void UpdateUndownloadabilityDocument(UndownloadabilityDocument undownloadabilityDocument)
        {
            UpdateDocument(undownloadabilityDocument);
        }

        public void UpdateLetterForDecommissioningDocument(LetterForDecommissioningDocument letterForDecommissioningDocument)
        {
            UpdateDocument(letterForDecommissioningDocument);
        }

        public object Find(string registrationNumber, DocumentType documentType)
        {
            if (string.IsNullOrEmpty(registrationNumber))
            {
                throw new FaultException("Registration number was not supplied");
            }

            registrationNumber = registrationNumber.ToUpper();

            var companyKey = FetchClaimValue(ConnectConstants.ConnectCompanyKeyClaim);

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
                    return FindDocument<LetterForDecommissioningDocument>(context, registrationNumber, companyKey);
                }

                return null;
            }
        }

        private void UploadDocument<T>(T document) where T : Document
        {
            using (var context = new ConnectContext())
            {
                document.UserId = GetUserId();
                context.Set<T>().Add(document);

                context.SaveChanges();
            }
        }

        private void UpdateDocument<T>(T document) where T : Document
        {
            using (var context = new ConnectContext())
            {
                var companyKey = FetchClaimValue(ConnectConstants.ConnectCompanyKeyClaim);
                var existingDocument = FindDocument<T>(context, document.RegistrationNumber, companyKey);

                if (existingDocument != null)
                {
                    document.Id = existingDocument.Id;
                    document.UserId = GetUserId();

                    context.Entry(existingDocument).CurrentValues.SetValues(document);
                    context.SaveChanges();
                }
            }
        }

        private void AutoUploadDocument<T>(T document) where T : Document
        {
            using (var context = new ConnectContext())
            {
                var companyKey = FetchClaimValue(ConnectConstants.ConnectCompanyKeyClaim);
                var existingDocument = FindDocuments<T>(context, document.RegistrationNumber, companyKey);

                bool hasExisting = existingDocument.Any();
                foreach (var item in existingDocument)
                {
                    if (item.Equals(document))
                    {
                        hasExisting = true;
                        break;
                    }
                }

                if (!hasExisting)
                {
                    document.UserId = GetUserId();
                    context.Set<T>().Add(document);

                    context.SaveChanges();
                }
            }
        }

        private static Document FindDocument<T>(ConnectContext context, string registrationNumber, string companyKey) where T : Document
        {
            return FindDocuments<T>(context, registrationNumber, companyKey).FirstOrDefault();
        }

        private static IQueryable<T> FindDocuments<T>(ConnectContext context, string registrationNumber, string companyKey) where T : Document
        {
            return context.Set<T>()
                .Where(doc => doc.RegistrationNumber == registrationNumber)
                .OrderByDescending(doc => doc.Created)
                .Join(context.UserNodes, doc => doc.UserId, user => user.ConnectUser.Id, (doc, user) => new
                {
                    user.CompanyKey,
                    Document = doc
                })
                .Where(b => b.CompanyKey == companyKey)
                .Select(a => a.Document);
        }
    }
}