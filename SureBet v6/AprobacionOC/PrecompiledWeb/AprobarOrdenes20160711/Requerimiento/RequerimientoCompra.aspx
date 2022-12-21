<%@ page title="" language="C#" masterpagefile="~/PaginasMaestras/mpAprobarRQ.master" autoeventwireup="true" inherits="Requerimiento_Default, App_Web_vuha2efg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" Runat="Server">
    <table width="100%" 
        style="font-family: 'Courier New', Courier, 'espacio sencillo'; font-size: 10px" 
        border="1" cellpadding="0" cellspacing="0" bgcolor="#EAEAEA">
    <tr>
        <td align="center">
            <asp:Label ID="lblOrden" runat="server" Text="REQUERIMIENTO DE COMPRA" Font-Bold="True" 
                Font-Size="Large"></asp:Label>            
        </td>
    </tr>
    <tr>
        <td>
            <table width ="100%" class="cabeceraWeb" >
                <!-- Cabecera -->
                <tr>
                    <td width="70%">
                        <table width="100%">
                            <tr>
                                <td colspan="4">
                                    <table width="100%">
                                        <tr>
                                            <td>Requerimiento<asp:TextBox ID="txtNumero" runat="server" Font-Size="XX-Small" 
                                                    Width="185px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>Fecha Registro<asp:TextBox ID="txtFecRegistro" runat="server" 
                                                    Font-Size="XX-Small" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>Fecha Sugerida<asp:TextBox ID="txtFecSugerida" runat="server" 
                                                    Font-Size="XX-Small" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>Estado<asp:TextBox ID="txtEstado" runat="server" Font-Size="XX-Small" 
                                                    Width="101px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td width="10%">U. Negocio</td>
                                <td width="60%">
                                    <asp:TextBox ID="txtUNegocio" runat="server" Font-Size="XX-Small" Width="367px" 
                                        ReadOnly="True"></asp:TextBox>
                                </td>
                                <td width="30%" colspan="2">
                                <table border=3><tr>
                                <td>Sit Aprobado</td>
                                <td align="center">
                                    <asp:TextBox ID="txtSituacion" runat="server" Font-Size="XX-Small" 
                                        Width="110px" ReadOnly="True"></asp:TextBox>
                                </td></tr>
                                </table></td>
                            </tr>
                            <tr>
                                <td width="10%">C. Costo</td>
                                <td width="60%">
                                    <asp:TextBox ID="txtCenCos_ID" runat="server" Font-Size="XX-Small" 
                                        ReadOnly="True"></asp:TextBox>
                                    <asp:TextBox ID="txtCenCos" runat="server" Font-Size="XX-Small" Width="280px" 
                                        ReadOnly="True"></asp:TextBox>
                                </td>
                                <td width="15%">Prioridad</td>
                                <td width="15%">
                                    <asp:TextBox ID="txtPrioridad" runat="server" Font-Size="XX-Small" 
                                        Width="110px" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="10%">Originado por</td>
                                <td width="60%">
                                    <asp:TextBox ID="txtUser_Origen_ID" runat="server" Font-Size="XX-Small" 
                                        Width="80px" ReadOnly="True"></asp:TextBox>
                                    <asp:TextBox ID="txtUser_Origen" runat="server" Font-Size="XX-Small" 
                                        Width="276px" ReadOnly="True"></asp:TextBox>
                                </td>
                                
                                <td colspan="2">
                                    <asp:TextBox ID="txtJustifica" runat="server" Font-Size="XX-Small" Height="30px" 
                                        Width="300px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            </table>
                    </td>
                    <td width="30%" valign="top">
                        <table width="100%">
                            <tr>
                                <td width="30%"><b>Tipo Requisicion</b></td>
                                <td width="70%">
                                    <asp:TextBox ID="txtTipo_Requisicion" runat="server" Font-Size="XX-Small" Width="300px" 
                                        ReadOnly="True" BackColor="#3399FF" ForeColor="White"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblOrden_Compra" runat="server" Text="A.Marco / C.L. Servicios"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOrden_Compra" runat="server" Font-Size="XX-Small" Width="80px" 
                                        ReadOnly="True" BackColor="#3399FF" ForeColor="White"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td><asp:Label ID="lblProveedor" runat="server" Text="Proveedor"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtProveedor" runat="server" Font-Size="XX-Small" Width="300px" 
                                        ReadOnly="True" BackColor="#3399FF" ForeColor="White"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="30%">PCN</td>
                                <td width="70%">
                                    <asp:TextBox ID="txtPCN" runat="server" Font-Size="XX-Small" Width="165px" 
                                        ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Disciplina</td>
                                <td>
                                    <asp:TextBox ID="txtDisciplina_ID" runat="server" Font-Size="XX-Small" 
                                        Width="30px" ReadOnly="True"></asp:TextBox>
                                    <asp:TextBox ID="txtDisciplina" runat="server" Font-Size="XX-Small" 
                                        Width="124px" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Reembolso</td>
                                <td>
                                    <asp:TextBox ID="txtReembolso" runat="server" Font-Size="XX-Small" Width="30px" 
                                        ReadOnly="True"></asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;
                                    Presupuesto
                                    <asp:TextBox ID="txtPresupuesto" runat="server" Font-Size="XX-Small" 
                                        Width="30px" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>9 Digitos</td>
                                <td>
                                    <asp:TextBox ID="txt9Digitos" runat="server" Font-Size="XX-Small" Width="165px" 
                                        ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                </td></tr>
                <tr><td colspan="2">
                        <table width="100%">
                        <tr>
                        <td width="7%">Resumen</td>
                        <td width="42%"><asp:TextBox ID="txtResumen" runat="server" Font-Size="XX-Small" Width="369px" 
                                        ReadOnly="True"></asp:TextBox></td>
                        <td rowspan="2"><table border="1" width="100%"><tr><td>
                                               <asp:GridView ID="grvAprobacion" runat="server" Width="100%" 
                                                    AutoGenerateColumns="False" style="margin-right: 0px">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Usuario" DataField="ARA_User_ID" >
                                                        <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                                        <ItemStyle Width="75px" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Nombres y Apellidos" DataField="User_Nombre">
                                                        <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                                        <ItemStyle Width="275px" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Orden" DataField="ARA_Nivel_Aprob">
                                                        <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                                        <ItemStyle Width="30px" HorizontalAlign="center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Ara_Ind_Aprob_Texto" HeaderText="Aprob">
                                                        <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" />
                                                        <ItemStyle Width="30px" HorizontalAlign="center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Ara_FechaEval" HeaderText="Fec Aprob.">
                                                        <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" />
                                                        <ItemStyle Width="150px" HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                                </td></tr>
                            </table>
                        </td>
                        </tr>
                        <tr>
                                <td width="7%">Motivo</td>
                                <td width="42%">
                                    <asp:TextBox ID="txtMotivo" runat="server" Font-Size="XX-Small" Height="48px" 
                                        Width="369px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                                </td>
                        </tr>
                        
                        </table></tr>
                    </td>
                </tr>
                <!-- Detalle -->
                <table border=1 width="100%">
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="grvDetalle" runat="server" Width="100%" 
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField HeaderText="Item" DataField="RCD_Item" >
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Left" />
                                <ItemStyle Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Prd. Compras" DataField="RCD_Producto_ID">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Left" />
                                <ItemStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Descripción Compras" DataField="Producto">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Left" />
                                <ItemStyle Width="400px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Unidad" DataField="Ume">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Left" />
                                <ItemStyle Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Cantidad" 
                                    DataFormatString="{0:N3}" DataField="RCD_Cantidad">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Especificaciones" DataField="Rcd_Especificacion">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="300px" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Estado" DataField="RCD_Estado">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="150px" HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Prov. Sug. Comparas" DataField="RCD_Proveedor_ID">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Nombres" DataField="Proveedor">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="300px" HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RCD_Sustento" HeaderText="Sustento">
                                <HeaderStyle BackColor="#CCCCFF" HorizontalAlign="Center" />
                                <ItemStyle Width="200px" HorizontalAlign="Right" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>

                    </td>
                    </tr>
                    </table>
                <!-- Pie -->
                <tr>
                    <td colspan="2">
                    <br />
                        (*)
                    Documentos adjuntos:</td>
                </tr>
                <tr>
                    <td colspan="2">

                    <asp:GridView ID="grvAdjuntos" runat="server" 
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField HeaderText="Item" DataField="RAD_Item" >
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Left" />
                                <ItemStyle Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Nombre Adjunto" DataField="RAD_Nombre">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Left" />
                                <ItemStyle Width="200px" />
                                </asp:BoundField>
                                <asp:HyperLinkField HeaderText="Link" Text="Ver adjunto..." 
                                    DataNavigateUrlFields="Rad_Codigo_Link" DataTextField="Rad_Codigo" 
                                    Target="_blank" >
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="center" />
                                <ItemStyle Width="100px" />
                                </asp:HyperLinkField>

                            </Columns>
                        </asp:GridView>
                           
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

