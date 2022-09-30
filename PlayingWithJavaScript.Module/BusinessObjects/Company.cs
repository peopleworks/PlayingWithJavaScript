using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PlayingWithJavaScript.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Company : BaseObject
    {
        public Company(Session session) : base(session)
        {
        }
        public override void AfterConstruction() { base.AfterConstruction(); }


        string companyName;
        [Size(100)]
        public string CompanyName
        {
            get => companyName;
            set => SetPropertyValue(nameof(CompanyName), ref companyName, value);
        }

        string companyUrl;
        public string CompanyUrl
        {
            get => companyUrl;
            set => SetPropertyValue(nameof(CompanyUrl), ref companyUrl, value);
        }

        [VisibleInListView(true)]
        [ImageEditor(
           ListViewImageEditorMode = ImageEditorMode.PictureEdit,
           DetailViewImageEditorMode = ImageEditorMode.PictureEdit,
           ListViewImageEditorCustomHeight = 40)]
        public byte[] ScreenShot
        {
            get { return GetPropertyValue<byte[]>(nameof(ScreenShot)); }
            set { SetPropertyValue<byte[]>(nameof(ScreenShot), value); }
        }



    }
}