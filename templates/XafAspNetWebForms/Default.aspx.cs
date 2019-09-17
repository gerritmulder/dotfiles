using System.Web.UI;
using System.Web.UI.HtmlControls;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Web.Controls;
using DevExpress.ExpressApp.Web.Templates;

public class Default : BaseXafPage
{
    protected HtmlGenericControl content;
    protected HtmlForm form;
    protected ASPxProgressControl progressControl;
    public override Control InnerContentPlaceHolder => content;
    protected override ContextActionsMenu CreateContextActionsMenu()
        => new ContextActionsMenu(this, "Edit", "RecordEdit", "ObjectsCreation", "ListView", "Reports");
}
