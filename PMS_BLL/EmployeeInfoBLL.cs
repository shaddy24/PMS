using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMS_DAL.Service;
using PMS_Entities;
using PMS_Utilities;

namespace PMS_BLL
{
  public class EmployeeInfoBLL
  {
      
      public EmployeeInfoDAL _employeeInfoDAL = null;


         public IEnumerable<EmployeeInfoTableViewFilterEntity> GetFiltered(EmployeeInfoTableViewFilterEntity objEmployeeInfoFilter)
          {
              

              objEmployeeInfoFilter.SortDirection = ("" + objEmployeeInfoFilter.SortDirection).Trim().ToUpper();

              if (objEmployeeInfoFilter.RowStart == 0)
                  objEmployeeInfoFilter.NoOfRecord = DefaultValueUtil.TableDisplayCountPerPage;
              if (!string.IsNullOrEmpty(objEmployeeInfoFilter.SortDirection))
                  if (objEmployeeInfoFilter.SortDirection != "ASC" && objEmployeeInfoFilter.SortDirection != "DESC")
                      objEmployeeInfoFilter.SortDirection = "";




              IEnumerable<EmployeeInfoTableViewFilterEntity> result = null;

              try
              {
                  _employeeInfoDAL = new EmployeeInfoDAL();

                  result = _employeeInfoDAL.GetFiltered(objEmployeeInfoFilter, true);

              }
              catch (Exception ex)
              {
                  
              }

              _employeeInfoDAL = null;

              return result;
          }



  }

}
