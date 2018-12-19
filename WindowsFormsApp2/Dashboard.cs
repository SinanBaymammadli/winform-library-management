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
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

namespace WindowsFormsApp2
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        TMDbClient client = new TMDbClient("d5b78d201d27c93fd84daac0db027c00");

        private void Form1_Load(object sender, EventArgs e)
        {
            this.searchMovies("a");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;

            this.searchMovies(text);
        }

        private void searchMovies(string text)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            SearchContainer<SearchMovie> results = client.SearchMovieAsync(text).Result;

            foreach (SearchMovie result in results.Results)
            {
                dataGridView1.Rows.Add(result.Id, result.Title);
            }
        }

        private void dataGridView1_DoubleCellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            var form = new MovieShow(id);
            form.Show();
        }
    }
}
