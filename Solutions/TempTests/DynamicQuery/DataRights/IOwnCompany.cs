using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DynamicQuery.DataRights
{
    /// <summary>
    /// 拥有公司
    /// </summary>
    public interface IOwnCompany
    {
        /// <summary>
        /// 拥有用户Id
        /// </summary>
        int OwnCompanyId { get; }
    }
}
