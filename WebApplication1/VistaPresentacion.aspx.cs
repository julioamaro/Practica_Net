using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication13.Datos;
using WebApplication13.Negocio;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds;
            ds = EstadosBLL.GetEstados();

            grdEstados.DataSource = ds;
            grdEstados.DataBind();
            
        }
        [WebMethod]
        public static IEnumerable<CiudadesVO> GetCiudades(EstadosVO EstadosVO)
        {
            var LsCiudades = CiudadesBLL.GetCiudades(EstadosVO.Id);

            var listaCiudades = LsCiudades.Tables[0].AsEnumerable().Select(DataRow => new CiudadesVO {
                Id = DataRow.Field<string>("IdCiudad").ToString(),
                Nombre = DataRow.Field<string>("Nombre").ToString(),
            }).ToList();

            return listaCiudades;
        }

        [WebMethod]
        public static IEnumerable<VendedoresVO> GetVendedores(VendedoresVO VendedoresVO)
        {
            var LsCiudades = VendedoresBLL.GetVendedores(VendedoresVO.IdCiudad);

            var listaCiudades = LsCiudades.Tables[0].AsEnumerable().Select(DataRow => new VendedoresVO
            {
                IdCiudad = DataRow.Field<string>("IdCiudad").ToString(),
                IdVendedor = DataRow.Field<string>("IdVendedor").ToString(),
                IdFactura = DataRow.Field<string>("IdFacturas").ToString()
            }).ToList();

            return listaCiudades;
        }
    }
    }
