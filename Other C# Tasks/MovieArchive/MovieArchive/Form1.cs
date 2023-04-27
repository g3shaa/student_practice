using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MovieArchive
{
    public partial class MovieForm : Form
    {
        public string connectionString = "Data Source=desktop-aapmf08;Initial Catalog=Movies;Integrated Security=True";
        public MovieForm()
        {
            InitializeComponent();
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            int releaseYear = int.Parse(txtReleaseYear.Text);
            string genre = txtGenre.Text;
            string director = txtDirector.Text;
            string opinion = txtOpinion.Text;
            decimal rating = decimal.Parse(txtRating.Text);

            if (txtDirector.Text != "" && txtGenre.Text != "" && txtRating.Text != "" && txtReleaseYear.Text != "" && txtTitle.Text != "")
            {
                string query = "INSERT INTO Movies (Title, ReleaseYear, Genre, Director, Rating, Opinion) " +
                "VALUES (@Title, @ReleaseYear, @Genre, @Director, @Rating, @Opinion)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@ReleaseYear", releaseYear);
                    command.Parameters.AddWithValue("@Genre", genre);
                    command.Parameters.AddWithValue("@Director", director); 
                    command.Parameters.AddWithValue("@Rating", rating);
                    command.Parameters.AddWithValue("@Opinion", opinion);


                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        MessageBox.Show("Филмът е запазен успешно!");
                        label8.Visible = true;
                        label8.Text = "Трябва да актуализираш таблицата!";
                        btnShowMovies.Text = "Актуализирай таблицата";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Грешка: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Трябва да въведеш данни в полетата!");
            }

            
        }

        private void btnShowMovies_Click(object sender, EventArgs e)
        {
            
                string query = "SELECT * FROM Movies";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvMovies.DataSource = dataTable;
                        label8.Visible = true;
                        label8.Text = "Таблицата е визуализирана!";
                        btnShowMovies.Text = "Актуализирай таблицата";
                }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Грешка: " + ex.Message);
                    }
                }

                
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDirector.Text = " ";
            txtGenre.Text = " ";
            txtRating.Text = " ";
            txtReleaseYear.Text = " ";
            txtTitle.Text = " ";
            txtOpinion.Text = " ";  
           // MessageBox.Show("Изчисти всички полета!");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int movieId = int.Parse(txtMovieId.Text);
            if (movieId != 0)
            {
                string query = "DELETE FROM Movies WHERE MovieId = @id";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", movieId);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Записът е изтрит успешно!");
                    label8.Visible = true;
                    label8.Text = "Трябва да актуализираш таблицата!";
                    btnShowMovies.Text = "Актуализирай таблицата";
                }
            } else
            {
                MessageBox.Show("Трябва да напишеш Филм ID на филма ,който искаш да изтриеш!", "Филмова библиотека");
            }
                

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Сигурен ли си, че искаш да затвориш апликацията?", "Филмова библиотека", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
               
            }

        }
    }
}
