<%@ page title="" language="C#" masterpagefile="~/PaginasMaestras/mpAprobarOrden.master" autoeventwireup="true" inherits="OrdenCompra_Default, App_Web_f4epmlic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" Runat="Server">
    <script language="javascript" type="text/javascript">
        function onClick_Taba(obj) {

            var sNombreTab = obj.id;
            sNombreTab = sNombreTab.substring(3);

            var objTD = document.getElementById("td" +  sNombreTab);
            var objLBL = document.getElementById("lbl" + sNombreTab);
            var objTR = document.getElementById("tr" + sNombreTab);

            tdTabDetalle.bgColor = "#0099FF";
            lblTabDetalle.style.color = "White";
            lblTabDetalle.style.fontWeight = "Bold";
            lblTabDetalle.style.textDecoration = "";
            divTabDetalleFin.style.display = "none";
            trTabDetalle.style.display = "none";

            tdTabEnvioMateriales.bgColor = "#0099FF";
            lblTabEnvioMateriales.style.color = "White";
            lblTabEnvioMateriales.style.fontWeight = "Bold";
            lblTabEnvioMateriales.style.textDecoration = "";
            trTabEnvioMateriales.style.display = "none";

            tdTabFechaEntrega.bgColor = "#0099FF";
            lblTabFechaEntrega.style.color = "White";
            lblTabFechaEntrega.style.fontWeight = "Bold";
            lblTabFechaEntrega.style.textDecoration = "";
            trTabFechaEntrega.style.display = "none";

            tdTabCentroCosto.bgColor = "#0099FF";
            lblTabCentroCosto.style.color = "White";
            lblTabCentroCosto.style.fontWeight = "Bold";
            lblTabCentroCosto.style.textDecoration = "";
            trTabCentroCosto.style.display = "none";

            tdTabReferencia.bgColor = "#0099FF";
            lblTabReferencia.style.color = "White";
            lblTabReferencia.style.fontWeight = "Bold";
            lblTabReferencia.style.textDecoration = "";
            trTabReferencia.style.display = "none";

            tdTabAprobacion.bgColor = "#0099FF";
            lblTabAprobacion.style.color = "White";
            lblTabAprobacion.style.fontWeight = "Bold";
            lblTabAprobacion.style.textDecoration = "";
            trTabAprobacion.style.display = "none";

            tdTabCotizacion.bgColor = "#0099FF";
            lblTabCotizacion.style.color = "White";
            lblTabCotizacion.style.fontWeight = "Bold";
            lblTabCotizacion.style.textDecoration = "";
            trTabCotizacion.style.display = "none";

            if (objTD) 
            {
                objTD.bgColor = "White";
                objLBL.style.color = "#400040";
                objLBL.style.fontWeight = "Bold";
                objLBL.style.textDecoration = "underline";
                objTR.style.display = "";
                if (sNombreTab == "TabDetale")
                    divTabDetalleFin.style.display = "";
            }

        }
    </script>

    <table width="100%" 
        style="font-family: 'Courier New', Courier, 'espacio sencillo'; font-size: 10px" 
        border="1" cellpadding="0" cellspacing="0" bgcolor="#EAEAEA">
    <tr>
        <td align="center">
            <asp:Label ID="lblOrden" runat="server" Text="ORDEN DE COMPRA" Font-Bold="True" 
                Font-Size="Large"></asp:Label>            
        </td>
    </tr>
    <tr id="Datos_1">
        <td>
            <table width="100%">
                <tr>
                    <td width="60%" valign="top">
                        <table width="100%" 
                            style="border-style: solid; border-width: 1px; font-family: 'Courier New', Courier, 'espacio sencillo'; font-size: 10px;">
                            <tr>
                                <td width="25%">Serie: <asp:TextBox ID="txtSerie" runat="server" ReadOnly="True" 
                                        Width="20px" Font-Size="X-Small"></asp:TextBox></td>
                                <td width="30%">Número: 
                                    <asp:TextBox ID="txtNumero" runat="server" ReadOnly="true" 
                                        Width="100px" Font-Size="X-Small"></asp:TextBox></td>
                                <td width="45%">Fecha Emisión: 
                                    <asp:TextBox ID="txtFechaEmision" runat="server" ReadOnly="True" Width="30%" 
                                        Font-Size="X-Small"></asp:TextBox>
                                    <asp:TextBox ID="txtAnho" runat="server" ReadOnly="True" Width="15%" 
                                        Font-Size="X-Small"></asp:TextBox>
                                    <asp:TextBox ID="txtMes" runat="server" ReadOnly="True" Width="10%" 
                                        Font-Size="X-Small"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">Proveedor: 
                                    <asp:TextBox ID="txtRUCProveedor" runat="server" ReadOnly="True" Width="15%"></asp:TextBox>
                                    <asp:TextBox ID="txtRazonProveedor"
                                        runat="server" ReadOnly="true" Width="70%" Font-Size="X-Small"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="3">Dirección: 
                                    <asp:TextBox ID="txtDireccionProveedor" runat="server" ReadOnly="true" 
                                        Width="70%" Font-Size="X-Small"></asp:TextBox>
                                    <asp:TextBox ID="txtDireccionTelefono" runat="server" ReadOnly="true" 
                                        Width="15%" Font-Size="X-Small"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="15%" valign="top">
                        <table width="100%">
                            <tr>
                                <td>T/Cambio: 
                                    <asp:TextBox ID="txtTipoCambio" runat="server" ReadOnly="true" Width="55%" 
                                        Font-Size="X-Small" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Tasa Igv: 
                                    <asp:TextBox ID="txtTasaIgv" runat="server" ReadOnly="true" Width="55%" 
                                        Font-Size="X-Small"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="25%" valign="top">
                        <table width="100%">
                            <tr>
                                <td width="40%">Tipo:</td> 
                                <td width="60%"><asp:TextBox ID="txtLocal" runat="server" ReadOnly="true" 
                                        Width="75%" Font-Size="X-Small"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td width="40%">Estado:</td>
                                <td width="60%"><asp:TextBox ID="txtEstadoOC" runat="server" ReadOnly="true" 
                                        Width="75%" Font-Size="X-Small"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td width="40%">Evento Genera:</td>
                                <td width="60%">
                                    <asp:TextBox ID="txtEventoGenera" runat="server" ReadOnly="true" Width="75%" 
                                        Font-Size="X-Small"></asp:TextBox></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td Width="8%">Atención a:</td>
                    <td Width="30%">
                        <asp:TextBox ID="txtAtencion1" runat="server" ReadOnly="true" Width="10%" 
                            Font-Size="X-Small"></asp:TextBox>
                        <asp:TextBox ID="txtAtencion2"
                            runat="server" ReadOnly="true" Width="20%" Font-Size="X-Small"></asp:TextBox>
                        <asp:TextBox ID="txtAtencion3" runat="server" ReadOnly="true" Width="60%" 
                            Font-Size="X-Small"></asp:TextBox></td>
                    <td Width="8%">Cargo:</td>
                    <td Width="22%">
                        <asp:TextBox ID="txtCargo" runat="server" ReadOnly="true" Width="95%" 
                            Font-Size="X-Small"></asp:TextBox>
                    </td>
                    <td Width="10%">Tipo de Compra:</td>
                    <td Width="22%">
                        <asp:TextBox ID="txtTipoCompra" runat="server" ReadOnly="true" Width="95%" 
                            Font-Size="X-Small"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td>Moneda:</td>
                    <td>
                        <asp:TextBox ID="txtMoneda" runat="server" ReadOnly="true" Width="200px" 
                            Font-Size="X-Small"></asp:TextBox>
                    </td>
                    <td>Condición de Pago:</td>
                    <td align="left">
                        <asp:TextBox ID="txtCondicionPago" runat="server" ReadOnly="true" Width="80px" 
                            Font-Size="X-Small"></asp:TextBox>
                        <asp:TextBox ID="txtDescripcionCP" runat="server" ReadOnly="true" Width="300px" 
                            Font-Size="X-Small"></asp:TextBox>
                        <asp:TextBox ID="txtNroCuotas" runat="server" ReadOnly="true" Width="80px" 
                            Font-Size="X-Small"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Fecha Entrega:</td>
                    <td>
                        <asp:TextBox ID="txtFechaEntrega" runat="server" ReadOnly="true" Width="100px" 
                            Font-Size="X-Small"></asp:TextBox>
                    </td>
                    <td>Luega de Entrega:</td>
                    <td>
                        <asp:TextBox ID="txtLugarEntrega" runat="server" ReadOnly="true" Width="500px" 
                            Font-Size="X-Small"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td>Sujeto a Detracción:</td>
                    <td>
                        <asp:TextBox ID="txtSujetoDetraccion" runat="server" ReadOnly="true" 
                            Width="40px" Font-Size="X-Small"></asp:TextBox>
                    </td>
                    <td>Tabla de Impuestos:</td>
                    <td>
                        <asp:TextBox ID="txtImpuesto" runat="server" ReadOnly="true" Width="60px" 
                            Font-Size="X-Small"></asp:TextBox>
                        <asp:TextBox ID="txtNombreImpuesto"
                            runat="server" ReadOnly="true" Width="300px" Font-Size="X-Small"></asp:TextBox>
                    </td>
                    <td>Tasa:</td>
                    <td>
                        <asp:TextBox ID="txtTasaImpuesto" runat="server" ReadOnly="true" Width="60px" 
                            Font-Size="X-Small" ></asp:TextBox></td>
                    <td>Requerimiento:</td>
                    <td>
                        <asp:TextBox ID="txtRequerimiento" runat="server" ReadOnly="true" Width="180px" 
                            Font-Size="X-Small"></asp:TextBox></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table Width="100%">
                <tr>
                    <td Width="60%" valign="top">
                        <table Width="100%">
                            <tr>
                                <td>Glosa:</td>
                                <td colspan="4">
                                    <asp:TextBox ID="txtGlosa" runat="server" ReadOnly="true" Width="90%" 
                                        TextMode="MultiLine" Font-Size="X-Small"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Sit. Atendido:</td>
                                <td>
                                    <asp:TextBox ID="txtSituacionAtendido" runat="server" ReadOnly="true" 
                                        Width="100px" Font-Size="X-Small"></asp:TextBox></td>
                                <td>Reg. Doc.</td>
                                <td>
                                    <asp:TextBox ID="txtRegistroDoc" runat="server" ReadOnly="true" Width="150px" 
                                        Font-Size="X-Small"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkControlServicios" runat="server" Enabled="false" Text="Control por Servicios de Maquila" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    Ver Contrato:
                                    <asp:HyperLink ID="HypContrato" runat="server" 
                                        ToolTip="click para ver documento del contrato">Ver documento con datos del contrato...</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td Width="40%" valign="top">
                        <table Width="100%">
                            <tr>
                                <td width="30%">Centro de Costos:</td>
                                <td width="70%">
                                    <asp:TextBox ID="txtCentroCosto" runat="server" ReadOnly="true" Width="18%" 
                                        Font-Size="X-Small"></asp:TextBox>
                                    <asp:TextBox ID="txtDescripcionCC" runat="server" ReadOnly="true" Width="75%" 
                                        Font-Size="X-Small"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="30%">Responsable:</td>
                                <td width="70%">
                                    <asp:TextBox ID="txtCodResponsable" runat="server" ReadOnly="true" Width="18%" 
                                        Font-Size="X-Small"></asp:TextBox>
                                    <asp:TextBox ID="txtNombreResponsable"
                                        runat="server" ReadOnly="true" Width="75%" Font-Size="X-Small"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="30%">Indicador Igv:</td>
                                <td width="70%">
                                    <asp:TextBox ID="txtIndicadorIGV" runat="server" ReadOnly="true" Width="95%" 
                                        Font-Size="X-Small"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td width="30%">Calcular Item:</td>
                                <td width="70%">
                                    <asp:TextBox ID="txtCalcularItem" runat="server" ReadOnly="true" Width="95%" 
                                        Font-Size="X-Small"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td>
                        <table width="100%">
                            <tr id="trTabs">
                                <td>
                                    <table width="85%" style="text-align: center">
                                        <tr>
                                            <td bgcolor="White" width="14%" id="tdTabDetalle">
                                                <div id="divTabDetalle" style="cursor: pointer" onclick="javascript:onClick_Taba(this);">
                                                    <span id="lblTabDetalle" style="color:#400040;font-weight:bold;text-decoration:underline;">Detalle</span>
                                                </div>
                                            </td>
                                            <td bgcolor="#0099FF" width="15%" id="tdTabEnvioMateriales">
                                                <div id="divTabEnvioMateriales" style="cursor: pointer" onclick="javascript:onClick_Taba(this);">
                                                    <span id="lblTabEnvioMateriales" style="color:White;font-weight:bold;">Envío de Materiales</span>
                                                </div>
                                            </td>
                                            <td bgcolor="#0099FF" width="15%" id="tdTabFechaEntrega">
                                                <div id="divTabFechaEntrega" style="cursor: pointer" onclick="javascript:onClick_Taba(this);">
                                                    <span id="lblTabFechaEntrega" style="color:White;font-weight:bold;">Fechas de Entregas</span>
                                                </div>
                                            </td>
                                            <td bgcolor="#0099FF" width="14%" id="tdTabCentroCosto">
                                                <div id="divTabCentroCosto" style="cursor: pointer" onclick="javascript:onClick_Taba(this);">
                                                    <span id="lblTabCentroCosto" style="color:White;font-weight:bold;">Centros de Costo</span>
                                                </div>
                                            </td>
                                            <td bgcolor="#0099FF" width="14%" id="tdTabReferencia">
                                                <div id="divTabReferencia" style="cursor: pointer" onclick="javascript:onClick_Taba(this);">
                                                    <span id="lblTabReferencia" style="color:White;font-weight:bold;">Referencias</span>
                                                </div>
                                            </td>
                                            <td bgcolor="#0099FF" width="14%" id="tdTabAprobacion">
                                                <div id="divTabAprobacion" style="cursor: pointer" onclick="javascript:onClick_Taba(this);">
                                                    <span id="lblTabAprobacion" style="color:White;font-weight:bold;">Aprobaciones</span>
                                                </div>
                                            </td>
                                            <td bgcolor="#0099FF" width="14%" id="tdTabCotizacion">
                                                <div id="divTabCotizacion" style="cursor: pointer" onclick="javascript:onClick_Taba(this);">
                                                    <span id="lblTabCotizacion" style="color:White;font-weight:bold;">Cotización</span>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>    
                    </td>
                </tr>
                <tr id="trTabDetalle">
                    <td>
                        <asp:GridView ID="grvDetalle" runat="server" Width="100%" 
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField HeaderText="Item" DataField="OCD_Item">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="60px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Producto" DataField="OCD_Producto_ID">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="T/Inv" DataField="Producto_TipoINV">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="60px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Descripción" DataField="Producto">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="400px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Especif." DataField="OCD_Especif">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="60px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Cantidad" DataField="OCD_Cantidad" 
                                    DataFormatString="{0:N3}">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="% Ajuste" DataField="OCD_Ajuste_Porcentaje" 
                                    DataFormatString="{0:P2}">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Ajuste" DataField="OCD_Ajuste_Cantidad" 
                                    DataFormatString="{0:N3}">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Unid. Comp." DataField="OCD_Ume_Compra">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Unid." DataField="OCD_Cantidad_Real" DataFormatString="{0:N3}">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Precio Unit." DataField="OCD_Precio_Unit" DataFormatString="{0:N3}">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Imp. Bruto" DataField="OCD_Importe_Bruto" DataFormatString="{0:N3}">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Descuento"  DataField="OCD_Importe_Dcto" DataFormatString="{0:N3}">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Valor Venta"  DataField="OCD_Valor_Venta" DataFormatString="{0:N3}">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="IGV"  DataField="OCD_Importe_IGV" DataFormatString="{0:N3}">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Total"  DataField="OCD_Importe_Total" DataFormatString="{0:N3}">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="100px" HorizontalAlign="Right" />
                                </asp:BoundField>
                            </Columns>

                        </asp:GridView>
                    </td>
                </tr>
                <tr id="trTabEnvioMateriales" style="display:none">
                    <td>
                       <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" 
                                        Text="Envío de Materiales para consumo por servicios por Maquila" 
                                        Font-Overline="False" Font-Bold="True" Font-Underline="True"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="grvEnvioMateriales" runat="server" Width="100%">
                                        <Columns>
                                            <asp:BoundField HeaderText="Item" >
                                            <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                            <ItemStyle Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Código" >
                                            <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                            <ItemStyle Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Descripción" >
                                            <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                            <ItemStyle Width="800px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="T Inv." >
                                            <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                            <ItemStyle Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="UM" >
                                            <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                            <ItemStyle Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Cant. Solicitado" >
                                            <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                            <ItemStyle Width="200px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Cant. Envío Proveedor" >
                                            <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                            <ItemStyle Width="200px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Cant Pendiente">
                                            <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                            <ItemStyle Width="100px" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                       </table>
                    </td>
                </tr>
                <tr id="trTabFechaEntrega" style="display:none">
                    <td>
                        <asp:GridView ID="grvFechaEntrega" runat="server" Width="60%" 
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField HeaderText="Item" DataField="OCE_Numero_Entrega" >
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Fecha" DataField="OCE_Fecha_Entrega" DataFormatString="{0:d}">
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="250px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Lugar" DataField="OCE_Lugar_Entrega_Id" >
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Descripción" DataField="OCE_Lugar_Entrega" >
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="800px" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr id="trTabCentroCosto" style="display:none">
                    <td>
                        <asp:GridView ID="grvCentroCosto" runat="server" Width="50%" 
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField HeaderText="C. Costo" DataField="ODC_Centro_Costo_ID" >
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Nombre" DataField="Centro_Costo" >
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="800px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="%" DataField="ODC_Porcentaje" 
                                    DataFormatString="{0:N2}" >
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="100px" HorizontalAlign="Center" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr id="trTabReferencia" style="display:none">
                    <td>
                        <table width="100%">
                            <tr align="center">
                                <td width="20%">
                                    <asp:Label ID="Label2" runat="server" Text="<< Atención en Almacen >>"></asp:Label>
                                </td>
                                <td width="40%">
                                    <asp:Label ID="Label3" runat="server" Text="<< Registro de Compra - Pagos >>"></asp:Label>
                                </td>
                                <td width="40%">
                                    <asp:Label ID="Label4" runat="server" Text="<< Requerimiento Efectivo - Adelantos >>"></asp:Label>
                                </td>
                            </tr>
                            <tr valign="top">
                                <td>
                                    <asp:TextBox ID="txtAtencionAlmacen" runat="server" Width="100%" 
                                        TextMode="MultiLine" Rows="6" ReadOnly="True" Font-Size="X-Small"></asp:TextBox>
                                </td>
                                <td>
                                    <table width="100%">
                                        <tr>
                                            <td colspan="3">
                                                <asp:GridView ID="grvRegistroCompras" runat="server" Width="100%" 
                                                    AutoGenerateColumns="False">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Cta. Corriente" DataField="DOR_CtaCte" >
                                                        <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                                        <ItemStyle Width="30%" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Fecha" DataField="DOR_Fecha_Emision" 
                                                            DataFormatString="{0:d}" >
                                                        <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                                        <ItemStyle Width="20%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Imp. Nacional" DataField="DOR_Importe_Nacional" 
                                                            DataFormatString="{0:N2}" >
                                                        <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                                        <ItemStyle Width="25%" HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Imp. Dolar" DataField="DOR_Importe_Dolar" 
                                                            DataFormatString="{0:N2}" >
                                                        <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                                        <ItemStyle Width="25%" HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="50%" align="right">Totales:</td>
                                            <td width="25%">
                                                <asp:TextBox ID="txtRegTotaImpNac" runat="server" ReadOnly="true" Width="95%" 
                                                    Font-Size="X-Small"></asp:TextBox>
                                            </td>
                                            <td width="25%">
                                                <asp:TextBox ID="txtRegTotalImpDolar" runat="server" ReadOnly="true" 
                                                    Width="95%" Font-Size="X-Small"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table width="100%">
                                        <tr>
                                            <td colspan="3">
                                                <asp:GridView ID="grvRequerimientoEfectivo" runat="server" Width="100%" 
                                                    AutoGenerateColumns="False">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Número" DataField="REF_Numero" >
                                                        <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                                        <ItemStyle Width="30%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Fecha" DataField="REF_Fecha" 
                                                            DataFormatString="{0:d}" >
                                                        <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                                        <ItemStyle Width="20%" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Moneda" DataField="REF_Moneda" >
                                                        <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                                        <ItemStyle Width="25%" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField HeaderText="Imp. Nacional" DataField="REF_Importe" 
                                                            DataFormatString="{0:N2}" >
                                                        <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                                        <ItemStyle Width="25%" HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="75%" align="right">Totales:
                                            </td>
                                            <td width="25%">
                                                <asp:TextBox ID="txtReqTotalImpNac" runat="server" ReadOnly="true" Width="95%" 
                                                    Font-Size="X-Small"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="trTabAprobacion" style="display:none">
                    <td>
                        <table width="100%">
                            <tr>
                                <td width="50%">Niveles de Aprobación</td>
                                <td width="50%">Glosa - Genera O/Compra</td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:GridView ID="grvAprobacion" runat="server" Width="100%" 
                                        AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:BoundField HeaderText="Nivel" DataField="AOA_Nivel_Aprobacion" >
                                            <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                            <ItemStyle Width="30px" HorizontalAlign="Center"/>
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Responsable" DataField="AOA_Usuario_ID" >
                                            <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                            <ItemStyle Width="75px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Nombres y Apellidos" DataField="AOA_Nombres" >
                                            <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                            <ItemStyle Width="275px" HorizontalAlign="Center"/>
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Aprob" DataField="AOA_Indicador_Aprobacion_Texto" >
                                            <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                            <ItemStyle Width="30px" HorizontalAlign="Center"/>
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Fec Aprobacion" DataField="AOA_FechaEval" >
                                            <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                            <ItemStyle Width="150px" HorizontalAlign="Center"/>
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td valign="top">
                                    <asp:TextBox ID="txtGlosaAprobacion" runat="server" TextMode="MultiLine" 
                                        Rows="5" Width="100%" ReadOnly="true" Font-Size="X-Small"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="trTabCotizacion" style="display:none">
                    <td>
                        <asp:GridView ID="grvCotizacion" runat="server" Width="100%">
                            <Columns>
                                <asp:BoundField HeaderText="Sol. Compra" >
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Item" >
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Glosa" >
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="800px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Referencia" >
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Adjuntar" >
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="200px" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Visualizar" >
                                <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                <ItemStyle Width="200px" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td width="35%" valign="top">&nbsp;
                        <div id="divTabDetalleFin">
                            <asp:GridView ID="grvTabDetalleFin" runat="server" Width="100%" 
                                AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField HeaderText="Requerimiento" >
                                    <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                    <ItemStyle Width="200px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Originado por" >
                                    <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                    <ItemStyle Width="200px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Cantidad en O/Compra" >
                                    <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                    <ItemStyle Width="200px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Fecha de Entrega" >
                                    <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                    <ItemStyle Width="200px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Pedido" >
                                    <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                    <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Cliente" >
                                    <HeaderStyle BackColor="#CCCCFF" Font-Bold="True" HorizontalAlign="Center" />
                                    <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </td>
                    <td width="40%">
                        <table width="100%">
                            <tr>
                                <td>
                                    <table width="100%">
                                        <tr>
                                            <td width="20%">% Tolerancia</td>
                                            <td width="20%">Imp. Bruto:</td>
                                            <td width="20%">
                                                <asp:TextBox ID="txtImporteBruto" runat="server" Width="95%" ReadOnly="true" 
                                                    Font-Size="X-Small"></asp:TextBox>
                                            </td>
                                            <td width="20%">Valor Venta:</td>
                                            <td width="20%">
                                                <asp:TextBox ID="txtValorVenta" runat="server" Width="95%" ReadOnly="true" 
                                                    Font-Size="X-Small"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="20%">
                                                <asp:TextBox ID="txtTolerancia" runat="server" Width="95%" ReadOnly="true" 
                                                    Font-Size="X-Small"></asp:TextBox>
                                            </td>
                                            <td width="20%">Imp. Descto:</td>
                                            <td width="20%">
                                                <asp:TextBox ID="txtImporteDscto" runat="server" Width="95%" ReadOnly="true" 
                                                    Font-Size="X-Small"></asp:TextBox>
                                            </td>
                                            <td width="20%">Imp. Igv:</td>
                                            <td width="20%">
                                                <asp:TextBox ID="txtImporteIgv" runat="server" Width="95%" ReadOnly="true" 
                                                    Font-Size="X-Small"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="20%">&nbsp;</td>
                                            <td width="20%">&nbsp;</td>
                                            <td width="20%">&nbsp;</td>
                                            <td width="20%">Imp. Total:</td>
                                            <td width="20%">
                                                <asp:TextBox ID="txtImporteTotal" runat="server" Width="95%" ReadOnly="true" 
                                                    Font-Size="X-Small"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top">
                                    <asp:TextBox ID="txtTextoAdicionalFinal" runat="server" ReadOnly="true" 
                                        Width="95%" TextMode="MultiLine" Rows="3" Font-Size="X-Small"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="25%" valign="top">
                        <asp:TextBox ID="txtTabDetalleComment" runat="server" ReadOnly="True" 
                            Width="95%" Rows="8" TextMode="MultiLine" Font-Size="X-Small"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

