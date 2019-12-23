using System;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        service serv = new service();
        private void data()
        {
            for (int i = 0; i < serv.retNumber(); i++)
            {
                dataGridView1.Rows.Add(serv.retName(i), serv.retDisp(i), serv.retStatus(i), serv.retCanStop(i));
            }
        }
        private void progress()
        {
            for (int i = 0; i < serv.retNumber(); i++)
            {
                dataGridView1.Rows.Add(serv.retName(i), serv.retDisp(i), serv.retStatus(i), serv.retCanStop(i));
            }
        }
        public Form1()
        {
            serv.added();
            InitializeComponent();
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Название службы"; //текст в шапке
            //column1.Width = 200; //ширина колонки
            column1.ReadOnly = true; //значение в этой колонке нельзя править
            column1.Name = "name"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column1.Frozen = true; //флаг, что данная колонка всегда отображается на своем месте
            column1.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки
            var column2 = new DataGridViewColumn();
            //column2.Width = 200;
            column2.HeaderText = "Описание";
            column2.Name = "price";
            column2.CellTemplate = new DataGridViewTextBoxCell();
            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Статус";
           // column3.Width = 150;
            column3.Name = "count";
            column3.CellTemplate = new DataGridViewTextBoxCell();
            var column4 = new DataGridViewColumn();
            //column4.Width = 150;
            column4.HeaderText = "Может быть остановлена";
            column4.Name = "";
            column4.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.Columns.Add(column3);
            dataGridView1.Columns.Add(column4);
            data();
            
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var index = dataGridView1.SelectedCells[0].RowIndex;
            if (serv.retStatus(index) == "Stopped" || serv.retStatus(index) == "StopPending")
            {
                MessageBox.Show("Service was stopped");
            }
            else
            {
                progresss();
                serv.stopService(index);
                dataGridView1.Rows.Clear();
                data();
               
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            var index = dataGridView1.SelectedCells[0].RowIndex;
            if (serv.retStatus(index) == "Running")
            {
                MessageBox.Show("Service was running");
            }
            else
            {
                progresss();
                serv.startService(index);
                dataGridView1.Rows.Clear();
                data();

            }
        }
        private void progresss()
        {
            dataGridView1.Hide();
            Invoke(new Action(() => progressBar1.Minimum = 0));
            Invoke(new Action(() => progressBar1.Maximum = 4));
            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(1500);
                Invoke(new Action(() => progressBar1.Value++));
                
            }
            Invoke(new Action(() => progressBar1.Value = 0));
            progressBar1.Hide();
            dataGridView1.Show();
        }
        private void button3_Click(object sender, System.EventArgs e)
        {
           
           
        }
    }
}
