using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace WinForm
{
    public class CustomAutoCompleteTextbox : TextBox
    {
        private bool first = true;
        public List<string> Test = new List<string>();
        public int Tabs = 0;
        private int mSelStart;
        private List<string> myAutoCompleteList = new List<string>();
        private readonly ListBox listBox = new ListBox();
        private readonly Form formInstance = new Form();
        private Form myParentForm;
        private bool suspendFocus;
        private AutoCompleteEventArgs args;
        private readonly Timer hideTimer = new Timer();
        private readonly Timer focusTimer = new Timer();
        private SelectOptions mySelectionMethods = (SelectOptions.OnDoubleClick | SelectOptions.OnEnterPress);
        private bool mySelectTextAfterItemSelect = true;
        private int cnt;

        public bool SelectTextAfterItemSelect
        {
            get
            {
                return mySelectTextAfterItemSelect;
            }
            set
            {
                mySelectTextAfterItemSelect = value;
            }
        }

        [System.ComponentModel.Browsable(false)]
        public SelectOptions SelectionMethods
        {
            get
            {
                return mySelectionMethods;
            }
            set
            {
                mySelectionMethods = value;
            }
        }

        public bool OnEnterSelect { get; set; }

        public FormBorderStyle AutoCompleteFormBorder { get; set; }

        public bool ShowAutoCompleteOnFocus { get; set; }

        public ListBox ListBoxDisplay
        {
            get
            {
                return listBox;
            }
        }

        public List<string> AutoCompleteList { get; set; }

        public event EventHandler<AutoCompleteEventArgs> BeforeDisplayingAutoComplete;

        public event EventHandler<ItemSelectedEventArgs> ItemSelected;

        [Flags]
        public enum SelectOptions
        {
            None = 0,

            OnEnterPress = 1,

            OnSingleClick = 2,

            OnDoubleClick = 4,

            OnTabPress = 8,

            OnRightArrow = 16,

            OnEnterSingleClick = 3,

            OnEnterSingleDoubleClicks = 7,

            OnEnterDoubleClick = 5,

            OnEnterTab = 9,
        }

        public class AutoCompleteEventArgs : EventArgs
        {
            public int SelectedIndex { get; set; }

            public bool Cancel { get; set; }

            public List<string> AutoCompleteList { get; set; }
        }

        public CustomAutoCompleteTextbox()
        {
            AutoCompleteFormBorder = FormBorderStyle.None;
            hideTimer.Tick += HideTimer_Tick;
            focusTimer.Tick += FocusTimer_Tick;

            listBox.Click += myLbox_Click;
            listBox.DoubleClick += myLbox_DoubleClick;
            listBox.GotFocus += myLbox_GotFocus;
            listBox.KeyDown += myLbox_KeyDown;

            listBox.KeyUp += myLbox_KeyUp;
            listBox.LostFocus += myLbox_LostFocus;
            listBox.MouseClick += myLbox_MouseClick;
            listBox.MouseDoubleClick += myLbox_MouseDoubleClick;
            listBox.MouseDown += myLbox_MouseDown;


            GotFocus += CustomAutoCompleteTextbox_GotFocus;
            KeyDown += CustomAutoCompleteTextbox_KeyDown;
            Leave += CustomAutoCompleteTextbox_Leave;
            LostFocus += CustomAutoCompleteTextbox_LostFocus;
            Move += CustomAutoCompleteTextbox_Move;
            ParentChanged += CustomAutoCompleteTextbox_ParentChanged;
        }

        override protected void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            ShowOnChar(new string(((char)(e.KeyValue)), 1));
        }

        private void ShowOnChar(string c)
        {
            if (IsPrintChar(c))
            {
                ShowAutoComplete();
            }
        }

        private bool IsPrintChar(int c)
        {
            return IsPrintChar(((char)(c)));
        }

        private bool IsPrintChar(char c)
        {
            return IsPrintChar(c.ToString(CultureInfo.InvariantCulture));
        }

        private bool IsPrintChar(string c)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(c, "[^\\t\\n\\r\\f\\v]");
        }

        private void CustomAutoCompleteTextbox_GotFocus(object sender, EventArgs e)
        {
            if ((!suspendFocus
                        && (ShowAutoCompleteOnFocus
                        && (formInstance.Visible == false))))
            {
                ShowAutoComplete();
            }
        }

        private void CustomAutoCompleteTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!SelectItem(e.KeyCode, false, false))
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        if ((listBox.SelectedIndex > 0))
                        {
                            MoveLBox((listBox.SelectedIndex - 1));
                        }
                        break;
                    case Keys.Down:
                        MoveLBox((listBox.SelectedIndex + 1));
                        break;
                }
            }
        }

        private void MoveLBox(int index)
        {
            try
            {
                if ((index > (listBox.Items.Count - 1)))
                {
                    index = (listBox.Items.Count - 1);
                }
                listBox.SelectedIndex = index;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void CustomAutoCompleteTextbox_Leave(object sender, EventArgs e)
        {
            DoHide();
        }

        private void CustomAutoCompleteTextbox_LostFocus(object sender, EventArgs e)
        {
            DoHide();
        }

        private void CustomAutoCompleteTextbox_Move(object sender, EventArgs e)
        {

            MoveDrop();

        }

        private void CustomAutoCompleteTextbox_ParentChanged(object sender, EventArgs e)
        {
            //if (myParentForm != null) myParentForm.Deactivate -= new EventHandler(myParentForm_Deactivate);
            //myParentForm = GetParentForm(this);
            //if (myParentForm != null) myParentForm.Deactivate += new EventHandler(myParentForm_Deactivate);
        }

        private void HideTimer_Tick(object sender, EventArgs e)
        {

            MoveDrop();
            DoHide();
            cnt++;
            if ((cnt <= 300)) return;
            if (!AppHasFocus(""))
            {
                DoHideAuto();
            }
            cnt = 0;
        }

        private void myLbox_Click(object sender, EventArgs e)
        {
        }

        private void myLbox_DoubleClick(object sender, EventArgs e)
        {
        }

        private bool SelectItem(Keys key, bool singleClick)
        {
            return SelectItem(key, singleClick, false);
        }

        private bool SelectItem(Keys key)
        {
            return SelectItem(key, false, false);
        }

        private bool SelectItem(Keys key, bool singleClick, bool doubleClick)
        {

            // Warning!!! Optional parameters not supported
            // Warning!!! Optional parameters not supported
            // Warning!!! Optional parameters not supported
            bool doSelect = true;
            var meth = SelectOptions.None;

            if (((mySelectionMethods & SelectOptions.OnEnterPress) > 0) && (key == Keys.Enter))
            {
                meth = SelectOptions.OnEnterPress;
            }
            else if (((mySelectionMethods & SelectOptions.OnRightArrow) > 0) && key == Keys.Right)
            {
                meth = SelectOptions.OnRightArrow;
            }
            else if (((mySelectionMethods & SelectOptions.OnTabPress) > 0) && key == Keys.Tab)
            {
                meth = SelectOptions.OnTabPress;
            }
            else if (((mySelectionMethods & SelectOptions.OnSingleClick) > 0) && singleClick)
            {
                meth = SelectOptions.OnEnterPress;
            }
            else if (((mySelectionMethods & SelectOptions.OnDoubleClick) > 0) && doubleClick)
            {
                meth = SelectOptions.OnEnterPress;
            }
            else
            {
                doSelect = false;
            }

            if (doSelect)
            {
                DoSelectItem(meth);
            }

            return doSelect;
        }

        public class ItemSelectedEventArgs : EventArgs
        {
            public ItemSelectedEventArgs() { }

            public ItemSelectedEventArgs(int index, SelectOptions method, string itemText)
            {
                Index = index;
                Method = method;
                ItemText = itemText;
            }

            public string ItemText { get; set; }

            public SelectOptions Method { get; set; }

            public int Index { get; set; }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern int GetWindowThreadProcessId(IntPtr hWnd, ref int processID);

        private bool AppHasFocus(string exeNameWithoutExtension)
        {
            bool Out = false;

            // Warning!!! Optional parameters not supported
            int pid = 0;

            if ((exeNameWithoutExtension == ""))
            {
                exeNameWithoutExtension = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            }

            IntPtr activeHandle = GetForegroundWindow();
            GetWindowThreadProcessId(activeHandle, ref pid);
            if ((pid > 0))
            {
                // For Each p As Process In Process.GetProcessesByName(ExeNameWithoutExtension)
                if ((pid == System.Diagnostics.Process.GetCurrentProcess().Id))
                {
                    Out = true;
                }
                //  Next
            }

            return Out;
        }

        private void SaveSelects()
        {
            mSelStart = SelectionStart;
        }

        private void LoadSelects()
        {
            SelectionStart = mSelStart;
        }

        private void ShowAutoComplete()
        {
            args = new AutoCompleteEventArgs {Cancel = false, AutoCompleteList = myAutoCompleteList};
            // With...
            if ((listBox.SelectedIndex == -1))
            {
                args.SelectedIndex = 0;
                System.Diagnostics.Debug.WriteLine("Always {0}", args.SelectedIndex);
            }
            else
            {
                args.SelectedIndex = listBox.SelectedIndex;
                System.Diagnostics.Debug.WriteLine("Not always {0}", args.SelectedIndex);
            }

            if (BeforeDisplayingAutoComplete != null) BeforeDisplayingAutoComplete(this, args);
            myAutoCompleteList = args.AutoCompleteList;

            if ((!args.Cancel && (args.AutoCompleteList != null) && args.AutoCompleteList.Count > 0))
            {
                DoShowAuto();
            }
            else
            {
                DoHideAuto();
            }

        }

        private void DoShowAuto()
        {
            SaveSelects();

            listBox.BeginUpdate();
            try
            {
                listBox.Items.Clear();
                if (myAutoCompleteList != null) listBox.Items.AddRange(myAutoCompleteList.ToArray());
                MoveLBox(args.SelectedIndex);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            listBox.EndUpdate();
            myParentForm = GetParentForm(this);
            if (myParentForm != null)
            {
                listBox.Name = ("mmmlbox" + DateTime.Now.Millisecond);
                if ((formInstance.Visible == false))
                {
                    formInstance.Font = Font;
                    listBox.Font = Font;
                    listBox.Visible = true;
                    formInstance.Visible = false;
                    formInstance.ControlBox = false;
                    formInstance.Text = "";
                    if (first)
                    {
                        formInstance.Width = Width;
                        formInstance.Height = 200;
                    }
                    first = false;
                    if (!formInstance.Controls.Contains(listBox))
                    {
                        formInstance.Controls.Add(listBox);
                    }
                    formInstance.FormBorderStyle = FormBorderStyle.None;
                    formInstance.ShowInTaskbar = false;
                    // With...
                    listBox.Dock = DockStyle.Fill;
                    listBox.SelectionMode = SelectionMode.One;
                    // Frm.Controls.Add(myLbox)
                    suspendFocus = true;
                    formInstance.TopMost = true;
                    formInstance.FormBorderStyle = AutoCompleteFormBorder;
                    formInstance.BringToFront();
                    MoveDrop();
                    formInstance.Visible = true;
                    formInstance.Show();
                    MoveDrop();
                    hideTimer.Interval = 10;
                    Focus();
                    suspendFocus = false;
                    hideTimer.Enabled = true;
                    LoadSelects();
                }
            }

        }

        void MoveDrop()
        {

            // Point pnt = new Point(Left, (Top + (Height + 2)));
            Point screenPnt = PointToScreen(new Point(-2, Height));

            // Dim FrmPnt As Point = Frm.PointToClient(ScreenPnt)
            if (formInstance != null)
            {
                formInstance.Location = screenPnt;
                // myForm.BringToFront()
                // myForm.Focus()
                // myLbox.Focus()
                // Me.Focus()
            }

        }

        void DoHide()
        {

            HideAuto();

        }

        private void DFocus(int delay)
        {
            // Warning!!! Optional parameters not supported
            focusTimer.Interval = delay;
            focusTimer.Start();
        }

        private void DFocus()
        {
            DFocus(10);
        }

        private void DoHideAuto()
        {

            formInstance.Hide();
            hideTimer.Enabled = false;
            focusTimer.Enabled = false;

        }

        private void HideAuto()
        {

            if ((formInstance.Visible && HasLostFocus()))
            {
                DoHideAuto();
            }

        }

        private bool HasLostFocus()
        {
            return formInstance == null || formInstance.ActiveControl != listBox || 
                (myParentForm == null || myParentForm.ActiveControl != this);
        }

        private Form GetParentForm(Control inControl)
        {
            var topControl = FindTopParent(inControl) as Form;
            return topControl;
        }

        private Control FindTopParent(Control inCon)
        {
            return (inCon.Parent == null) ? inCon : FindTopParent(inCon.Parent);
        }

        private void DoSelectItem(SelectOptions method)
        {
            System.Diagnostics.Debug.WriteLine("At position: {0}", listBox.SelectedIndex);
            if (((listBox.Items.Count > 0) && (listBox.SelectedIndex > -1)))
            {
                string value = listBox.SelectedItem.ToString();
                string orig = Text;
                Text = value;
                if (mySelectTextAfterItemSelect)
                {
                    try
                    {
                        SelectionStart = orig.Length;
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                    }
                }

                var itemSelectedEventArgs = new ItemSelectedEventArgs
                    {
                        Index = listBox.SelectedIndex,
                        Method = method,
                        ItemText = value
                    };

                if (ItemSelected != null) ItemSelected(this, itemSelectedEventArgs);

                //ItemSelected(this, new clsItemSelectedEventArgs(myLbox.SelectedIndex, Method, Value));
                DoHideAuto();
            }

        }

        private void myLbox_GotFocus(object sender, EventArgs e)
        {
            DFocus();
        }

        private void myLbox_KeyDown(object sender, KeyEventArgs e)
        {
            SelectItem(e.KeyCode);
        }

        private void myLbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (IsPrintChar(e.KeyValue))
            {
                // Me.OnKeyUp(e)
                // Call MoveDrop()
            }
        }

        private void myLbox_LostFocus(object sender, EventArgs e)
        {
            DoHide();
        }

        private void myLbox_MouseClick(object sender, MouseEventArgs e)
        {

            // If e.Button <> Windows.Forms.MouseButtons.None Then
            SelectItem(Keys.None, true);
            // End If

        }

        private void myLbox_MouseDoubleClick(object resender, MouseEventArgs mouseEventArgs)
        {
            // If e.Button <> Windows.Forms.MouseButtons.None Then
            SelectItem(Keys.None, false, true);
            // End If
        }

        //private void myForm_Deactivate(object sender, EventArgs e)
        //{


        //}

        //private void myParentForm_Deactivate(object sender, EventArgs e)
        //{


        //}

        private void FocusTimer_Tick(object resender, EventArgs ea)
        {

            Focus();

        }

        private void myLbox_MouseDown(object resender, MouseEventArgs ea)
        {
            myLbox_MouseClick(resender, ea);
        }
    }
}
