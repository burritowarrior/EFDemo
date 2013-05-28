using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class MainForm2 : Form
    {
        public MainForm2()
        {
            InitializeComponent();
        }

        // http://mnairooz.blogspot.com/2010/07/implementing-asynchronous-callbacks.html
        private void MainForm2_Load(object sender, EventArgs e)
        {
            var parent = new Task<int>(() =>
            {
                MessageBox.Show(@"In parent");
                return 100; 
            });


            Task<int> child = parent.ContinueWith( a =>
            {
                MessageBox.Show(@"In Child");
                return 19 + a.Result;
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            parent.Start();

            Task.Factory.StartNew(() =>
                {
                    MessageBox.Show(@"In the lone parent...");
                    return "some";
                }).ContinueWith(t =>
                    {
                        MessageBox.Show(@"In the lone child");
                        label2.Text = string.Format("{0} data", t.Result.ToString(CultureInfo.InvariantCulture));
                    }, TaskScheduler.FromCurrentSynchronizationContext());




            // MessageBox.Show(child.Result.ToString());
            label1.Text = child.Result.ToString(CultureInfo.InvariantCulture);
        }
    }
}
