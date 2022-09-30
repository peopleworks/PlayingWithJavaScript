using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Xpo;
using System;
using System.Linq;

namespace PlayingWithJavaScript.Module.BusinessObjects
{
    public class ApplicationUserLoginAudit : XPObject
    {
        public ApplicationUserLoginAudit(Session session) : base(session)
        {
        }
        public override void AfterConstruction() { base.AfterConstruction(); }

        private ApplicationUser user;
        [Association("User-LoginAudit")]
        public ApplicationUser User { get { return user; } set { SetPropertyValue(nameof(User), ref user, value); } }


        [XafDisplayName("View Location on Map")]
        public string LocationUrl
        {
            get
            {
                if (Latitude == 0 && Longitude == 0)
                    return null;
                return "http://" + $"www.google.com/maps/place/{Latitude},{Longitude}";
            }
        }

        private double _latitude;

        public double Latitude
        {
            get { return _latitude; }
            set { SetPropertyValue<double>(nameof(Latitude), ref _latitude, value); }
        }

        private double _longitude;

        public double Longitude
        {
            get { return _longitude; }
            set { SetPropertyValue<double>(nameof(Longitude), ref _longitude, value); }
        }


        private string ipAddress;
        [Size(50)]
        [XafDisplayName("IP Address")]
        public string IPAddress
        {
            get { return ipAddress; }
            set { SetPropertyValue<string>(nameof(IPAddress), ref ipAddress, value); }
        }


        private DateTime connectionDate;
        [ModelDefault("DisplayFormat", "MM/dd/yyyy HH:mm")]
        [ModelDefault("EditMask", "MM/dd/yyyy HH:mm")]

        public DateTime ConnectionDate
        {
            get { return connectionDate; }
            set { SetPropertyValue<DateTime>(nameof(ConnectionDate), ref connectionDate, value); }
        }


    }
}