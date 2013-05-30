using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinForm
{
    public partial class TestHarness : Form
    {
        public TestHarness()
        {
            InitializeComponent();
        }

        private CustomAutoCompleteTextbox clsCustomAutoCompleteTextbox1;

        private List<string> masterList = new List<string>();

        private DataTable dt;

        private void TestHarness_Load(object sender, EventArgs e)
        {
            clsCustomAutoCompleteTextbox1 = new CustomAutoCompleteTextbox
            {
                AutoCompleteFormBorder = FormBorderStyle.None,
                AutoCompleteList = null,
                Location = new Point(27, 57),
                Name = "CustomAutoCompleteTextbox1",
                OnEnterSelect = true,
                SelectionMethods = CustomAutoCompleteTextbox.SelectOptions.OnEnterSingleClick,
                SelectTextAfterItemSelect = true,
                ShowAutoCompleteOnFocus = false,
                Size = new Size(232, 20),
                TabIndex = 0
            };

            Controls.Add(clsCustomAutoCompleteTextbox1);

            clsCustomAutoCompleteTextbox1.BeforeDisplayingAutoComplete += BeforeDisplayingAutoComplete;

            var accountValues = new List<string>
                {
                    "123123 - Bob", 
                    "534543 - Sally", 
                    "123123 - George", 
                    "34213 - Happy",
                    "78214 - Jelly",
                    "20539 - Sammy",
                    "47193 - Grumpy",
                    "32123 - Sleepy",
                    "48292 - Dopey"
                };
            masterList = accountValues;
            clsCustomAutoCompleteTextbox1.AutoCompleteList = accountValues;

            var autoCompleteComboBox = new AutoCompleteComboBox
                {
                    Location = new Point(27, 157),
                    Size = new Size(232, 20)
                };

            autoCompleteComboBox.Items.Add("Apples");
            autoCompleteComboBox.Items.Add("Oranges");
            autoCompleteComboBox.Items.Add("Grapefruits");
            autoCompleteComboBox.Items.Add("Pears");
            autoCompleteComboBox.Items.Add("Strawberries");
            autoCompleteComboBox.Items.Add("Cantaloupe");
            autoCompleteComboBox.Items.Add("Mango");
            autoCompleteComboBox.Items.Add("Peaches");

            autoCompleteComboBox.LimitToList = true;
            autoCompleteComboBox.NotInList += (o, args) =>
                {

                };

            Controls.Add(autoCompleteComboBox);

            dt = new DataTable();
            // dt.Columns.Add("colNumbers", typeof (int));
            dt.Columns.Add("colCustomers", typeof(string));
            dt.Rows.Add(new object[] { "1 John" });
            dt.Rows.Add(new object[] { "2 Kate" });
            dt.Rows.Add(new object[] { "3 Jill" });
            dt.Rows.Add(new object[] { "4 Jonas" });
            dt.Rows.Add(new object[] { "5 Karen" });
            dt.Rows.Add(new object[] { "6 Kevin" });

            comboBox1.DataSource = dt.DefaultView; //allows us to filter the results
            comboBox1.DisplayMember = "colCustomers";
        }

        private void BeforeDisplayingAutoComplete(object sender, CustomAutoCompleteTextbox.AutoCompleteEventArgs e)
        {
            string name = clsCustomAutoCompleteTextbox1.Text.ToLower();
            var display = masterList.Where(str => (str.ToLower().IndexOf(name, StringComparison.Ordinal) > -1)).ToList();

            e.AutoCompleteList = display;
            e.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                dt.DefaultView.RowFilter = "colCustomers LIKE '%" + comboBox1.Text + "%'";
            }
        }
    }
}
