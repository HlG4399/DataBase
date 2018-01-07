using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    public partial class SyntheticalExperimenta : Form
    {
        public SyntheticalExperimenta()
        {
            InitializeComponent();
        }

        private void btn_StudentInformation_Click(object sender, EventArgs e)
        {
            StudentInformationManagement studentinformationmanagement = new StudentInformationManagement();
            studentinformationmanagement.Location = new Point(this.Location.X + 100, this.Location.Y);
            studentinformationmanagement.ShowDialog();
        }

        private void btn_StudentAchievement_Click(object sender, EventArgs e)
        {
            StudentAchievementManagement studentachievementmanagement = new StudentAchievementManagement();
            studentachievementmanagement.ShowDialog();
        }

        private void btn_CourseMaterials_Click(object sender, EventArgs e)
        {
            CourseMaterialsManagement coursematerialsmanagement = new CourseMaterialsManagement();
            coursematerialsmanagement.ShowDialog();
        }
    }
}
