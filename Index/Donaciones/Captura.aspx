<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Captura.aspx.cs" Inherits="Index.Descuento.Captura" %>
<%@ Register Src="~/Site.Master" TagPrefix="uc1" TagName="topnavbar" %>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Fundacion Index</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />
      <style type="text/css">
			
			* {
				margin:0px;
				padding:0px;
			}
			
			#header {
				margin:auto;
				width:500px;
               
				font-family:Arial, Helvetica, sans-serif;
			}
			
			ul, ol {
				list-style:none;
			}
			
			.nav > li {
				float:left;
			}
			
			.nav li a {
				
				
				text-decoration:none;
				padding:15px 12px;
				display:block;
			}
			
			.nav li a:hover {
				
			}
			.nav ul{
                background-color:#ffffff;
			}
			.nav li ul {
				display:none;
				position:absolute;
				min-width:500px;
			}
			
			.nav li:hover > ul {
				display:block;
			}
			
			.nav li ul li {
				position:relative;
			}
			
			.nav li ul li ul {
				right:-140px;
				top:-30px;
			}
            .navbar {
                 height:100px;
            }
		</style>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <style type="text/css">
.carousel{
    background: #2f4357;
    margin-top: 20px;
   
}
.carousel .item{
    min-height: 280px; /* Prevent carousel from being distorted if for some reason image doesn't load */
    max-height:700px;

}
.carousel .item img{
    margin: 0 auto; /* Align slide image horizontally center */
}
.carousel .item p{
    background: rgba(31, 40, 93, 0.5); /* Align slide image horizontally center */
}
.carousel .item h3{
    background: rgba(31, 40, 93, 0.5); /* Align slide image horizontally center */
}
.bs-example{
	margin: 20px;
}
</style>


     <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">

  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script>
  $( function() {
         $("#datepicker").datepicker({ dateFormat: 'dd/mm/yy' });
  } );
  </script>
    <script>
