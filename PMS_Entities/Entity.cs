using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_Entities
{
    public abstract class Entity
    {
      public bool IsSuccess { get; set; }
      public List<string> MessageList { get; set; }
    }
}
