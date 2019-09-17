using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Win;
using System;

namespace XafNetCore3WinForms
{
    internal class Program
    {
        [STAThread]
        private static void Main()
        {
            ImageLoader.Instance.UseSvgImages = true;
            using var app = new WinApplication()
            {
                UseLightStyle = true,
                UseOldTemplates = false
            };

            app.CreateCustomObjectSpaceProvider += (s, e)
                => e.ObjectSpaceProvider = new NonPersistentObjectSpaceProvider();

            try
            {
                app.Setup();
                app.Start();
            }
            catch (Exception ex)
            {
                app.HandleException(ex);
            }
        }
    }
}
