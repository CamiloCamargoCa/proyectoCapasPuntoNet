<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="Presentacion.MenuPrincipal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page ui-tabs ui-corner-all">
 <fieldset style="background-color:#fff" >
    <legend class="ui-tabs ui-widget ui-widget-header ui-widget-content ui-corner-all"> MENÚ ADMINISTRADOR </legend>
    <div>
        <% = ScriptModulos%>
    </div>
     </fieldset>


    </div>
</asp:Content>
