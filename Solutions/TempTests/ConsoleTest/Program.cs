using System;
using System.Collections.Generic;
using System.Linq;
using WitsWay.TempTests.ConsoleTest.Enums;
using WitsWay.TempTests.DynamicQuery.Builders;
using WitsWay.TempTests.DynamicQuery.Entities;

namespace WitsWay.TempTests.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var modules = new List<Employee>
            {
                new Employee
                {
                   Age=10, BirthDay=DateTime.Now.AddYears(-10),EmployeeId=1,Name="张三",IsJoin = true,Remark="张三丰的后代",SortCode=11,School="儒家",Sex=Sex.Male,States=EmployeeStatus.Enable|EmployeeStatus.Confirmed
                }, 
                new Employee
                {
                   Age=20, BirthDay=DateTime.Now.AddYears(-20),EmployeeId=2,Name="孔四",IsJoin = false,Remark="孔夫子的后代",SortCode=12,School="儒家",Sex=Sex.Male,States=EmployeeStatus.Enable|EmployeeStatus.Confirmed
                },  
                new Employee
                {
                   Age=30, BirthDay=DateTime.Now.AddYears(-30),EmployeeId=3,Name="唐十三",IsJoin = true,Remark="唐太宗的后代",SortCode=13,School="道家",Sex=Sex.Male,States=EmployeeStatus.Enable|EmployeeStatus.Confirmed
                },  
                new Employee
                {
                   Age=40, BirthDay=DateTime.Now.AddYears(-40),EmployeeId=4,Name="叶不问",IsJoin = true,Remark="叶问的后代",SortCode=14,School="道家",Sex=Sex.Male,States=EmployeeStatus.Enable
                },  
                new Employee
                {
                   Age=50, BirthDay=DateTime.Now.AddYears(-50),EmployeeId=5,Name="秦大大",IsJoin = true,Remark="秦始皇的后代",SortCode=15,School="墨家",Sex=Sex.Female,States=EmployeeStatus.Enable|EmployeeStatus.Confirmed
                },
            };
            var queryModules = modules.AsQueryable();

            var rule = new FilterRule
            {
                Condition = "and",
                Field = "",
                Id = "1",
                Input = "",
                Operator = "",
                Type = "",
                Value = "",
                Rules = new List<FilterRule>
                {
                    new FilterRule{Condition = "",Field = "Age",Id="2",Input="spin",Operator="greater_or_equal",Type = "integer",Value="21"},
                    new FilterRule{Condition = "",Field = "Age",Id="2",Input="spin",Operator="less_or_equal",Type = "integer",Value="51"},
                }
            };

            var filterModules = queryModules.BuildQuery(rule);

            var sortedModules = filterModules.OrderByDescending(e => e.BirthDay).ThenBy(e => e.IsJoin).Skip(1).Take(1);


            var filterClause = ClauseBuilder.BuildClause<Employee>(rule);
            var filterList = filterModules.ToList();
            //ClauseBuilder.BuildClause<>()


            var columns = ColumnBuilder.GetDefaultColumnDefinitions(typeof(FilterRule));
            //System.Linq.Expressions.UnaryExpression typeAsExpression = System.Linq.Expressions.Expression.TypeAs(System.Linq.Expressions.Expression.Constant(34, typeof (int)),typeof (int?));

            //Console.WriteLine(typeAsExpression.ToString());

            //Expression<Func<int, int, int>> expression = (a, b) => a * b + 2;
            //var body = expression.Body;
        }
    }
}
