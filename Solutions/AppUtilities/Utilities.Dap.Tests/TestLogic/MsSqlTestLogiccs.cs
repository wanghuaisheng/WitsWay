using System.Collections.Generic;
using System.Linq;
using Utilities.Dap.Tests.Common;
using Utilities.Dap.Tests.Entities;
using WitsWay.Utilities.Dap.Extentions;

namespace Utilities.Dap.Tests.TestLogic
{
    public class MsSqlTestLogic:NpgsqlBase
    {

        public List<Test2> FindAction()
        {
            using (var db = GetConnection())
            {
                return db.Query<Test2>(sql =>
                {
                    sql.WhereIsIn(p => p.Id, new List<object>() {1,4});
                }).ToList();
            }
        }

        public PageResult<Test2> FindPage(int pageSize, int pageNumber)
        {
            using (var db = GetConnection())
            {
                return db.PagedQuery<Test2>(pageSize, pageNumber, p => p.Id >= 1);
            }
        }


        public PageResult<Test2> FindPageAction(int pageSize, int pageNumber)
        {
            using (var db = GetConnection())
            {
                return db.PagedQuery<Test2>(pageSize, pageNumber, sql =>
                {
                    sql.Where(p => p.Id >= 1);
                } );
            }
        }
    }
}
