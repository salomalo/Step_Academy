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
            conn.ConnectionString = "Data Source="+form.ServerName+
                                    ";Initial Catalog="+form.DBName+
                                    ";User Id="+form.UserName+
                                    ";Password="+form.Password;
            //Создаем и формируем адаптер
            adapter = new SqlDataAdapter();
            //формируем команду на выборку
            DbCommand select = new SqlCommand();
            select.Connection = conn;
            select.CommandText = "Select * from goods";
            //добавляем команду к адаптеру
            adapter.SelectCommand = select;

            //формируем команду на добавление
            DbCommand insert = new SqlCommand();
            insert.Connection = conn;
            insert.CommandText = "insert into goods values(@n,@p)";
            //формируем параметры для команды
            DbParameter Name, Price;
            Name = new SqlParameter("n", SqlDbType.Text);
            Price = new SqlParameter("p", SqlDbType.Float);
            /*указываем из какий столбцов таблицы брать значения для параметров*/
            Name.SourceColumn = "name";
            Price.SourceColumn = "price";
            //добавляем параметры к команде
            insert.Parameters.Add(Name);
            insert.Parameters.Add(Price);
            //добавляем команду к адаптеру
            adapter.InsertCommand = insert;

            //формируем команду на удаление
            DbCommand delete = new SqlCommand();
            delete.Connection = conn;
            delete.CommandText = "delete from goods where id=@id";
            //формируем параметр для команды
            DbParameter Id;
            Id = new SqlParameter("id", SqlDbType.Int);
            /*указываем из какого столбца таблицы брать значения для параметра*/
            Id.SourceColumn = "id";
            //добавляем параметр к команде
            insert.Parameters.Add(Id);
            //добавляем команду к адаптеру
            adapter.DeleteCommand = delete;
 

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
