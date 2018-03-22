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
        public List<string> Anotation { get; private set; }
        Board board;
        Move move;
        List<FigureMoving> allMoves;


        public Chess(string fen = "rnbqkbnr/11p11111/11111111/1P111111/8/8/11111111/RNBQKBNR b KQkq - 0 1")//"rnbqkbnr/1p1111p1/8/8/8/8/1P1111P1/RNBQKBNR w KQkq - 0 1")
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
            if (!this.move.CanMove(fm)) return this;
            if (board.isCheckAfterMove(fm)) return this;
            Board nextBoard = board.Move(fm,true);
            Chess nextChess = new Chess(nextBoard);
            return nextChess;
        }

        public char GetFigureAt (int x, int y)
        {
            Square s = new Square(x, y);
            Figure f = board.GetFigureAt(s);

            return f==Figure.none ? '.' : (char)f;
        }

        void FindAllMoves()
        {
            allMoves = new List<FigureMoving>();
            foreach (var fs in board.YieldFigures())
            {
                foreach (var to in Square.YieldSquares())
                {
                    FigureMoving fm = new FigureMoving(fs, to);
                    if (move.CanMove(fm) && !board.isCheckAfterMove(fm))
                        allMoves.Add(fm);
                }
            }
        }

        public List<string> getAllMoves ()
        {
            FindAllMoves();
            List<string> list = new List<string>();
            foreach (var fm in allMoves)
            {
                list.Add(fm.ToString());
            }
            return list;
        }
    }
}
