namespace Webcal.Connect.Shared.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;
    using Data;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class BaseUserModel : IdentityUser<int, ConnectUserLogin, ConnectUserRole, ConnectUserClaim>, ICloneable
    {
        [DataMember]
        public DateTime? Deleted { get; set; }

        [XmlIgnore, NotMapped]
        public bool IsDeleted
        {
            get { return Deleted != null; }
        }

        public virtual object Clone()
        {
            return MemberwiseClone();
        }

        public virtual T Clone<T>()
        {
            return (T) Clone();
        }

        [Serializable]
        public class BaseNotification : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
}