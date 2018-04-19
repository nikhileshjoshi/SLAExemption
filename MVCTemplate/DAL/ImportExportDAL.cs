using SLAExemptionTool.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SLAExemptionTool.DAL
{
    public class ImportExportDAL
    {
        private DBConnection conn;

        /// <constructor>
        /// Constructor ImportExportDAL
        /// </constructor>
        public ImportExportDAL()
        {
            conn = new DBConnection();
        }


        /// <summary>
        /// This method insert/update the ticket information
        /// </summary>
        /// <param name="dtTicketDetails">Ticket informations loaded</param>
        /// <returns></returns>
        public bool MaintainTicketDetails(DataTable dtTicketDetails)
        {
            string query = string.Format("usp_MaintainTicketDetails");
            SqlParameter sqlParameters = new SqlParameter("@TicketDetails", dtTicketDetails);
            sqlParameters.Direction = ParameterDirection.Input;
            sqlParameters.SqlDbType = SqlDbType.Structured;
            conn.execute(query, sqlParameters);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
        public List<TicketDetails> FetchTicketDetails(string emailId)
        {
            string query = string.Format("usp_FetchTicketDetails");
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@EmailID", DbType.String);
            sqlParameters[0].Value = Convert.ToString(emailId);
            DataTable dtResult = null;
            dtResult = conn.executeSelectQuery(query, sqlParameters);
            List<TicketDetails> lstTickets = new List<TicketDetails>();
            if (dtResult != null)
            {
                foreach (DataRow item in dtResult.Rows)
                {
                    TicketDetails _tDetails = new TicketDetails();
                    _tDetails.TicketNumber = item["TicketNumber"].ToString();
                    _tDetails.SLAName = item["SLA"].ToString();
                    lstTickets.Add(_tDetails);
                }
            }
            return lstTickets;
        }

    }
}