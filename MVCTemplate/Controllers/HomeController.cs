using SLAExemptionTool.BLL;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace SLAExemptionTool.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        //// GET: Home
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            string path = Server.MapPath("~/App_Data/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = Path.GetFileName(postedFile.FileName);
            if (postedFile != null)
            {

                postedFile.SaveAs(path + fileName);
                ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
            }

            using (OleDbConnection conn = new OleDbConnection())
            {
                DataTable dt = new DataTable();
                string Import_FileName = path + fileName; //Server.MapPath(postedFile.FileName);
                                                          //Import_FileName = System.IO.Path.GetDirectoryName(file_path);
                string fileExtension = Path.GetExtension(Import_FileName);

                if (fileExtension == ".xlsx")
                    conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Import_FileName + ";" + "Extended Properties=" + "\"" + "Excel 12.0;HDR=YES;" + "\"";

                using (OleDbCommand comm = new OleDbCommand())
                {
                    comm.CommandText = "Select * from [Sheet1$]";
                    comm.Connection = conn;
                    using (OleDbDataAdapter da = new OleDbDataAdapter())
                    {
                        da.SelectCommand = comm;
                        da.Fill(dt);
                    }
                }
                ImportExportBL importExportBL = new ImportExportBL();
                importExportBL.MaintainTicketDetails(dt);

            }
            return View();
        }


    }
}