function myFunction() {
    var x = document.getElementById("txtPrecioUnitario");
    console.log(x.value);
    var peso = document.getElementById("txtPesoCompra");
    console.log(peso.value)
    var total = document.getElementById("txtImporteTotal");
    total.value = peso.value * x.value;
    
        }
        
        function myFunction2() {
    var iva = document.getElementById("txtIva");
    
    var subtotal = document.getElementById("txtSubtotal");
    
            var total = document.getElementById("txtTotal");
            iva.value = total.value - (total.value / 1.16)
            subtotal.value = parseInt(total.value) - parseInt(iva.value);

   
}
</script> 
</head>
<body>
    <form runat="server">
         <div class="navbar navbar-default navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" runat="server" href="~/"><img src="/img/Logo.png" class=".img-responsive" height="60" /></a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav navbar-right">
                        <li><a runat="server" href="~/">Inicio</a></li>
                         <li runat="server" id="llogin"><a runat="server" href="~/Login">Login</a></li>
                      

                          <li id="recicladores" runat="server"><a href="">Recicladores</a>
								<ul>
									  <li><a href="Donaciones/Captura">Captura</a></li>
                        <li><a href="#">Reportes</a></li>
								</ul>
							</li>

                         


                            <li id="maquilas" runat="server"><a href="">Maquilas</a>
								<ul>
                                       <li><a href="#">Reportes</a></li>
								</ul>
							</li>
                    </ul>
                </div>
            </div>
        </div>
    <br />
    <br />
    <br />
    <br />

   <div class="container">
       <div class="panel panel-primary"  id="div_maestro" runat="server">
          <!-- Default panel contents -->
         
            

              <div class="panel panel-primary" id="div_detalle" runat="server">
              <!-- Default panel contents -->
              <div class="panel-heading">Detalle</div>
              <div class="panel-body">
                  <div class="col-md-4">
                    <h4><asp:Label ID="Label8" runat="server" Text="Material"></asp:Label></h4>
                    <asp:DropDownList ID="cmbxMaterial" class="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-4">
                     <h4><asp:Label ID="Label9" runat="server" Text="Boleta Pesaje"></asp:Label></h4>
                    <input id="txtBoletaPesaje" class="form-control" runat="server" type="Text" />
                </div>
               
                <div class="col-md-4">
                     <h4><asp:Label ID="Label10" runat="server" Text="Pase Salida"></asp:Label></h4>
                    <input id="txtPaseSalida" class="form-control" runat="server" type="Text" />
                </div>

                    <div class="col-md-4">
                    <h4><asp:Label ID="Label11" runat="server" Text="Peso Pase"></asp:Label></h4>
                        <input id="txtPesoPase" class="form-control" step=".01" runat="server" type="number" />
                </div>
                <div class="col-md-4">
                     <h4><asp:Label ID="Label12" runat="server" Text="Peso Bascula"></asp:Label></h4>
                    <input id="txtPesoCompra" class="form-control" step=".01" runat="server" type="number" />
                </div>
               
                <div class="col-md-4">
                     <h4><asp:Label ID="Label13" runat="server" Text="Precio Unitario"></asp:Label></h4>
                    <input id="txtPrecioUnitario" class="form-control"  onfocusout="myFunction()" step=".01" runat="server" type="number" />
                </div>


                   <div class="col-md-4">
                     <h4><asp:Label ID="Label14" runat="server" Text="Unidad Medida"></asp:Label></h4>
                       <asp:DropDownList ID="txtUnidadMedida" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
               
                <div class="col-md-4">
                     <h4><asp:Label ID="Label15" runat="server" Text="Importe Total"></asp:Label></h4>
                    <asp:TextBox ID="txtImporteTotal" CssClass="form-control" runat="server" Enabled="true"></asp:TextBox><br /><br />
                     
                     <asp:Button ID="btnDetalle" runat="server" CssClass="btn btn-primary" Text="Guardar Detalle" OnClick="btnDetalle_Click"  />
                </div>

                  
              </div>

            </div>

           <br />
            <div class="panel-heading">Captura</div>
          <div class="panel-body">
            <div class="row">
                <div class="col-md-4">
                    <h4><asp:Label ID="Label1" runat="server" Text="Planta"></asp:Label></h4>
                    <asp:DropDownList ID="cmbxPlanta" class="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <h4><asp:Label ID="Label2" runat="server" Text="Recicladora"></asp:Label></h4>
                    <asp:DropDownList ID="cmbxRecicladora" class="form-control" runat="server"></asp:DropDownList>
                </div>
               
                 <div class="col-md-4">
                     <h4><asp:Label ID="Label6" runat="server" Text="Fecha"></asp:Label></h4>
                    
                    <input type="text" runat="server" onfocusout="myFunction2()" class="form-control" id="datepicker">
                </div>
            </div>

               <div class="row">
                <div class="col-md-4">
                    <h4><asp:Label ID="Label4" runat="server" Text="SubTotal"></asp:Label></h4>
                   <%-- <input id="txtSubtotal" disabled  class="form-control" step=".01" runat="server" type="number" />--%>
                    <asp:TextBox ID="txtSubtotal" Enabled="false"   Cssclass="form-control" runat="server">0</asp:TextBox>
                </div>
                <div class="col-md-4">
                     <h4><asp:Label ID="Label5" runat="server" Text="IVA"></asp:Label></h4>
                    <input id="txtIva" disabled  class="form-control" step=".01"  runat="server" type="number" />
                </div>
               

                    <div class="col-md-4">
                    <h4><asp:Label ID="Label3" runat="server" Text="Total"></asp:Label></h4>
                        <asp:TextBox ID="txtTotal" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
              
                </div>


            </div>

              <div class="row">
                <div class="col-md-4">
                    <h4><asp:Label ID="Label7" runat="server" Text="Capturo"></asp:Label></h4>
                    <asp:TextBox ID="txtCapturo" CssClass="form-control" runat="server"></asp:TextBox><br />  <%--<asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Registrar" OnClick="Button1_Click" />--%>
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-success" Text="Terminar Captura" OnClick="Button1_Click"  />
                </div>
                  <div class="col-md-4">
                    
                </div>
            </div>

             


          </div>

           
       </div>
       <asp:GridView ID="gridDetalles" CssClass="table" runat="server"></asp:GridView>
   </div>
        </form>
</body>
