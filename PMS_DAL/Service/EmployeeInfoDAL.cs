using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using PMS_Utilities;
using PMS_Entities;
using PMS_DAL.DB;

namespace PMS_DAL.Service
{
  public class EmployeeInfoDAL
  {
      
       public IEnumerable<EmployeeInfoTableViewFilterEntity> GetFiltered(EmployeeInfoTableViewFilterEntity e, bool isPartial)
        {
            using (SqlConnection conn = new SqlConnection(MSSQLConnectionProvider.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandTimeout = MSSQLConnectionProvider.GetConnectionTimeOut(),
                    CommandText = "sp_EmployeeInfoGetFiltered",
                    CommandType = CommandType.StoredProcedure
                })
                {
                    cmd.Parameters.Add("@RowStart", SqlDbType.Int);
                    cmd.Parameters.Add("@NoOfRecord", SqlDbType.Int);

                    cmd.Parameters.Add("@SortColumn", SqlDbType.VarChar);
                    cmd.Parameters.Add("@SortDirection", SqlDbType.VarChar);
                    cmd.Parameters.Add("@IsPartial", SqlDbType.Bit);


                    string sortColumn = "";

                    switch (e.SortColumn)
                    {
                        case 1:
                            sortColumn = "Name ";
                            break;
                        case 2:
                            sortColumn = "Gender";

                            break;
                        case 3:
                            sortColumn = "Birthday ";
                            break;
                        case 4:
                            sortColumn = "Email";
                            break;
                        case 5:
                            sortColumn = "Address ";
                            break;
                        default:
                            break;
                    }

                    cmd.Parameters["@RowStart"].Value = e.RowStart;
                    cmd.Parameters["@NoOfRecord"].Value = e.NoOfRecord;
                    cmd.Parameters["@SortColumn"].Value = sortColumn;
                    cmd.Parameters["@SortDirection"].Value = e.SortDirection;
                    cmd.Parameters["@IsPartial"].Value = isPartial;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                    cmd.Parameters.Add("@Gender", SqlDbType.VarChar);
                    cmd.Parameters.Add("@Birthday", SqlDbType.VarChar);
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar);
                    cmd.Parameters.Add("@Address", SqlDbType.VarChar);


                    cmd.Parameters["@Name"].Value = e.Name;
                    cmd.Parameters["@Gender"].Value = e.Gender;
                    cmd.Parameters["@Birthday"].Value = e.Birthday;
                    cmd.Parameters["@Email"].Value = e.Email;
                    cmd.Parameters["@Address"].Value = e.Address;


                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new EmployeeInfoTableViewFilterEntity()
                            {
                                TotalNoOfRecords = Convert.ToInt32(reader["TotalNoOfRecord"]),
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = "" + reader["Name"],
                                Gender = "" + reader["Gender"],
                                Birthday = reader["Birthday"] == DBNull.Value ? "" : Convert.ToDateTime(reader["Birthday"].ToString()).ToString("MM/dd/yyyy"),
                                Email = "" + reader["Email"],
                                Address = "" + reader["Address"],

                            };
                        }
                    }
                }
            }

        }







  }
}
