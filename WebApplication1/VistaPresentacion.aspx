<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaPresentacion.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/style.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#tablaCiudades').on('click', '.cssColumn',function () {
                var IdCiudad;
                var currentRow = $(this).closest("tr");
                IdCiudad = currentRow.find("td:eq(0)").text();

                var VendedoresVO = {
                    "idCiudad": IdCiudad.toString(),
                    "IdVendedor": 0,
                    "IdFactura": 0
                }

                var stringData = JSON.stringify(VendedoresVO)
                $.ajax({
                    url: "../VistaPresentacion.aspx/GetVendedores",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    data: "{'VendedoresVO':" + stringData + "}",
                    dataType: "json",
                    success: function (response) {

                        var Vendedores = response.d;

                        $('#tablaVendedores').empty();

                        for (var i = 0; i < Vendedores.length; i++) {
                            $('#tablaVendedores').append('<tr>' +
                                '<td>' + Vendedores[i].IdCiudad + '</td>' +
                                '<td>' + Vendedores[i].IdFactura + '</td>' +
                                '<td>' + Vendedores[i].IdVendedor + '</td>' +
                                '</tr>');
                        }


                    },
                    error: function (erromessage) {
                        alert(erromessage.responseText);
                    }
                });
            });
            $('#grdEstados tr').click(function () {

                var row = $(this).closest("tr");
                var tds = row.find("td");
                var IdEstado = tds[0].textContent;

                var EstadosVO = {
                    "Id": IdEstado.toString(),
                    "Estado": ''
                }

                var stringData = JSON.stringify(EstadosVO)
                $.ajax({
                    url: "../VistaPresentacion.aspx/GetCiudades",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    data: "{'EstadosVO':" + stringData + "}",
                    dataType: "json",
                    success: function (response) {

                        var Ciudades = response.d;

                        $('#tablaCiudades').empty();

                        for (var i = 0; i < Ciudades.length; i++) {
                            $('#tablaCiudades').append('<tr class="cssColumn">' +
                                '<td>' + Ciudades[i].Id + '</td>' +
                                '<td>' + Ciudades[i].Nombre + '</td>' +
                                '</tr>');
                        }
                    },
                    error: function (erromessage) {
                        alert(erromessage.responseText);
                    }
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
        <br />
        <div class="Gridcss">
            
        <asp:GridView  ID="grdEstados" runat="server" CssClass="table table-striped" >
          
        </asp:GridView>
        </div>
        <br />
        <br />
               <div class="table-responsive Gridcss">
                <table class="table table-striped table-bordered table-hover">
                    <thead style="background-color: Silver;">
                        <tr>
                            <td title="Este es el ID">
                                <b>ID</b>
                            </td>
                            <td>
                                <b>Ciudad</b>
                            </td>
                        </tr>
                    </thead>
                    <tbody id="tablaCiudades">
                    </tbody>
                </table>
            </div>
        <br />
          <div class="table-responsive Gridcss">
                <table  class="table table-striped table-bordered table-hover">
                    <thead style="background-color: Silver;">
                        <tr>
                            <td title="Este es el ID">
                                <b>IDCiudad</b>
                            </td>
                            <td>
                                <b>IdFactura</b>
                            </td>
                            <td>
                                <b>IdVendedor</b>
                            </td>
                        </tr>
                    </thead>
                    <tbody id="tablaVendedores">
                    </tbody>
                </table>
            </div>

       <%-- <table id='tablaCiudades' style="width: 200px;"  border="1"></table> --%>

</form>
</body>
</html>
