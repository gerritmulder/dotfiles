using DevExpress.ExpressApp.Web.Controls;
using DevExpress.ExpressApp.Web.Templates;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public class LoginPage : BaseXafPage
{
    protected HtmlGenericControl content;
    protected HtmlForm form;
    protected HtmlHead head;
    protected ASPxProgressControl progressControl;
    public override Control InnerContentPlaceHolder => content;
}