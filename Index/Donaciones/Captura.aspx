<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Captura.aspx.cs" Inherits="Index.Descuento.Captura" %>

<asp:Content  ContentPlaceHolderID="MainContent" runat="server">
   
    <br />
    <br />
    <br />
    <br />
   <div class="container">
       <div class="panel panel-primary">
          <!-- Default panel contents -->
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
                    <h4><asp:Label ID="Label3" runat="server" Text="Fecha"></asp:Label></h4>
                    <asp:TextBox ID="txtFecha" class="form-control" runat="server"></asp:TextBox>
              
                </div>
            </div>

               <div class="row">
                <div class="col-md-4">
                    <h4><asp:Label ID="Label4" runat="server" Text="SubTotal"></asp:Label></h4>
                    <input id="txtSubtotal" class="form-control" runat="server" type="number" />
                </div>
                <div class="col-md-4">
                     <h4><asp:Label ID="Label5" runat="server" Text="IVA"></asp:Label></h4>
                    <input id="txtIva" class="form-control" runat="server" type="number" />
                </div>
                <div class="col-md-4">
                     <h4><asp:Label ID="Label6" runat="server" Text="Total"></asp:Label></h4>
                    <input id="txtTotal" class="form-control" runat="server" type="number" />
                </div>
            </div>

              <div class="row">
                <div class="col-md-4">
                    <h4><asp:Label ID="Label7" runat="server" Text="Capturo"></asp:Label></h4>
                    <input id="txtCapturo" class="form-control" runat="server" type="text" /><br />  <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Registrar" OnClick="Button1_Click" />
                </div>
                  <div class="col-md-4">
                    
                </div>
            </div>
              <br />

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
                        <input id="txtPesoPase" class="form-control" runat="server" type="number" />
                </div>
                <div class="col-md-4">
                     <h4><asp:Label ID="Label12" runat="server" Text="Peso Compra"></asp:Label></h4>
                    <input id="txtPesoCompra" class="form-control" runat="server" type="number" />
                </div>
               
                <div class="col-md-4">
                     <h4><asp:Label ID="Label13" runat="server" Text="Precio Unitario"></asp:Label></h4>
                    <input id="txtPrecioUnitario" class="form-control" runat="server" type="number" />
                </div>


                   <div class="col-md-4">
                     <h4><asp:Label ID="Label14" runat="server" Text="Unidad Medida"></asp:Label></h4>
                    <input id="txtUnidadMedida" class="form-control" runat="server" type="number" />
                </div>
               
                <div class="col-md-4">
                     <h4><asp:Label ID="Label15" runat="server" Text="Importe Total"></asp:Label></h4>
                    <input id="txtImporteTotal" class="form-control" runat="server" type="number" /><br /><br />
                     <asp:Button ID="btnDetalle" runat="server" CssClass="btn btn-primary" Text="Guardar Detalle" OnClick="btnDetalle_Click"  />
                </div>


              </div>

            </div>


             


          </div>
       </div>
   </div>
</asp:Content>
