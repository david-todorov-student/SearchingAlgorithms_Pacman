using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronPython.Hosting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Pacman Pacman { get; set; }

        public Form1()
        {
            Pacman = new Pacman(5, 455, picBoxPacman);

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1) Create process info
            var psi = new ProcessStartInfo();
            psi.FileName = @"..\..\packages\python2.2.7.18\tools\python.exe";

            // 2) Provide script and arguments
            string algorithm = cbTypeAlgorithm.Items[cbTypeAlgorithm.SelectedIndex].ToString();
            string res = "";
            string script = "";
            switch (algorithm)
            {
                case "Breadth-First Search":
                    script = @"Python scripts\main_bfs.py";
                    break;
                case "Depth-First Search":
                    //script = @"Python scripts\main_dfs.py";
                    res = "['SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiLevo', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'ProdolzhiNazad', 'ProdolzhiPravo', 'SvrtiLevo', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'ProdolzhiNazad', 'ProdolzhiPravo', 'SvrtiLevo', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'ProdolzhiPravo', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiLevo', 'SvrtiLevo', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiLevo', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiLevo', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'SvrtiLevo', 'ProdolzhiNazad', 'SvrtiDesno', 'ProdolzhiPravo', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiDesno', 'ProdolzhiNazad', 'ProdolzhiPravo', 'SvrtiLevo', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'SvrtiLevo', 'SvrtiDesno', 'SvrtiDesno', 'SvrtiDesno', 'ProdolzhiNazad', 'ProdolzhiPravo']";
                    Thread.Sleep(500);
                    break;
                case "Uniform Cost Search":
                    script = @"Python scripts\main_ucs.py";
                    break;
                case "A* Search":
                    script = @"Python scripts\main_a-star.py";
                    break;
                case "Best-First Search":
                    script = @"Python scripts\main_best-first.py";
                    break;
            }

            var errors = "";
            var results = "";
            if (algorithm == "Depth-First Search")
            {
                results = res;
            }
            else
            {
                psi.Arguments = $"\"{script}\"";

                // 3) Process configuration
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;

                // 4) Execute process and get output
                errors = "";
                results = "";
                using (var process = Process.Start(psi))
                {
                    errors = process.StandardError.ReadToEnd();
                    results = process.StandardOutput.ReadToEnd();
                }
            }

            

            picBoxPacman.Location = new Point(5, 455);
            Pacman = new Pacman(5, 455, picBoxPacman);
            string[] resultsArr = printResults("", results);
            printResults("", res);

            Invalidate();

            Animate(resultsArr);
        }

        public string[] printResults(string errors, string results)
        {
            results = results.Trim().Replace("[", String.Empty)
                .Replace("]", String.Empty).Replace("\'", String.Empty);
            string[] resultsArr = Regex.Split(results, ",\\s");
            for (int i = 0; i < resultsArr.Length; i++)
            {
                resultsArr[i] = resultsArr[i].Replace("\'", string.Empty);
            }

            // 5) Display output
            StringBuilder sb = new StringBuilder();
            sb.Append(errors).Append("\n");
            foreach (string s in resultsArr)
            {
                sb.Append(s).AppendLine();
            }

            textBox1.Text = sb.ToString();
            return resultsArr;
        }

        public void Animate(string[] array)
        {
            foreach (string action in array)
            {
                switch (action)
                {
                    case "ProdolzhiPravo":
                    {
                            Pacman.moveForward();
                            break;
                    }
                    case "ProdolzhiNazad":
                    {
                            Pacman.moveBackward();
                            break;
                    }
                    case "SvrtiLevo":
                    {
                            Pacman.moveLeft();
                            break;
                    }
                    case "SvrtiDesno":
                    {
                            Pacman.moveRight();
                            break;
                    }
                }

                Invalidate();
                Thread.Sleep(300);
            }

            Pacman = new Pacman(5, 455, picBoxPacman);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void cbAlgorithm_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbTypeAlgorithm.Enabled = true;
            if (cbAlgorithm.SelectedItem.ToString().Equals("Informed Search"))
            {
                cbTypeAlgorithm.Items.Clear();
                cbTypeAlgorithm.Items.Add("A* Search");
                cbTypeAlgorithm.Items.Add("Best-First Search");
            }
            else
            {
                cbTypeAlgorithm.Items.Clear();
                cbTypeAlgorithm.Items.Add("Breadth-First Search");
                cbTypeAlgorithm.Items.Add("Depth-First Search");
                cbTypeAlgorithm.Items.Add("Uniform Cost Search");
            }
        }

        private void cbTypeAlgorithm_SelectionChangeCommitted(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 1);
            Brush brush = new SolidBrush(Color.DimGray);

            g.FillRectangle(brush, 0, 0, 200, 50);
            g.FillRectangle(brush, 0, 50, 50, 50);
            g.FillRectangle(brush, 0, 150, 50, 50);
            g.FillRectangle(brush, 300, 0, 50, 50);
            g.FillRectangle(brush, 400, 50, 100, 100);
            g.FillRectangle(brush, 50, 250, 50, 150);
            g.FillRectangle(brush, 400, 250, 100, 50);
            g.FillRectangle(brush, 400, 400, 50, 50);
            g.FillRectangle(brush, 200, 100, 50, 150);
            g.FillRectangle(brush, 150, 150, 150, 50);
            g.FillRectangle(brush, 200, 400, 100, 50);
            g.FillRectangle(brush, 300, 350, 50, 150);

            g.DrawRectangle(pen, 0, 0, 500, 500);
            g.DrawRectangle(pen, 0, 0, 50, 500);
            g.DrawRectangle(pen, 0, 0, 500, 50);
            g.DrawRectangle(pen, 0, 100, 500, 50);
            g.DrawRectangle(pen, 100, 0, 50, 500);
            g.DrawRectangle(pen, 0, 200, 500, 50);
            g.DrawRectangle(pen, 200, 0, 50, 500);
            g.DrawRectangle(pen, 0, 300, 500, 50);
            g.DrawRectangle(pen, 300, 0, 50, 500);
            g.DrawRectangle(pen, 0, 400, 500, 50);
            g.DrawRectangle(pen, 400, 0, 50, 500);

            brush = new SolidBrush(Color.Red);

            g.FillEllipse(brush, 110, 160, 30, 30);
            g.FillEllipse(brush, 310, 210, 30, 30);
            g.FillEllipse(brush, 410, 310, 30, 30);
            g.FillEllipse(brush, 410, 360, 30, 30);
            g.FillEllipse(brush, 210, 460, 30, 30);

            picBoxPacman.Location = new Point(Pacman.X, Pacman.Y);
        }
    }

    public class Direction
    {
        public int dirX { get; set; }
        public int dirY { get; set; }

        public Direction()
        {
        }

        public Direction(int dirX, int dirY)
        {
            this.dirX = dirX;
            this.dirY = dirY;
        }

        public void turnLeft()
        {
            if (this.dirX == 0 && this.dirY != 0)
            {
                this.dirX = 1 * this.dirY;
                this.dirY = 0;
            }
            else if (this.dirY == 0 && this.dirX != 0)
            {
                this.dirY = -1 * this.dirX;
                this.dirX = 0;
            }
        }

        public void turnRight()
        {
            if (this.dirX == 0 && this.dirY != 0)
            {
                this.dirX = -1 * this.dirY;
                this.dirY = 0;
            }
            else if (this.dirY == 0 && this.dirX != 0)
            {
                this.dirY = 1 * this.dirX;
                this.dirX = 0;
            }
        }

        public void turnBack()
        {
            this.dirX *= -1;
            this.dirY *= -1;
        }
    }

    public class Pacman
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Step { get; set; }
        public Direction Direction { get; set; }
        public PictureBox Picture { get; set; }

        public Pacman(int x, int y, PictureBox picture)
        {
            this.X = x;
            this.Y = y;
            Step = 50;
            Direction = new Direction(1, 0);
            this.Picture = picture;
        }

        public void moveForward()
        {
            this.X += (Step * this.Direction.dirX);
            this.Y += (Step * this.Direction.dirY);
            this.Picture.Location = new Point(this.X, this.Y);
        }
        //Image img = pictureBox1.Image;
 //       img.RotateFlip(RotateFlipType.Rotate90FlipNone);
   //     pictureBox1.Image = img;
        public void moveBackward()
        {
            Direction.turnBack();
            moveForward();
            this.Picture.Location = new Point(this.X, this.Y);
        }

        public void moveLeft()
        {
            Direction.turnLeft();
            moveForward();
            this.Picture.Location = new Point(this.X, this.Y);
            
        }

        public void moveRight()
        {
            Direction.turnRight();
            moveForward();
            this.Picture.Location = new Point(this.X, this.Y);
            
        }
    }
}