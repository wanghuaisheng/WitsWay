using System.Collections.Generic;
using System.Linq;
using Utilities.Dap.Tests.Common;
using Utilities.Dap.Tests.Entities;
using WitsWay.Utilities.Dap.Extentions;

namespace Utilities.Dap.Tests
{
    public class testmysqllogic : MysqlBase
    {

        public List<Tbn> Find()
        {
            using (var db = GetConnection())
            {
                return db.Query<Tbn>(p => p.id >= 1).ToList();
            }
        }

        public PageResult<Tbn> FindPage(int pageSize, int pageNumber)
        {
            using (var db = GetConnection())
            {
                return db.PagedQuery<Tbn>(pageSize, pageNumber, p => p.id >= 1);
            }
        }
    }
}
