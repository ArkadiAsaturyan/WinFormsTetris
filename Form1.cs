using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WinFormsTetris
{
    public partial class Form1 : Form
    {
        int timerSpeed = 150;
        int rowIndex = 12;
        int methodMarker = 0;
        int points = 0;

        public Form1()
        {
            InitializeComponent();
            KeyDown += Form1_KeyDown;

            Logic();

        }

        void Logic()
        {
            Random random = new Random();
            int methodID = random.Next(0, 2);

            if (methodID == 0) ShapeSquare();
            else if (methodID == 1) ShapeLine();

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
        Control control1;

        Control cntrl1;
        Control cntrl2;

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (methodMarker == 1)
            {
                cntrl1 = tableLayoutPanel1.GetControlFromPosition(x, y + 2);
                cntrl2 = tableLayoutPanel1.GetControlFromPosition(x + 1, y + 2);

                if (x != 0)
                {
                    c1 = tableLayoutPanel1.GetControlFromPosition(x - 1, y);
                    c2 = tableLayoutPanel1.GetControlFromPosition(x - 1, y + 1);


                }
                c3 = tableLayoutPanel1.GetControlFromPosition(x + 2, y);
                c4 = tableLayoutPanel1.GetControlFromPosition(x + 2, y + 1);

                switch (e.KeyCode)
                {
                    case Keys.A:
                        if (cntrl1 == null && cntrl2 == null && c1 == null && c2 == null && x != 0 && y != 16)
                        {
                            tableLayoutPanel1.Controls.Add(btn1, x - 1, y);
                            tableLayoutPanel1.Controls.Add(btn2, x, y);
                            tableLayoutPanel1.Controls.Add(btn3, x - 1, y + 1);
                            tableLayoutPanel1.Controls.Add(btn4, x, y + 1);
                            x--;
                        }

                        break;

                    case Keys.D:

                        if (cntrl1 == null && cntrl2 == null && c3 == null && c4 == null && x != 8 && y != 16)
                        {
                            tableLayoutPanel1.Controls.Add(btn1, x + 1, y);
                            tableLayoutPanel1.Controls.Add(btn2, x + 2, y);
                            tableLayoutPanel1.Controls.Add(btn3, x + 1, y + 1);
                            tableLayoutPanel1.Controls.Add(btn4, x + 2, y + 1);
                            x++;
                        }
                        break;

                    case Keys.S:
                        timerSpeed = 50;
                        break;

                }
            }

            else if (methodMarker == 2)
            {
                control1 = tableLayoutPanel1.GetControlFromPosition(x, y + 4);

                if (x != 0)
                {
                    c1 = tableLayoutPanel1.GetControlFromPosition(x - 1, y);
                    c2 = tableLayoutPanel1.GetControlFromPosition(x - 1, y + 1);
                    c3 = tableLayoutPanel1.GetControlFromPosition(x - 1, y + 2);
                    c4 = tableLayoutPanel1.GetControlFromPosition(x - 1, y + 3);

                }

                c5 = tableLayoutPanel1.GetControlFromPosition(x + 1, y);
                c6 = tableLayoutPanel1.GetControlFromPosition(x + 1, y + 1);
                c7 = tableLayoutPanel1.GetControlFromPosition(x + 1, y + 2);
                c8 = tableLayoutPanel1.GetControlFromPosition(x + 1, y + 3);

                switch (e.KeyCode)
                {
                    case Keys.A:
                        if (control1 == null && c1 == null && c2 == null && c3 == null && c4 == null && x != 0 && y != 14)
                        {
                            tableLayoutPanel1.Controls.Add(btn1, x - 1, y);
                            tableLayoutPanel1.Controls.Add(btn2, x - 1, y + 1);
                            tableLayoutPanel1.Controls.Add(btn3, x - 1, y + 2);
                            tableLayoutPanel1.Controls.Add(btn4, x - 1, y + 3);
                            x--;
                        }

                        break;

                    case Keys.D:

                        if (control1 == null && c5 == null && c6 == null && c7 == null && c8 == null && x != 9 && y != 14)
                        {
                            tableLayoutPanel1.Controls.Add(btn1, x + 1, y);
                            tableLayoutPanel1.Controls.Add(btn2, x + 1, y + 1);
                            tableLayoutPanel1.Controls.Add(btn3, x + 1, y + 2);
                            tableLayoutPanel1.Controls.Add(btn4, x + 1, y + 3);
                            x++;
                        }
                        break;

                    case Keys.S:
                        timerSpeed = 50;
                        break;

                }

            }

        }

        Control c1;
        Control c2;
        Control c3;
        Control c4;
        Control c5;
        Control c6;
        Control c7;
        Control c8;

        Button btn1;
        Button btn2;
        Button btn3;
        Button btn4;

        int x, y;




        public async void ShapeSquare()
        {
            methodMarker = 1;

            Random random = new Random();
            x = random.Next(0, 9);
            y = 0;
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn4 = new Button();

            btn1.BackColor = Color.Black;
            btn2.BackColor = Color.Black;
            btn3.BackColor = Color.Black;
            btn4.BackColor = Color.Black;

            btn1.FlatStyle = FlatStyle.Popup;
            btn2.FlatStyle = FlatStyle.Popup;
            btn3.FlatStyle = FlatStyle.Popup;
            btn4.FlatStyle = FlatStyle.Popup;






            cntrl1 = tableLayoutPanel1.GetControlFromPosition(x, y + 2);
            cntrl2 = tableLayoutPanel1.GetControlFromPosition(x + 1, y + 2);

            while (cntrl1 == null && cntrl2 == null && y + 1 < 17)
            {



                tableLayoutPanel1.Controls.Add(btn1, x, y);
                tableLayoutPanel1.Controls.Add(btn2, x + 1, y);
                tableLayoutPanel1.Controls.Add(btn3, x, y + 1);
                tableLayoutPanel1.Controls.Add(btn4, x + 1, y + 1);

                tableLayoutPanel1.SetCellPosition(btn1, new TableLayoutPanelCellPosition(x, y + 1));
                tableLayoutPanel1.SetCellPosition(btn2, new TableLayoutPanelCellPosition(x + 1, y + 1));
                tableLayoutPanel1.SetCellPosition(btn3, new TableLayoutPanelCellPosition(x, y + 2));
                tableLayoutPanel1.SetCellPosition(btn4, new TableLayoutPanelCellPosition(x + 1, y + 2));


                y++;
                cntrl1 = tableLayoutPanel1.GetControlFromPosition(x, y + 2);
                cntrl2 = tableLayoutPanel1.GetControlFromPosition(x + 1, y + 2);
                await Task.Delay(timerSpeed);
                //  timerSpeed = 300;


            }

            // написать после while цикл for, покрутить все x или y и проверить, если какая нибудь строка полностью заполнена

            bool isFull = true;
            Control forControl;
            for (int i = 0; i <= 17; i++) // y 
            {
                for (int j = 0; j <= 9; j++) // x
                {
                    forControl = tableLayoutPanel1.GetControlFromPosition(j, i);
                    if (forControl == null)
                    {
                        isFull = false;

                    }



                }

                if (isFull)
                {

                    button1.BackColor = Color.Red;

                    label1.Text = points++.ToString();

                    tableLayoutPanel1.RemoveRow(i);

                }


                isFull = true;
            }


            Random rnd = new Random();
            int methodID = rnd.Next(0, 2);

            if (methodID == 0) ShapeSquare();
            else if (methodID == 1) ShapeLine();


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public async void ShapeLine()
        {
            methodMarker = 2;

            Random random = new Random();
            x = random.Next(0, 9);
            y = 0;
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btn4 = new Button();

            btn1.BackColor = Color.Black;
            btn2.BackColor = Color.Black;
            btn3.BackColor = Color.Black;
            btn4.BackColor = Color.Black;

            btn1.FlatStyle = FlatStyle.Popup;
            btn2.FlatStyle = FlatStyle.Popup;
            btn3.FlatStyle = FlatStyle.Popup;
            btn4.FlatStyle = FlatStyle.Popup;



            control1 = tableLayoutPanel1.GetControlFromPosition(x, y + 4);

            while (control1 == null && y + 3 < 17)
            {
                await Task.Delay(timerSpeed);

                tableLayoutPanel1.Controls.Add(btn1, x, y);
                tableLayoutPanel1.Controls.Add(btn2, x, y + 1);
                tableLayoutPanel1.Controls.Add(btn3, x, y + 2);
                tableLayoutPanel1.Controls.Add(btn4, x, y + 3);

                tableLayoutPanel1.SetCellPosition(btn1, new TableLayoutPanelCellPosition(x, y + 1));
                tableLayoutPanel1.SetCellPosition(btn2, new TableLayoutPanelCellPosition(x, y + 2));
                tableLayoutPanel1.SetCellPosition(btn3, new TableLayoutPanelCellPosition(x, y + 3));
                tableLayoutPanel1.SetCellPosition(btn4, new TableLayoutPanelCellPosition(x, y + 4));

                y++;
                control1 = tableLayoutPanel1.GetControlFromPosition(x, y + 4);

                //  timerSpeed = 300;

            }

            bool isFull = true;
            Control forControl;
            for (int i = 0; i <= 17; i++) // y
            {
                for (int j = 0; j <= 9; j++) // x
                {
                    forControl = tableLayoutPanel1.GetControlFromPosition(j, i);
                    if (forControl == null)
                    {
                        isFull = false;

                    }

                }

                if (isFull)
                {
                    button1.BackColor = Color.Red;
                    label1.Text = points++.ToString();


                    tableLayoutPanel1.RemoveRow(i);
                }

                isFull = true;
            }



            Random rnd = new Random();
            int methodID = rnd.Next(0, 2);

            if (methodID == 0) ShapeSquare();
            else if (methodID == 1) ShapeLine();

        }
    }
}
