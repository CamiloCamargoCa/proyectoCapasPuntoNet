<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionFacultades.aspx.cs" Inherits="Presentacion.GestionFacultades" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnListadoFacultades" runat="server">
                <br />
                <table>
                    <caption>Listado Facultades </caption>
                    <tr>
                        <td>
                            <asp:GridView ID="gvlistadoFacultades" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="fac_id" HeaderText="Id" />
                                    <asp:BoundField DataField="fac_nom" HeaderText="Nombre de la Facultad" />
                                   <asp:TemplateField HeaderText="Eliminar">
                                        <ItemTemplate>
                                            <asp:Button ID="BtnEliminar" runat="server" OnClick="BtnEliminar_Click" Text="Eliminar" />
                                            <cc1:ConfirmButtonExtender TargetControlID="BtnEliminar" ID="confBtnDeleteo" runat="server"
                                                DisplayModalPopupID="ModalPopupExtendero"></cc1:ConfirmButtonExtender>

                                            <cc1:ModalPopupExtender ID="ModalPopupExtendero" runat="server" TargetControlID="BtnEliminar"
                                                PopupControlID="PNLo" OkControlID="ButtonOko" CancelControlID="ButtonCancelo" BackgroundCssClass="modalBackground" />

                                            <asp:Panel ID="PNLo" runat="server" Style="display: none; width: 400px; background-color: White; border-width: 2px; border-color: Black; border-style: solid; padding: 20px; color: Black;">
                                                ¿ Está seguro de eliminar este Facultad ?
                                                <br />
                                                <br />
                                                <div style="text-align: right;">
                                                    <asp:Button ID="ButtonOko" runat="server" Text="Aceptar" />
                                                    <asp:Button ID="ButtonCancelo" runat="server" Text="Cancelar" />
                                                </div>
                                            </asp:Panel>



                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Editar">
                                        <ItemTemplate>
                                            <asp:Button ID="btneditar" runat="server" Text="Editar" OnClick="btneditar_Click" />
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
            <asp:Panel ID="pnlInsertarFacultad" runat="server">
                <table>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblmensaje" runat="server" Text="Ingrese nombre Facultad"></asp:Label>
                        </td>
                    </tr>
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
                            <asp:Label ID="lblnomFacultad" runat="server" Text="Nombre"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtnomFacultad" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                   
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btningresar" runat="server" Text="Ingresar" OnClick="btningresar_Click" />
                            <asp:Button ID="btnactualizar" runat="server" Text="Actualizar" OnClick="btnactualizar_Click1" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
