using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieLibrary
{
    public partial class Form1 : Form
    {
        private List<Movie> movies = new List<Movie>();
        private string filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\movies.json";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Валидация на входните данни
            if (string.IsNullOrEmpty(txtTitle.Text) || string.IsNullOrEmpty(txtDirector.Text) || string.IsNullOrEmpty(txtYear.Text))
            {
                MessageBox.Show("Попълнете всички полета.");
                return;
            }

            int year;
            if (!int.TryParse(txtYear.Text, out year))
            {
                MessageBox.Show("Въведете валидна година.");
                return;
            }

            // Създаване на нов обект Movie
            var movie = new Movie
            {
                Title = txtTitle.Text,
                Director = txtDirector.Text,
                Year = year
            };

            // Добавяне на филма към списъка
            movies.Add(movie);

            // Запазване на списъка в JSON файл
            SaveMoviesToJsonFile();
            MessageBox.Show("Данните за филма са запазени в movies.json на Desktop!");

            // Изчистване на формата
            txtTitle.Clear();
            txtDirector.Clear();
            txtYear.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Зареждане на списъка с филми от JSON файл
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                movies = JsonConvert.DeserializeObject<List<Movie>>(json);
            }
        }

        private void SaveMoviesToJsonFile()
        {
            // Запазване на списъка в JSON формат
            string json = JsonConvert.SerializeObject(movies);

            // Записване на JSON файл на десктопа
            File.WriteAllText(filePath, json);
        }
    }

    public class Movie
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
    }
}
