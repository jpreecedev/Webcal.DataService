namespace Webcal.DataService.WCFService
{
    using System.IdentityModel.Selectors;
    using System.ServiceModel;

    public class Authenticator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName != "test" && password != "test")
            {
                throw new FaultException("Invalid user and/or password");
            }
        }
    }
}