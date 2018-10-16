﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteProgramas.aspx.cs" Inherits="Presentacion.ReporteProgramas" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="775px">
        <LocalReport ReportPath="TmpReportePrograma.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="dsProgramas" Name="dsProgramas" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="dsProgramas" runat="server" SelectMethod="ListarProgramas" TypeName="ReglasDeNegocio.ProgramaControlador, ReglasDeNegocio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null">
        <SelectParameters>
            <asp:Parameter DefaultValue="Data Source=USER-PC\SQLEXPRESS2014;Initial Catalog=tallerBdCapas;Integrated Security=True" Name="Conexion" Type="String"></asp:Parameter>
        </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>