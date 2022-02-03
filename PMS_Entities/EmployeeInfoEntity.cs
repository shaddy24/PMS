using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_Entities
{

  public class EmployeeInfoEntity : Entity
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Birthday { get; set; }
    public string Gender { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    //Validation
    public bool ifAllfieldsNull { get; set; }
    public bool ifPatientExists { get; set; }
    public bool isValidField { get; set; }


  }


  public class EmployeeInfoTableViewEntity : TableViewDefaultFilterEntity
  {
    public int TotalNoOfRecords { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Birthday { get; set; }
    public string Gender { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

  }

  public class EmployeeInfoTableViewFilterEntity : TableViewDefaultFilterEntity
  {
    public int TotalNoOfRecords { get; set; }
    public string SearchField { get; set; }
    public string SearchValue { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Birthday { get; set; }
    public string Gender { get; set; }
    public string ContactNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
  }






}
