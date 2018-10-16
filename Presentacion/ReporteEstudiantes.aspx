<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteEstudiantes.aspx.cs" Inherits="Presentacion.ReporteEstudiantes" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="757px">
        <LocalReport ReportPath="TmpReporteEstudiante.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="dsEstudiantes" Name="dsEstudiantes" />
            </DataSources>
        </LocalReport>
</rsweb:ReportViewer>
    <asp:ObjectDataSource ID="dsEstudiantes" runat="server" SelectMethod="ListarEstudiantes" TypeName="ReglasDeNegocio.EstudianteControlador, ReglasDeNegocio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null">
        <SelectParameters>
            <asp:Parameter DefaultValue="Data Source=USER-PC\SQLEXPRESS2014;Initial Catalog=tallerBdCapas;Integrated Security=True" Name="Conexion" Type="String"></asp:Parameter>
        </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>
