﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace J_Explore
{
    public partial class Registrasi_Admin : Form
    {
        public Registrasi_Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = "Server=localhost;Port=5432;User Id=postgres;Password=Rizal020304;Database=pbo;";

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    int id = Convert.ToInt32(textBox1.Text);
                    string username = textBox1.Text;
                    string password = textBox2.Text;
                    string email = textBox3.Text;
                    string phoneNumber = textBox4.Text;

                    string query = "INSERT INTO akun_admin (id_akun_admin,username, password, email, no_hp) " +
                                   "VALUES (@id, @username, @password, @email, @no_hp)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.Parameters.AddWithValue("username", username);
                        cmd.Parameters.AddWithValue("password", password);
                        cmd.Parameters.AddWithValue("email", email);
                        cmd.Parameters.AddWithValue("no_hp", phoneNumber);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Akun berhasil dibuat!");

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                }
            }
        }
    }
}
