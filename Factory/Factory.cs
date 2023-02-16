using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum SizeType
{
    size_3x3x2,
    size_3x4x2
}

namespace MG_94_2018.Factory
{
    public class Factory
    {
        public static ITable GetTable(SizeType sizeType)
        {
            switch (sizeType)
            {
                case SizeType.size_3x3x2:
                    return new EasyTableFactory().GetTable();
                case SizeType.size_3x4x2:
                    return new MediumTableFactory().GetTable();
            }
            return null;
        }
    }
}
