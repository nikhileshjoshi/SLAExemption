using SLAExemptionTool.DAL;
using SLAExemptionTool.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SLAExemptionTool.BLL
{
    public class ImportExportBL
    {
        private ImportExportDAL _importExportDAL;

        /// <constructor>
        /// Constructor ImportExportBL
        /// </constructor>
        public ImportExportBL()
        {
            _importExportDAL = new ImportExportDAL();
        }

        /// <method>
        /// 
        /// </method>
        public void MaintainTicketDetails(DataTable dtTicketDetails)
        {
            bool result = _importExportDAL.MaintainTicketDetails(dtTicketDetails);
        }
        public List<TicketDetails> FetchTicketDetails(string emailId)
        {
            return _importExportDAL.FetchTicketDetails(emailId);
        }
    }
}