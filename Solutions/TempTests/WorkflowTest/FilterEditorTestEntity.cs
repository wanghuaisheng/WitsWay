namespace WitsWay.TempTests.WorkflowTest
{
    [DevExpress.Xpo.NonPersistent()]
    public class Address : DevExpress.Xpo.XPObject
    {

        public Address(DevExpress.Xpo.Session session) : base(session) { }

        public string StreetName
        {
            get { return (string)GetPropertyValue("StreetName"); }
            set { SetPropertyValue("StreetName", value);}
        }

        public Country Country
        {
            get { return (Country)GetPropertyValue("Country"); }
            set { SetPropertyValue("Country", value);}
        }
    }

    [DevExpress.Xpo.NonPersistent()]
    public class Country : DevExpress.Xpo.XPObject
    {
        public Country(DevExpress.Xpo.Session session) : base(session) {}

        public string Name
        {
            get { return (string)GetPropertyValue("Name"); }
            set { SetPropertyValue("Name", value); }
        }
    }

    public class AddressHalfXpo : DevExpress.Xpo.XPObject
    {

        public AddressHalfXpo(DevExpress.Xpo.Session session) : base(session) { }

        public string StreetName
        {
            get { return (string)GetPropertyValue("StreetName"); }
            set { SetPropertyValue("StreetName", value); }
        }

        [DevExpress.Xpo.NonPersistent()]
        public Country Country
        {
            get { return (Country)GetPropertyValue("Country"); }
            set { SetPropertyValue("Country", value); }
        }
    }

    public class AddressFullXpo : DevExpress.Xpo.XPObject
    {

        public AddressFullXpo(DevExpress.Xpo.Session session) : base(session) { }

        public string StreetName
        {
            get { return (string)GetPropertyValue("StreetName"); }
            set { SetPropertyValue("StreetName", value); }
        }

        public CountryXpo Country
        {
            get { return (CountryXpo)GetPropertyValue("Country"); }
            set { SetPropertyValue("Country", value); }
        }
    }

    public class CountryXpo : DevExpress.Xpo.XPObject
    {
        public CountryXpo(DevExpress.Xpo.Session session) : base(session) { }

        public string Name
        {
            get { return (string)GetPropertyValue("Name"); }
            set { SetPropertyValue("Name", value); }
        }
    }
}
