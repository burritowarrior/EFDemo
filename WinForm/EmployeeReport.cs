using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace WinForm
{
    public partial class EmployeeReport : Form
    {
        private BackgroundWorker backgroundWorker;
        private List<EmployeeDTO> employeeDtos;
        public EmployeeReport()
        {
            InitializeComponent();
            employeeDtos = new List<EmployeeDTO>();
            backgroundWorker = new BackgroundWorker();
        }

        private void EmployeeReport_Load(object sender, EventArgs e)
        {
            label1.Text = string.Format("Started load operation at: {0:hh:mm:ss tt}", DateTime.Now);

            // DoWorkEventArgs
            backgroundWorker.DoWork += (o, args) =>
                {
                    Invoke(new MethodInvoker(() => { label2.Text = @"Generating data..."; }));
                    args.Result = ReadFile();
                };

            // RunWorkerCompletedEventArgs
            backgroundWorker.RunWorkerCompleted += (o, args) =>
                {
                    var itemCount = (int) args.Result;
                    label2.Text = string.Format("Ended load operation at: {0:hh:mm:ss tt}", DateTime.Now);
                    label3.Text = string.Format("There are {0:#,#} rows", itemCount);
                };

            backgroundWorker.RunWorkerAsync();
            this.reportViewer1.RefreshReport();
        }

        private int ReadFile()
        {
            int lineCount = 0;

            const string inputFile = @"SampleData.csv";
            if (File.Exists(inputFile))
            {
                using (var streamReader = new StreamReader(inputFile))
                {
                    var line = streamReader.ReadLine();
                    while (line != null)
                    {
                        var tokens = line.Split(new[] {','});
                        var item = new EmployeeDTO
                            {
                                EmployeeID = Convert.ToInt32(tokens[0]),
                                EmployeeName = tokens[1],
                                HoursWorked = Convert.ToDecimal(tokens[2]),
                                PayRate = Convert.ToDecimal(tokens[3]),
                                GrossPay = Convert.ToDecimal(tokens[4])
                            };
                        employeeDtos.Add(item);
                        line = streamReader.ReadLine();
                    }
                    lineCount = employeeDtos.Count;
                }
            }

            return lineCount;
        }
    }
}
