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
using System.Collections.Generic;

namespace  WitsWay.Utilities.Compare
{
    /// <summary>
    /// Public interface for mocking.  Mock yeah, bird yeah, yeah yeah.
    /// </summary>
    public interface ICompareObjects
    {
        /// <summary>
        /// Show breadcrumb at each stage of the comparision.  
        /// This is useful for debugging deep object graphs.
        /// The default is false
        /// </summary>
        bool ShowBreadcrumb { get; set; }

        /// <summary>
        /// Ignore classes, properties, or fields by name during the comparison.
        /// Case sensitive.
        /// </summary>
        /// <example>ElementsToIgnore.Add("CreditCardNumber")</example>
        List<string> ElementsToIgnore { get; set; }

        /// <summary>
        /// Only compare elements by name for classes, properties, and fields
        /// Case sensitive.
        /// </summary>
        /// <example>ElementsToInclude.Add("FirstName")</example>
        List<string> ElementsToInclude { get; set; }

        /// <summary>
        /// If true, private properties and fields will be compared. The default is false.  Silverlight and WinRT restricts access to private variables.
        /// </summary>
        bool ComparePrivateProperties { get; set; }

        /// <summary>
        /// If true, private fields will be compared. The default is false.  Silverlight and WinRT restricts access to private variables.
        /// </summary>
        bool ComparePrivateFields { get; set; }

        /// <summary>
        /// If true, static properties will be compared.  The default is true.
        /// </summary>
        bool CompareStaticProperties { get; set; }

        /// <summary>
        /// If true, static fields will be compared.  The default is true.
        /// </summary>
        bool CompareStaticFields { get; set; }

        /// <summary>
        /// If true, child objects will be compared. The default is true. 
        /// If false, and a list or array is compared list items will be compared but not their children.
        /// </summary>
        bool CompareChildren { get; set; }

        /// <summary>
        /// If true, compare read only properties (only the getter is implemented).
        /// The default is true.
        /// </summary>
        bool CompareReadOnly { get; set; }

        /// <summary>
        /// If true, compare fields of a class (see also CompareProperties).
        /// The default is true.
        /// </summary>
        bool CompareFields { get; set; }

        /// <summary>
        /// If true, compare each item within a collection to every item in the other (warning, setting this to true significantly impacts performance).
        /// The default is false.
        /// </summary>
        bool IgnoreCollectionOrder { get; set; }

        /// <summary>
        /// If true, compare properties of a class (see also CompareFields).
        /// The default is true.
        /// </summary>
        bool CompareProperties { get; set; }

        /// <summary>
        /// The maximum number of differences to detect
        /// </summary>
        /// <remarks>
        /// Default is 1 for performance reasons.
        /// </remarks>
        int MaxDifferences { get; set; }

        /// <summary>
        /// The differences found during the compare
        /// </summary>
        List<Difference> Differences { get; set; }

        /// <summary>
        /// The differences found in a string suitable for a textbox
        /// </summary>
        string DifferencesString { get; }

        /// <summary>
        /// Reflection properties and fields are cached. By default this cache is cleared after each compare.  Set to false to keep the cache for multiple compares.
        /// </summary>
        /// <seealso cref="Caching"/>
        /// <seealso cref="ClearCache"/>
        bool AutoClearCache { get; set; }

        /// <summary>
        /// By default properties and fields for types are cached for each compare.  By default this cache is cleared after each compare.
        /// </summary>
        /// <seealso cref="AutoClearCache"/>
        /// <seealso cref="ClearCache"/>
        bool Caching { get; set; }

        /// <summary>
        /// A list of attributes to ignore a class, property or field
        /// </summary>
        /// <example>AttributesToIgnore.Add(typeof(XmlIgnoreAttribute));</example>
        List<Type> AttributesToIgnore { get; set; }

        /// <summary>
        /// If true, objects will be compared ignore their type diferences
        /// </summary>
        bool IgnoreObjectTypes { get; set; }

        /// <summary>
        /// Func that determine when use CustomComparer for comparing specific type.
        /// Default value return permanent false value.
        /// </summary>
        Func<Type, bool> IsUseCustomTypeComparer { get; set; }

        /// <summary>
        /// Action that performed for comparing objects.
        /// T1: contain current CompareObjects
        /// T2: object1 for comparing
        /// T3: object1 for comparing
        /// T4: current CompareObjects breadcrumb
        /// </summary>
        Action<CompareObjects, object, object, string> CustomComparer { get; set; }

        /// <summary>
        /// In the differences string, this is the name for expected name, default is Expected 
        /// </summary>
        string ExpectedName { get; set; }

        /// <summary>
        /// In the differences string, this is the name for the actual name, default is Actual
        /// </summary>
        string ActualName { get; set; }

        /// <summary>
        /// Compare two objects of the same type to each other.
        /// </summary>
        /// <remarks>
        /// Check the Differences or DifferencesString Properties for the differences.
        /// Default MaxDifferences is 1 for performance
        /// </remarks>
        /// <param name="object1"></param>
        /// <param name="object2"></param>
        /// <returns>True if they are equal</returns>
        bool Compare(object object1, object object2);

        /// <summary>
        /// Reflection properties and fields are cached. By default this cache is cleared automatically after each compare.
        /// </summary>
        /// <seealso cref="CompareObjects.AutoClearCache"/>
        /// <seealso cref="CompareObjects.Caching"/>
        void ClearCache();

        /// <summary>
        /// Callback invoked each time the comparer finds a difference
        /// </summary>
        Action<Difference> DifferenceCallback { set; }


        /// <summary>
        /// Sometimes one wants to match items between collections by some key first, and then
        /// compare the matched objects.  Without this, the comparer basically says there is no 
        /// match in collection B for any given item in collection A.  The results of this aren't
        /// particularly useful for graphs that are mostly the same, but not quite. Enter CollectionMatchingSpec
        /// 
        /// the enumerable strings should be property (not field, for now, to keep it simple) names of the
        /// Type when encountered that will be used for matching
        /// 
        /// to match on all props/fields: Don't set this property (default comparer behavior)
        /// NOTE: types are looked up as exact.  e.g. if foo is an entry in the dictionary and bar is a 
        /// sub-class of foo, upon encountering a bar type, the comparer will not find the entry of foo
        /// </summary>
        IDictionary<Type, IEnumerable<string>> CollectionMatchingSpec { get; set; }
    }
}