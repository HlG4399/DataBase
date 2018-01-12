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

namespace DataBase
{
    public partial class CourseMaterialsManagement : Form
    {
        SqlConnection conn;
        DataSet ds;
        SqlDataAdapter adapter;

        public CourseMaterialsManagement()
        {
            InitializeComponent();
            string sqlstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\文档库\C#\Project\DataBase\DataBase.mdf;Integrated Security=True;Connect Timeout=30";
            conn = new SqlConnection(sqlstr);
            conn.Open();
            dataGridView.GridColor = Color.RoyalBlue;
            dataGridView.ScrollBars = ScrollBars.Vertical;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            for (int i = 0; i < 3; i++)
            {
                dataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dataGridView.MultiSelect = true;
        }

        private void btn_display_Click(object sender, EventArgs e)
        {
            string sqlstr = "select * from tSubject";
            adapter = new SqlDataAdapter(sqlstr, conn);
            ds = new DataSet();
            adapter.Fill(ds, "tSubject");
            dataGridView.DataSource = ds.Tables[0];
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (ds != null)
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "tSubject");
                MessageBox.Show("信息更新成功");
            }
        }
    }
}
