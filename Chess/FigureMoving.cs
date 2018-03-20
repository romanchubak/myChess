using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class FigureMoving
    {
        public Figure figure { get; set; }
        public Square from { get; set; }
        public Square to { get; set; }
        public Figure promotion { get; set; }

        public FigureMoving(FigureOnSquare fs, Square to, Figure promotion = Figure.none)
        {
            figure = fs.figure;
            from = fs.square;
            this.to = to;
            this.promotion = promotion;
        }
        public FigureMoving(string move)
        {
            figure = (Figure)move[0];
            from = new Square(move.Substring(1, 2));
            to = new Square(move.Substring(3, 2));
            promotion = (move.Length == 6) ? (Figure)move[5] : Figure.none;
        }
    }
}
