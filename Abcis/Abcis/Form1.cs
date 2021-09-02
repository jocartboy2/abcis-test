using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace Abcis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button5_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource = await Helper.GetAll(); 
        }
        s
        private async void button4_Click(object sender, EventArgs e)
        {
            var response = await Helper.Post(textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, textBox12.Text);  
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var result = await Helper.Get(Convert.ToInt32(textBox1.Text)); 
            List<GetAbcis> list = new List<GetAbcis>();
            
            dataGridView1.DataSource = result;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var response = await Delete(Convert.ToInt32(textBox2.Text));
        }
         
        private static async Task<string> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.DeleteAsync("https://localhost:5001/api/abcis/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        MessageBox.Show("Successful Delete");
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }

                }
            }
            return string.Empty;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var response = await Helper.PUT(textBox13.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text);
        }
    }
}
