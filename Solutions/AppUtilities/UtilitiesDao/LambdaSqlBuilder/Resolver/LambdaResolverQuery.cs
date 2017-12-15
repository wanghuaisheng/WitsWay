using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using WitsWay.Utilities.Dap.LambdaSqlBuilder.Resolver.ExpressionTree;

namespace WitsWay.Utilities.Dap.LambdaSqlBuilder.Resolver
{
    partial class LambdaResolver
    {
        public void ResolveQuery<T>(Expression<Func<T, bool>> expression)
        {
            var expressionTree = ResolveQuery<T>((dynamic)expression.Body);
            BuildSql(expressionTree);
        }

        private Node ResolveQuery(ConstantExpression constantExpression)
        {
            return new ValueNode { Value = constantExpression.Value };
        }

        private Node ResolveQuery<T>(UnaryExpression unaryExpression)
        {
            return new SingleOperationNode
            {
                Operator = unaryExpression.NodeType,
                Child = ResolveQuery((dynamic)unaryExpression.Operand)
            };
        }
        
        private Node ResolveQuery<T>(BinaryExpression binaryExpression)
        {
            var left = ResolveQuery<T>((dynamic) binaryExpression.Left);
            var opera = binaryExpression.NodeType;
            var right = ResolveQuery<T>((dynamic) binaryExpression.Right);
            return new OperationNode {Left = left,Operator = opera,Right = right};
        }

        private Node ResolveQuery<T>(MethodCallExpression callExpression)
        {
            LikeMethod callFunction;
            if (Enum.TryParse(callExpression.Method.Name, true, out callFunction))
            {
                //var member = callExpression.Object as MemberExpression;
                var tvalue = GetExpressionValue(callExpression.Arguments.First());
                var fieldValue = Convert.ToString(tvalue);
                return new LikeNode
                {
                               MemberNode = new MemberNode
                               {
                                           TableName =GetTableName<T>(),// GetTableName(member),
                                           FieldName = GetColumnName(callExpression.Object)
                                       },
                               Method = callFunction,
                               Value = fieldValue
                           };
            }
            else
            {
                var value = ResolveMethodCall(callExpression);
                return new ValueNode { Value = value };
            }
        }

        private Node ResolveQuery<T>(MemberExpression memberExpression, MemberExpression rootExpression)
        {
            rootExpression = rootExpression ?? memberExpression;

            if (rootExpression.Expression == null)
            {
                return new ValueNode { Value = GetExpressionValue(rootExpression) };
            }

            switch (memberExpression.Expression.NodeType)
            {
                case ExpressionType.Parameter:
                    return new MemberNode { TableName = GetTableName<T>(), FieldName = GetColumnName(rootExpression) };
                case ExpressionType.MemberAccess:
                    return ResolveQuery<T>(memberExpression.Expression as MemberExpression, rootExpression);
                case ExpressionType.Call:
                case ExpressionType.Constant:
                    return new ValueNode { Value = GetExpressionValue(rootExpression) };
                default:
                    throw new ArgumentException("Expected member expression");
            }
        }

        private Node ResolveQuery<T>(MemberExpression memberExpression)
        {
            var rootExpression = memberExpression;
            switch (memberExpression.Expression.NodeType)
            {
                case ExpressionType.Parameter:
                    return new MemberNode { TableName = GetTableName<T>(), FieldName = GetColumnName(rootExpression) };
                case ExpressionType.MemberAccess:
                    return ResolveQuery<T>(memberExpression.Expression as MemberExpression, rootExpression);
                case ExpressionType.Call:
                case ExpressionType.Constant:
                    return new ValueNode { Value = GetExpressionValue(rootExpression) };
                default:
                    throw new ArgumentException("Expected member expression");
            }
        }


        #region Helpers

        private object GetExpressionValue(Expression expression)
        {
           

            switch (expression.NodeType)
            {
                case ExpressionType.Constant:
                    return (expression as ConstantExpression).Value;
                case ExpressionType.Call:
                    return ResolveMethodCall(expression as MethodCallExpression);
                case ExpressionType.MemberAccess:
                    var memberExpr = (expression as MemberExpression);
                    if (memberExpr.Expression == null)
                    {
                        var obj1 = memberExpr;//GetExpressionValue(memberExpr);
                        return ResolveValue((dynamic)memberExpr.Member, obj1);
                    }
                    var obj = GetExpressionValue(memberExpr.Expression);
                    return ResolveValue((dynamic)memberExpr.Member, obj);
                default:
                    throw new ArgumentException("Expected constant expression");
            }
        }

        private object ResolveMethodCall(MethodCallExpression callExpression)
        {
            try
            {
                var arguments = callExpression.Arguments.Select(GetExpressionValue).ToArray();
                var obj = callExpression.Object != null ? GetExpressionValue(callExpression.Object) : arguments.First();

                return callExpression.Method.Invoke(obj, arguments);
            }
            catch
            {
                throw new Exception("请不要使用静态方法,可以使用实例方法,或者使用临时变量");
            }
        }

        private object ResolveValue(PropertyInfo property, object obj)
        {
            return property.GetValue(obj, null);
        }

        private object ResolveValue(FieldInfo field, object obj)
        {
            return field.GetValue(obj);
        }

        #endregion

        #region Fail functions

        private void ResolveQuery(Expression expression)
        {
            throw new ArgumentException($"不支持该Lambda表达式 '{expression.NodeType}' ");
        }

        #endregion
    }
}
