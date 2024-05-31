using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChessboardCovering
{
    public partial class MainForm : Form
    {
        private int size;
        private int[,] board;
        private int tile = 0;
        private Point specialPoint = new Point(0, 0);
        private Random random = new Random();

        public MainForm()
        {
            InitializeComponent();
            InitializeBoard();
            this.Resize += MainForm_Resize;
        }

        private void InitializeBoard()
        {
            size = (int)Math.Pow(2, (int)numericUpDownSize.Value);
            board = new int[size, size];
            if (specialPoint.X >= size || specialPoint.Y >= size)
            {
                specialPoint = new Point(0, 0);
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = -1; // Initialize all squares to -1
                }
            }
            board[specialPoint.X, specialPoint.Y] = 0; // Mark the special square with 0
            tile = 0;
            this.panelBoard.Invalidate();
        }

        private void CoverBoard(int startX, int startY, int missingX, int missingY, int size)
        {
            if (size == 1)
                return;

            int t = ++tile;
            int s = size / 2;

            // Cover the top-left sub-board
            if (missingX < startX + s && missingY < startY + s)
            {
                CoverBoard(startX, startY, missingX, missingY, s);
            }
            else
            {
                board[startX + s - 1, startY + s - 1] = t;
                CoverBoard(startX, startY, startX + s - 1, startY + s - 1, s);
            }

            // Cover the top-right sub-board
            if (missingX < startX + s && missingY >= startY + s)
            {
                CoverBoard(startX, startY + s, missingX, missingY, s);
            }
            else
            {
                board[startX + s - 1, startY + s] = t;
                CoverBoard(startX, startY + s, startX + s - 1, startY + s, s);
            }

            // Cover the bottom-left sub-board
            if (missingX >= startX + s && missingY < startY + s)
            {
                CoverBoard(startX + s, startY, missingX, missingY, s);
            }
            else
            {
                board[startX + s, startY + s - 1] = t;
                CoverBoard(startX + s, startY, startX + s, startY + s - 1, s);
            }

            // Cover the bottom-right sub-board
            if (missingX >= startX + s && missingY >= startY + s)
            {
                CoverBoard(startX + s, startY + s, missingX, missingY, s);
            }
            else
            {
                board[startX + s, startY + s] = t;
                CoverBoard(startX + s, startY + s, startX + s, startY + s, s);
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            // Do nothing here, painting is handled in panelBoard_Paint
        }

        private void DrawBoard(Graphics g, int width, int height)
        {
            int cellSize = Math.Min(width, height) / size;
            Font largeFont = new Font(this.Font.FontFamily, cellSize / 2);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Rectangle rect = new Rectangle(i * cellSize, j * cellSize, cellSize, cellSize);
                    if (board[i, j] == 0)
                    {
                        g.FillRectangle(Brushes.Black, rect);
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        g.DrawString("0", largeFont, Brushes.White, rect, sf);
                    }
                    else if (board[i, j] > 0)
                    {
                        Color color = Color.FromArgb((board[i, j] * 40) % 256, (board[i, j] * 80) % 256, (board[i, j] * 160) % 256);
                        g.FillRectangle(new SolidBrush(color), rect);
                        StringFormat sf = new StringFormat();
                        sf.Alignment = StringAlignment.Center;
                        sf.LineAlignment = StringAlignment.Center;
                        g.DrawString(board[i, j].ToString(), largeFont, Brushes.White, rect, sf);
                    }
                    g.DrawRectangle(Pens.Black, rect);
                }
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            panelBoard.Invalidate();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            InitializeBoard();
            CoverBoard(0, 0, specialPoint.X, specialPoint.Y, size);
            panelBoard.Invalidate();
        }

        private void numericUpDownSize_ValueChanged(object sender, EventArgs e)
        {
            InitializeBoard();
        }

        private void buttonRandomSpecial_Click(object sender, EventArgs e)
        {
            specialPoint = new Point(random.Next(size), random.Next(size));
            InitializeBoard();
        }

        private void buttonSetSpecial_Click(object sender, EventArgs e)
        {
            try
            {
                int x = int.Parse(textBoxSpecialX.Text);
                int y = int.Parse(textBoxSpecialY.Text);
                if (x >= 0 && x < size && y >= 0 && y < size)
                {
                    specialPoint = new Point(x, y);
                    InitializeBoard();
                }
                else
                {
                    MessageBox.Show("Special point must be within the board.");
                }
            }
            catch
            {
                MessageBox.Show("Invalid input. Please enter valid integers.");
            }
        }

        private void panelBoard_Paint(object sender, PaintEventArgs e)
        {
            DrawBoard(e.Graphics, panelBoard.ClientSize.Width, panelBoard.ClientSize.Height);
        }
    }
}