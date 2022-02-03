using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_Utilities
{
  public class ConnStringUtil
  {
    public string connectionString = ConfigurationManager.ConnectionStrings["PhoneBook"].ConnectionString;

  }
}
