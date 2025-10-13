using System.Web;
using System.Web.Mvc;

namespace TPAppis_Equipo_16_B
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
