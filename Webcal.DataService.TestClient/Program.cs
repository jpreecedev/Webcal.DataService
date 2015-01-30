namespace Webcal.DataService.TestClient
{
    using WebcalConnect;
    
    internal class Program
    {
        private static void Main(string[] args)
        {
            var client = new DataServiceClient();
            client.ClientCredentials.UserName.UserName = "test";
            client.ClientCredentials.UserName.Password = "test";

            var a = client.GetData(20);
        }
    }
}