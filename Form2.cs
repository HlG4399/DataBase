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
using System.IO;

namespace DataBase
{
    public partial class StudentInformationManagement : Form
    {
        SqlCommand cmd;
        SqlConnection conn;
        DataSet ds;

        public StudentInformationManagement()
        {
            InitializeComponent();
            string sqlstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\文档库\C#\Project\DataBase\DataBase.mdf;Integrated Security=True;Connect Timeout=30";
            conn = new SqlConnection(sqlstr);
            conn.Open();
        }

        private void data_display()
        {
            cmd = new SqlCommand();
            cmd.CommandText = "select * from tStudent";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd.CommandText, conn);
            ds = new DataSet();
            adapter.Fill(ds, "tStudent");
            listView.Items.Clear();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ListViewItem lvi;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    lvi = new ListViewItem(new string[] { ds.Tables[0].Rows[i]["fStdID"].ToString(), ds.Tables[0].Rows[i]["fStdName"].ToString() });
                    listView.Items.Add(lvi);
                }
            }
        }

        private void btn_display_Click(object sender, EventArgs e)
        {
            data_display();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (id.Text.Length < 12)
            {
                MessageBox.Show("学号的位数应为12。");
                return;
            }
            if (StudentName.Text.Length==0)
            {
                MessageBox.Show("学生姓名应不为空");
                return;
            }
            cmd = new SqlCommand();
            cmd.CommandText = "insert into tStudent(fStdID,fStdName) values(" + id.Text + ",'" + StudentName.Text + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            if (cmd.ExecuteNonQuery()>0)
            {
                MessageBox.Show("信息添加成功！");
            }
            else
            {
                MessageBox.Show("信息添加失败！");
            }
            data_display();
        }

        private void id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 57) && (e.KeyChar != 8) && (e.KeyChar != 46))
            {
                e.Handled = true;
            }
        }

        private void StudentInformationManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "delete from tStudent where fStdID="+listView.FocusedItem.SubItems[0].Text;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("信息删除成功！");
            }
            else
            {
                MessageBox.Show("信息删除失败！");
            }
            data_display();
        }

        private void btn_modify_Click(object sender, EventArgs e)
        {
            if (listView.FocusedItem != null)
            {
                if (id.Text.Length < 12)
                {
                    MessageBox.Show("学号的位数应为12。");
                    return;
                }
                if (StudentName.Text.Length == 0)
                {
                    MessageBox.Show("学生姓名应不为空");
                    return;
                }
                cmd = new SqlCommand();
                cmd.CommandText = "update tStudent set fStdID="+id.Text+",fStdName='"+StudentName.Text+ "' where fStdID=" + listView.FocusedItem.SubItems[0].Text;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("信息修改成功！");
                }
                else
                {
                    MessageBox.Show("信息修改失败！");
                }
                data_display();
            }
            else
            {
                MessageBox.Show("请指定需要修改的行。");
            }
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            data_display();
            if (ds.Tables[0].Rows.Count > 0)
            {
                FileStream fs = new FileStream("data.txt", FileMode.Truncate);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sw.WriteLine("{0}\t{1}", ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString());
                }
                MessageBox.Show("数据导出成功，请到程序文件所在目录下进行查看。");
                sw.Close();
                fs.Close();
            }
        }
    }
}
