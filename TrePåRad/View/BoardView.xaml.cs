using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrePåRad.Controller;
using TrePåRad.Model;

namespace TrePåRad.View
{
    /// <summary>
    /// Interaction logic for BoardView.xaml
    /// </summary>
    public partial class BoardView : UserControl
    {
        private readonly CellView[] _cellViews;
        private readonly BoardModel _boardModel;

        public BoardView()
        {
            InitializeComponent();
            _cellViews = MyGrid.Children.OfType<CellView>().ToArray();
            _boardModel = new BoardModel();
            var boardController = new BoardController(_boardModel, Update);
            for (var i = 0; i < _boardModel.Cells.Length; i++)
            {
                var iCopy = i;
                _cellViews[i].CellModel = _boardModel.Cells[i];
                _cellViews[i].Click += (sender, args) => boardController.Mark(true, iCopy);
            }
        }

        public void Update()
        {
            foreach (var cellView in _cellViews)
            {
                cellView.Update();
            }
        }
    }
}
