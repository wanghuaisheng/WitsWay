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
using System;

namespace  WitsWay.Utilities.Compare
{
    /// <summary>
    /// Detailed information about the difference
    /// </summary>
    public class Difference
    {
        /// <summary>
        /// Name of Expected Object
        /// </summary>
        public string ExpectedName { get; set; }

        /// <summary>
        /// Name of Actual Object
        /// </summary>
        public string ActualName { get; set; }

        /// <summary>
        /// The breadcrumb of the property leading up to the value
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// The child property name
        /// </summary>
        public string ChildPropertyName { get; set; }

        /// <summary>
        /// Object1 Value as a string
        /// </summary>
        public string Object1Value { get; set; }

        /// <summary>
        /// Object2 Value as a string
        /// </summary>
        public string Object2Value { get; set; }

        /// <summary>
        /// Object1 as a reference
        /// </summary>
        public WeakReference Object1 { get; set; }

        /// <summary>
        /// Object2 as a reference
        /// </summary>
        public WeakReference Object2 { get; set; }

        /// <summary>
        /// Prefix to put on the beginning of the message
        /// </summary>
        public string MessagePrefix { get; set; }

        /// <summary>
        /// Nicely formatted string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string message;

            if (!String.IsNullOrEmpty(PropertyName))
            {
                if (String.IsNullOrEmpty(ChildPropertyName))
                    message = String.Format("{0}.{2} != {1}.{2} ({3},{4})", ExpectedName, ActualName,PropertyName,Object1Value, Object2Value);
                else
                    message = String.Format("{0}.{2}.{5} != {1}.{2}.{5} ({3},{4})", ExpectedName, ActualName, PropertyName, Object1Value, Object2Value, ChildPropertyName);
            }
            else
            {
                message = $"{ExpectedName} != {ActualName} ({Object1Value},{Object2Value})";
            }

            if (!String.IsNullOrEmpty(MessagePrefix))
                message = $"{MessagePrefix}: {message}";

            return message;
        }
    }
}