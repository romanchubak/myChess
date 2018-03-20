using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Chess
    {
        public string fen { get; private set; }
        Board board;
        Move move;

        public Chess (string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1")
        {
            this.fen = fen;
            this.board = new Board(fen);
            move = new Move(board);
        }

        Chess (Board board)
        {
            this.board = board;
            fen = board.fen;
            move = new Move(board);
        }

        public Chess Move (string move) // Pe2e4
        {
            FigureMoving fm = new FigureMoving(move);
            if (!this.move.CanMove(fm))
                return this;
            Board nextBoard = board.Move(fm);
            Chess nextChess = new Chess(nextBoard);
            return nextChess;
        }

        public char GetFigureAt (int x, int y)
        {
            Square s = new Square(x, y);
            Figure f = board.GetFigureAt(s);

            return f==Figure.none ? '.' : (char)f;
        }
    }
}
