using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTetris
{
    internal class ShapeMaker
    {
        TableLayoutPanel tableLayoutPanel;
        Timer timer;
        public void MakeSquare()
        {
            timer = new Timer();
            timer.Interval = 1000;
           // timer.Tick += new EventHandler(MakeSquare);

            int y = 1;
            tableLayoutPanel = new TableLayoutPanel();
            Button btn1 = new Button();
            btn1.BackColor = Color.Black;
            btn1.FlatStyle = FlatStyle.Popup;

            tableLayoutPanel.Controls.Add(btn1, 7, y);

            tableLayoutPanel.SetCellPosition(btn1, new TableLayoutPanelCellPosition(8, ++y ));

        }

        public void MoveSquare()
        {


        }
    }
}
