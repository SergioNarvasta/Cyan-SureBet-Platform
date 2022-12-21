<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function Refresca_Objetos() {
            alert("Entrando al Log");
            var obj = document.getElementById("Button1");
            if (obj) {
                alert("Comprobando disabled");
                alert(obj.disabled);
                if (obj.disabled) {
                    alert("El boton disabled");
                    var obj1 = document.getElementById("btnCliente");
                    if (obj1) {
                        alert("actualizando disabled");
                        obj1.disabled = true;
                    }
                }
            }
        }

        function btnCliente_onclick() {
            var x;
            
            var motivo = prompt("Please enter your name", "motivo de rechazo");

            if (motivo != null) {
                x = motivo;
                var obj = document.getElementById("txtMensaje");
                if (obj) {
                    obj.value = x;
                }
                var obj = document.getElementById("btnServer");
                if (obj) {
                    obj.click();
                  }
            }
            else 
            {
                x = "Debe ingresar motivo de rechazo";
                var obj = document.getElementById("txtMensaje");
                if (obj) {
                    obj.value = x;
                }
            }
            

            
        }

// ]]>
    </script>
</head>
<body onload="Refresca_Objetos()">
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="txtCIA" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtNRO" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtUSR" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" 
            Enabled="False" />
    
        <br />
        <br />
        <br />
        <asp:TextBox ID="txtCIA_RQ" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtRQ" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtUser_RQ" runat="server"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" />
        <br />
        <br />
        <br />
        <asp:TextBox ID="txtMensaje" runat="server" Width="434px"></asp:TextBox>
    
        
        <input id="btnCliente" type="button" value="Prueba Cliente" 
            onclick="return btnCliente_onclick()" /></div>
        <table><tr><td>
        <asp:Button ID="btnServer" runat="server" Text="Prueba Server" onclick="btnServer_Click" style="display:none"/></td>
        </tr>
        </table>
    </form>

</body>
</html>
