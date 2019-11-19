using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace wedding_agency
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }


        private void SetupDataGridView()
        {
            Controls.Add(userDataGridView1);

            userDataGridView1.ColumnCount = 11;

            userDataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            userDataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            userDataGridView1.ColumnHeadersDefaultCellStyle.Font =
                new Font(userDataGridView1.Font, FontStyle.Bold);

            userDataGridView1.Name = "userDataGridView";
            userDataGridView1.Location = new Point(14, 30);
            userDataGridView1.Size = new Size(500, 250);
            userDataGridView1.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            userDataGridView1.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            userDataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            userDataGridView1.GridColor = Color.Black;
            userDataGridView1.RowHeadersVisible = false;
         


            userDataGridView1.Columns[0].Name = "Имя";
            userDataGridView1.Columns[1].Name = "Фамилия";
            userDataGridView1.Columns[2].Name = "Пол";
            userDataGridView1.Columns[3].Name = "Дата рождения";
            userDataGridView1.Columns[4].Name = "Страна";
            userDataGridView1.Columns[5].Name = "Город";
            userDataGridView1.Columns[6].Name = "Рост см.";
            userDataGridView1.Columns[7].Name = "Вес  кг.";
            userDataGridView1.Columns[8].Name = "Цвет волос";
            userDataGridView1.Columns[9].Name = "Цвет глаз";

            userDataGridView1.Columns[9].DefaultCellStyle.Font =
                new Font(userDataGridView1.DefaultCellStyle.Font, FontStyle.Italic);

            userDataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            userDataGridView1.MultiSelect = false;
            userDataGridView1.Width = 600;
            userDataGridView1.Height = 250;



            userDataGridView1.CellFormatting += new
                DataGridViewCellFormattingEventHandler(
                userDataGridView1_CellFormatting);
        }
        private void InfoDataGridView()
        {
            string[] row0 = {"Виктор","Петров","мужской","10/25/1988", "Украина", "Киев",
            "188", "81", "русый", "голубой" };
            string[] row1 = { "Анна","Николаева","женский","06/18/1985", "Россия", "Москва",
            "168", "52", "блондин", "карий" };
            string[] row2 = { "Иван","Иванов","мужской","08/14/1979", "Украина", "Харьков",
            "190", "90", "брюнет", "карий" };
            string[] row3 = { "Петр","Семенов","мужской","06/09/1984", "Украина", "Киев",
            "184", "85", "брюнет", "голубой" };
            string[] row4 = { "Сергей","Денисов","мужской","10/09/1986", "Украина", "Харьков",
            "189", "85", "блондин", "голубой" };
            string[] row5 = { "Виктория","Коваль","женский","05/15/1989", "Украина", "Харьков",
            "174", "58", "русый", "карий" };
            string[] row6 = { "Инна","Маркова","женский","11/22/1990", "Россия", "Ярославль",
            "165", "52", "шатен", "голубой" };
            string[] row7 = { "Андрей","Пархоменко","мужской","01/03/1979", "Россия", "Москва",
            "194", "92", "брюнет", "карий" };
            string[] row8 = { "Анна","Ахматова","женский","09/07/1993", "Украина", "Днепр",
            "165", "52", "шатен", "голубой" };
            string[] row9 = { "Виталий","Петренко","мужской","12/23/1985", "Украина", "Днепр",
            "178", "80", "брюнет", "зеленый" };
            string[] row10 = { "Елена","Белецкая","женский","07/05/1978", "Украина", "Киев",
            "172", "61", "шатен", "зеленый" };


            userDataGridView1.Rows.Add(row0);
            userDataGridView1.Rows.Add(row1);
            userDataGridView1.Rows.Add(row2);
            userDataGridView1.Rows.Add(row3);
            userDataGridView1.Rows.Add(row4);
            userDataGridView1.Rows.Add(row5);
            userDataGridView1.Rows.Add(row6);
            userDataGridView1.Rows.Add(row7);
            userDataGridView1.Rows.Add(row8);
            userDataGridView1.Rows.Add(row9);
            userDataGridView1.Rows.Add(row10);



            userDataGridView1.Columns[0].DisplayIndex = 0;
            userDataGridView1.Columns[1].DisplayIndex = 1;
            userDataGridView1.Columns[2].DisplayIndex = 2;
            userDataGridView1.Columns[3].DisplayIndex = 3;
            userDataGridView1.Columns[4].DisplayIndex = 4;
            userDataGridView1.Columns[5].DisplayIndex = 5;
            userDataGridView1.Columns[6].DisplayIndex = 6;
            userDataGridView1.Columns[7].DisplayIndex = 7;
            userDataGridView1.Columns[8].DisplayIndex = 8;
            userDataGridView1.Columns[9].DisplayIndex = 9;
            userDataGridView1.Columns[10].DisplayIndex = 10;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            SetupDataGridView();
            InfoDataGridView();

        }

        private void userDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e != null)
            {
                if (userDataGridView1.Columns[e.ColumnIndex].Name == "Release Date")
                {
                    if (e.Value != null)
                    {
                        try
                        {
                            e.Value = DateTime.Parse(e.Value.ToString())
                                .ToLongDateString();
                            e.FormattingApplied = true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("{0} is not a valid date.", e.Value.ToString());
                        }
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (userDataGridView1.SelectedCells == null)
            {
                DialogResult dialogResult = MessageBox.Show("Выберите данные для удаления", "Некорректный ввод", MessageBoxButtons.YesNo);

            }
            else
            {
                DialogResult dialogResult1 = MessageBox.Show("Вы уверены что хотите удалить данные?", "Подтверждение удаления", MessageBoxButtons.YesNo);


                if (dialogResult1 == DialogResult.Yes)
                {
                    int index = userDataGridView1.SelectedCells[0].RowIndex;
                    userDataGridView1.Rows.RemoveAt(index);
                }
                else if (dialogResult1 == DialogResult.No)
                {

                }
            }
        }



        private void addNewRowbutton1_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
        }

        private void addgroupboxbutton1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string sex = textBox3.Text;
            string dateofbirthday = textBox4.Text;
            string country = textBox5.Text;
            string city = textBox6.Text;
            string height = textBox7.Text;
            string weight = textBox8.Text;
            string haircolor = textBox9.Text;
            string eyecolor = textBox10.Text;
            userDataGridView1.Rows.Add(name, surname, sex, dateofbirthday, country, city, height, weight, haircolor, eyecolor);
            groupBox1.Visible = false;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    StreamReader myread = new StreamReader(myStream);
                    string[] str;
                    int num = 0;
                    try
                    {
                        string[] str1 = myread.ReadToEnd().Split('\n');
                        num = str1.Count();
                        userDataGridView1.RowCount = num;
                        for (int i = 0; i < num; i++)
                        {
                            str = str1[i].Split(' ');

                            for (int j = 0; j < userDataGridView1.ColumnCount; j++)
                            {
                                try
                                {
                                    userDataGridView1.Rows[i].Cells[j].Value = str[j];
                                }
                                catch { }
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myread.Close();
                    }


                }

            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Stream mystream = null;
            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //saveFileDialog1.Filter = "txt|*.jpg|Bitmap Image|*.bmp|Gif Image|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((mystream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter mywriter = new StreamWriter(mystream);

                    try
                    {

                        for (int i = 0; i < userDataGridView1.RowCount - 1; i++)
                        {

                            for (int j = 0; j < userDataGridView1.ColumnCount; j++)
                            {
                                mywriter.Write(userDataGridView1.Rows[i].Cells[j].Value.ToString() + "^");
                            }
                            mywriter.WriteLine();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        mywriter.Close();
                    }
                    mystream.Close();

                }
            }
        }

        private void sort_Click(object sender, EventArgs e)
        {
            textBox11.Show();
            userDataGridView1.Sort(userDataGridView1.Columns[textBox11.Text], ListSortDirection.Ascending);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < userDataGridView1.RowCount-1; i++)
                for (int j = 0; j < userDataGridView1.RowCount; j++)
                    if (userDataGridView1[i, j].FormattedValue.ToString().Contains(textBox12.Text.Trim()))
                    {
                        userDataGridView1.CurrentCell = userDataGridView1[i, j];
                        if (i < userDataGridView1.RowCount - 1)
                            userDataGridView1[i, j].Style.BackColor = Color.AliceBlue;
                        userDataGridView1[i, j].Style.ForeColor = Color.Blue;
                    }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


