using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_Entities
{
    public class TableViewDefaultFilterEntity : Entity
    {
      public int RowStart { get; set; }
      public int NoOfRecord { get; set; }
      public int SortColumn { get; set; }
      public string SortDirection { get; set; }
    }
}
