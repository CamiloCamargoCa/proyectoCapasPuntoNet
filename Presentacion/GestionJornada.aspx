<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionJornada.aspx.cs" Inherits="Presentacion.GestionJornada" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlListadoJornada" runat="server">
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gvlistadojornada" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="jor_id" HeaderText="Id" />
                                    <asp:BoundField DataField="jor_nom" HeaderText="Nombre" />
                                    <asp:TemplateField HeaderText="Eliminar">
                                        <ItemTemplate>
                                            <asp:Button ID="btneliminar" runat="server" Text="Eliminar" OnClick="btneliminar_Click" />

                                            <cc1:ConfirmButtonExtender TargetControlID="btneliminar" ID="confBtnDeleteo" runat="server"
                                                DisplayModalPopupID="ModalPopupExtendero"></cc1:ConfirmButtonExtender>

                                            <cc1:ModalPopupExtender ID="ModalPopupExtendero" runat="server" TargetControlID="btneliminar"
                                                PopupControlID="PNLo" OkControlID="ButtonOko" CancelControlID="ButtonCancelo" BackgroundCssClass="modalBackground" />

                                            <asp:Panel ID="PNLo" runat="server" Style="display: none; width: 400px; background-color: White; border-width: 2px; border-color: Black; border-style: solid; padding: 20px; color: Black;">
                                                ¿ Está seguro de eliminar esta Jornada ?
                                                <br />
                                                <br />
                                                <div style="text-align: right;">
                                                    <asp:Button ID="ButtonOko" runat="server" Text="Aceptar" />
                                                    <asp:Button ID="ButtonCancelo" runat="server" Text="Cancelar" />
                                                </div>
                                            </asp:Panel>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Actualizar">
                                        <ItemTemplate>
                                            <asp:Button ID="btnactualizar" runat="server" Text="Actualizar" OnClick="btnactualizar_Click1" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlInsertarJornada" runat="server">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblcodigo" runat="server" Text="ID"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblvalorcodigo" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblmensAJE" runat="server" Text="Ingrese el nombre de la jornada"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtnombrejornada" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btningresar" runat="server" Text="Ingresar" OnClick="btningresar_Click" />
                            <asp:Button ID="btnactualizar" runat="server" Text="Actualizar" OnClick="btnactualizar_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
