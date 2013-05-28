using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AutoMapper;

namespace WinForm
{
    public partial class Form3 : Form
    {
        private readonly sakilaEntities context;
        private List<PersonDTO> personDtos;

        public Form3()
        {
            InitializeComponent();
            context = new sakilaEntities();
        }

        // Perform mapping from EF to custom object
        private void Form3_Load(object sender, EventArgs e)
        {
            // TextInfo ti = new CultureInfo("en-us", false).TextInfo;
            personDtos = (from c in context.customers
                          where c.last_name.StartsWith("s")
                          select new PersonDTO
                              {
                                  Name = c.first_name + " " + c.last_name,
                                  EmailAddress = c.email
                              }).ToList();
            dataGridView1.DataSource = personDtos;

            PerformDynamicMapping();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var c in context.customers.Where(c => c.last_name.StartsWith("s")))
                {

                    var person = personDtos.First(p => p.EmailAddress == c.email);
                    var tokens = person.Name.Split(new[] { ' ' });
                    c.first_name = tokens[0];
                    c.last_name = tokens[1];
                    c.email = person.EmailAddress;

                }
                context.SaveChanges();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void PerformDynamicMapping()
        {
            var items = from c in context.customers
                        where c.last_name.StartsWith("e")
                        select new
                        {
                            Name = c.first_name + " " + c.last_name,
                            EmailAddress = c.email
                        };

            dataGridView2.DataSource = items.Select(Mapper.DynamicMap<PersonDTO>).ToList();
        }
        private void DoNothing()
        {
            //var items = from c in context.customers.Include("address")
            //            where c.last_name.StartsWith("s")
            //            select new PersonDTO
            //            {
            //                Name = c.first_name + " " + c.last_name,
            //                EmailAddress = c.address.address1
            //            };            
        }
    }
}
