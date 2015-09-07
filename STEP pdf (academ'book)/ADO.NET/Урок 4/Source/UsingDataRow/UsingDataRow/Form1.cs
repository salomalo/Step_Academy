using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace UsingDataRow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                InitDataSet();
               
               
            }
            catch(System.Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            
        }
       
         private void InitDataSet()
        {
            //Создаем таблицу с именем student
            DataTable student = dataSet1.Tables.Add("student");
            //Добавляем столбцы в таблицу
            student.Columns.Add("id", typeof(Int32));
            student.Columns.Add("fio", typeof(String));
            student.Columns.Add("age", typeof(Int32));
            student.Columns.Add("id_gruppa", typeof(Int32));

            //Создаем таблицу с именем gruppa
            DataTable gruppa = dataSet1.Tables.Add("gruppa");
            //Добавляем столбцы в таблицу
            gruppa.Columns.Add("id", typeof(Int32));
            gruppa.Columns.Add("name", typeof(String));
            
            //Добавляем ограничения первичных ключей и делаем из счетчиком
            student.Constraints.Add("PK_Student", student.Columns["id"], true);
            student.Columns[0].AutoIncrement = true;
            gruppa.Constraints.Add("PK_Gruppa", gruppa.Columns["id"], true);
            gruppa.Columns[0].AutoIncrement = true;
             //также исключим возможность пустого значения в ключах
            student.Columns["id"].AllowDBNull = false;
            gruppa.Columns["id"].AllowDBNull = false;   

            /*Добавляем ограничение уникальности на поле name таблицы gruppa
             и поле fio таблицы student        */ 
            Constraint c = new UniqueConstraint(gruppa.Columns["name"]);
            gruppa.Constraints.Add(c);
            c = new UniqueConstraint(student.Columns["fio"]);
            student.Constraints.Add(c);
            
            //Добавляем внешний ключ
            student.Constraints.Add("FK_Student", gruppa.Columns["id"], student.Columns["id_gruppa"]);
           //скажем что внешний ключ не может содержать пустые строки
            student.Columns["id_gruppa"].AllowDBNull = false;
             //Добавляем отношение между этими таблицами
            dataSet1.Relations.Add("Stud_Gruppa",gruppa.Columns["id"], student.Columns["id_gruppa"]);

             //Привяжем ListBox к источнику данных
            listBox1.DataSource = dataSet1.Tables["gruppa"];
            //указываем отображаеый столбец
            listBox1.DisplayMember = "name";

            //Вычитываем данные в таблицы из XML документа
            dataSet1.Tables["gruppa"].ReadXml("..\\..\\1.xml");
            /*
             Таблица студентов вычитывается автоматически, т.к. мы указали отношение
             */
            
            ShowStudents(0);
            
        }

         private void ReLoad_Click(object sender, EventArgs e)
         {
             try
            {
                dataSet1 = new DataSet();
                 InitDataSet();
            }
            catch(System.Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
                         
         }

         private void ShowStudents(int n)
         {
             DataTable stud = dataSet1.Tables["student"].Clone();
             DataRow parent =dataSet1.Tables["gruppa"].Rows[n];
             DataRow[] childs = parent.GetChildRows("Stud_Gruppa");
             foreach (DataRow row in childs)
             {
                 stud.ImportRow(row);//.Rows.Add(row[0],row[1],row[2],row[3]);
             }
             dataGridView1.DataSource = stud;
             //задим ширину второй колонки равной 200
             dataGridView1.Columns[1].Width = 200;

         }

          private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
         {
             if (listBox1.SelectedIndex != -1)
             {
                 ShowStudents(listBox1.SelectedIndex);
             }
         }
        
    }
}
