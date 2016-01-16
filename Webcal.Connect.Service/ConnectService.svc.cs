namespace Connect.Service
{
    using System.Data.Entity;
    using System.Linq;
    using System.ServiceModel;
    using Shared;
    using Shared.Models;

    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
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

        public void UploadCustomerContact(CustomerContact customerContact)
        {
            using (var context = new ConnectContext())
            {
                context.CustomerContacts.Add(customerContact);
                context.SaveChanges();
            }
        }

        public CustomerContact[] FindExistingCustomerContact(string customerName)
        {
            if (string.IsNullOrEmpty(customerName))
            {
                return null;
            }

            customerName = customerName.Trim().ToLower().Replace(" ", "").Replace(".", "").Replace("-", "");

            if (customerName.Length < 3)
            {
                return null;
            }

            using (var context = new ConnectContext())
            {
                var a = context.CustomerContacts.Where(c => c.Name != null && c.Name.Trim().ToLower().Replace(" ", "").Replace(".", "").Replace("-", "").StartsWith(customerName)).ToArray();
                return a;
            }
        }

        public ServiceCredentials GetServiceCredentials()
        {
            return new ServiceCredentials
            {
                Username = "backup@webcalconnect.com",
                Password = "7w3uTX096cMlpyc",
                UserId = GetUserId()
            };
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

        private static Document FindDocument<T>(ConnectContext context, string registrationNumber, string companyKey) where T : Document
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
                .Select(a => a.Document)
                .FirstOrDefault();
        }
    }
}