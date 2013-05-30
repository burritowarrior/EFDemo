using System.Windows.Forms;
using System.ComponentModel;

namespace WinForm
{
    public class AutoCompleteComboBox : ComboBox
    {
        public event CancelEventHandler NotInList;

        private bool limitToList = true;
        private bool inEditMode;

        [Category("Behavior")]
        public bool LimitToList
        {
            get { return limitToList; }
            set { limitToList = value; }
        }

        protected virtual void OnNotInList(CancelEventArgs e)
        {
            if (NotInList != null)
            {
                NotInList(this, e);
            }
        }   

        protected override void OnTextChanged(System.EventArgs e)
        {
            if (inEditMode)
            {
                string input = Text;
                int index = FindString(input);
                System.Diagnostics.Debug.WriteLine("The position is: {0}", index);
                if (index >= 0)
                {
                    inEditMode = false;
                    SelectedIndex = index;
                    inEditMode = true;
                    Select(input.Length, Text.Length);
                }
            }

            base.OnTextChanged(e);
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            if (LimitToList)
            {
                int pos = FindStringExact(Text);
        
                if (pos == -1)
                {
                    OnNotInList(e);
                }
                else
                {
                    SelectedIndex = pos;
                }
            }

            base.OnValidating(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            inEditMode = (e.KeyCode != Keys.Back && e.KeyCode != Keys.Delete);
            base.OnKeyDown(e);
        }
    }
}