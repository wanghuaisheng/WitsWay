using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace DapperTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string ConnectionString { get; } = ConfigurationManager.ConnectionStrings["Main"].ConnectionString;
        private void _btnDapperQuery_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var guid = Guid.NewGuid();
                var dog = connection.Query<Dog>("select Age = @Age, Id = @Id", new { Age = (int?)null, Id = guid });

                var dogList = dog as IList<Dog> ?? dog.ToList();
                if (dogList.Count == 1)
                    Debug.WriteLine("dogList.Count == 1");
                if (dogList.First().Age == null)
                    Debug.WriteLine("dogList.First().Age == null");
                if (dogList.First().Id == guid)
                    Debug.WriteLine(" dogList.First().Id==guid");
                //Dynamic
                var rows = connection.Query("select 1 A, 2 B union all select 3, 4").ToArray();
                if ((int)rows[0].A == 1 && (int)rows[0].B == 2 && (int)rows[1].A == 3 && (int)rows[1].B == 4)
                    Debug.WriteLine("ok");

                var result = connection.Execute(@"
  set nocount on 
  create table #t(i int) 
  set nocount off 
  insert #t 
  select @a a union all select @b 
  set nocount on 
  drop table #t", new { a = 1, b = 2 });
                if (result == 2)
                    Debug.WriteLine("影响行数2");

                //////3 rows inserted: "1,1", "2,2" and "3,3"
                ////connection.Execute(@"insert MyTable(colA, colB) values (@a, @b)",
                ////        new[] { new { a = 1, b = 1 }, new { a = 2, b = 2 }, new { a = 3, b = 3 } }
                ////    ).IsEqualTo(3);

                //Dapper allows you to pass in IEnumerable<int> and will automatically parameterize your query.
                connection.Query<int>("select * from (select 1 as Id union all select 2 union all select 3) as X where Id in @Ids", new { Ids = new int[] { 1, 2, 3 } });
                

                connection.Close();
            }

        }
    }

    public class Dog
    {
        public int? Age { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float? Weight { get; set; }

        public int IgnoredProperty => 1;
    }
}
