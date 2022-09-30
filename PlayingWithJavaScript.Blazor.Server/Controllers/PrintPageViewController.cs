using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayingWithJavaScript.Blazor.Server.Controllers
{
    public partial class PrintPageViewController : ViewController
    {
        BlazorApplication blazorApplication => (BlazorApplication)Application;
        public PrintPageViewController()
        {
            SimpleAction printPageAction = new SimpleAction(this, "PrintPageAction", PredefinedCategory.Edit)
            {
                Caption = "Print Page",
                ConfirmationMessage = "Are you sure you want to Print this Page?",
                ImageName = "Action_Printing_Print"
            };


            printPageAction.Execute += PrintPageAction_Execute;

        }

        private void PrintPageAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var JSRuntime = blazorApplication.ServiceProvider.GetRequiredService<IJSRuntime>();
            JSRuntime.InvokeAsync<object>("printPage");

        }

        protected override void OnActivated() { base.OnActivated(); }
        protected override void OnViewControlsCreated() { base.OnViewControlsCreated(); }
        protected override void OnDeactivated() { base.OnDeactivated(); }
    }
}
