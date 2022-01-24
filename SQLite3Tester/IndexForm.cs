using DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLite3Tester
{
    public partial class IndexForm : Form
    {
        SQliteDb Db = new SQliteDb();
        DataDB dataDB = new DataDB();
        string savePath = Application.StartupPath + @"\Data.db";

        List<string> Column = new List<string>() { "id", "name", "apartment" };
        public IndexForm()
        {
            InitializeComponent();

            if (!Db.CheckDatatable("Emp"))
            {
                Db.CreateTable(savePath, Db.CreateTableString("Emp", Column));
            }

            var tables = Db.TableInfo(savePath);
            foreach (DataRow item in tables.Rows)
                cb_table.Items.Add(item["TABLE_NAME"]);

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void IndexForm_Load(object sender, EventArgs e)
        {
            if (cb_table.Items.Count > 0)
            {
                cb_table.SelectedIndex = 0;
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            searchData();
        }

        DataTable ToDGV(List<Emp> data)
        {
            DataTable dataTable = new DataTable();

            foreach (var item in Column)
                dataTable.Columns.Add(item);

            if (data.Count > 0)
            {
                int rowCount = 0;
                foreach (var item in data)
                {
                    dataTable.Rows.Add();
                    dataTable.Rows[rowCount][0] = item.id;
                    dataTable.Rows[rowCount][1] = item.name;
                    dataTable.Rows[rowCount][2] = item.apartment;
                    rowCount++;
                }
            }

            return dataTable;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            addData();
        }

        private void btn_Drop_Click(object sender, EventArgs e)
        {

        }

        void addData()
        {
            List<string> insert = new List<string>();
            string data = $"{txt_id.Text}_{txt_name.Text}_{txt_apartment.Text}";
            for (int i = 0; i < 1000; i++)
            {
                insert.Add(data);
            }
            Db.DataAdd(savePath, cb_table.Text, Column, insert);
        }

        void searchData()
        {
            var data = from x in dataDB.Emps select x;

            List<Emp> empList = new List<Emp>();

            foreach (var item in data)
            {
                Emp emp = new Emp();
                emp.id = item.Id; emp.name = item.Name; emp.apartment = item.Apartment;
                empList.Add(emp);
            }

            var table = ToDGV(empList);

            Invoke((MethodInvoker)delegate
            {
                dgv_data.DataSource = table;
            });
        }
    }
}
