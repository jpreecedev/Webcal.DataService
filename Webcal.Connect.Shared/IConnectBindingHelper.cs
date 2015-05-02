namespace Connect.Shared
{
    using System.ServiceModel.Channels;

    public interface IConnectBindingHelper
    {
        Binding CreateBinding();
    }
}