using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UrbaniaIntranet.Objetos;

namespace Index.Descuento
{
    public partial class Captura : System.Web.UI.Page
    {
        BDClass conn = new BDClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable mat = conn.cmbx_Materiales();
            DataTable plants = conn.cmbx_Plantas();
            DataTable reci = conn.cmbx_Recicladores();
            if (Session["DonacionID"] != null)
            {
                div_detalle.Visible = true;
            }
            else {
                div_detalle.Visible = false;
            }

            if (!IsPostBack) {
                cmbxMaterial.DataTextField = "DESCRIPCION";
                cmbxMaterial.DataValueField = "CODIGO";
                cmbxMaterial.DataSource = mat;
                cmbxMaterial.DataBind();

                cmbxPlanta.DataTextField = "DESCRIPCION";
                cmbxPlanta.DataValueField = "CODIGO";
                cmbxPlanta.DataSource = plants;
                cmbxPlanta.DataBind();

                cmbxRecicladora.DataTextField = "DESCRIPCION";
                cmbxRecicladora.DataValueField = "CODIGO";
                cmbxRecicladora.DataSource = reci;
                cmbxRecicladora.DataBind();
            }
        }
        decimal id = 0;
        protected void Button1_Click(object sender, EventArgs e)
        {
            id = conn.INS_DONACION(cmbxPlanta.SelectedValue, cmbxRecicladora.SelectedValue, txtFecha.Text, txtSubtotal.Value, txtIva.Value, txtTotal.Value, txtCapturo.Value);
            Session["DonacionID"] = id;
            if (id > 0) {
                Response.Write("<script>alert('Se Registrada Con Exito, Ahora Puedes Agregar Detalles.');</script>");
                Button1.Enabled = false;
                div_detalle.Visible = true;
            }
            
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            decimal valid = conn.INS_DONACIONDETALLE(Session["DonacionID"].ToString(),cmbxMaterial.SelectedValue,txtBoletaPesaje.Value,txtPaseSalida.Value,txtPesoPase.Value,txtPesoCompra.Value,
                txtPrecioUnitario.Value,txtUnidadMedida.Value,txtTotal.Value);
            if (valid > 0)
            {
                Response.Write("<script>alert('Se Registrada Con Exito, Ahora Puedes Otro Detalles.');</script>");
                cmbxMaterial.SelectedIndex = -1;
                txtBoletaPesaje.Value = "";
                txtPaseSalida.Value = "";
                txtPesoPase.Value = "";
                txtPesoCompra.Value = "";
                txtPrecioUnitario.Value = "";
                txtUnidadMedida.Value = "";
                txtTotal.Value = "";
            }
        }
    }
}