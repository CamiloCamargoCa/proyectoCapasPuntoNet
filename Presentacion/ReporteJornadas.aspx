<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteJornadas.aspx.cs" Inherits="Presentacion.ReporteJornadas" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="797px">
        <LocalReport ReportPath="TmpReporteJornada.rdlc" ReportEmbeddedResource="Presentacion.TmpReporteJornada.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="dsJornadas" Name="dsJornadas" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="dsJornadas" runat="server" SelectMethod="ListarJornadas" TypeName="ReglasDeNegocio.JornadaControlador, ReglasDeNegocio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null">
        <SelectParameters>
            <asp:Parameter DefaultValue="Data Source=USER-PC\SQLEXPRESS2014;Initial Catalog=tallerBdCapas;Integrated Security=True" Name="Conexion" Type="String"></asp:Parameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
