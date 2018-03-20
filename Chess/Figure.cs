using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    enum Figure
    {
        none = '.',
        WhiteKing = 'K',
        WhiteQueen = 'Q',
        WhiteRook = 'R',
        WhiteBishop = 'B',
        WhiteKnight = 'N',
        WhitePawn = 'P',

        BlackKing = 'k',
        BlackQueen = 'q',
        BlackRook = 'r',
        BlackBishop = 'b',
        BlackKnight = 'n',
        BlackPawn = 'p'
    }

    static class FigureMothods
    {
        public static Color GetColor (this Figure figure)
        {
            if ((char)figure >= 'a' && (char)figure <= 'z')
                return Color.black;
            else if ((char)figure >= 'A' && (char)figure <= 'Z')
                return Color.white;
            else return Color.none;
        }
    }

}
