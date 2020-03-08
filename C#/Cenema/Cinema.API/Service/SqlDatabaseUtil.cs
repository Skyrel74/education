using Cinema.API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Cinema.API.Service
{
    public class SqlDatabaseUtil
    {
        private readonly string _connectionString;

        public SqlDatabaseUtil()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Cinema"].ConnectionString;
        }

        public IEnumerable<TimeSlotCost> SelectTimeSlotCosts(string sql, params SqlParameter[] parameters)
        {
            var results = new List<TimeSlotCost>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand(sql, connection);
                if (parameters != null && parameters.Any())
                {
                    cmd.Parameters.AddRange(parameters);
                }
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            results.Add(new TimeSlotCost()
                            {
                                Id = (int)reader["Id"],
                                Cost = (decimal)reader["Cost"]
                            });
                        }
                    }
                }
            }
            return results;
        }

        public bool Execute(string sql, params SqlParameter[] parameters)
        {
            int result;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand(sql, connection);
                if (parameters != null && parameters.Any())
                {
                    cmd.Parameters.AddRange(parameters);
                }
                result = cmd.ExecuteNonQuery();
            }

            return result != 0;
        }
    }
}