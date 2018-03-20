using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class FigureOnSquare
    {
        public Figure figure { get; set; }
        public Square square { get; set; }

        public FigureOnSquare(Figure f, Square s)
        {
            figure = f;
            square = s;
        }
    }
}
