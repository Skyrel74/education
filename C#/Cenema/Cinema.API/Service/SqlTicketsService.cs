using Cinema.API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cinema.API.Service
{
    public class SqlTicketsService
    {
        private readonly SqlDatabaseUtil _sqlDatabaseUtil;

        public SqlTicketsService()
        {
            _sqlDatabaseUtil = new SqlDatabaseUtil();
        }
        public bool UpdateTimeSlotCost(TimeSlotCost timeSlotCost)
        {
            return _sqlDatabaseUtil.Execute("update timeslots set cost=@cost where id=@id", 
                new SqlParameter("@id", timeSlotCost.Id),
                new SqlParameter("@cost", timeSlotCost.Cost));
        }

        public TimeSlotCost GetTimeSlotCost(int id)
        {
            return _sqlDatabaseUtil.SelectTimeSlotCosts("select id,cost from timeslots where id=@id", 
                new SqlParameter("@id", id)).FirstOrDefault();
        }

        public IEnumerable<TimeSlotCost> GetAllTimeSlotCosts()
        {
            return _sqlDatabaseUtil.SelectTimeSlotCosts("select id,cost from timeslots");
        }
    }
}