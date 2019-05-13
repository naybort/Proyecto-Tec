using System.Web;
using System.Web.Mvc;

namespace ITCR.DATIC.SistemaHorasConsulta.Modelo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
