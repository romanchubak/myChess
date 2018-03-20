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
            return true;
        }

        private bool CanMoveTo()
        {
            return fm.to.OnBoard() &&
                   board.GetFigureAt(fm.to).GetColor() != board.moveColor;
        }

        private bool CanMoveFrom()
        {
            return fm.from.OnBoard() &&
                   fm.figure.GetColor() == board.moveColor;
        }
    }
}
