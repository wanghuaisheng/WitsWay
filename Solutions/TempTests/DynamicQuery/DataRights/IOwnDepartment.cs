using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicQuery.DataRights
{
    /// <summary>
    /// 拥有部门
    /// </summary>
    public interface IOwnDepartment
    {
        /// <summary>
        /// 拥有部门Id
        /// </summary>
        int OwnDepartentId { get; }
    }
}
