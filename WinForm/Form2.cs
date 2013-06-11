using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using AutoMapper;

namespace WinForm
{
    public partial class Form2 : Form
    {
        private const string CONNECTION_STRING = @"server=localhost;User Id=sqluser;Password=sqluser;database=sakila";
        private const string SQL_QUERY = @"SELECT country_id, country, last_update FROM sakila.country";
        private readonly List<CountryDTO> countries;

        public Form2()
        {
            InitializeComponent();
            countries = new List<CountryDTO>();
            SimpleConvert();
            ConvertObjects();
            ConvertNestedObject();
        }

        // What we're trying to move away from
        private void Form2_Load(object sender, EventArgs e)
        {
            using (var sqlConnection = new MySqlConnection(CONNECTION_STRING))
            using (var sqlCommand = new MySqlCommand(SQL_QUERY, sqlConnection))
            {
                sqlConnection.Open();
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    countries.Add(new CountryDTO
                        {
                            // CountryId = (reader.IsDBNull(0)) ? 0 : Convert.ToInt32(reader[0]),
                            CountryId = reader.SafeConvertTo<int>(0),
                            Country = reader.SafeConvert(1),
                            LastUpdate = reader.SafeConvertTo<DateTime>(2)
                        });
                }
            }

            comboBoxCities.DataSource = countries;
            comboBoxCities.DisplayMember = "Country";
            comboBoxCities.ValueMember = "CountryId";
        }

        private void SimpleConvert()
        {
            Car firstCar = new Car {Year = 2010, Make = "Chevrolet", Model = "Camaro"};
            Mapper.CreateMap<Car, FastCar>();
            FastCar secondCar = Mapper.Map<Car, FastCar>(firstCar);
            label3.Text = secondCar.ToString();
        }

        private void ConvertObjects()
        {
            Mapper.CreateMap<Employee, EmployeeViewItem>()
               .ForMember(ev => ev.Address,
                           m => m.MapFrom(a => a.Address.City + ", " +
                                               a.Address.Street + " " +
                                               a.Address.Number)
                          )
               .ForMember(ev => ev.Gender,
                           m => m.ResolveUsing<GenderResolver>().FromMember(e => e.Gender))
               .ForMember(ev => ev.StartDate, m => m.AddFormatter<DateFormatter>());

            var employee = new Employee
            {
                Name = "John SMith",
                Email = "john@codearsenal.net",
                Address = new Address
                {
                    Country = "USA",
                    City = "New York",
                    Street = "Wall Street",
                    Number = 7
                },
                Position = "Manager",
                Gender = true,
                Age = 35,
                YearsInCompany = 5,
                StartDate = new DateTime(2007, 11, 2)
            };

            EmployeeViewItem employeeVIewItem = Mapper.Map<Employee, EmployeeViewItem>(employee);
            Text = @"Conversion Success";
        }

        private void ConvertNestedObject()
        {
            var student = new Student
                {
                    FirstName = "Joe",
                    LastName = "Smith",
                    Major = "Anthropology",
                    Grades = new List<Grade>
                        {
                            new Grade { ClassName = "Music", Score = 82},
                            new Grade { ClassName = "Math", Score = 87},
                            new Grade { ClassName = "Latin", Score = 91},
                            new Grade { ClassName = "Nutrition", Score = 96},
                        }
                };

            Mapper.CreateMap<Student, StudentOverview>()
                  .ForMember(so => so.StudentName,
                             m => m.MapFrom(s => s.LastName + ", " + s.FirstName)
                )
                  .ForMember(ev => ev.StudentAverage,
                             m => m.ResolveUsing<GradeResolver>().FromMember(s => s.Grades));

            StudentOverview studentOverview = Mapper.Map<Student, StudentOverview>(student);
            Text = @"Completed!";
        }

        private void buttonGetData_Click(object sender, EventArgs e)
        {
            comboBoxDTOs.DataSource = GetCountryList();
            comboBoxDTOs.DisplayMember = "Country";
            comboBoxDTOs.ValueMember = "CountryId";
        }

        public List<CountryDTO> GetCountryList()
        {
            using (DbConnection connection = new MySqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                return connection.Query<CountryDTO>(SQL_QUERY, commandType: CommandType.Text).ToList();
            }
        }
    }

    public class Car
    {
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }

    public class FastCar
    {
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        public override string ToString()
        {
            // return base.ToString();
            return string.Format("Year: {0} - Make: {1} - Model: {2}", Year, Make, Model);
        }
    }
}
