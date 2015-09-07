using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CreateDataTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Создаем таблицу с именем human
            DataTable human = dataSet1.Tables.Add("human");
            //Добавляем столбцы в таблицу
            human.Columns.Add("id", typeof(Int32));
            human.Columns.Add("name", typeof(String));
            human.Columns.Add("age", typeof(Int32));
            //Добавляем ограничение первичного ключа
            human.Constraints.Add("PK_Human", human.Columns["id"], true);
            //Делаем поле id счетчиком
            human.Columns[0].AutoIncrement = true;
            //Добавляем ограничение уникальности на поле name
            Constraint c = new UniqueConstraint(human.Columns["name"]);
            human.Constraints.Add(c);
            //задем полю age значение по умолчанию равное 16
            human.Columns["age"].DefaultValue = 16;

            //добавляем строку в таблицу
            human.Rows.Add(1, "Иванов Иван Иванович", 41);

            
            //Привяжем DataGridView к источнику данных
            dataGridView1.DataSource = dataSet1;
            //указываем отображаемую в текущий момент таблицу
            dataGridView1.DataMember = "human";
            //задим ширину второй колонки равной 200
            dataGridView1.Columns[1].Width = 200;

        }

        private void Save_Click(object sender, EventArgs e)
        {
            dataSet1.WriteXml("1.xml");
        }
    }
}
