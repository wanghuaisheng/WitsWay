using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using WitsWay.TempTests.DynamicQuery.Enums;
using WitsWay.TempTests.DynamicQuery.Extends;

namespace WitsWay.TempTests.DynamicQuery.Factorys
{

    /// <summary>
    /// 表达式工厂
    /// </summary>
    public static class ExpressionFactory
    {
        /// <summary>
        /// 日期Parse是否转换为UTC
        /// </summary>
        public static bool ParseDatesAsUtc { get; set; }

        public static Expression GetExpression(SupportRelations kind, Expression propertyExp)
        {
            return GetExpression(kind, propertyExp, null, null);
        }

        public static Expression GetExpression(SupportRelations kind, Expression propertyExp, Type type, string value)
        {
            switch (kind)
            {
                case SupportRelations.IsNull: return IsNull(propertyExp);
                case SupportRelations.IsNotNull: return IsNotNull(propertyExp);
                case SupportRelations.IsEmpty: return IsEmpty(propertyExp);
                case SupportRelations.IsNotEmpty: return IsNotEmpty(propertyExp);
                case SupportRelations.Contains: return Contains(type, value, propertyExp);
                case SupportRelations.NotContains: return NotContains(type, value, propertyExp);
                case SupportRelations.EndsWith: return EndsWith(type, value, propertyExp);
                case SupportRelations.NotEndsWith: return NotEndsWith(type, value, propertyExp);
                case SupportRelations.StartsWith: return BeginsWith(type, value, propertyExp);
                case SupportRelations.NotStartsWith: return NotBeginsWith(type, value, propertyExp);
                case SupportRelations.Equals: return Equals(type, value, propertyExp);
                case SupportRelations.NotEquals: return NotEquals(type, value, propertyExp);
                case SupportRelations.LessThan: return LessThan(type, value, propertyExp);
                case SupportRelations.LessThanOrEqual: return LessThanOrEqual(type, value, propertyExp);
                case SupportRelations.GreaterThan: return GreaterThan(type, value, propertyExp);
                case SupportRelations.GreaterThanOrEqual: return GreaterThanOrEqual(type, value, propertyExp);
                case SupportRelations.Between: return Between(type, value, propertyExp);
                case SupportRelations.NotBetween: return NotBetween(type, value, propertyExp);
                case SupportRelations.In: return In(type, value, propertyExp);
                case SupportRelations.NotIn: return NotIn(type, value, propertyExp);
                default: throw new NotImplementedException("未实现对应类型的表达式");
            }
        }

