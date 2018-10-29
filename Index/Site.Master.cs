using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Index
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["rol"] != null)
            {
                if (Session["rol"].ToString() == "planta")
                {
                    recicladores.Visible = false;
                    maquilas.Visible = true;
                    llogin.Visible = false;
                }
                if (Session["rol"].ToString() == "reciclador")
                {
                    recicladores.Visible = true;
                    maquilas.Visible = false;
                    llogin.Visible = false;
                }
            }
            else {

                recicladores.Visible = false;
                maquilas.Visible = false;
            }
        }
    }
}