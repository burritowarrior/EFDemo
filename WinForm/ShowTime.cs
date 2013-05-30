using System;
using System.Windows.Forms;

namespace WinForm
{
    public partial class ShowTime : Form
    {
        public ShowTime()
        {
            InitializeComponent();
            var timer = new System.Threading.Timer(ShowTimeOnForm, null, 0, 1000);
        }

        private void ShowTimeOnForm(object state)
        {
            // Don't do anything if the form's handle hasn't been created 
            // or the form has been disposed.
            if (!IsHandleCreated && !IsDisposed) return;

            Invoke((MethodInvoker) (() => Text = DateTime.Now.ToLongTimeString()));
        }
    }
}
