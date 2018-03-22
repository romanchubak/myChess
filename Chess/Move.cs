using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Move
    {
        FigureMoving fm;
        Board board;


        public Move(Board board)
        {
            this.board = board;
        }

        public bool CanMove(FigureMoving fm)
        {
            this.fm = fm;
            return CanMoveFrom() &&
                   CanMoveTo() &&
                   CanFigureMove();
        }

        private bool CanFigureMove()
        {
            switch (fm.figure)
            {
                case Figure.none:
                    return false;
                case Figure.WhiteKing:
                case Figure.BlackKing:
                    return CanKingMove();
                case Figure.WhiteQueen:
                case Figure.BlackQueen:
                    return CanStraightMove();
                case Figure.WhiteRook:
                case Figure.BlackRook:
                    return (fm.SignX == 0 || fm.SignY == 0) && CanStraightMove();
                case Figure.WhiteBishop:
                case Figure.BlackBishop:
                    return (fm.SignX != 0 && fm.SignY != 0) && CanStraightMove();
                case Figure.WhiteKnight:
                case Figure.BlackKnight:
                    return CanKningtMove();
                case Figure.WhitePawn:
                case Figure.BlackPawn:
                    return CanPawnMove();

                default:
                    return false;

            }
        }

        private bool CanPawnMove()
        {
            if (fm.from.y < 1 || fm.from.y > 6)
                return false;
            int stepY = fm.figure.GetColor() == Color.white ? 1 : -1;
            return CanPawnGo(stepY) || CanPawnJump(stepY) || CanPawnEat(stepY);
        }

        private bool CanPawnEat(int stepY)
        {
            if (board.Anotation.Count > 0)
            {
                FigureMoving lastmove = new FigureMoving(board.Anotation[board.Anotation.Count - 1]);
                if (board.GetFigureAt(lastmove.to) == (board.moveColor == Color.black ? Figure.WhitePawn : Figure.BlackPawn))
                    if (lastmove.AbsDeltaY == 2)
                        if(lastmove.to.x - fm.from.x == fm.SignX && fm.AbsDeltaX == 1)
                            if(fm.to.y - lastmove.to.y == stepY && fm.AbsDeltaY == 1)
                            {
                                board.needToClear = lastmove.to;
                                return true;
                            }
                        
            }
            if (board.GetFigureAt(fm.to) != Figure.none)
                if (fm.AbsDeltaX == 1)
                    if (fm.AbsDeltaY == 1 && fm.SignY == stepY)
                        return true;
            return false;
        }

        private bool CanPawnJump(int stepY)
        {

            if (board.GetFigureAt(fm.to) == Figure.none)
                if (fm.DeltaX == 0)
                    if (fm.DeltaY == 2 * stepY)
                        if (fm.from.y == 1 || fm.from.y == 6)
                            if (board.GetFigureAt(new Square(fm.from.x, fm.from.y + stepY)) == Figure.none)
                                return true;
            return false;
        }

        private bool CanPawnGo(int stepY)
        {
            if (board.GetFigureAt(fm.to) == Figure.none)
                if (fm.DeltaX == 0)
                    if (fm.DeltaY == stepY)
                        return true;
            return false;
        }

        private bool CanStraightMove()
        {
            Square at = fm.from;
            do
            {
                at = new Square(at.x + fm.SignX, at.y + fm.SignY);
                if (at == fm.to)
                    return true;
            } while (at.OnBoard() && board.GetFigureAt(at) == Figure.none);
            return false;
        }

        private bool CanKningtMove()
        {
            if (fm.AbsDeltaX == 1 && fm.AbsDeltaY == 2) return true;
            if (fm.AbsDeltaX == 2 && fm.AbsDeltaY == 1) return true;
            return false;
        }

        private bool CanKingMove()
        {
            if (fm.AbsDeltaX <= 1 && fm.AbsDeltaY <= 1)
                return true;
            return false;
        }

        private bool CanMoveTo()
        {
            return fm.to.OnBoard() && fm.from != fm.to &&
                   board.GetFigureAt(fm.to).GetColor() != board.moveColor;
        }

        private bool CanMoveFrom()
        {
            return fm.from.OnBoard() &&
                   fm.figure.GetColor() == board.moveColor;
        }
    }
}
