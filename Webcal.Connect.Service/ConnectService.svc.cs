namespace Connect.Service
{
    using System;
    using System.Linq;
    using System.ServiceModel;
    using Shared;
    using Shared.Models;

    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public partial class ConnectService : BaseConnectService, IConnectService
    {
        public string Echo()
        {
            return "Echo";
        }
        
        public void UploadCustomerContact(CustomerContact customerContact)
        {
            using (var context = new ConnectContext())
            {
                customerContact.UserId = GetUserId();
                customerContact.Uploaded = DateTime.Now;

                context.CustomerContacts.Add(customerContact);
                context.SaveChanges();
            }
        }

        public void UploadDetailedException(DetailedException detailedException)
        {
            using (var context = new ConnectContext())
            {
                var existing = context.DetailedExceptions.Any(c => c.ExceptionDetails == detailedException.ExceptionDetails);
                if (!existing)
                {
                    detailedException.UserId = GetUserId();
                    context.DetailedExceptions.Add(detailedException);
                    context.SaveChanges();
                }
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
    }
}