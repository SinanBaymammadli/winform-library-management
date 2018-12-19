using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMDbLib.Client;
using TMDbLib.Objects.Movies;

namespace WindowsFormsApp2
{
    public partial class MovieShow : Form
    {
        string id;
        TMDbClient client = new TMDbClient("d5b78d201d27c93fd84daac0db027c00");

        public MovieShow(string movieId)
        {
            id = movieId;
            InitializeComponent();
        }

        private void Movie_Load(object sender, EventArgs e)
        {
            Movie movie = client.GetMovieAsync(id).Result;

            label1.Text = movie.Title;
            label2.Text = movie.Overview;
            
            pictureBox1.Load("http://image.tmdb.org/t/p/w300" + movie.PosterPath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Movie movie = client.GetMovieAsync(id).Result;

            
        }
    }
}
