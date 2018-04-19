using SLAExemptionTool.BLL;
using SLAExemptionTool.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SLAExemptionTool.Controllers
{
    public class ImportExportController : Controller
    {
        // GET: Ticket
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult TicketDetails()
        {            
            ImportExportBL importExportBL = new ImportExportBL();
            List<TicketDetails> lstTicketDetails = new List<TicketDetails>();
            lstTicketDetails = importExportBL.FetchTicketDetails("EmailId");
            return PartialView("TicketResult", lstTicketDetails);
        }
    }
}