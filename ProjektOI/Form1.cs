using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjektOI
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Katarzyna\Documents\BazaDanychPies.mdf;Integrated Security = True; Connect Timeout = 30");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            do_Checked();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into [TabeleczkaKosztow] (Cena,Wyprawka,Toaleta,Zdrowie, Jedzenie,Pielegnacja,ZKWP,Data) values('" + txt_Cena.Text + "','" + txt_Wyprawka.Text + "','" + txt_Toaleta.Text + "','" + txt_Zdrowie.Text + "','" + txt_Jedzenie.Text + "','" + txt_Pielegnacja.Text + "','" + txt_ZKWP.Text + "','" + txt_data.Text + "')";
                cmd.ExecuteNonQuery();
                connection.Close();
                txt_Cena.Text = "";
                txt_Wyprawka.Text = "";
                txt_Toaleta.Text = "";
                txt_Zdrowie.Text = "";
                txt_Jedzenie.Text = "";
                txt_Pielegnacja.Text = "";
                txt_ZKWP.Text = "";
                txt_data.Text = "";
                display_data();
                MessageBox.Show("Dane wprowadzone!", "Komunikat", MessageBoxButtons.OK);
        }
        public void display_data()
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [TabeleczkaKosztow]";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView1.DataSource = dta;
            connection.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            display_data();
        }

        private void button8_Click(object sender, EventArgs e)
        {         
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from [TabeleczkaKosztow] where data = '" + txt_data.Text + "'";
            cmd.ExecuteNonQuery();
            connection.Close();
            txt_Cena.Text = "";
            txt_Wyprawka.Text = "";
            txt_Toaleta.Text = "";
            txt_Zdrowie.Text = "";
            txt_Jedzenie.Text = "";
            txt_Pielegnacja.Text = "";
            txt_ZKWP.Text = "";
            txt_data.Text = "";
            display_data();
            MessageBox.Show("Dane usunięte!","Komunikat",MessageBoxButtons.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
            }
            MessageBox.Show("Na wyprawkę wydano: "+sum.ToString()+" złotych.", "Suma");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
            }
            MessageBox.Show("Na toaletę psa wydano: " + sum.ToString() + " złotych.", "Suma");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
            }
            MessageBox.Show("Na zdrowie psa wydano: " + sum.ToString() + " złotych.", "Suma");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
            }
            MessageBox.Show("Na jedzenie wydano: " + sum.ToString() + " złotych.", "Suma");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
            }
            MessageBox.Show("Na pielęgnację psa wydano: " + sum.ToString() + " złotych.", "Suma");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
            }
            MessageBox.Show("Na ZKwP wydano: " + sum.ToString() + " złotych.", "Suma");
        }
        private void button10_Click(object sender, EventArgs e)
        {
            
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value);
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                }
                MessageBox.Show("Wydano na psa : " + sum.ToString() + " złotych","Całkowity koszt",MessageBoxButtons.OK);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DialogResult res = new DialogResult();
            Form Piesek = new Pocieszenie();
            res = Piesek.ShowDialog();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            do_Checked(); 
        }
        private void do_Checked()
        {
            button12.Enabled = checkBox1.Checked; 
        }
        private void button12_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                MessageBox.Show("Wpisz liczbę 0, jeśli nie należysz do Związku Kynologicznego w Polsce.", "Informacja",MessageBoxButtons.OK);
            }
        }
        private void txt_Cena_TextChanged(object sender, EventArgs e)
        {
            string tylkoL = txt_Cena.Text;
            char[] tab = tylkoL.ToCharArray();

            foreach (var item in tab)
            {
                if (Char.IsDigit(item))
                { }
                else
                {
                    MessageBox.Show("Wpisz tylko cyfry!","Nieprawidłowy format");
                    txt_Cena.Text = "";
                }
            }
        }

        private void txt_Wyprawka_TextChanged(object sender, EventArgs e)
        {
            string tylkoL = txt_Wyprawka.Text;
            char[] tab = tylkoL.ToCharArray();

            foreach (var item in tab)
            {
                if (Char.IsDigit(item))
                { }
                else
                {
                    MessageBox.Show("Wpisz tylko cyfry!", "Nieprawidłowy format");
                    txt_Wyprawka.Text = "";
                }
            }
        }

        private void txt_Toaleta_TextChanged(object sender, EventArgs e)
        {
            string tylkoL = txt_Toaleta.Text;
            char[] tab = tylkoL.ToCharArray();

            foreach (var item in tab)
            {
                if (Char.IsDigit(item))
                { }
                else
                {
                    MessageBox.Show("Wpisz tylko cyfry!", "Nieprawidłowy format");
                   txt_Toaleta.Text = "";
                }
            }
        }

        private void txt_Zdrowie_TextChanged(object sender, EventArgs e)
        {
            string tylkoL = txt_Zdrowie.Text;
            char[] tab = tylkoL.ToCharArray();

            foreach (var item in tab)
            {
                if (Char.IsDigit(item))
                { }
                else
                {
                    MessageBox.Show("Wpisz tylko cyfry!", "Nieprawidłowy format");
                    txt_Zdrowie.Text = "";
                }
            }
        }

        private void txt_Jedzenie_TextChanged(object sender, EventArgs e)
        {
            string tylkoL = txt_Jedzenie.Text;
            char[] tab = tylkoL.ToCharArray();

            foreach (var item in tab)
            {
                if (Char.IsDigit(item))
                { }
                else
                {
                    MessageBox.Show("Wpisz tylko cyfry!", "Nieprawidłowy format");
                    txt_Jedzenie.Text = "";
                }
            }
        }
        private void txt_Pielegnacja_TextChanged(object sender, EventArgs e)
        {
            string tylkoL = txt_Pielegnacja.Text;
            char[] tab = tylkoL.ToCharArray();

            foreach (var item in tab)
            {
                if (Char.IsDigit(item))
                { }
                else
                {
                    MessageBox.Show("Wpisz tylko cyfry!", "Nieprawidłowy format");
                    txt_Pielegnacja.Text = "";
                }
            }
        }
        private void txt_ZKWP_TextChanged(object sender, EventArgs e)
        {
            string tylkoL = txt_ZKWP.Text;
            char[] tab = tylkoL.ToCharArray();

            foreach (var item in tab)
            {
                if (Char.IsDigit(item))
                { }
                else
                {
                    MessageBox.Show("Wpisz tylko cyfry!", "Nieprawidłowy format");
                    txt_ZKWP.Text = "";
                }
            }
        }

        private void txt_data_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
