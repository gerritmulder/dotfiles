public class DebugShowViewStrategy : DevExpress.ExpressApp.Win.WinShowViewStrategyBase
{
	public DebugShowViewStrategy(DevExpress.ExpressApp.XafApplication application) : base(application)
	{
	}

	protected override DevExpress.ExpressApp.Win.WinWindow CreateWindow(
		DevExpress.ExpressApp.ShowViewParameters parameters,
		DevExpress.ExpressApp.ShowViewSource showViewSource,
		bool isMain)
	{
		if (isMain)
		{
			var controllersManager = Application.GetType().GetProperty("ControllersManager", 
				System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
				.GetValue(Application, null) as DevExpress.ExpressApp.Core.ControllersManager;
			var controllers = controllersManager.CreateControllers(typeof(DevExpress.ExpressApp.Controller), Application.Model, parameters.CreatedView);
			for (int i = controllers.Count - 1; i >= 0; i--)
				if (typeof(DevExpress.ExpressApp.SystemModule.DialogController).IsAssignableFrom(controllers[i].GetType()))
					controllers.RemoveAt(i);

			if (parameters.Controllers != null)
				controllers.AddRange(parameters.Controllers);

			foreach (var controller in controllers)
				controller.Application = Application;

			return new DevExpress.ExpressApp.Win.WinWindow(Application,
				DevExpress.ExpressApp.TemplateContext.ApplicationWindow, controllers, isMain, true);
		}
		else
			return base.CreateWindow(parameters, showViewSource, isMain);
	}

	protected override DevExpress.ExpressApp.UIType GetUIType() => DevExpress.ExpressApp.UIType.TabbedMDI;
}
