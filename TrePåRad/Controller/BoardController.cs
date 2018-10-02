using System;
using System.Linq;
using System.Threading;
using TrePåRad.Model;

namespace TrePåRad.Controller
{
    public class BoardController
    {
        private readonly Random _random = new Random();
        private readonly BoardModel _boardModel;
        private readonly UpdateMethod _updateMethod;

        public delegate void UpdateMethod();

        public BoardController(BoardModel boardModel, UpdateMethod updateMethod)
        {
            _updateMethod = updateMethod;
            _boardModel = boardModel;
        }

        public  void Mark(bool isPlayer1, int index)
        {
            _boardModel.Cells[index].Mark(isPlayer1);
            _updateMethod();
            Thread.Sleep(500);
            MarkRandomPlayer2();
        }

        private  void MarkRandomPlayer2()
        {
            var emptyCells = _boardModel.Cells.Where(c=>c.IsEmpty()).ToArray();
            if (emptyCells.Length == 0) return;
            var index = _random.Next(0, emptyCells.Length);
            emptyCells[index].Mark(false);
            _updateMethod();
        }
    }
}
