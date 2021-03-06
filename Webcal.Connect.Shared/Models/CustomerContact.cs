﻿namespace Connect.Shared.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Table("CustomerContacts")]
    public class CustomerContact : BaseModel, ICustomerContact
    {
        public string Email { get; set; }
        public List<LinkedVehicle> LinkedVehicles { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Secondary Email")]
        public string SecondaryEmail { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

        [Display(Name = "Town")]
        public string Town { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [XmlIgnore, NotMapped]
        public ConnectUser ConnectUser { get; set; }

        [XmlIgnore]
        public int UserId { get; set; }

        [DataMember]
        public DateTime? Uploaded { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}