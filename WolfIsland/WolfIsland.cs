using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace WolfIsland
{
    public partial class WolfIsland : Form
    {
        private const int FieldSize = 20;
        private Button[,] buttons;
        private Timer timer;
        private int counter;
        private bool simulationStarted;
        private List<Rabbit> rabbits;
        private List<SheWolf> shewolves;
        private List<Wolf> wolves;
        public WolfIsland()
        {
            InitializeComponent();
            InitializeField();
            InitializeTimer();
            rabbits = new List<Rabbit>();
            shewolves = new List<SheWolf>();
            wolves = new List<Wolf>();
        }
        private void InitializeField()
        {
            buttons = new Button[FieldSize, FieldSize];
            const int buttonSize = 25;
            const int spacing = 1;

            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    buttons[i, j] = new Button
                    {
                        Width = buttonSize,
                        Height = buttonSize,
                        Location = new System.Drawing.Point(i * (buttonSize + spacing), j * (buttonSize + spacing))
                    };

                    buttons[i, j].KeyPress += Button_Click; // Додати обробник події для створення кролика
                    Controls.Add(buttons[i, j]);
                }
            }
        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 100; // 0.1 seconds
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            counter++;
            MoveRabbits();
            MoveSheWolves();
            MoveWolves();
        }

        private void MoveRabbits()
        {
            List<Rabbit> newRabbits = new List<Rabbit>();

            foreach (Rabbit rabbit in rabbits)
            {
                int currentX = rabbit.X;
                int currentY = rabbit.Y;

                // Вибір нових координат для кролика
                int newX = GetRandomNeighborCoordinate(currentX);
                int newY = GetRandomNeighborCoordinate(currentY);

                if (newX != currentX || newY != currentY) // Кролик переміщується
                {
                    rabbit.Move(newX, newY);
                    buttons[currentX, currentY].BackColor = System.Drawing.Color.White;
                    buttons[newX, newY].BackColor = System.Drawing.Color.DarkMagenta;
                    // Якщо на наступній клітинці немає іншого кролика, створюємо нового кролика з ймовірністю 0.2
                    if (!HasRabbit(currentX, currentY) && !HasSheWolf(currentX, currentY) && ShouldCreateNewRabbit())
                    {
                        Rabbit newRabbit = new Rabbit(currentX, currentY);
                        newRabbits.Add(newRabbit);
                        buttons[currentX, currentY].BackColor = System.Drawing.Color.DarkMagenta;
                    }
                }
            }

            rabbits.AddRange(newRabbits);
        }
        private void MoveWolves()
        {
            List<Wolf> newWolves = new List<Wolf>();

            // Створення копії колекції wolves
            List<Wolf> wolvesCopy = wolves.ToList();

            foreach (Wolf wolf in wolvesCopy)
            {
                int currentX = wolf.X;
                int currentY = wolf.Y;
                int newSaturation = wolf.Saturation;

                // Вибір нових координат для вовчиці
                int newX = GetRandomNeighborCoordinate(currentX);
                int newY = GetRandomNeighborCoordinate(currentY);
                int eat = 10;
                newSaturation = wolf.ReduceSaturation(newSaturation);
                if (wolf.IsHungry(newSaturation))
                {
                    WolfDead(newX, newY);
                }

                if (newX != currentX || newY != currentY) // Вовчиця переміщується
                {
                    wolf.Move(newX, newY);
                    buttons[currentX, currentY].BackColor = System.Drawing.Color.White;
                    buttons[newX, newY].BackColor = System.Drawing.Color.DarkBlue;

                    // Перевірка, чи на наступній клітинці є кролик
                    if (HasRabbit(newX, newY))
                    {
                        EatRabbit(newX, newY); // Вовчиця "з'їдає" кролика
                        wolf.Saturation = wolf.Eat(); // Збільшення ситості вовчиці
                    }
                    else if (HasSheWolf(newX, newY))
                    {
                        if (newSaturation >= 6)
                        {
                            if (ShouldCreateNewWolf())
                            {
                                Wolf newWolf = new Wolf(newX, newY, eat);
                                newWolves.Add(newWolf);
                                buttons[newX, newY].BackColor = System.Drawing.Color.DarkBlue;
                            }
                            else
                            {
                                SheWolf newSheWolf = new SheWolf(newX, newY, eat);
                                shewolves.Add(newSheWolf);
                                buttons[newX, newY].BackColor = System.Drawing.Color.Brown;
                            }
                            wolf.Saturation = wolf.Sex();
                        }
                    }
                    else if (!HasRabbit(newX, newY) && !HasWolf(newX, newY)) // Якщо на наступній клітинці немає кролика або вовчиці
                    {
                        /*if (wolf.IsHungry(newSaturation)) // Перевірка, чи вовчиця голодна
                        {
                            WolfDead(newX, newY);
                            // buttons[newX, newY].BackColor = System.Drawing.Color.DarkGray;
                        }
                        else // Вовчиця помирає, якщо голодна
                        {
                            // SheWolfDead(newX, newY);*/
                        buttons[newX, newY].BackColor = System.Drawing.Color.DarkBlue;
                        //}
                    }
                }
            }
            wolves.AddRange(newWolves);
        }
        private bool HasWolf(int x, int y)
        {
            foreach (Wolf wolf in wolves)
            {
                if (wolf.X == x && wolf.Y == y)
                    return true;
            }

            return false;
        }
        private bool ShouldCreateNewWolf()
        {
            Random random = new Random();
            return random.Next(0, 2) == 0; // Ймовірність 50%
        }
        private void MoveSheWolves()
        {
            List<SheWolf> newSheWolves = new List<SheWolf>();

            // Створення копії колекції wolves
            List<SheWolf> shewolvesCopy = shewolves.ToList();

            foreach (SheWolf shewolf in shewolvesCopy)
            {
                int currentX = shewolf.X;
                int currentY = shewolf.Y;
                int newSaturation = shewolf.Saturation;

                // Вибір нових координат для вовчиці
                int newX = GetRandomNeighborCoordinate(currentX);
                int newY = GetRandomNeighborCoordinate(currentY);
                shewolf.ReduceSaturation(newSaturation);
                if (shewolf.IsHungry(newSaturation)) // Перевірка, чи вовчиця голодна
                {
                    SheWolfDead(currentX, currentY);
                    // buttons[newX, newY].BackColor = System.Drawing.Color.DarkGray;
                }

                if (newX != currentX || newY != currentY) // Вовчиця переміщується
                {
                    shewolf.Move(newX, newY);
                    buttons[currentX, currentY].BackColor = System.Drawing.Color.White;
                    buttons[newX, newY].BackColor = System.Drawing.Color.Brown;

                    // Перевірка, чи на наступній клітинці є кролик
                    if (HasRabbit(newX, newY))
                    {
                        EatRabbit(newX, newY); // Вовчиця "з'їдає" кролика
                        shewolf.Saturation = shewolf.Eat(); // Збільшення ситості вовчиці
                    }
                    else if (!HasRabbit(newX, newY) && !HasSheWolf(newX, newY)) // Якщо на наступній клітинці немає кролика або вовчиці
                    {
                        buttons[newX, newY].BackColor = System.Drawing.Color.Brown;
                    }
                }
            }
            shewolves.AddRange(newSheWolves);
        }
        private void SheWolfDead(int x, int y)
        {
            SheWolf shewolfToRemove = null;

            foreach (SheWolf shewolf in shewolves)
            {
                if (shewolf.X == x && shewolf.Y == y)
                {
                    shewolfToRemove = shewolf;
                    break;
                }
            }

            if (shewolfToRemove != null)
            {
                shewolves.Remove(shewolfToRemove);
                buttons[x, y].BackColor = System.Drawing.Color.White;
            }
        }
        private void WolfDead(int x, int y)
        {
            Wolf wolfToRemove = null;

            foreach (Wolf wolf in wolves)
            {
                if (wolf.X == x && wolf.Y == y)
                {
                    wolfToRemove = wolf;
                    break;
                }
            }

            if (wolfToRemove != null)
            {
                wolves.Remove(wolfToRemove);
                buttons[x, y].BackColor = System.Drawing.Color.White;
            }
        }
        private bool ShouldCreateNewRabbit()
        {
            Random random = new Random();
            return random.NextDouble() <= 0.02; // Ймовірність створення нового кролика - 0.2
        }

        private bool HasRabbit(int x, int y)
        {
            foreach (Rabbit rabbit in rabbits)
            {
                if (rabbit.X == x && rabbit.Y == y)
                {
                    return true;
                }
            }
            return false;
        }

        private bool HasSheWolf(int x, int y)
        {
            foreach (SheWolf shewolf in shewolves)
            {
                if (shewolf.X == x && shewolf.Y == y)
                {
                    return true;
                }
            }
            return false;
        }

        private void EatRabbit(int x, int y)
        {
            Rabbit rabbitToRemove = null;

            foreach (Rabbit rabbit in rabbits)
            {
                if (rabbit.X == x && rabbit.Y == y)
                {
                    rabbitToRemove = rabbit;
                    break;
                }
            }

            if (rabbitToRemove != null)
            {
                rabbits.Remove(rabbitToRemove);
                buttons[x, y].BackColor = System.Drawing.Color.White;
            }
        }

        private int GetRandomNeighborCoordinate(int currentCoordinate)
        {
            Random random = new Random();
            int min = Math.Max(0, currentCoordinate - 1);
            int max = Math.Min(FieldSize - 1, currentCoordinate + 1);
            return random.Next(min, max + 1);
        }


        private void Button_Click(object sender, KeyPressEventArgs e)
        {
            if (!simulationStarted && e.KeyChar == 'R' || e.KeyChar == 'r')
            {
                Button clickedButton = (Button)sender;
                int x = clickedButton.Location.X / (clickedButton.Width + 5);
                int y = clickedButton.Location.Y / (clickedButton.Height + 5);
                Rabbit newRabbit = new Rabbit(x, y);
                rabbits.Add(newRabbit);
                clickedButton.BackColor = System.Drawing.Color.DarkMagenta;
            }
            else if (!simulationStarted && e.KeyChar == 'S' || e.KeyChar == 's')
            {
                Button clickedButton = (Button)ActiveControl;
                int x = clickedButton.Location.X / (clickedButton.Width + 5);
                int y = clickedButton.Location.Y / (clickedButton.Height + 5);
                SheWolf newSheWolf = new SheWolf(x, y, 10);
                shewolves.Add(newSheWolf);
                clickedButton.BackColor = System.Drawing.Color.Brown;
            }
            else if (!simulationStarted && e.KeyChar == 'W' || e.KeyChar == 'w')
            {
                Button clickedButton = (Button)ActiveControl;
                int x = clickedButton.Location.X / (clickedButton.Width + 5);
                int y = clickedButton.Location.Y / (clickedButton.Height + 5);
                int eat = 10;
                Wolf newWolf = new Wolf(x, y, eat);
                wolves.Add(newWolf);
                clickedButton.BackColor = System.Drawing.Color.DarkBlue;
            }
        }
        private void ClearField()
        {
            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    buttons[i, j].BackColor = System.Drawing.Color.White;
                }
            }
        }
        private void GenerateButton_Click(object sender, EventArgs e)
        {
            simulationStarted = true;
            counter = 0;
            timer.Start();
            generateButton.Enabled = false;
            stopbtn.Enabled = true;
        }

        private void stopbtn_Click(object sender, EventArgs e)
        {
            simulationStarted = false;
            timer.Stop();
            generateButton.Enabled = true;
            stopbtn.Enabled = false;
        }

        private void restartbtn_Click(object sender, EventArgs e)
        {
            ClearField();

            // Скидання даних
            counter = 0;
            rabbits.Clear();
            shewolves.Clear();
            wolves.Clear();

            // Включення генерації
            simulationStarted = false;
            timer.Stop();
            generateButton.Enabled = true;
            stopbtn.Enabled = false;

        }
    }
}
