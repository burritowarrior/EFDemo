using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class MainForm : Form
    {
        private readonly Button startButton;
        private readonly Button errorButton;
        private readonly Button cancelButton;
        private readonly ProgressBar progressBar;

        public MainForm()
        {
            InitializeComponent();

            startButton = new Button
            {
                Text = @"Start",
                Height = 23,
                Width = 75,
                Left = 12,
                Top = 12,
            };

            errorButton = new Button
            {
                Text = @"Error",
                Height = 23,
                Width = 75,
                Left = startButton.Right + 6,
                Top = 12,
            };

            cancelButton = new Button
            {
                Text = @"Cancel",
                Enabled = false,
                Height = 23,
                Width = 75,
                Left = errorButton.Right + 6,
                Top = 12,
            };

            progressBar = new ProgressBar
            {
                Width = cancelButton.Right - 12,
                Height = 23,
                Left = 12,
                Top = startButton.Bottom + 6,
            };

            startButton.Click += (sender, e) => startButton_Click(sender, e);
            errorButton.Click += (sender, e) => errorButton_Click(sender, e);
            cancelButton.Click += (sender, e) => cancelButton_Click(sender, e);

            Controls.AddRange(new Control[]
            {
                  startButton,
                  errorButton,
                  cancelButton,
                  progressBar
            });
        }

        partial void startButton_Click(object sender, EventArgs e);
        partial void errorButton_Click(object sender, EventArgs e);
        partial void cancelButton_Click(object sender, EventArgs e);

        private void TaskIsRunning()
        {
            // Update UI to reflect background task.
            startButton.Enabled = false;
            errorButton.Enabled = false;
            cancelButton.Enabled = true;
        }

        private void TaskIsComplete()
        {
            // Reset UI.
            progressBar.Value = 0;
            startButton.Enabled = true;
            errorButton.Enabled = true;
            cancelButton.Enabled = false;
        }
    }

    partial class MainForm
    {
        private CancellationTokenSource cancellationTokenSource;

        partial void startButton_Click(object sender, EventArgs e)
        {
            // Start the background task without error.
            StartBackgroundTask(false);

            // Update UI to reflect background task.
            TaskIsRunning();
        }

        partial void errorButton_Click(object sender, EventArgs e)
        {
            // Start the background task with error.
            StartBackgroundTask(true);

            // Update UI to reflect background task.
            TaskIsRunning();
        }

        partial void cancelButton_Click(object sender, EventArgs e)
        {
            // Cancel the background task.
            cancellationTokenSource.Cancel();

            // The UI will be updated by the cancellation handler.
        }

        private void StartBackgroundTask(bool causeError)
        {
            cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            var progressReporter = new ProgressReporter();
            var task = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i != 100; ++i)
                {
                    // Check for cancellation 
                    cancellationToken.ThrowIfCancellationRequested();

                    Thread.Sleep(30); // Do some work. 

                    // Report progress of the work. 
                    progressReporter.ReportProgress(() =>
                    {
                        // Note: code passed to "ReportProgress" can access UI elements freely. 
                        progressBar.Value = i;
                    });
                }

                // After all that work, cause the error if requested.
                if (causeError)
                {
                    throw new InvalidOperationException("Oops...");
                }

                // The answer, at last! 
                return 42;
            }, cancellationToken);

            // ProgressReporter can be used to report successful completion,
            //  cancelation, or failure to the UI thread. 
            progressReporter.RegisterContinuation(task, () =>
            {
                // Update UI to reflect completion.
                progressBar.Value = 100;

                // Display results.
                if (task.Exception != null)
                    MessageBox.Show(@"Background task error: " + task.Exception);
                else if (task.IsCanceled)
                    MessageBox.Show(@"Background task cancelled");
                else
                    MessageBox.Show(@"Background task result: " + task.Result);

                // Reset UI.
                TaskIsComplete();
            });
        }
    }
}