        /// <summary>
        /// 获取常量表达式
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="value">值</param>
        /// <param name="isCollection">是否是集合</param>
        /// <returns>常量表达式集合</returns>
        private static List<ConstantExpression> GetConstants(Type type, string value, bool isCollection)
        {
            if (type == typeof(DateTime) && ParseDatesAsUtc)
            {
                DateTime tDate;
                if (isCollection)
                {
                    var vals = value.Split(new[] { ",", "[", "]", "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                            .Where(p => !string.IsNullOrWhiteSpace(p))
                            .Select(p => DateTime.TryParse(p.Trim(), CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out tDate) ? (DateTime?)tDate : null)
                            .Select(p => Expression.Constant(p, type));
                    return vals.ToList();
                }
                return Expression.Constant(DateTime.TryParse(value.Trim(), CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out tDate) ? (DateTime?)tDate : null).ListWrapper();
            }
            if (isCollection)
            {
                var tc = TypeDescriptor.GetConverter(type);
                var vals = value.Split(new[] { ",", "[", "]", "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Where(p => !string.IsNullOrWhiteSpace(p))
                        .Select(p => tc.ConvertFromString(p.Trim())).Select(p => Expression.Constant(p, type));
                return vals.ToList();
            }
            else
            {
                var tc = TypeDescriptor.GetConverter(type);
                return Expression.Constant(tc.ConvertFromString(value.Trim())).ListWrapper();
            }
        }

        private static Expression GetNullCheckExpression(Expression propertyExp)
        {
            var isNullable = !propertyExp.Type.IsValueType || Nullable.GetUnderlyingType(propertyExp.Type) != null;
            return isNullable
                ? Expression.NotEqual(propertyExp, Expression.Constant(propertyExp.Type.GetDefaultValue(), propertyExp.Type))
                : Expression.Equal(Expression.Constant(true, typeof(bool)), Expression.Constant(true, typeof(bool)));
        }

        #region [Expressions]


        private static Expression IsNull(Expression propertyExp)
        {
            var isNullable = !propertyExp.Type.IsValueType || Nullable.GetUnderlyingType(propertyExp.Type) != null;

            if (isNullable)
            {
                var someValue = Expression.Constant(null, propertyExp.Type);

                Expression exOut = Expression.Equal(propertyExp, someValue);

                return exOut;
            }
            return Expression.Equal(Expression.Constant(true, typeof(bool)),
                Expression.Constant(false, typeof(bool)));
        }

        private static Expression IsNotNull(Expression propertyExp)
        {
            return Expression.Not(IsNull(propertyExp));
        }

        private static Expression IsEmpty(Expression propertyExp)
        {
            var someValue = Expression.Constant(0, typeof(int));

            var nullCheck = GetNullCheckExpression(propertyExp);

            Expression exOut;

            if (propertyExp.Type.IsGenericList())
            {

                exOut = Expression.Property(propertyExp, propertyExp.Type.GetProperty("Count"));

                exOut = Expression.AndAlso(nullCheck, Expression.Equal(exOut, someValue));
            }
            else
            {
                exOut = Expression.Property(propertyExp, typeof(string).GetProperty("Length"));

                exOut = Expression.AndAlso(nullCheck, Expression.Equal(exOut, someValue));
            }

            return exOut;
        }

        private static Expression IsNotEmpty(Expression propertyExp)
        {
            return Expression.Not(IsEmpty(propertyExp));
        }

        private static Expression Contains(Type type, string value, Expression propertyExp)
        {
            var someValue = Expression.Constant(value.ToLower(), typeof(string));

            var nullCheck = GetNullCheckExpression(propertyExp);

            var method = propertyExp.Type.GetMethod("Contains", new[] { type });

            Expression exOut = Expression.Call(propertyExp, typeof(string).GetMethod("ToLower", Type.EmptyTypes));

            exOut = Expression.AndAlso(nullCheck, Expression.Call(exOut, method, someValue));

            return exOut;
        }

        private static Expression NotContains(Type type, string value, Expression propertyExp)
        {
            return Expression.Not(Contains(type, value, propertyExp));
        }

        private static Expression EndsWith(Type type, string value, Expression propertyExp)
        {
            var someValue = Expression.Constant(value.ToLower(), typeof(string));

            var nullCheck = GetNullCheckExpression(propertyExp);

            var method = propertyExp.Type.GetMethod("EndsWith", new[] { type });

            Expression exOut = Expression.Call(propertyExp, typeof(string).GetMethod("ToLower", Type.EmptyTypes));

            exOut = Expression.AndAlso(nullCheck, Expression.Call(exOut, method, someValue));

            return exOut;
        }

        private static Expression NotEndsWith(Type type, string value, Expression propertyExp)
        {
            return Expression.Not(EndsWith(type, value, propertyExp));
        }

        private static Expression BeginsWith(Type type, string value, Expression propertyExp)
        {
            var someValue = Expression.Constant(value.ToLower(), typeof(string));

            var nullCheck = GetNullCheckExpression(propertyExp);

            var method = propertyExp.Type.GetMethod("StartsWith", new[] { type });

            Expression exOut = Expression.Call(propertyExp, typeof(string).GetMethod("ToLower", Type.EmptyTypes));

            exOut = Expression.AndAlso(nullCheck, Expression.Call(exOut, method, someValue));

            return exOut;
        }

        private static Expression NotBeginsWith(Type type, string value, Expression propertyExp)
        {
            return Expression.Not(BeginsWith(type, value, propertyExp));
        }

        private static Expression Equals(Type type, string value, Expression propertyExp)
        {
            Expression someValue = GetConstants(type, value, false).First();

            Expression exOut;
            if (type == typeof(string))
            {
                var nullCheck = GetNullCheckExpression(propertyExp);

                exOut = Expression.Call(propertyExp, typeof(string).GetMethod("ToLower", Type.EmptyTypes));
                someValue = Expression.Call(someValue, typeof(string).GetMethod("ToLower", Type.EmptyTypes));
                exOut = Expression.AndAlso(nullCheck, Expression.Equal(exOut, someValue));
            }
            else
            {
                exOut = Expression.Equal(propertyExp, Expression.Convert(someValue, propertyExp.Type));
            }

            return exOut;


        }

        private static Expression NotEquals(Type type, string value, Expression propertyExp)
        {
            return Expression.Not(Equals(type, value, propertyExp));
        }

        private static Expression LessThan(Type type, string value, Expression propertyExp)
        {
            var someValue = GetConstants(type, value, false).First();

            Expression exOut = Expression.LessThan(propertyExp, Expression.Convert(someValue, propertyExp.Type));


            return exOut;


        }

        private static Expression LessThanOrEqual(Type type, string value, Expression propertyExp)
        {
            var someValue = GetConstants(type, value, false).First();

            Expression exOut = Expression.LessThanOrEqual(propertyExp, Expression.Convert(someValue, propertyExp.Type));


            return exOut;


        }

        private static Expression GreaterThan(Type type, string value, Expression propertyExp)
        {

            var someValue = GetConstants(type, value, false).First();



            Expression exOut = Expression.GreaterThan(propertyExp, Expression.Convert(someValue, propertyExp.Type));


            return exOut;


        }

        private static Expression GreaterThanOrEqual(Type type, string value, Expression propertyExp)
        {
            var someValue = GetConstants(type, value, false).First();

            Expression exOut = Expression.GreaterThanOrEqual(propertyExp, Expression.Convert(someValue, propertyExp.Type));


            return exOut;


        }

        private static Expression Between(Type type, string value, Expression propertyExp)
        {
            var someValue = GetConstants(type, value, true);


            Expression exBelow = Expression.GreaterThanOrEqual(propertyExp, Expression.Convert(someValue[0], propertyExp.Type));
            Expression exAbove = Expression.LessThanOrEqual(propertyExp, Expression.Convert(someValue[1], propertyExp.Type));

            return Expression.And(exBelow, exAbove);


        }

        private static Expression NotBetween(Type type, string value, Expression propertyExp)
        {
            return Expression.Not(Between(type, value, propertyExp));
        }

        private static Expression In(Type type, string value, Expression propertyExp)
        {
            var someValues = GetConstants(type, value, true);
            var nullCheck = GetNullCheckExpression(propertyExp);
            if (propertyExp.Type.IsGenericList())
            {
                var genericType = propertyExp.Type.GetGenericArguments().First();
                var method = propertyExp.Type.GetMethod("Contains", new[] { genericType });
                Expression exOut;

                if (someValues.Count > 1)
                {
                    exOut = Expression.Call(propertyExp, method, Expression.Convert(someValues[0], genericType));
                    var counter = 1;
                    while (counter < someValues.Count)
                    {
                        exOut = Expression.Or(exOut,
                            Expression.Call(propertyExp, method, Expression.Convert(someValues[counter], genericType)));
                        counter++;
                    }
                }
                else
                {
                    exOut = Expression.Call(propertyExp, method, Expression.Convert(someValues.First(), genericType));
                }
                return Expression.AndAlso(nullCheck, exOut);
            }
            else
            {
                Expression exOut;
                if (someValues.Count > 1)
                {
                    if (type == typeof(string))
                    {

                        exOut = Expression.Call(propertyExp, typeof(string).GetMethod("ToLower", Type.EmptyTypes));
                        exOut = Expression.Equal(exOut, Expression.Convert(someValues[0], propertyExp.Type));
                        var counter = 1;
                        while (counter < someValues.Count)
                        {
                            exOut = Expression.Or(exOut,
                                Expression.Equal(
                                    Expression.Call(propertyExp, typeof(string).GetMethod("ToLower", Type.EmptyTypes)),
                                    Expression.Convert(someValues[counter], propertyExp.Type)));
                            counter++;
                        }
                    }
                    else
                    {
                        exOut = Expression.Equal(propertyExp, Expression.Convert(someValues[0], propertyExp.Type));
                        var counter = 1;
                        while (counter < someValues.Count)
                        {
                            exOut = Expression.Or(exOut,
                                Expression.Equal(propertyExp, Expression.Convert(someValues[counter], propertyExp.Type)));
                            counter++;
                        }
                    }
                }
                else
                {
                    if (type == typeof(string))
                    {

                        exOut = Expression.Call(propertyExp, typeof(string).GetMethod("ToLower", Type.EmptyTypes));
                        exOut = Expression.Equal(exOut, someValues.First());
                    }
                    else
                    {
                        exOut = Expression.Equal(propertyExp, Expression.Convert(someValues.First(), propertyExp.Type));
                    }
                }
                return Expression.AndAlso(nullCheck, exOut);
            }


        }

        private static Expression NotIn(Type type, string value, Expression propertyExp)
        {
            return Expression.Not(In(type, value, propertyExp));
        }

        #endregion

    }
}
