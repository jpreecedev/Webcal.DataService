namespace Connect.Shared
{
    using System.ServiceModel.Channels;
    using System.ServiceModel.Security.Tokens;

    public interface IConnectBindingHelper
    {
        Binding CreateBinding(SecurityTokenParameters parameters);
    }
}