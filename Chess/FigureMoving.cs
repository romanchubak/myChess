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


        public int DeltaX { get { return to.x - from.x; } }
        public int DeltaY { get { return to.y - from.y; } }

        public int AbsDeltaX { get { return Math.Abs(DeltaX); } }
        public int AbsDeltaY { get { return Math.Abs(DeltaY); } }

        public int SignX { get{ return Math.Sign(DeltaX); } }
        public int SignY { get { return Math.Sign(DeltaY); } }

        public override string ToString()
        {
            string text = (char)figure + from.Name + to.Name;
            if(promotion != Figure.none) text+=(char)promotion;
            return text;
        }

    }
}
