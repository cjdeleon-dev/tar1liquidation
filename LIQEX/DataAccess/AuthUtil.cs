using LIQEX.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace LIQEX.DataAccess
{
    public class AuthUtil
    {
        private static string constr = ConfigurationManager.ConnectionStrings["getconnectionstring"].ConnectionString;

        public ProcessModel isLoginSuccess(UserLoginModel ulm)
        {
            ProcessModel pm = new ProcessModel();

            using (OleDbConnection con = new OleDbConnection(constr))
            {
                try
                {
                    con.Open();

                    OleDbCommand ocmd = new OleDbCommand("sp_getempdetailsbylogin", con);
                    ocmd.CommandType = System.Data.CommandType.StoredProcedure;

                    ocmd.Parameters.Clear();
                    ocmd.Parameters.AddWithValue("@empid", ulm.EmpId);
                    ocmd.Parameters.AddWithValue("@pass", ulm.Password);

                    OleDbDataReader ordr = ocmd.ExecuteReader();

                    if (ordr.HasRows)
                    {
                        while (ordr.Read())
                        {
                            pm.Id = Convert.ToInt32(ordr["id"]);
                            pm.IsProcessSuccess = true;
                            pm.Message = "Success";
                        }
                    }
                    else
                    {
                        pm.Id = 0;
                        pm.IsProcessSuccess = false;
                        pm.Message ="Employee Id is not exist or the pasword is incorrect.";
                    }
                }
                catch (Exception ex)
                {
                    pm.Id = 0;
                    pm.IsProcessSuccess = false;
                    pm.Message = ex.Message;
                }
                finally
                {
                    con.Close();
                }
            }

            return pm;
        }
    }
}