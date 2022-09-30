using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using PlayingWithJavaScript.Module.BusinessObjects;
using PlayingWithJavaScript.Module.Helper;
using System;
using System.Linq;

namespace PlayingWithJavaScript.Module.Controllers
{
    public partial class CompanyViewController : ViewController<DetailView>
    {
        public CompanyViewController()
        {
            TargetObjectType = typeof(Company);
            TargetViewType = ViewType.DetailView;
            using (SimpleAction refreshAction = new SimpleAction(
                this,
                "RefreshCompanyWebImage",
                PredefinedCategory.Reports))
            {
                refreshAction.ImageName = "Action_Refresh";
                refreshAction.Execute += async delegate (object sender, SimpleActionExecuteEventArgs e)
                {
                    Company currentObject = View.CurrentObject as Company;

                    if (currentObject != null)
                    {
                        if (!string.IsNullOrEmpty(currentObject.CompanyUrl))
                        {
                            Application.ShowViewStrategy
                                .ShowMessage(
                                    new MessageOptions
                                    {
                                        Duration = 1000,
                                        Message = "Getting information from Web Site...",
                                        Type = InformationType.Info
                                    });


                            string screenShotPath = await JavaScripCSharpFunctions.GetSiteScreenShot(
                                currentObject.CompanyName,
                                currentObject.CompanyUrl);


                            byte[] image = System.IO.File.ReadAllBytes(screenShotPath);


                            currentObject.ScreenShot = image;


                            ObjectSpace.CommitChanges();

                            View.ObjectSpace.Refresh();
                            ObjectSpace.Refresh();

                            Application.ShowViewStrategy
                                .ShowMessage(
                                    new MessageOptions
                                    {
                                        Duration = 5000,
                                        Message = "Company Site Image Updated!!",
                                        Type = InformationType.Success
                                    });
                        }
                    }
                };
            }
        }

        protected override void OnActivated() { base.OnActivated(); }
        protected override void OnViewControlsCreated() { base.OnViewControlsCreated(); }
        protected override void OnDeactivated() { base.OnDeactivated(); }
    }
}
