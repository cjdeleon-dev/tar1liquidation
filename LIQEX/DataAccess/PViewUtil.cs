using LIQEX.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace LIQEX.DataAccess
{
    public class PViewUtil
    {
        private static string constr = ConfigurationManager.ConnectionStrings["getconnectionstring"].ConnectionString;

        public LoggedUserModel GetLoggedUserInfoById(int id)
        {
            LoggedUserModel lum = new LoggedUserModel();

            using (OleDbConnection con = new OleDbConnection(constr))
            {
                try
                {
                    con.Open();

                    OleDbCommand ocmd = new OleDbCommand("sp_getuserloggedbyid", con);
                    ocmd.CommandType = System.Data.CommandType.StoredProcedure;

                    ocmd.Parameters.Clear();
                    ocmd.Parameters.AddWithValue("@id", id);
                    
                    OleDbDataReader ordr = ocmd.ExecuteReader();

                    if (ordr.HasRows)
                    {
                        while (ordr.Read())
                        {
                            lum.Id = Convert.ToInt32(ordr["id"]);
                            lum.EmployeeId = ordr["empid"].ToString();
                            lum.Name = ordr["name"].ToString();
                            lum.Position = ordr["position"].ToString();
                            lum.Department = ordr["department"].ToString();
                            lum.Rights = ordr["rights"].ToString();
                            if (lum.Photo == null)
                            {
                                MemoryStream ms = new MemoryStream();
                                Image img = Image.FromFile(HostingEnvironment.MapPath("/Content/images/anonymous.jpg"));
                                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                lum.Photo = ms.ToArray();
                            }

                        }
                    }
                    
                }
                catch (Exception)
                {
                    lum = null;
                }
                finally
                {
                    con.Close();
                }
            }

            return lum;
        }
    }
}