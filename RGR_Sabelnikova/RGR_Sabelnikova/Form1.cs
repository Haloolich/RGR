using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGR_Sabelnikova
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 wolfsIsland = new Form2();
            wolfsIsland.Show();
        }
    }
}
/*
  int[,] currentRabbitState;
        int[,] nextRabbitState;
        bool isPlaying = false;
        //задаємо розміри карти
        const int mapSize = 20;
        const int cellSize = 20;
        int[,] map = new int[mapSize, mapSize];
        //зображення звірів????
        Image rabbit;
        Image wolf;
        Image shewolf;
        public AnimalsBatle()
        {
            InitializeComponent();

            rabbit = new Bitmap("C:\\Users\\JeySay\\Downloads\\rabbit.png");
            
            Init();
            this.Text = "Wolfs Island";
            
        }
        //ініціалізація гри
        public void Init()
        {
            //CreateMap();
            currentRabbitState = InitMap(currentRabbitState);
            nextRabbitState = InitMap(nextRabbitState);
        }
        //створення ігрової карти
        /*public void CreateMap()
        {//задаю довжину і ширину поля. далі за допомогою фор проходжусь і створюю кнопки-клітиинки
            this.Width = mapSize * cellSize;
            this.Height = mapSize * cellSize;

            for(int i = 0; i <mapSize; i++)
            {
                for(int j = 0; j<mapSize; j++)
                {
                    Button button = new Button();
                    button.Location = new Point(j * cellSize, i * cellSize);
                    button.Size = new Size(cellSize, cellSize);
                    this.Controls.Add(button);
                }
            }
        }
int[,] InitMap(int[,] arr)
{
    //int[,] arr = new int[mapSize, mapSize];
    for (int i = 0; i < mapSize; i++)
    {
        for (int j = 0; j < mapSize; j++)
        {
            arr[i, j] = 0;
        }
    }
    return arr;
}
*/
