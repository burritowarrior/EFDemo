using System;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WinForm
{
    public partial class ThreadForm : Form
    {
        public ThreadForm()
        {
            InitializeComponent();
        }

        // Creates a delegate with the same signature as the method used for a long operation
        // In this case we'll use SomeLongOperation()
        private delegate bool SomeLongOperationDelegate();

        // Creates a delegate with the same signature as the method used to update the UI
        // In this case we'll use UpdateUIHelper(string value)
        private delegate void UpdateUIDelegate(string value);

        // Creates a delegate with the same signature as the method used to set form controls
        // In this case we'll use SetFormControls(bool Enabled)
        private delegate void SetFormControlsDelegate(bool enabled);

        /// <summary>
        /// User actions start the long-running operation
        /// Step 1, 2 and 3
        /// </summary>
        private void buttonGo_Click(object sender, EventArgs e)
        {
            SetFormControls(false);

            UpdateUI("Starting...");

            // create an instance of SomeLongOperationDelegate
            SomeLongOperationDelegate someLongOperationDelegate = SomeLongOperation;

            // start asynchronous operation, pass someLongOperationDelegate as a parameter, so we can get it back later on callback
            someLongOperationDelegate.BeginInvoke(SomeLongOperationCallBack, someLongOperationDelegate);
        }

        /// <summary>
        /// Sets any controls on the form that you want to have set prior to starting the long operation
        /// </summary>
        /// <param name="enabled">Enable or disable controls</param>
        private void SetFormControls(bool enabled)
        {
            // update any controls here, if you want to (such as enable or disable controls)
            // buttonGo.Enabled = Enabled;
        }

        /// <summary>
        /// Long operation such as a call to the database
        /// Step 4
        /// </summary>
        /// <returns>bool value to indicate success</returns>
        private bool SomeLongOperation()
        {
            // perform some longish operation

            for (var i = 1; i < 8; i++)
            {
                UpdateUI(
                    new StringBuilder("Operation busy ").
                        Append(i.ToString(CultureInfo.InvariantCulture)).
                        Append("... (Managed TID: ").
                        Append(Thread.CurrentThread.ManagedThreadId.ToString(CultureInfo.InvariantCulture)).
                        Append(")").ToString());

                Thread.Sleep(150);
            }

            return true;
        }

        /// <summary>
        /// CallBack for the someLongOperationDelegate instance
        /// Step 5 and 6
        /// </summary>
        /// <param name="result">IAsyncResult object</param>
        private void SomeLongOperationCallBack(IAsyncResult result)
        {
            // original delegate passed in the asyncState parameter, get it back here
            ((SomeLongOperationDelegate)result.AsyncState).EndInvoke(result);

            // update the user interface
            UpdateUI(
                new StringBuilder("CallBack (Managed TID: ").
                    Append(Thread.CurrentThread.ManagedThreadId.ToString(CultureInfo.InvariantCulture)).
                    Append(")").ToString());

            // start an asynchronous operation to set the controls on the form
            // BeginInvoke(new SetFormControlsDelegate(SetFormControls), new object[] { true });
            BeginInvoke(new SetFormControlsDelegate(SetFormControls), new object[] { true });
        }

        /// <summary>
        /// Checks whether or not an Invoke is required and calls the method accordingly
        /// </summary>
        /// <param name="value">value of string to go into the listbox</param>
        private void UpdateUI(string value)
        {
            // There are two different ways of invoking a method on the UI thread, one synchronous
            // (Invoke) and one asynchronous (BeginInvoke).  They work in much the same way - you 
            // specify a delegate and (optionally) some arguments, and a message goes on the queue for the 
            // UI thread to process.  If you use Invoke, the current thread will block until the delegate 
            // has been executed.  If you use BeginInvoke, the call will return immediately.  If you need to 
            // get the return value of a delegate invoked aysnchronously, you can use EndInvoke with the 
            // IAsyncResult returned by BeginInvoke to wait until the delegate has completed and fetch 
            // the return value

            // if the calling thread is not the same thread that created the controls to be updated
            // call an Invoke to update controls
            if (InvokeRequired)
            {
                // Invoke(new UpdateUIDelegate(UpdateUIHelper), new object[] { value });
                // Invoke(new MethodInvoker(delegate
                // {
                //     UpdateUI(value);
                // }));
                // BeginInvoke(new MethodInvoker(delegate
                // {
                //     UpdateUI(value);
                // }));
                Invoke(new MethodInvoker(() => UpdateUI(value)));
            }
            else
                UpdateUIHelper(value);
        }

        /// <summary>
        /// Updates the user interface with whatever needs to be updated
        /// </summary>
        /// <param name="value">value of string to go into the listbox</param>
        private void UpdateUIHelper(string value)
        {
            listboxResults.Items.Add(
                new StringBuilder(value).
                    Append(" (Parent Managed TID: ").
                    Append(Thread.CurrentThread.ManagedThreadId.ToString(CultureInfo.InvariantCulture)).
                    Append(")").ToString());

            listboxResults.SelectedIndex = (listboxResults.Items.Count - 1);
        }
    }
}
