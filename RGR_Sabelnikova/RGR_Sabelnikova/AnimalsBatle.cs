using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGR_Sabelnikova
{
    public partial class AnimalsBatle : Form
    {
        //розмір карти і розмір клітинки
        const int mapSize = 20;
        const int cellSize = 30;
        //майбутні і теперішні поколінння
        //клітинка-кнопка
        Button[,] cells = new Button[mapSize, mapSize];
        Random random = new Random();

        bool isPlaying = false;
        //створений таймер для затримки
        Timer mainTimer;

        int offset = 25;
        public AnimalsBatle()
        {
            InitializeComponent();
            SetFormSize();
            BuildMenu();
            Init();
        }

        //ініціалізація гри
        public void Init()
        {
            isPlaying = false;
            mainTimer = new Timer();
            mainTimer.Interval = 100;
            mainTimer.Tick += new EventHandler(UpdateStates);
            InitCells();
        }

        //оновлення гри
        private void UpdateStates(object sender, EventArgs e)
        {
            CalculateNextState();
            if (CheckGenerationDead())
            {
                mainTimer.Stop();
                MessageBox.Show("Поколение себя изжило :(");
            }
        }
        //закоментировать!!!
        bool CheckGenerationDead()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (cells[i,j].Text == "R" || cells[i, j].Text == "V")
                        return false;
                }
            }
            return true;
        }
        void SetFormSize()
        {
            this.Width = (mapSize + 1) * cellSize;
            this.Height = (mapSize + 1) * cellSize + 40;
        }
        void ClearGame()
        {
            isPlaying = false;
            mainTimer = new Timer();
            mainTimer.Interval = 100;
            mainTimer.Tick += new EventHandler(UpdateStates);
            ResetCells();
        }

        void ResetCells()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    cells[i, j].BackColor = Color.White;
                }
            }
        }

        void BuildMenu()
        {
            var menu = new MenuStrip();

            var restart = new ToolStripMenuItem("Начать заного");
            restart.Click += new EventHandler(Restart);

            var play = new ToolStripMenuItem("Начать симуляцию");
            play.Click += new EventHandler(Play);

            menu.Items.Add(play);
            menu.Items.Add(restart);

            this.Controls.Add(menu);
        }

        private void Restart(object sender, EventArgs e)
        {
            mainTimer.Stop();
            ClearGame();
        }

        private void Play(object sender, EventArgs e)
        {
            if (!isPlaying)
            {
                isPlaying = true;
                mainTimer.Start();
            }
        }

        //відображення клітинок(чорна або біла)


        //створення нового покоління. тут накладається умова 
        void CalculateNextState()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    /*var countNeighboors = CountNeighboors(i, j);
                    if (currentState[i, j] == 0 && countNeighboors == 3)
                    {
                        nextState[i, j] = 1;
                    }
                    else if (currentState[i, j] == 1 && (countNeighboors < 2 && countNeighboors > 3))
                    {
                        nextState[i, j] = 0;
                    }
                    else if (currentState[i, j] == 1 && (countNeighboors >= 2 && countNeighboors <= 3))
                    {
                        nextState[i, j] = 1;
                    }
                    else
                    {
                        nextState[i, j] = 0;
                    }*/
                    int tempI = i;
                    int tempJ = j;
                    try
                    {
                        if (cells[i, j].Text == "V")
                        {
                            tempI = i;
                            tempJ = j;
                            int direction = random.Next(8);
                            cells[i, j].Text = "";
                            if (direction == 0)
                            {
                                if (i - 1 > 0 && i - 1 < 20 && j - 1 > 0 && j - 1 < 20 && cells[i--, j--].Text != "V")
                                {
                                    i--; j--;
                                    cells[i, j].Text = "V"; break;
                                }
                                else
                                {
                                    cells[i, j].Text = "V"; break;
                                }
                            }
                            if (direction == 1)
                            {
                                if (j - 1 > 0 && j - 1 < 20 && cells[i, j--].Text != "V")
                                {
                                    j--;
                                    cells[i, j].Text = "V"; break;
                                }
                                else
                                {
                                    cells[i, j].Text = "V"; break;
                                }
                            }
                            if (direction == 2)
                            {
                                if (i + 1 > 0 && i + 1 < 20 && j - 1 > 0 && j - 1 < 20 && cells[i++, j--].Text != "V")
                                {
                                    i++; j--;
                                    cells[i, j].Text = "V"; break;
                                }
                                else
                                {
                                    cells[i, j].Text = "V"; break;
                                }
                            }
                            if (direction == 3)
                            {
                                if (i - 1 > 0 && i - 1 < 20 && cells[i--, j].Text != "V")
                                {
                                    i--;
                                    cells[i, j].Text = "V"; break;
                                }
                                else
                                {
                                    cells[i, j].Text = "V"; break;
                                }
                            }
                            if (direction == 4)
                            {
                                if (i + 1 > 0 && i + 1 < 20 && cells[i++, j].Text != "V")
                                {
                                    i++;
                                    cells[i, j].Text = "V"; break;
                                }
                                else
                                {
                                    cells[i, j].Text = "V";
                                    break;
                                }

                            }
                            if (direction == 5)
                            {
                                if (i - 1 > 0 && i - 1 < 20 && j + 1 > 0 && j + 1 < 20 && cells[i--, j++].Text != "V")
                                {
                                    i--; j++;
                                    cells[i, j].Text = "V"; break;
                                }
                                else
                                {
                                    cells[i, j].Text = "V";
                                    break;
                                }
                            }
                            if (direction == 6)
                            {
                                if (j + 1 > 0 && j + 1 < 20 && cells[i, j++].Text != "V")
                                {
                                    j++;
                                    cells[i, j].Text = "V"; break;
                                }
                                else
                                {
                                    cells[i, j].Text = "V";
                                    break;
                                }
                            }
                            if (direction == 7)
                            {
                                if (i + 1 > 0 && i + 1 < 20 && j + 1 > 0 && j + 1 < 20 && cells[i++, j++].Text != "V")
                                {
                                    i++; j++;
                                    cells[i, j].Text = "V"; break;
                                }
                                else
                                {
                                    cells[i, j].Text = "V";
                                    break;
                                }
                            }

                        }

                        if (cells[i, j].Text == "R")
                        {
                            tempI = i;
                            tempJ = j;
                            if (random.NextDouble() <= 0.2)  // з ймовірністю 0.2
                            {
                                cells[i, j].Text = "R";
                            }
                            else
                            {
                                cells[i, j].Text = "R";
                            }
                            int direction = random.Next(9);
                            // змінюємо координати кролика в залежності від напрямку руху
                            if(direction == 0)
                            {
                                if (i - 1 > 0 && i - 1 < 20 && j - 1> 0 && j - 1 < 20 && cells[i--, j--].Text != "R") 
                                {
                                    i--; j--;
                                    cells[i, j].Text = "R"; break;
                                }
                                else
                                {
                                    cells[i, j].Text = "R"; break;
                                }
                            }
                            if (direction == 1)
                            {
                                if (j - 1 > 0 && j - 1 < 20 && cells[i, j--].Text != "R")
                                {
                                    j--;
                                    cells[i, j].Text = "R"; break;
                                }
                                else
                                {
                                    cells[i, j].Text = "R"; break;
                                }
                            }
                            if (direction == 2)
                            {
                                if (i + 1 > 0 && i + 1 < 20 && j - 1 > 0 && j - 1 < 20 && cells[i++, j--].Text != "R")
                                {
                                    i++; j--;
                                    cells[i, j].Text = "R"; break;
                                }
                                else
                                {
                                    cells[i, j].Text = "R"; break;
                                }
                            }
                            if (direction == 3)
                            {
                                if (i - 1 > 0 && i - 1 < 20 && cells[i--, j].Text != "R")
                                {
                                    i--;
                                    cells[i, j].Text = "R"; break;
                                }
                                else
                                {
                                    cells[i, j].Text = "R"; break;
                                }
                            }
                            if (direction == 4)
                            {
                                if (i  > 0 && i < 20 && j  > 0 && j  < 20)
                                {
                                    cells[i, j].Text = "R"; break;
                                }
                            }
                            if (direction == 5)
                            {
                                if (i + 1 > 0 && i + 1 < 20 && cells[i++, j].Text != "R")
                                {
                                    i++;
                                    cells[i, j].Text = "R"; break;
                                }
                                else
                                {
                                    cells[i, j].Text = "R"; break;
                                }
                            }
                            if (direction == 6)
                            {
                                if (i - 1 > 0 && i - 1 < 20 && j + 1 > 0 && j + 1 < 20 && cells[i--, j++].Text != "R")
                                {
                                    i--; j++;
                                    cells[i, j].Text = "R"; break;
                                }
                                else
                                {
                                    cells[i, j].Text = "R"; break;
                                }
                            }
                            if (direction == 7)
                            {
                                if ( j + 1 > 0 && j + 1 < 20 && cells[i, j++].Text != "R")
                                {
                                    j++;
                                    cells[i, j].Text = "R"; break;
                                }
                                else
                                {
                                    cells[i, j].Text = "R"; break;
                                }
                            }
                            if (direction == 8)
                            {
                                if (i + 1 > 0 && i + 1 < 20 && j + 1 > 0 && j + 1 < 20 && cells[i++, j++].Text != "R")
                                {
                                    i++; j++;
                                    cells[i, j].Text = "R"; break;
                                }
                                else
                                {
                                    cells[i, j].Text = "R"; break;
                                }
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Could not list files in the given directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        //підрахунок сусідів
        int CountNeighboors(int i, int j)
        {
            var count = 0;
            for (int k = i - 1; k <= i + 1; k++)
            {
                for (int l = j - 1; l <= j + 1; l++)
                {
                    if (!IsInsideMap(k, l))
                        continue;
                    if (k == i && l == j)
                        continue;
                    if (cells[k, l].Text == "R")
                        count++;
                }
            }
            return count;
        }

        bool IsInsideMap(int i, int j)
        {
            if (i < 0 || i >= mapSize || j < 0 || j >= mapSize)
            {
                return false;
            }
            return true;
        }

        //заповнення масивів
        int[,] InitMap()
        {
            int[,] arr = new int[mapSize, mapSize];
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    arr[i, j] = 0;
                }
            }
            return arr;
        }

        //створюю кнопки-комірки
        void InitCells()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    Button button = new Button();
                    button.Size = new Size(cellSize, cellSize);
                    button.BackColor = Color.White;
                    button.Text = "";
                    button.Location = new Point(j * cellSize, (i * cellSize) + offset);
                    button.KeyPress += new KeyPressEventHandler(TwoCellClick);
                    button.KeyPress += new KeyPressEventHandler(RebbitCellClick);
                    this.Controls.Add(button);
                    cells[i, j] = button;
                }
            }
        }

        private void RebbitCellClick(object sender, KeyPressEventArgs e)
        {
            var pressedButton = sender as Button;
            if (!isPlaying && e.KeyChar == 'r' || e.KeyChar == 'R')
            {
                var i = (pressedButton.Location.Y - offset) / cellSize;
                var j = pressedButton.Location.X / cellSize;

                if (cells[i, j].Text == "")
                {
                    cells[i, j].Text = "R";
                }
                else
                {
                    cells[i, j].Text = "";
                }
            }
        }

        private void TwoCellClick(object sender, KeyPressEventArgs e)
        {
            var pressedButton = sender as Button;
            if (!isPlaying && e.KeyChar == 'v' || e.KeyChar == 'V')
            {
                var i = (pressedButton.Location.Y - offset) / cellSize;
                var j = pressedButton.Location.X / cellSize;

                if (cells[i, j].Text == "")
                {
                    cells[i, j].Text = "V";
                }
                else
                {
                    cells[i, j].Text = "";
                }
            }
        }
    }
}