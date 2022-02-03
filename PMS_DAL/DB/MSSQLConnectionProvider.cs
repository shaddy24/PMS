using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_DAL.DB
{
  public class MSSQLConnectionProvider
  {

    public static string GetConnectionString()
    {
      string result;
      result = ConfigurationManager.ConnectionStrings["PMS"].ConnectionString;
      return result;
    }

    public static int GetConnectionTimeOut()
    {
      int result = 0;
      return result;
    }

  }
}
