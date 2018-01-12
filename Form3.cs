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
    public partial class StudentAchievementManagement : Form
    {
        SqlConnection conn;
        DataSet ds;
        SqlDataAdapter adapter;
        //初始化绑定默认关键词（此数据源可以从数据库取）
        List<string> listOnit1 = new List<string>();
        List<string> listOnit2 = new List<string>();
        List<string> listOnit3 = new List<string>();
        //输入key之后，返回的关键词
        List<string> listNew1 = new List<string>();
        List<string> listNew2 = new List<string>();
        List<string> listNew3 = new List<string>();

        public StudentAchievementManagement()
        {
            InitializeComponent();
            string sqlstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\文档库\C#\Project\DataBase\DataBase.mdf;Integrated Security=True;Connect Timeout=30";
            conn = new SqlConnection(sqlstr);
            conn.Open();
            dataGridView.GridColor = Color.RoyalBlue;
            dataGridView.ScrollBars = ScrollBars.Vertical;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            for (int i = 0; i < 4; i++)
            {
                dataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dataGridView.MultiSelect = true;
        }

        private void data_display()
        {
            string sqlstr = "select * from tScore";
            adapter = new SqlDataAdapter(sqlstr, conn);
            ds = new DataSet();
            adapter.Fill(ds, "tScore");
            dataGridView.DataSource = ds.Tables[0];
            for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listOnit1.Add(ds.Tables[0].Rows[i]["fStdID"].ToString());
                listOnit2.Add(ds.Tables[0].Rows[i]["fSubID"].ToString());
                listOnit3.Add(ds.Tables[0].Rows[i]["fScore"].ToString());
            }
            id.Items.AddRange(listOnit1.ToArray());
            Course.Items.AddRange(listOnit2.ToArray());
            Grade.Items.AddRange(listOnit3.ToArray());
        }

        private void btn_display_Click(object sender, EventArgs e)
        {
            data_display();
        }

        private void StudentAchievementManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (ds != null)
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "tScore");
                if((sender as Button).Text == "添加数据")
                {
                    MessageBox.Show("信息添加成功");
                }
                if ((sender as Button).Text == "修改选定数据")
                {
                    MessageBox.Show("信息修改成功");
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (ds != null)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                for (int i = 0; i < dataGridView.SelectedRows.Count; i++)
                {
                    cmd.CommandText = "delete from tScore where fScoreID=" + dataGridView.SelectedRows[i].Cells[0].Value;
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("信息删除成功！");
                data_display();
            }
        }

        private void id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
        }

        private void id_TextChanged(object sender, EventArgs e)
        {
            if (ds != null)
            {
                string sqlstr = "select * from tScore where fStdID like '%" + id.Text + "%' and fSubID like '%" + Course.Text + "%' and fScore like '%" + Grade.Text + "%'";
                SqlDataAdapter adapter1 = new SqlDataAdapter(sqlstr, conn);
                DataSet ds1 = new DataSet();
                adapter1.Fill(ds1, "tScore");
                dataGridView.DataSource = ds1.Tables[0];
            }
        }

        private void id_TextUpdate(object sender, EventArgs e)
        {
            //清空combobox
            id.Items.Clear();
            //清空listNew
            listNew1.Clear();
            //遍历全部备查数据
            foreach (var item in listOnit1)
            {
                if (item.Contains(id.Text))
                {
                    //符合，插入ListNew
                    listNew1.Add(item);
                }
            }
            //combobox添加已经查到的关键词
            id.Items.AddRange(listNew1.ToArray());
            //设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
            id.SelectionStart = id.Text.Length;
            //保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
            Cursor = Cursors.Default;
            //自动弹出下拉框
            id.DroppedDown = true;
        }

        private void Course_TextUpdate(object sender, EventArgs e)
        {
            //清空combobox
            Course.Items.Clear();
            //清空listNew
            listNew2.Clear();
            //遍历全部备查数据
            foreach (var item in listOnit2)
            {
                if (item.Contains(Course.Text))
                {
                    //符合，插入ListNew
                    listNew2.Add(item);
                }
            }
            //combobox添加已经查到的关键词
            Course.Items.AddRange(listNew2.ToArray());
            //设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
            Course.SelectionStart = Course.Text.Length;
            //保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
            Cursor = Cursors.Default;
            //自动弹出下拉框
            Course.DroppedDown = true;
        }

        private void Grade_TextUpdate(object sender, EventArgs e)
        {
            //清空combobox
            Grade.Items.Clear();
            //清空listNew
            listNew3.Clear();
            //遍历全部备查数据
            foreach (var item in listOnit3)
            {
                if (item.Contains(Grade.Text))
                {
                    //符合，插入ListNew
                    listNew3.Add(item);
                }
            }
            //combobox添加已经查到的关键词
            Grade.Items.AddRange(listNew3.ToArray());
            //设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列
            Grade.SelectionStart = Grade.Text.Length;
            //保持鼠标指针原来状态，有时候鼠标指针会被下拉框覆盖，所以要进行一次设置。
            Cursor = Cursors.Default;
            //自动弹出下拉框
            Grade.DroppedDown = true;
        }
    }
}
