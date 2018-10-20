﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteFacultades.aspx.cs" Inherits="Presentacion.ReporteFacultades" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="798px">
        <LocalReport ReportPath="TmpReporteFacultad.rdlc" ReportEmbeddedResource="Presentacion.TmpReporteFacultad.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="dsFacultades" Name="dsFacultades" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="dsFacultades" runat="server" SelectMethod="ListarFacultades" TypeName="ReglasDeNegocio.FacultadControlador, ReglasDeNegocio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null">
        <SelectParameters>
            <asp:Parameter DefaultValue="Data Source=USER-PC\SQLEXPRESS2014;Initial Catalog=tallerBdCapas;Integrated Security=True" Name="Conexion" Type="String"></asp:Parameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
