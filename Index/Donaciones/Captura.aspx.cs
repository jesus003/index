using Index.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
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
            DataTable uni = conn.cmbx_Unidades();
            
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
            else
            {

                recicladores.Visible = false;
                maquilas.Visible = false;
            }
            if (Session["DonacionID"] != null)
            {
                div_detalle.Visible = true;
              
                BindGrid();
            }
            else {
                div_detalle.Visible = true;
            }
            if (Session["listDetalle"] != null) {
               listDetalle = (List<ObjDonacionDetalle>)Session["listDetalle"];
            }
            if (!IsPostBack) {
                cmbxMaterial.DataTextField = "DESCRIPCION";
                cmbxMaterial.DataValueField = "ALMACEN";
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


                txtUnidadMedida.DataTextField = "DESCRIPCION";
                txtUnidadMedida.DataValueField = "ABREVIATURA";
                txtUnidadMedida.DataSource = uni;
                txtUnidadMedida.DataBind();
                if (Session["user_name"] != null) { 
                txtCapturo.Text = Session["user_name"].ToString();
                }
                txtCapturo.Visible = false;
                Label7.Visible = false;
                txtTotal.Text = "0";
                txtIva.Value = "0";
                txtSubtotal.Text = "0";
            }
        }
        decimal id = 0;
        protected void Button1_Click(object sender, EventArgs e)
        {
            id = conn.INS_DONACION(cmbxPlanta.SelectedValue, cmbxRecicladora.SelectedValue, datepicker.Value, txtSubtotal.Text, txtIva.Value, txtTotal.Text, txtCapturo.Text);
           
            if (id > 0) {


                foreach (var item in listDetalle)
                {
                    conn.INS_DONACIONDETALLE(id.ToString(), item.Material,item.BoletaPesaje,item.PaseSalida,item.PesoPase, item.PesoCompra,
                   item.PrecioUnitario, item.UnidadMedida, item.ImporteTotal);
                }

                Response.Write("<script>alert('Se Registrada Con Exito.');</script>");
                div_detalle.Visible = true;
                Session.Remove("DonacionID");
                Response.Redirect("../Default");
            }
            
        }
        List<ObjDonacionDetalle> listDetalle = new List<ObjDonacionDetalle>();
        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            ObjDonacionDetalle detalle = new ObjDonacionDetalle();
            detalle.DonacionID = "0";
            detalle.Fecha = DateTime.Now.ToShortDateString();
            detalle.Material = cmbxMaterial.SelectedValue;
            detalle.BoletaPesaje = txtBoletaPesaje.Value;
            detalle.PaseSalida = txtPaseSalida.Value;
            detalle.PesoPase = txtPesoPase.Value;
            detalle.PesoCompra = txtPesoCompra.Value;
            detalle.PrecioUnitario = txtPrecioUnitario.Value;
            detalle.UnidadMedida = txtUnidadMedida.SelectedValue;
            detalle.ImporteTotal = txtImporteTotal.Text;
            detalle.MaterialD = cmbxMaterial.SelectedItem.Text;
            listDetalle.Add(detalle);
            Session["listDetalle"] = listDetalle;
            BindGrid();

            Debug.WriteLine(txtImporteTotal.Text);
            double valor =Convert.ToDouble(txtImporteTotal.Text);
            double iva = valor * 0.16;
            txtTotal.Text = (Convert.ToDouble(txtTotal.Text) + (valor+iva)).ToString();
            txtIva.Value = (Convert.ToDouble(txtIva.Value) + iva).ToString();
            txtSubtotal.Text = (Convert.ToDouble(txtSubtotal.Text) + valor).ToString();


            //decimal valid = conn.INS_DONACIONDETALLE(Session["DonacionID"].ToString(),cmbxMaterial.SelectedValue,txtBoletaPesaje.Value,txtPaseSalida.Value,txtPesoPase.Value,txtPesoCompra.Value,
            //    txtPrecioUnitario.Value,txtUnidadMedida.SelectedValue, txtImporteTotal.Value);
            //if (valid > 0)
            //{
            //    Response.Write("<script>alert('Se Registrada Con Exito, Ahora Puedes Otro Detalles.');</script>");
            cmbxMaterial.SelectedIndex = -1;
            txtBoletaPesaje.Value = "";
            txtPaseSalida.Value = "";
            txtPesoPase.Value = "";
            txtPesoCompra.Value = "";
            txtPrecioUnitario.Value = "";
            txtUnidadMedida.SelectedIndex = -1;
            txtImporteTotal.Text = "";
            
            //    BindGrid();
            //}
        }
        private void BindGrid()
        {
            try
            {
                DataTable tblData = new DataTable();
                //tblData = conn.getDetalles(Session["DonacionID"].ToString());


                var source = new BindingSource();
                
                source.DataSource = listDetalle;
                Debug.WriteLine("Lista detalle:"+listDetalle.Count());
                ListtoDataTable lsttodt = new ListtoDataTable();
                DataTable dt = lsttodt.ToDataTable(listDetalle);
                gridDetalles.DataSource = dt;

                Debug.WriteLine("grid detalle datasource:" + gridDetalles.Rows.Count);
                if (dt.Rows.Count > 0)
                {
                    gridDetalles.DataBind();

                }
                else
                {
                    gridDetalles.DataSource = new DataTable();
                    gridDetalles.DataBind();
                }
            }
            catch (Exception ex)
            {
                // log
                throw;
            }
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "<script>quitHourglass();</script>", false);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Remove("DonacionID");
            Response.Redirect("../Default");
        }
    }
    public class ListtoDataTable
    {
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }

}