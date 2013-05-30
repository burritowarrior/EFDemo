using System;
using System.Linq;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Form1 : Form
    {
        private readonly sakilaEntities context;

        public Form1()
        {
            InitializeComponent();
            context = new sakilaEntities();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // dataGridView1.DataSource = context.customers.Where(c => c.last_name.StartsWith("s")).ToList();
            dataGridView1.DataSource = context.countries.ToList();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
        }

        private void form2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.ShowDialog();
        }

        private void form3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form3 = new Form3();
            form3.ShowDialog();
        }

        private void mainFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
        }

        private void mainFormToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainForm2 mainForm2 = new MainForm2();
            mainForm2.ShowDialog();
        }

        private void threadFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThreadForm threadForm = new ThreadForm();
            threadForm.ShowDialog();
        }

        private void testHarnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestHarness testHarness = new TestHarness();
            testHarness.ShowDialog();
        }

        private void showTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowTime showTime = new ShowTime();
            showTime.ShowDialog();
        }

        private void sampleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeReport employeeReport = new EmployeeReport();
            employeeReport.ShowDialog();
        }
    }
}
