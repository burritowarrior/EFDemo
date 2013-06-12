using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WinForm
{
    public static class ExpressionTreeExtensions
    {
        private static Expression BuildBinaryOrTree<T>(IEnumerator<T> itemEnumerator,
                                                       Expression expressionToCompareTo, 
                                                       Expression expression)
        {
            if (itemEnumerator.MoveNext() == false)
                return expression;

            ConstantExpression constant = Expression.Constant(itemEnumerator.Current, typeof(T));
            BinaryExpression comparison = Expression.Equal(expressionToCompareTo, constant);

            BinaryExpression newExpression = (expression == null) ? 
                                              comparison : 
                                              Expression.OrElse(expression, comparison);

            return BuildBinaryOrTree(itemEnumerator, expressionToCompareTo, newExpression);
        }

        public static Expression<Func<TValue, bool>> BuildOrExpressionTree<TValue, TCompareAgainst>(
                IEnumerable<TCompareAgainst> wantedItems,
                Expression<Func<TValue, TCompareAgainst>> convertBetweenTypes)
        {
            ParameterExpression inputParam = convertBetweenTypes.Parameters[0];

            Expression binaryExpressionTree = BuildBinaryOrTree(wantedItems.GetEnumerator(), convertBetweenTypes.Body, null);

            return Expression.Lambda<Func<TValue, bool>>(binaryExpressionTree, new[] { inputParam });
        }

        public static Expression<Func<TValue, bool>> BuildOrExpressionTreeExtension<TValue, TCompareAgainst>(
                this IEnumerable<TCompareAgainst> wantedItems,
                Expression<Func<TValue, TCompareAgainst>> convertBetweenTypes)
        {
            ParameterExpression inputParam = convertBetweenTypes.Parameters[0];

            Expression binaryExpressionTree = BuildBinaryOrTree(wantedItems.GetEnumerator(), convertBetweenTypes.Body, null);

            return Expression.Lambda<Func<TValue, bool>>(binaryExpressionTree, new[] { inputParam });
        }
    }
}
