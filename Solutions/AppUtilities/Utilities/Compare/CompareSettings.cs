#region Origin
//VERSION 1.7.3.0
//http://comparenetobjects.codeplex.com/
#endregion
#region License
//Microsoft Public License (Ms-PL)
//This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, do not use the software.
//1. Definitions
//The terms "reproduce," "reproduction," "derivative works," and "distribution" have the same meaning here as under U.S. copyright law.
//A "contribution" is the original software, or any additions or changes to the software.
//A "contributor" is any person that distributes its contribution under this license.
//"Licensed patents" are a contributor's patent claims that read directly on its contribution.
//2. Grant of Rights
//(A) Copyright Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free copyright license to reproduce its contribution, prepare derivative works of its contribution, and distribute its contribution or any derivative works that you create.
//(B) Patent Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free license under its licensed patents to make, have made, use, sell, offer for sale, import, and/or otherwise dispose of its contribution in the software or derivative works of the contribution in the software.
//3. Conditions and Limitations
//(A) No Trademark License- This license does not grant you rights to use any contributors' name, logo, or trademarks.
//(B) If you bring a patent claim against any contributor over patents that you claim are infringed by the software, your patent license from such contributor to the software ends automatically.
//(C) If you distribute any portion of the software, you must retain all copyright, patent, trademark, and attribution notices that are present in the software.
//(D) If you distribute any portion of the software in source code form, you may do so only under this license by including a complete copy of this license with your distribution. If you distribute any portion of the software in compiled or object code form, you may only do so under a license that complies with this license.
//(E) The software is licensed "as-is." You bear the risk of using it. The contributors give no express warranties, guarantees or conditions. You may have additional consumer rights under your local laws which this license cannot change. To the extent permitted under your local laws, the contributors exclude the implied warranties of merchantability, fitness for a particular purpose and non-infringement.
#endregion
#region ChangeLog
/******************************************
 * 2017-10-7 OutMan Create
 * 
 * ***************************************/
#endregion
using System.Collections.Generic;

namespace WitsWay.Utilities.Compare
{
    /// <summary>
    /// 比较设置
    /// </summary>
    public class CompareSettings
    {
        /// <summary>
        /// 忽略元素
        /// </summary>
        public static List<string> ElementsToIgnore = new List<string>();
        /// <summary>
        /// 忽略标签
        /// </summary>
        public static List<string> AttributesToIgnore = new List<string>();
        /// <summary>
        /// 是否比较静态字段
        /// </summary>
        public static bool CompareStaticFields = true;
        /// <summary>
        /// 是否比较静态属性
        /// </summary>
        public static bool CompareStaticProperties = true;
        /// <summary>
        /// 是否比较私有属性
        /// </summary>
        public static bool ComparePrivateProperties = false;
        /// <summary>
        /// 是否比较私有字段
        /// </summary>
        public static bool ComparePrivateFields = false;
        /// <summary>
        /// 是否比较子对象
        /// </summary>
        public static bool CompareChildren = true;
        /// <summary>
        /// 是否比较只读属性
        /// </summary>
        public static bool CompareReadOnly = true;
        /// <summary>
        /// 是否比较字段
        /// </summary>
        public static bool CompareFields = true;
        /// <summary>
        /// 是否比较属性
        /// </summary>
        public static bool CompareProperties = true;
        /// <summary>
        /// 是否启用缓存
        /// </summary>
        public static bool Caching = true;
        /// <summary>
        /// 是否自动清理缓存
        /// </summary>
        public static bool AutoClearCache = true;
        /// <summary>
        /// 最大允许不同数量
        /// </summary>
        public static int MaxDifferences = 1;
        /// <summary>
        /// 是否忽略集合顺序
        /// </summary>
        public static bool IgnoreCollectionOrder = true;

    }
}
