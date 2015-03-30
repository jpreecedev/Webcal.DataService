namespace Connect.Shared
{
    using System;
    using Models;

    public interface IConnectEmail
    {
        int Id { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
        string EmailType { get; set; }
        DateTime From { get; set; }
        DateTime To { get; set; }
        ConnectUser User { get; set; }
    }
}