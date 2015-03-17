namespace Webcal.Connect.Shared
{
    using System;
    using System.IdentityModel.Selectors;
    using System.IdentityModel.Tokens;
    using System.ServiceModel.Security;
    using System.Xml;

    public class ConnectSecurityTokenSerializer : WSSecurityTokenSerializer
    {
        private readonly SecurityTokenVersion _version;

        public ConnectSecurityTokenSerializer(SecurityTokenVersion version)
        {
            _version = version;
        }

        protected override bool CanReadTokenCore(XmlReader reader)
        {
            XmlDictionaryReader localReader = XmlDictionaryReader.CreateDictionaryReader(reader);
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.IsStartElement(ConnectConstants.ConnectTokenName, ConnectConstants.ConnectNamespace))
            {
                return true;
            }
            return base.CanReadTokenCore(reader);
        }

        protected override SecurityToken ReadTokenCore(XmlReader reader, SecurityTokenResolver tokenResolver)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.IsStartElement(ConnectConstants.ConnectTokenName, ConnectConstants.ConnectNamespace))
            {
                string id = reader.GetAttribute(ConnectConstants.Id, ConnectConstants.WsUtilityNamespace);
                string url = reader.GetAttribute(ConnectConstants.ConnectUrlPrefix, ConnectConstants.ConnectNamespace);

                reader.ReadStartElement();

                string licenseKey = reader.ReadElementString(ConnectConstants.ConnectLicenseKeyElementName, ConnectConstants.ConnectNamespace);
                string companyKey = reader.ReadElementString(ConnectConstants.ConnectCompanyKeyElementName, ConnectConstants.ConnectNamespace);
                string machineKey = reader.ReadElementString(ConnectConstants.ConnectMachineKeyElementName, ConnectConstants.ConnectNamespace);

                reader.ReadEndElement();

                return new ConnectToken(new ConnectKeys(url, int.Parse(licenseKey), companyKey, machineKey), id);
            }
            return DefaultInstance.ReadToken(reader, tokenResolver);
        }

        protected override bool CanWriteTokenCore(SecurityToken token)
        {
            if (token is ConnectToken)
            {
                return true;
            }
            return base.CanWriteTokenCore(token);
        }

        protected override void WriteTokenCore(XmlWriter writer, SecurityToken token)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            if (token == null)
            {
                throw new ArgumentNullException("token");
            }

            var connectToken = token as ConnectToken;
            if (connectToken != null)
            {
                writer.WriteStartElement(ConnectConstants.ConnectTokenPrefix, ConnectConstants.ConnectTokenName, ConnectConstants.ConnectNamespace);
                writer.WriteAttributeString(ConnectConstants.WsUtilityPrefix, ConnectConstants.Id, ConnectConstants.WsUtilityNamespace, token.Id);
                writer.WriteAttributeString(ConnectConstants.ConnectTokenPrefix, ConnectConstants.ConnectUrlPrefix, ConnectConstants.ConnectNamespace, connectToken.ConnectKeys.Url);
                writer.WriteElementString(ConnectConstants.ConnectLicenseKeyElementName, ConnectConstants.ConnectNamespace, XmlConvert.ToString(connectToken.ConnectKeys.LicenseKey));
                writer.WriteElementString(ConnectConstants.ConnectCompanyKeyElementName, ConnectConstants.ConnectNamespace, connectToken.ConnectKeys.CompanyKey);
                writer.WriteElementString(ConnectConstants.ConnectMachineKeyElementName, ConnectConstants.ConnectNamespace, connectToken.ConnectKeys.MachineKey);
                writer.WriteEndElement();
                writer.Flush();
            }
            else
            {
                base.WriteTokenCore(writer, token);
            }
        }
    }
}