﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    enum Color
    {
        none,
        white,
        black
    }

    static class ColorMethod
    {
        public static Color FlipColor (this Color color)
        {
            if (color == Color.white) return Color.black;
            if (color == Color.black) return Color.white;
            return Color.none;
        }
    }
}
