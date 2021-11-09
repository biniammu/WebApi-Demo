using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiDemo.Models;

namespace WebApiDemo
{
    public class StateRepository
    {
        SqlConnection _sqlConnection = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=TrainingManagement;Integrated Security=True");

        public IEnumerable<States> GetStates()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("spGetStates", _sqlConnection);
            da.Fill(ds);
            List<States> states = new List<States>();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                States state = new States
                {
                    StateId = Int32.Parse(item["StateId"].ToString()),
                    StateName = item["StateName"].ToString(),
                };
                states.Add(state);
            }
            return states;
        }

        public States GetStateById(int id)
        {
            DataSet ds = new DataSet();
            SqlCommand sqlCommand = new SqlCommand("spGetStateById", _sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@pStateId", id);
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(ds, "States");

            DataRow row = ds.Tables["States"].Rows[0];
            States state = new States
            {
                StateId = Int32.Parse(row["StateId"].ToString()),

                StateName = row["StateName"].ToString()
            };

            return state;
        }
        public void InsertState(States state)
        {
            _sqlConnection.Open();
            SqlCommand command = new SqlCommand("spInsertState", _sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@pStateName", state.StateName);
            command.ExecuteNonQuery();
            command.Dispose();
            _sqlConnection.Close();
        }
    }
}