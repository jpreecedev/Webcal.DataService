namespace Connect.Shared
{
    public interface ICustomerContact
    {
        string Name { get; set; }

        string SecondaryEmail { get; set; }

        string Address { get; set; }

        string PostCode { get; set; }

        string Town { get; set; }

        string PhoneNumber { get; set; }
    }
}