using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Index
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_LoggedIn(object sender, EventArgs e)
        {

            string nombre = Login1.UserName;
            Session["user_name"] = nombre;
            string[] rol = Roles.GetRolesForUser(nombre);
            MembershipUser usuario = Membership.GetUser(User.Identity.Name);
            if (Roles.IsUserInRole(Login1.UserName, "reciclador"))
            {
                Session["rol"] = "reciclador";
            }
            if (Roles.IsUserInRole(Login1.UserName, "planta"))
            {
                Session["rol"] = "planta";
            }
            Response.Redirect("Default");
        
        }
    }
}