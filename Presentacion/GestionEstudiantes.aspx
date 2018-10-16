<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionEstudiantes.aspx.cs" Inherits="Presentacion.GestionEstudiantes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnListadoEstudiantes" runat="server">
                <br />
                <table>
                    <caption>Listado Estudiante</caption>
                    <tr>
                        <td>
                            <asp:GridView ID="gvlistadoestudiantes" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="est_id" HeaderText="Id" />
                                    <asp:BoundField DataField="est_nom" HeaderText="Nombre" />
                                    <asp:BoundField DataField="est_dir" HeaderText="Dirreccion" />
                                    <asp:BoundField DataField="est_tel" HeaderText="Telefono" />
                                    <asp:BoundField DataField="jor_id" HeaderText="Id Jor" />
                                    <asp:BoundField DataField="jor_nom" HeaderText="Jornada" />
                                    <asp:BoundField DataField="pro_id" HeaderText="Id Pro" />
                                    <asp:BoundField DataField="pro_nom" HeaderText="Programa" />
                                    <asp:TemplateField HeaderText="Eliminar">
                                        <ItemTemplate>
                                            <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" OnClick="BtnEliminar_Click1" />
                                            <cc1:ConfirmButtonExtender TargetControlID="BtnEliminar" ID="confBtnDeleteo" runat="server"
                                                DisplayModalPopupID="ModalPopupExtendero"></cc1:ConfirmButtonExtender>

                                            <cc1:ModalPopupExtender ID="ModalPopupExtendero" runat="server" TargetControlID="BtnEliminar"
                                                PopupControlID="PNLo" OkControlID="ButtonOko" CancelControlID="ButtonCancelo" BackgroundCssClass="modalBackground" />

                                            <asp:Panel ID="PNLo" runat="server" Style="display: none; width: 400px; background-color: White; border-width: 2px; border-color: Black; border-style: solid; padding: 20px; color: Black;">
                                                ¿ Está seguro de eliminar este estudiante ?
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
            <asp:Panel ID="pnlInsertarPrograma" runat="server">
                <table>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblmensaje" runat="server" Text="Ingrese nombre Programa"></asp:Label>
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
                            <asp:Label ID="lblnomestudiante" runat="server" Text="Nombre"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtnomestudiante" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <asp:Label ID="lbldirestudiante" runat="server" Text="Direccion"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtdirestudiante" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbltelestudiante" runat="server" Text="Telefono"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txttelestudiante" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblidjorestudiante" runat="server" Text="Id Jornada"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%--<asp:TextBox ID="txtidjorestudiante" runat="server"></asp:TextBox>--%>
                            <asp:DropDownList ID="ddlidjorestudiante" runat="server" DataTextField="jor_nom" DataValueField="jor_id"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblidproestudiante" runat="server" Text="Id Programa"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%--<asp:TextBox ID="txtidproestudiante" runat="server"></asp:TextBox>--%>
                            <asp:DropDownList ID="ddlidproestudiante" runat="server" DataTextField="pro_nom" DataValueField="pro_id"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btningresar" runat="server" Text="Ingresar" OnClick="btningresar_Click" />
                            <asp:Button ID="btnactualizar" runat="server" Text="Actualizar" OnClick="btnactualizar_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
