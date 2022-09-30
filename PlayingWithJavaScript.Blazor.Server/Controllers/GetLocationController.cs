using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor;
using Microsoft.JSInterop;
using PlayingWithJavaScript.Module.BusinessObjects;
using System;
using System.Linq;

namespace PlayingWithJavaScript.Blazor.Server.Controllers
{
    //HACK: Controller to Call JavaScript (Geolocation) and get information Back
    public partial class GetLocationController : ViewController
    {
        BlazorApplication blazorApplication => (BlazorApplication)Application;

        public GetLocationController()
        {
            InitializeComponent();
            TargetViewType = ViewType.ListView;
            TargetViewNesting = Nesting.Root;
        }
        protected override async void OnActivated()
        {
            base.OnActivated();

            try
            {
                var JSRuntime = blazorApplication.ServiceProvider.GetRequiredService<IJSRuntime>();
                string geolocationtext = new(await JSRuntime.InvokeAsync<string>("getLocation"));

                string[] location = geolocationtext.Split('|');

                Type objectType = typeof(ApplicationUserLoginAudit);
                IObjectSpace objectSpace = blazorApplication.CreateObjectSpace(objectType);
                ApplicationUserLoginAudit applicationUserLoginAudit = objectSpace.CreateObject<ApplicationUserLoginAudit>();
                applicationUserLoginAudit.ConnectionDate = DateTime.Now;
                applicationUserLoginAudit.Latitude = double.Parse(location[0]);
                applicationUserLoginAudit.Longitude = double.Parse(location[1]);
                applicationUserLoginAudit.IPAddress = string.Empty;
                applicationUserLoginAudit.User = objectSpace.GetObjectByKey<ApplicationUser>(SecuritySystem.CurrentUserId);
                objectSpace.CommitChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();

        }
        protected override void OnDeactivated()
        {

            base.OnDeactivated();
        }
    }
}
