using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Web;

namespace XafAspNetWebForms
{
    public class Application : WebApplication
    {
        protected override IViewUrlManager CreateViewUrlManager() => new ViewUrlManager();

        protected override void OnCreateCustomObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args)
            => args.ObjectSpaceProvider = new NonPersistentObjectSpaceProvider();

        protected override void OnDatabaseVersionMismatch(DatabaseVersionMismatchEventArgs args)
        {
            args.Updater.Update();
            args.Handled = true;
        }
    }
}