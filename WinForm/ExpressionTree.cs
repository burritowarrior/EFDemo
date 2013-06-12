using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace WinForm
{
    public partial class ExpressionTree : Form
    {
        public ExpressionTree()
        {
            InitializeComponent();
        }

        private void ExpressionTree_Load(object sender, EventArgs e)
        {
            // Manually build the expression tree for the lambda expression n => n < 1
            ParameterExpression numParam = Expression.Parameter(typeof (int), "n");
            ConstantExpression one = Expression.Constant(1, typeof (int));
            BinaryExpression numberLessThanOne = Expression.LessThan(numParam, one);

            Expression<Func<int, bool>> lambdaExpression =
                Expression.Lambda<Func<int, bool>>(
                    numberLessThanOne,
                    new ParameterExpression[] {numParam});

            var numberSource = new[] {-5, -3, -1, 1, 3, 5};
            var numbers = new List<int>(numberSource);
            var smallerNumbers = numbers.Where(lambdaExpression.Compile());

            Array.ForEach(smallerNumbers.ToArray(), Console.WriteLine);

            var context = new sakilaEntities();

            var data = context.customers.Where(c => c.customer_id == 33);

            int[] customerIDs = new int[] {33};

            Expression<Func<customer, bool>> whereClause =
                customerIDs.BuildOrExpressionTreeExtension<customer, int>(c => c.customer_id);
            IQueryable<customer> customers = context.customers.Where(whereClause);
            var selectedItem = customers.ToList().FirstOrDefault();
            if (selectedItem != null)
            {
                Console.WriteLine(selectedItem.first_name);
            }
        }
    }
}
