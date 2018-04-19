using System.Web.Mvc;

namespace SLAExemptionTool.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {


        public ManageController()
        {
        }



        protected override void Dispose(bool disposing)
        {

            base.Dispose(disposing);
        }
    }
}