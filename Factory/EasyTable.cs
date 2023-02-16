using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MG_94_2018.Factory
{
    public class EasyTable : ITable
    {
        private int _width = 150;
        private int _height = 200;
        private int _row = 3;
        private int _col = 6;
        public override int Width { get => _width; }
        public override int Height { get => _height; }
        public override int NumOfRows { get => _row; }
        public override int NumOfColumns { get => _col; }

    }
}
