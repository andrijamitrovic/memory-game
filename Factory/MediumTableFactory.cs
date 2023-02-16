using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG_94_2018.Factory
{
    public class MediumTableFactory : ITableFactory
    {
        public ITable GetTable()
        {
            ITable table = new MediumTable();
            return table;
        }
    }
}
