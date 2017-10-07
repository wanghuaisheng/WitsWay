using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DynamicQuery.DataRights
{
    /// <summary>
    /// 拥有用户
    /// </summary>
    public interface IOwnUser
    {
        /// <summary>
        /// 拥有用户Id
        /// </summary>
        int OwnUserId { get; }
    }
}
