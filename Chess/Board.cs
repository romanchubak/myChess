﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Board
    {
        public string fen { get; private set; }
        Figure[,] figures;
        public Color moveColor { get; private set; }
        public int moveNumber { get; private set; }

        public Board( string fen)
        {
            this.fen = fen;
            figures = new Figure[8, 8];
            Init();
        }

        private void Init()
        {
            string[] parts = fen.Split();
            if (parts.Length != 6) return;
            InitFigure(parts[0]);
            moveColor = (parts[1] == "b") ? Color.black : Color.white;
            moveNumber = int.Parse(parts[5]);
        }

        private void InitFigure(string data)
        {
            for (int j = 8; j >= 2; j--)
                data = data.Replace(j.ToString(), (j - 1).ToString() + "1");
            data = data.Replace('1', '.');
            string[] lines = data.Split('/');
            for (int y = 7; y >= 0; y--)
                for (int x = 0; x < 8; x++)
                    figures[x, y] = lines[7-y][x]=='.'? Figure.none:  (Figure)lines[7 - y][x];
        }

        public Figure GetFigureAt(Square s)
        {
            if (s.OnBoard())
                return figures[s.x, s.y];
            return Figure.none;
        }
        private void SetFigureAt(Square s, Figure f)
        {
            if (s.OnBoard())
                figures[s.x, s.y] = f;
        }

        public Board Move(FigureMoving fm)
        {
            Board next = new Board(fen);
            next.SetFigureAt(fm.from, Figure.none);
            next.SetFigureAt(fm.to, fm.promotion==Figure.none ? fm.figure: fm.promotion);
            if (moveColor == Color.black) next.moveNumber++;
            next.moveColor = moveColor.FlipColor();
            next.GenerateFen();
            return next;
        }

        private void GenerateFen()
        {
            fen = FenFigures() + " " +
                   (moveColor==Color.white ? "w": "b") + " - - 0 " + moveNumber.ToString();
        }

        private string FenFigures()
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 7; y >= 0; y--)
            {
                for (int x = 0; x < 8; x++)
                    sb.Append(figures[x, y] == Figure.none ? '1':(char)figures[x,y]);
                if (y > 0) sb.Append('/');
            }
            return sb.ToString();
        }
        
    }
}
