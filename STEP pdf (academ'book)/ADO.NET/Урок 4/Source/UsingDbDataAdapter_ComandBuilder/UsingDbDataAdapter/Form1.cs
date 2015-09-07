using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;

namespace UsingDbDataAdapter
{
    public partial class Form1 : Form
    {
        DbDataAdapter adapter;
        DbConnection conn;
        public Form1()
        {
            InitializeComponent();
            //Запросим у пользователя параметры соединения
            Form2 form = new Form2();
            if (form.ShowDialog() == DialogResult.Cancel) Close();

            //Создаем соединение, открывать его не нужно
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=" + form.ServerName +
                                    ";Initial Catalog=" + form.DBName +
                                    ";User Id=" + form.UserName +
                                    ";Password=" + form.Password;
            //Создаем и формируем адаптер
            adapter = new SqlDataAdapter();
            //формируем команду на выборку
            DbCommand select = new SqlCommand();
            select.Connection = conn;
            select.CommandText = "Select * from goods";
            //добавляем команду к адаптеру
            adapter.SelectCommand = select;

            /*Заполняем источник данных, это нужно сделать, иначе команды для вставки,
             обновления и удаления не смогут быть сформированны, поскольку не известна еще
             структура таблицы*/
            adapter.Fill(dataSet1);

            //формируем остальные команды
            //создаем SqlCommandBuilder
            SqlCommandBuilder builder = new SqlCommandBuilder((SqlDataAdapter)adapter);
            //получаем команды
            adapter.InsertCommand = builder.GetInsertCommand();
            adapter.DeleteCommand = builder.GetDeleteCommand();
            adapter.UpdateCommand = builder.GetUpdateCommand();
        }  

        private void Fill_Click(object sender, EventArgs e)
        {
            try
            {
                dataSet1.Clear();
                adapter.Fill(dataSet1);
                dataGridView1.DataSource = dataSet1.Tables[0];
            }
            catch (System.Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                adapter.Update(dataSet1);
                
            }
            catch (System.Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
    }
}
