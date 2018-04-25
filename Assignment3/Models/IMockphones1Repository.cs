using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public interface IMockphones1Repository
    {

        IQueryable<phones1> Phones1 { get;  }
        phones1 Save(phones1 phones);
        void Delete(phones1 phones);
    }
}
