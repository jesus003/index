<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="Index.Login" %>

<asp:Content  ContentPlaceHolderID="MainContent" runat="server">
   
   
    <div class="container-fluid">
        <div id="myCarousel" class="carousel slide" data-ride="carousel">
            <!-- Carousel indicators -->
            <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="1"></li>
                <li data-target="#myCarousel" data-slide-to="2"></li>
            </ol>   
            <!-- Wrapper for carousel items -->
            <div class="carousel-inner">
                <div class="item active">
                    <img src="img/HR_Foto_Ninos_3.jpg" alt="First Slide">
                     <div class="carousel-caption">
                        <h3>Bienvenidos a Fundación Index Chihuahua</h3>
                        <p>Organización sin fines de lucro dedicada a realizar programas sociales<br />
                         en beneficio de los colaboradores de la industria manufacturera de exportación
                         <br />y de la comunidad Chihuahuense en general.  </p>
                    </div>
                </div>
                <div class="item">
                    <img src="img/HR_FotoNinos_2.jpg" alt="Second Slide">
                     <div class="carousel-caption">
                         <h3>Bienvenidos a Fundación Index Chihuahua</h3>
                        <p>Organización sin fines de lucro dedicada a realizar programas sociales<br />
                         en beneficio de los colaboradores de la industria manufacturera de exportación
                         <br />y de la comunidad Chihuahuense en general.  </p>
                    </div>
                </div>
                
            </div>
            <!-- Carousel controls -->
            <a class="carousel-control left" href="#myCarousel" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left"></span>
            </a>
            <a class="carousel-control right" href="#myCarousel" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right"></span>
            </a>
        </div>
       
    </div>
    <hr />
   <div class="page-header">
  
      
  </div>   
     <div class="col-md-6">
         <asp:Login ID="Login1"  runat="server" OnLoggedIn="Login1_LoggedIn">
             <LayoutTemplate>
                 <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                     <tr>
                         <td>
                             <table cellpadding="0">
                                 <tr>
                                     <td align="center" colspan="2"><h2>Iniciar sesión</h2></td>
                                 </tr>
                                 <tr>
                                     <td align="right">
                                         <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre de usuario:</asp:Label>
                                     </td>
                                     <td>
                                         <asp:TextBox ID="UserName" CssClass="form-control" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td align="right">
                                         <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Contraseña:</asp:Label>
                                     </td>
                                     <td>
                                         <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td colspan="2">
                                         <asp:CheckBox ID="RememberMe" runat="server" Text="Recordármelo la próxima vez." />
                                     </td>
                                 </tr>
                                 <tr>
                                     <td align="center" colspan="2" style="color:Red;">
                                         <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td align="right" colspan="2">
                                         <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-primary" CommandName="Login" Text="Inicio de sesión" ValidationGroup="Login1" />
                                     </td>
                                 </tr>
                             </table>
                         </td>
                     </tr>
                 </table>
             </LayoutTemplate>
         </asp:Login>
    </div>
      <div class="col-md-6">
   <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d13996.026970725397!2d-106.1279166!3d28.7193445!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x542865db55c3e543!2sFundaci%C3%B3n+Index+Chihuahua!5e0!3m2!1ses!2smx!4v1533075387957" width="600" height="450" frameborder="0" style="border:0" allowfullscreen></iframe>
    </div>
    <hr />
     <br />
</asp:Content>