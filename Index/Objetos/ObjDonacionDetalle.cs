using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Index.Objetos
{
    public class ObjDonacionDetalle
    {
        public string Fecha { get; set; }
        public string DonacionID { get; set; }
        public string Material { get; set; }
        public string MaterialD { get; set; }
        public string BoletaPesaje { get; set; }

        public string PaseSalida { get; set; }
        public string PesoPase { get; set; }
        public string PesoCompra { get; set; }

        public string PrecioUnitario { get; set; }
        public string UnidadMedida { get; set; }
        public string ImporteTotal { get; set; }

       
    }
}