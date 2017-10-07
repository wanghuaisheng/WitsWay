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
//#region Includes
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Diagnostics;
//using System.Net;
//using System.Reflection;
//using DotNetSoft.Utilities.Compare;
//using KellermanSoftware.CompareNetObjects;
//using KellermanSoftware.CompareNetObjectsTests.Attributes;
//using KellermanSoftware.CompareNetObjectsTests.TestClasses;
//using NUnit.Framework;
//#endregion

//namespace KellermanSoftware.CompareNetObjectsTests
//{
//    [TestFixture(Description = "Tests for CompareObjects"), Category("CompareObjects")]
//    public class CompareObjectsTests
//    {
//        #region Class Variables
//        private CompareObjects _compare;
//        #endregion

//        #region Setup/Teardown

//        /// <summary>
//        /// Code that is run once for a suite of tests
//        /// </summary>
//        [TestFixtureSetUp]
//        public void TestFixtureSetup()
//        {

//        }

//        /// <summary>
//        /// Code that is run once after a suite of tests has finished executing
//        /// </summary>
//        [TestFixtureTearDown]
//        public void TestFixtureTearDown()
//        {

//        }

//        /// <summary>
//        /// Code that is run before each test
//        /// </summary>
//        [SetUp]
//        public void Initialize()
//        {
//            _compare = new CompareObjects();
//        }

//        /// <summary>
//        /// Code that is run after each test
//        /// </summary>
//        [TearDown]
//        public void Cleanup()
//        {
//            _compare = null;
//        }
//        #endregion

//        #region Documentation Tests
//        [Test]
//        public void DocumentationTest()
//        {
//            //This is the comparison class
//            CompareObjects compareObjects = new CompareObjects();

//            //Create a couple objects to compare
//            Person person1 = new Person();
//            person1.DateCreated = DateTime.Now;
//            person1.Name = "Greg";

//            Person person2 = new Person();
//            person2.Name = "John";
//            person2.DateCreated = person1.DateCreated;

//            //These will be different, write out the differences
//            if (!compareObjects.Compare(person1, person2))
//                Console.WriteLine(compareObjects.DifferencesString);
//        }

//        #endregion

//        #region IPEndpoint Tests
//        [Test]
//        public void IPEndPointPostiveTest()
//        {
//            IPEndPoint ipEndPoint1 = new IPEndPoint(44, 22);
//            IPEndPoint ipEndPoint2 = new IPEndPoint(44, 22);
//            if (!_compare.Compare(ipEndPoint1, ipEndPoint2))
//                throw new Exception(_compare.DifferencesString);
//        }

//        [Test]
//        public void IPEndPointNegativePortTest()
//        {
//            IPEndPoint ipEndPoint1 = new IPEndPoint(44, 22);
//            IPEndPoint ipEndPoint2 = new IPEndPoint(44, 21);
//            Assert.IsFalse(_compare.Compare(ipEndPoint1, ipEndPoint2));
//        }

//        [Test]
//        public void IPEndPointNegativeAddressTest()
//        {
//            IPEndPoint ipEndPoint1 = new IPEndPoint(44, 22);
//            IPEndPoint ipEndPoint2 = new IPEndPoint(45, 22);
//            Assert.IsFalse(_compare.Compare(ipEndPoint1, ipEndPoint2));
//        }
//        #endregion

//        #region Dataset Tests
//        private DataSet CreateMockDataset()
//        {
//            DataSet ds1 = new DataSet();
//            DataTable dt = new DataTable("IceCream");
//            ds1.Tables.Add(dt);
//            dt.Columns.Add("Flavor", typeof(string));
//            dt.Columns.Add("Price", typeof(decimal));
//            DataRow dr = dt.NewRow();
//            dr["Flavor"] = "Chocolate";
//            dr["Price"] = 1.99M;
//            dt.Rows.Add(dr);
//            dr = dt.NewRow();
//            dr["Flavor"] = "Vanilla";
//            dr["Price"] = 1.98M;
//            dt.Rows.Add(dr);
//            dr = dt.NewRow();
//            dr["Flavor"] = "Banana Prune Delight";
//            dr["Price"] = 2.99M;
//            dt.Rows.Add(dr);
//            return ds1;
//        }

//        [Test]
//        public void DatasetPositiveTest()
//        {
//            DataSet ds1 = CreateMockDataset();
//            DataSet ds2 = Common.CloneWithSerialization(ds1);
//            Assert.IsTrue(_compare.Compare(ds1, ds2));
//        }

//        [Test]
//        public void DatasetNegativeRowTest()
//        {
//            DataSet ds1 = CreateMockDataset();
//            DataSet ds2 = Common.CloneWithSerialization(ds1);
//            ds2.Tables[0].Rows[0].Delete();
//            Assert.IsFalse(_compare.Compare(ds1, ds2));
//        }

//        [Test]
//        public void DatasetNegativeColumnTest()
//        {
//            DataSet ds1 = CreateMockDataset();
//            DataSet ds2 = Common.CloneWithSerialization(ds1);
//            ds2.Tables[0].Columns.RemoveAt(0);
//            Assert.IsFalse(_compare.Compare(ds1, ds2));
//        }

//        [Test]
//        public void DatasetNegativeDataTest()
//        {
//            DataSet ds1 = CreateMockDataset();
//            DataSet ds2 = Common.CloneWithSerialization(ds1);
//            ds2.Tables[0].Rows[2][0] = "Chunky Chocolate Heaven";
//            Assert.IsFalse(_compare.Compare(ds1, ds2));
//        }

//        [Test]
//        public void DataTableNegativeDataTest()
//        {
//            DataSet ds1 = CreateMockDataset();
//            DataSet ds2 = Common.CloneWithSerialization(ds1);
//            ds2.Tables[0].Rows[2][0] = "Chunky Chocolate Heaven";
//            Assert.IsFalse(_compare.Compare(ds1.Tables[0], ds2.Tables[0]));
//        }

//        [Test]
//        public void DataRowNegativeDataTest()
//        {
//            DataSet ds1 = CreateMockDataset();
//            DataSet ds2 = Common.CloneWithSerialization(ds1);
//            ds2.Tables[0].Rows[2][0] = "Chunky Chocolate Heaven";
//            Assert.IsFalse(_compare.Compare(ds1.Tables[0].Rows[2], ds2.Tables[0].Rows[2]));
//        }

//        [Test]
//        public void DataRowDeletedTest()
//        {
//            DataSet ds1 = CreateMockDataset();
//            DataSet ds2 = Common.CloneWithSerialization(ds1);
//            ds2.Tables[0].Rows[2].Delete();
//            Assert.IsFalse(_compare.Compare(ds1.Tables[0], ds2.Tables[0]));
//        }
//        #endregion

//        #region Indexer Tests

//        [Test]
//        public void TestIndexerPositive()
//        {
//            var jane = new Person { Name = "Jane" };
//            var mary = new Person { Name = "Mary" };
//            var jack = new Person { Name = "Jack" };

//            var nameList1 = new List<Person>() { jane, jack, mary };
//            var nameList2 = new List<Person>() { jane, jack, mary };

//            var class1 = new ListClass<Person>(nameList1);
//            var class2 = new ListClass<Person>(nameList2);

//            Assert.IsTrue(_compare.Compare(class1, class2));
//        }

//        [Test]
//        public void TestIndexerNegative()
//        {
//            var jane = new Person { Name = "Jane" };
//            var john = new Person { Name = "John" };
//            var mary = new Person { Name = "Mary" };
//            var jack = new Person { Name = "Jack" };

//            var nameList1 = new List<Person>() { jane, jack, mary };
//            var nameList2 = new List<Person>() { jane, john, jack };

//            var class1 = new ListClass<Person>(nameList1);
//            var class2 = new ListClass<Person>(nameList2);

//            Assert.IsFalse(_compare.Compare(class1, class2));
//        }

//        [Test]
//        public void TestIndexerWithIgnoreCollectionOrder()
//        {
//            var jane = new Person { Name = "Jane" };
//            var john = new Person { Name = "Mary" };
//            var mary = new Person { Name = "Mary" };
//            var jack = new Person { Name = "Jack" };

//            var nameList1 = new List<Person>() { jane, jack, mary };
//            var nameList2 = new List<Person>() { jane, john, jack };

//            var class1 = new ListClass<Person>(nameList1);
//            var class2 = new ListClass<Person>(nameList2);

//            _compare.IgnoreCollectionOrder = true;

//            Assert.IsTrue(_compare.Compare(class1, class2));
//            Assert.IsTrue(_compare.Compare(class2, class1));
//        }

//        [Test]
//        public void TestIndexerWithIgnoreCollectionOrderNegative()
//        {
//            var jane = new Person { Name = "Jane" };
//            var john = new Person { Name = "Mary" };
//            var mary = new Person { Name = "Mary" };
//            var jack = new Person { Name = "Jack" };
//            var jo = new Person { Name = "Jo" };
//            var sarah = new Person { Name = "Sarah" };

//            var nameList1 = new List<Person>() { jane, jack, mary, jo };
//            var nameList2 = new List<Person>() { jane, john, jack, sarah };

//            var class1 = new ListClass<Person>(nameList1);
//            var class2 = new ListClass<Person>(nameList2);

//            _compare.IgnoreCollectionOrder = true;

//            Assert.IsFalse(_compare.Compare(class1, class2));
//            Assert.IsFalse(_compare.Compare(class2, class1));
//        }

//        [Test]
//        public void TestIndexerLengthNegative()
//        {
//            var jane = new Person { Name = "Jane" };
//            var john = new Person { Name = "John" };
//            var mary = new Person { Name = "Mary" };
//            var jack = new Person { Name = "Jack" };

//            var nameList1 = new List<Person>() { jane, john, jack, mary };
//            var nameList2 = new List<Person>() { jane, john, jack };

//            var class1 = new ListClass<Person>(nameList1);
//            var class2 = new ListClass<Person>(nameList2);

//            var prior = _compare.MaxDifferences;
//            _compare.MaxDifferences = int.MaxValue;

//            _compare.Compare(class1, class2);
//            Assert.AreEqual(_compare.Differences.Count, 3);

//            _compare.Compare(class2, class1);
//            Assert.AreEqual(_compare.Differences.Count, 3);

//            _compare.MaxDifferences = prior;
//        }

//        [Test]
//        public void TestIndexerWithIgnoreCollectionLengthNegative()
//        {
//            var jane = new Person { Name = "Jane" };
//            var john = new Person { Name = "John" };
//            var mary = new Person { Name = "Mary" };
//            var jack = new Person { Name = "Jack" };

//            var nameList1 = new List<Person>() { jane, john, jack, mary };
//            var nameList2 = new List<Person>() { jane, john, jack };

//            var class1 = new ListClass<Person>(nameList1);
//            var class2 = new ListClass<Person>(nameList2);

//            var prior = _compare.MaxDifferences;
//            _compare.MaxDifferences = int.MaxValue;
//            _compare.IgnoreCollectionOrder = true;

//            _compare.Compare(class1, class2);
//            Assert.AreEqual(_compare.Differences.Count, 3);

//            _compare.Compare(class2, class1);
//            Assert.AreEqual(_compare.Differences.Count, 3);


//            _compare.MaxDifferences = prior;
//        }
//        #endregion

//        #region CollectionMatchingSpec Tests
//        [Test]
//        public void CollectionWithSpecComplexMatch()
//        {
//            var entity1 = new Entity();
//            var entity2 = new Entity();
//            var len = 3;

//            var parent = new Entity
//            {
//                Description = "Me Papa",
//                EntityLevel = Level.Company
//            };

//            //entity1.Parent = parent;
//            //entity2.Parent = parent;

//            for (int i = 0; i < len; i++)
//            {
//                entity1.Children.Add(new Entity
//                {
//                    Description = i.ToString(),
//                    EntityLevel = Level.Division,
//                    Parent = parent
//                });


//                entity2.Children.Add(new Entity
//                {
//                    Description = (i).ToString(),
//                    EntityLevel = Level.Division,
//                    Parent = parent
//                });
//            }

//            var spec = new Dictionary<Type, IEnumerable<string>>();

//            spec.Add(typeof(Entity), new string[] { "Parent", "Description" });

//            _compare.IgnoreCollectionOrder = true;

//            _compare.CollectionMatchingSpec = spec;
//            _compare.MaxDifferences = int.MaxValue;

//            var result = _compare.Compare(entity1, entity2);

//            Assert.That(result);
//        }

//        [Test]
//        public void CollectionWithSpecComplexMatchNegative()
//        {
//            var entity1 = new Entity();
//            var entity2 = new Entity();
//            var len = 3;

//            var parent = new Entity
//            {
//                Description = "Me Papa",
//                EntityLevel = Level.Company
//            };

//            entity1.Parent = parent;
//            entity2.Parent = parent;
//            parent.Parent = parent;

//            for (int i = 0; i < len; i++)
//            {
//                entity1.Children.Add(new Entity
//                {
//                    Description = i.ToString(),
//                    EntityLevel = Level.Division,
//                    Parent = parent
//                });


//                entity2.Children.Add(new Entity
//                {
//                    Description = (i).ToString(),
//                    EntityLevel = Level.Department,
//                    Parent = parent
//                });
//            }

//            var spec = new Dictionary<Type, IEnumerable<string>>();

//            spec.Add(typeof(Entity), new string[] { "Parent", "Description" });

//            _compare.IgnoreCollectionOrder = true;

//            _compare.CollectionMatchingSpec = spec;
//            _compare.MaxDifferences = int.MaxValue;

//            var result = _compare.Compare(entity1, entity2);

//            Assert.AreEqual(_compare.Differences[0].Object1Value, Level.Division.ToString());

//            Assert.AreEqual(_compare.Differences[0].Object2Value, Level.Department.ToString());

//            //since the comparer will compare the Parent prop first, and it will find a difference
//            //it's Parent prop is actually null
//            Assert.That(_compare.Differences[0].ToString().Contains("(circular)"));
//        }

//        [Test]
//        public void CollectionWithSpecMatch()
//        {
//            var entity1 = new Entity();
//            var entity2 = new Entity();
//            var len = 3;

//            for (int i = 0; i < len; i++)
//            {
//                entity1.Children.Add(new Entity
//                {
//                    Description = i.ToString(),
//                    EntityLevel = Level.Company
//                });

//                entity2.Children.Add(new Entity
//                {
//                    Description = (i).ToString(),
//                    EntityLevel = Level.Department
//                });
//            }

//            var spec = new Dictionary<Type, IEnumerable<string>>();

//            spec.Add(typeof(Entity), new string[] { "Description" });

//            _compare.IgnoreCollectionOrder = true;

//            _compare.CollectionMatchingSpec = spec;

//            var result = _compare.Compare(entity1, entity2);

//            Assert.AreEqual(_compare.Differences[0].Object1Value, Level.Company.ToString());

//            Assert.AreEqual(_compare.Differences[0].Object2Value, Level.Department.ToString());

//            Assert.IsTrue(_compare.Differences[0].ToString().Contains("Match(Description"));
//        }


//        [Test]
//        public void CollectionWithSpecEmptyProps()
//        {
//            var entity1 = new Entity();
//            var entity2 = new Entity();
//            var len = 3;

//            for (int i = 0; i < len; i++)
//            {
//                entity1.Children.Add(new Entity
//                {
//                    Description = i.ToString(),
//                    EntityLevel = Level.Company
//                });

//                entity2.Children.Add(new Entity
//                {
//                    Description = (i).ToString(),
//                    EntityLevel = Level.Department
//                });
//            }

//            var spec = new Dictionary<Type, IEnumerable<string>>();

//            spec.Add(typeof(Entity), new string[] { });

//            _compare.IgnoreCollectionOrder = true;

//            _compare.CollectionMatchingSpec = spec;

//            var result = _compare.Compare(entity1, entity2);


//            Assert.AreEqual(_compare.Differences[0].Object1Value, Level.Company.ToString());

//        }

//        [Test]
//        public void CollectionWithSpecEmptyPropsAndEquality()
//        {
//            var entity1 = new EntityWithEquality();
//            var entity2 = new EntityWithEquality();
//            var len = 3;

//            for (int i = 0; i < len; i++)
//            {
//                entity1.Children.Add(new EntityWithEquality
//                {
//                    Description = i.ToString(),
//                    EntityLevel = Level.Company
//                });

//                entity2.Children.Add(new EntityWithEquality
//                {
//                    Description = (i).ToString(),
//                    EntityLevel = Level.Department
//                });
//            }

//            var spec = new Dictionary<Type, IEnumerable<string>>();

//            spec.Add(typeof(EntityWithEquality), new string[] { });

//            _compare.IgnoreCollectionOrder = true;

//            _compare.CollectionMatchingSpec = spec;

//            var result = _compare.Compare(entity1, entity2);


//            Assert.AreEqual(_compare.Differences[0].Object1Value, Level.Company.ToString());

//            Assert.AreEqual(_compare.Differences[0].Object2Value, Level.Department.ToString());

//            Assert.IsTrue(_compare.Differences[0].ToString().Contains("(Company,Department)"));

//        }

//        [Test]
//        public void CollectionWithSpecNoMatch()
//        {
//            var entity1 = new Entity();
//            var entity2 = new Entity();
//            var len = 3;

//            for (int i = 0; i < len; i++)
//            {
//                entity1.Children.Add(new Entity
//                {
//                    Description = i.ToString(),
//                    EntityLevel = Level.Company
//                });

//                entity2.Children.Add(new Entity
//                {
//                    Description = (i).ToString(),
//                    EntityLevel = Level.Department
//                });
//            }

//            var spec = new Dictionary<Type, IEnumerable<string>>();

//            spec.Add(typeof(Entity), new string[] { "Description", "EntityLevel" });

//            _compare.IgnoreCollectionOrder = true;

//            _compare.CollectionMatchingSpec = spec;

//            var result = _compare.Compare(entity1, entity2);

//            Assert.AreEqual(_compare.Differences[0].Object1Value, typeof(Entity).FullName);

//            Assert.AreEqual(_compare.Differences[0].Object2Value, "(null)");

//        }

//        #endregion

//        #region Shallow Tests
//        [Test]
//        public void ShallowWithNullNoChanges()
//        {
//            PrimitivePropertiesNullable p1 = new PrimitivePropertiesNullable();
//            PrimitivePropertiesNullable p2 = new PrimitivePropertiesNullable();
//            _compare.CompareChildren = false;

//            if (!_compare.Compare(p1, p2))
//                throw new Exception(_compare.DifferencesString);
//        }

//        [Test]
//        public void ShallowWithNullWithChanges()
//        {
//            PrimitivePropertiesNullable p1 = new PrimitivePropertiesNullable();
//            PrimitivePropertiesNullable p2 = new PrimitivePropertiesNullable();
//            p2.BooleanProperty = true;
//            _compare.CompareChildren = false;
//            Assert.IsFalse(_compare.Compare(p1, p2));
//        }

//        #endregion

//        #region Null Tests
//        [Test]
//        public void NullObjects()
//        {
//            Person p1 = null;
//            Person p2 = null;
//            if (!_compare.Compare(p1, p2))
//                throw new Exception(_compare.DifferencesString);
//        }

//        [Test]
//        public void ListOfNullObjects()
//        {
//            Person p1 = null;
//            Person p2 = null;

//            List<Person> list1 = new List<Person>();
//            list1.Add(p1);
//            list1.Add(p2);

//            List<Person> list2 = new List<Person>();
//            list2.Add(p1);
//            list2.Add(p2);

//            if (!_compare.Compare(list1, list2))
//                throw new Exception(_compare.DifferencesString);
//        }

//        [Test]
//        public void OneObjectNull()
//        {
//            Person p1 = null;
//            Person p2 = new Person();
//            Assert.IsFalse(_compare.Compare(p1, p2));
//            Assert.IsFalse(_compare.Compare(p2, p1));
//        }

//        [Test]
//        public void SecondObjectNull()
//        {
//            Person p1 = new Person();
//            Person p2 = null;
//            Assert.IsFalse(_compare.Compare(p1, p2));
//            Assert.IsFalse(_compare.Compare(p2, p1));
//        }


//        #endregion

//        #region Callback Tests
//        [Test]
//        public void CallbackNotCalledTest()
//        {
//            Person p1 = new Person();
//            p1.DateCreated = DateTime.Now;
//            p1.Name = "Greg";
//            Person p2 = new Person();
//            p2.Name = "Greg";
//            p2.DateCreated = p1.DateCreated;

//            var called = false;

//            _compare.DifferenceCallback = d =>
//            {
//                called = true;
//            };

//            _compare.Compare(p1, p2);

//            Assert.IsFalse(called);
//        }

//        [Test]
//        public void CallbackCalledTest()
//        {
//            Person p1 = new Person();
//            p1.DateCreated = DateTime.Now;
//            p1.Name = "Greg";
//            Person p2 = new Person();
//            p2.Name = "Greg";
//            p2.DateCreated = p1.DateCreated.AddSeconds(1);

//            var called = false;

//            _compare.DifferenceCallback = d =>
//            {
//                called = true;
//            };

//            _compare.Compare(p1, p2);

//            Assert.IsTrue(called);
//        }
//        #endregion

//        #region Property Tests
//        [Test]
//        public void PropertyAndFieldTest()
//        {
//            Person p1 = new Person();
//            p1.DateCreated = DateTime.Now;
//            p1.Name = "Greg";
//            Person p2 = new Person();
//            p2.Name = "Greg";
//            p2.DateCreated = p1.DateCreated;

//            if (!_compare.Compare(p1, p2))
//                throw new Exception(_compare.DifferencesString);
//        }

//        [Test]
//        public void TickTest()
//        {
//            Person p1 = new Person();
//            p1.DateCreated = DateTime.Now;
//            p1.Name = "Greg";
//            Person p2 = new Person();
//            p2.Name = "Greg";
//            p2.DateCreated = p1.DateCreated.AddTicks(1);

//            Assert.IsFalse(_compare.Compare(p1, p2));
//        }


//        #endregion

//        #region Dictionary Tests
//        [Test]
//        public void TestDictionary()
//        {
//            Person p1 = new Person();
//            p1.DateCreated = DateTime.Now;
//            p1.Name = "Owen";
//            Person p2 = new Person();
//            p2.Name = "Greg";
//            p2.DateCreated = DateTime.Now.AddDays(-1);

//            Dictionary<string, Person> dict1 = new Dictionary<string, Person>();
//            dict1.Add("1001", p1);
//            dict1.Add("1002", p2);

//            Dictionary<string, Person> dict2 = Common.CloneWithSerialization(dict1);

//            if (!_compare.Compare(dict1, dict2))
//                throw new Exception(_compare.DifferencesString);

//        }

//        [Test]
//        public void TestDictionaryWithIgnoreCollectionOrder()
//        {
//            var p1 = new Person();
//            p1.DateCreated = DateTime.Now;
//            p1.Name = "Owen";

//            var p2 = new Person();
//            p2.Name = "Greg";
//            p2.DateCreated = DateTime.Now.AddDays(-1);

//            var p3 = new Person();
//            p3.Name = "Wink";
//            p3.DateCreated = DateTime.Now.AddDays(-2);

//            var dict1 = new Dictionary<string, Person>();
//            dict1.Add("1001", p1);
//            dict1.Add("1002", p2);

//            var dict2 = new Dictionary<string, Person>();
//            dict2.Add("1002", p2);
//            dict2.Add("1001", p1);

//            _compare.IgnoreCollectionOrder = true;
//            if (!_compare.Compare(dict1, dict2))
//                throw new Exception(_compare.DifferencesString);

//            if (!_compare.Compare(dict2, dict1))
//                throw new Exception(_compare.DifferencesString);


//            dict1.Add("1003", p3);
//            dict2.Add("1003", p3);

//            if (!_compare.Compare(dict1, dict2))
//                throw new Exception(_compare.DifferencesString);

//            if (!_compare.Compare(dict2, dict1))
//                throw new Exception(_compare.DifferencesString);
//        }

//        [Test]
//        public void TestDictionaryWithIgnoreCollectionOrderOddOrder()
//        {
//            var p1 = new Person();
//            p1.DateCreated = DateTime.Now;
//            p1.Name = "Owen";

//            var p2 = new Person();
//            p2.Name = "Greg";
//            p2.DateCreated = DateTime.Now.AddDays(-1);

//            var p3 = new Person();
//            p3.Name = "Wink";
//            p3.DateCreated = DateTime.Now.AddDays(-2);

//            var p4 = new Person();
//            p3.Name = "Larry";
//            p3.DateCreated = DateTime.Now.AddDays(-3);

//            var dict1 = new Dictionary<string, Person>();
//            dict1.Add("1003", p3);
//            dict1.Add("1001", p1);
//            dict1.Add("1004", p4);
//            dict1.Add("1002", p2);

//            var dict2 = new Dictionary<string, Person>();
//            dict2.Add("1002", p2);
//            dict2.Add("1001", p1);
//            dict2.Add("1003", p3);
//            dict2.Add("1004", p4);

//            Assert.IsFalse(_compare.Compare(dict1, dict2));
//            Assert.IsFalse(_compare.Compare(dict2, dict1));
//        }

//        [Test]
//        public void TestDictionaryWithIgnoreCollectionOrderNegative()
//        {
//            var p1 = new Person();
//            p1.DateCreated = DateTime.Now;
//            p1.Name = "Owen";

//            var p2 = new Person();
//            p2.Name = "Greg";
//            p2.DateCreated = DateTime.Now.AddDays(-1);

//            var p3 = new Person();
//            p3.Name = "Wink";
//            p3.DateCreated = DateTime.Now.AddDays(-2);

//            var p4 = new Person();
//            p3.Name = "Larry";
//            p3.DateCreated = DateTime.Now.AddDays(-3);

//            var dict1 = new Dictionary<string, Person>();
//            dict1.Add("1001", p1);
//            dict1.Add("1002", p2);
//            dict1.Add("1003", p3);

//            var dict2 = new Dictionary<string, Person>();
//            dict2.Add("1002", p2);
//            dict2.Add("1001", p1);
//            dict2.Add("1003", p4);

//            Assert.IsFalse(_compare.Compare(dict1, dict2));
//        }

//        [Test]
//        public void TestDictionaryNegative()
//        {
//            Person p1 = new Person();
//            p1.DateCreated = DateTime.Now;
//            p1.Name = "Owen";
//            Person p2 = new Person();
//            p2.Name = "Greg";
//            p2.DateCreated = DateTime.Now.AddDays(-1);

//            Dictionary<string, Person> dict1 = new Dictionary<string, Person>();
//            dict1.Add("1001", p1);
//            dict1.Add("1002", p2);

//            Dictionary<string, Person> dict2 = Common.CloneWithSerialization(dict1);

//            dict2["1002"].DateCreated = DateTime.Now.AddDays(1);

//            Assert.IsFalse(_compare.Compare(dict1, dict2));

//        }
//        #endregion

//        #region Struct Tests
//        [Test]
//        public void TestStruct()
//        {
//            Size size1 = new Size();
//            size1.Width = 800;
//            size1.Height = 600;

//            Size size2 = new Size();
//            size2.Width = 1024;
//            size2.Height = 768;

//            List<Size> list1 = new List<Size>();
//            list1.Add(size1);
//            list1.Add(size2);

//            List<Size> list2 = new List<Size>();
//            list2.Add(size1);
//            list2.Add(size2);

//            if (!_compare.Compare(list1, list2))
//                throw new Exception(_compare.DifferencesString);
//        }

//        [Test]
//        public void TestStructNegative()
//        {
//            Size size1 = new Size();
//            size1.Width = 800;
//            size1.Height = 600;

//            Size size2 = new Size();
//            size2.Width = 1024;
//            size2.Height = 768;

//            List<Size> list1 = new List<Size>();
//            list1.Add(size1);
//            list1.Add(size2);

//            List<Size> list2 = new List<Size>();
//            list2.Add(size1);
//            Size size3 = new Size();
//            size3.Width = 1025;
//            size3.Height = 768;
//            list2.Add(size3);

//            Assert.IsFalse(_compare.Compare(list1, list2));
//        }

//        [Test]
//        public void TestStructWithNoPublicFields()
//        {
//            var point1 = new Point(1, 1);
//            var point2 = new Point(1, 1);

//            if (!_compare.Compare(point1, point2))
//                throw new Exception(_compare.DifferencesString);
//        }

//        [Test]
//        public void TestStructWithNoPublicFieldsNegative()
//        {
//            var point1 = new Point(1, 1);
//            var point2 = new Point(2, 2);

//            Assert.IsFalse(_compare.Compare(point1, point2));
//        }

//        [Test]
//        public void TestStructWithPublicStaticPropOfSameType()
//        {
//            var point1 = StructWithStaticProperty.Origin;
//            var point2 = StructWithStaticProperty.Origin;

//            if (!_compare.Compare(point1, point2))
//                throw new Exception(_compare.DifferencesString);
//        }

//        #endregion

//        #region Enumeration Tests
//        [Test]
//        public void TestEnumeration()
//        {
//            List<Deck> list1 = new List<Deck>();
//            list1.Add(Deck.Engineering);
//            list1.Add(Deck.SickBay);

//            List<Deck> list2 = new List<Deck>();
//            list2.Add(Deck.Engineering);
//            list2.Add(Deck.SickBay);

//            if (!_compare.Compare(list1, list2))
//                throw new Exception(_compare.DifferencesString);
//        }

//        [Test]
//        public void TestEnumerationNegative()
//        {
//            List<Deck> list1 = new List<Deck>();
//            list1.Add(Deck.Engineering);
//            list1.Add(Deck.SickBay);

//            List<Deck> list2 = new List<Deck>();
//            list2.Add(Deck.Engineering);
//            list2.Add(Deck.AstroPhysics);

//            Assert.IsFalse(_compare.Compare(list1, list2));
//            Console.WriteLine(_compare.DifferencesString);
//        }

//        [Test]
//        public void TestNullableEnumeration()
//        {
//            List<Deck?> list1 = new List<Deck?>();
//            list1.Add(Deck.Engineering);
//            list1.Add(null);

//            List<Deck?> list2 = new List<Deck?>();
//            list2.Add(Deck.Engineering);
//            list2.Add(null);

//            if (!_compare.Compare(list1, list2))
//                throw new Exception(_compare.DifferencesString);
//        }

//        [Test]
//        public void TestNullableEnumerationNegative()
//        {
//            List<Deck?> list1 = new List<Deck?>();
//            list1.Add(Deck.Engineering);
//            list1.Add(null);

//            List<Deck?> list2 = new List<Deck?>();
//            list2.Add(Deck.Engineering);
//            list2.Add(Deck.AstroPhysics);

//            Assert.IsFalse(_compare.Compare(list1, list2));
//        }

//        #endregion

//        #region GUID Tests
//        [Test]
//        public void TestGuid()
//        {
//            Guid guid1 = Guid.NewGuid();
//            Guid guid2 = Guid.NewGuid();

//            List<Guid> list1 = new List<Guid>();
//            list1.Add(guid1);
//            list1.Add(guid2);

//            List<Guid> list2 = new List<Guid>();
//            list2.Add(guid1);
//            list2.Add(guid2);

//            if (!_compare.Compare(list1, list2))
//                throw new Exception(_compare.DifferencesString);
//        }

//        [Test]
//        public void TestGuidNegative()
//        {
//            Guid guid1 = Guid.NewGuid();
//            Guid guid2 = Guid.NewGuid();
//            Guid guid3 = Guid.NewGuid();

//            List<Guid> list1 = new List<Guid>();
//            list1.Add(guid1);
//            list1.Add(guid2);

//            List<Guid> list2 = new List<Guid>();
//            list2.Add(guid1);
//            list2.Add(guid3);

//            Assert.IsFalse(_compare.Compare(list1, list2));
//        }

//        #endregion

//        #region Test Timespan
//        [Test]
//        public void TestTimespan()
//        {
//            TimeSpan ts1 = DateTime.Now - DateTime.Now.AddMinutes(-61);
//            TimeSpan ts2 = DateTime.Now - DateTime.Now.AddHours(-49);

//            List<TimeSpan> list1 = new List<TimeSpan>();
//            list1.Add(ts1);
//            list1.Add(ts2);

//            List<TimeSpan> list2 = new List<TimeSpan>();
//            list2.Add(ts1);
//            list2.Add(ts2);

//            if (!_compare.Compare(list1, list2))
//                throw new Exception(_compare.DifferencesString);
//        }

//        [Test]
//        public void TestTimeSpanNegative()
//        {
//            TimeSpan ts1 = DateTime.Now - DateTime.Now.AddMinutes(-61);
//            TimeSpan ts2 = DateTime.Now - DateTime.Now.AddHours(-49);
//            TimeSpan ts3 = DateTime.Now - DateTime.Now.AddHours(-48);

//            List<TimeSpan> list1 = new List<TimeSpan>();
//            list1.Add(ts1);
//            list1.Add(ts2);

//            List<TimeSpan> list2 = new List<TimeSpan>();
//            list2.Add(ts1);
//            list2.Add(ts3);

//            Assert.IsFalse(_compare.Compare(list1, list2));
//        }
//        #endregion

//        #region Test Pointers

//        [Test]
//        public void TestIntPtr()
//        {
//            Assert.IsTrue(_compare.Compare((IntPtr)1, (IntPtr)1));
//            Assert.IsFalse(_compare.Compare((IntPtr)1, (IntPtr)2));
//        }

//        [Test]
//        public void TestUIntPtr()
//        {
//            Assert.IsTrue(_compare.Compare((UIntPtr)1, (UIntPtr)1));
//            Assert.IsFalse(_compare.Compare((UIntPtr)1, (UIntPtr)2));
//        }

//        #endregion Test Pointers

//        #region Array Tests
//        [Test]
//        public void ByteArrayTest()
//        {
//            byte[] b1 = new byte[256];
//            byte[] b2 = new byte[256];
//            for (int i = 0; i <= 255; i++)
//                b1[i] = (byte)i;

//            b1.CopyTo(b2, 0);

//            if (!_compare.Compare(b1, b2))
//                throw new Exception(_compare.DifferencesString);
//        }

//        [Test]
//        public void ArrayTest()
//        {
//            Person p1 = new Person();
//            p1.DateCreated = DateTime.Now;
//            p1.Name = "Greg";

//            Person p2 = new Person();
//            p2.Name = "Greg";
//            p2.DateCreated = p1.DateCreated;

//            Person[] array1 = new Person[2];
//            Person[] array2 = new Person[2];

//            array1[0] = p1;
//            array1[1] = p2;

//            array2[0] = Common.CloneWithSerialization(p1);
//            array2[1] = Common.CloneWithSerialization(p2);

//            if (!_compare.Compare(array1, array2))
//                throw new Exception(_compare.DifferencesString);
//        }

//        [Test]
//        public void ArrayTestNegative()
//        {
//            Person p1 = new Person();
//            p1.DateCreated = DateTime.Now;
//            p1.Name = "Greg";

//            Person p2 = new Person();
//            p2.Name = "Greg";
//            p2.DateCreated = p1.DateCreated;

//            Person[] array1 = new Person[2];
//            Person[] array2 = new Person[2];

//            array1[0] = p1;
//            array1[1] = p2;

//            array2[0] = Common.CloneWithSerialization(p1);
//            array2[1] = Common.CloneWithSerialization(p2);
//            array2[1].Name = "Bob";

//            Assert.IsFalse(_compare.Compare(array1, array2));
//        }

//        [Test]
//        public void MultiDimensionalByteArrayTest()
//        {
//            byte[,] bytes1 = new byte[3, 2];
//            byte[,] bytes2 = new byte[3, 2];

//            bytes1[0, 0] = 3;
//            bytes1[1, 0] = 35;
//            bytes1[2, 0] = 6;
//            bytes1[0, 1] = 3;
//            bytes1[1, 1] = 35;
//            bytes1[2, 1] = 6;

//            bytes2[0, 0] = 3;
//            bytes2[1, 0] = 35;
//            bytes2[2, 0] = 6;
//            bytes2[0, 1] = 3;
//            bytes2[1, 1] = 35;
//            bytes2[2, 1] = 6;

//            if (!_compare.Compare(bytes1, bytes2))
//                throw new Exception(_compare.DifferencesString);
//        }

//        [Test]
//        public void MultiDimensionalByteArrayNegative()
//        {
//            byte[,] bytes1 = new byte[3, 2];
//            byte[,] bytes2 = new byte[3, 2];

//            bytes1[0, 0] = 3;
//            bytes1[1, 0] = 35;
//            bytes1[2, 0] = 6;
//            bytes1[0, 1] = 3;
//            bytes1[1, 1] = 35;
//            bytes1[2, 1] = 6;

//            bytes2[0, 0] = 3;
//            bytes2[1, 0] = 35;
//            bytes2[2, 0] = 6;
//            bytes2[0, 1] = 3;
//            bytes2[1, 1] = 36;
//            bytes2[2, 1] = 6;

//            Assert.IsFalse(_compare.Compare(bytes1, bytes2));
//        }

//        #endregion

//        #region Entity Tree Tests
//        [Test]
//        public void TestEntityTree()
//        {
//            List<Entity> entityTree = new List<Entity>();

//            //Brave Sir Robin Security Company
//            Entity top1 = new Entity();
//            top1.Description = "Brave Sir Robin Security Company";
//            top1.Parent = null;
//            top1.EntityLevel = Level.Company;
//            entityTree.Add(top1);

//            Entity div1 = new Entity();
//            div1.Description = "Minstrils";
//            div1.EntityLevel = Level.Division;
//            div1.Parent = top1;
//            top1.Children.Add(div1);

//            Entity div2 = new Entity();
//            div2.Description = "Sub Contracted Fighting";
//            div2.EntityLevel = Level.Division;
//            div2.Parent = top1;
//            top1.Children.Add(div2);

//            Entity dep2 = new Entity();
//            dep2.Description = "Trojan Rabbit Department";
//            dep2.EntityLevel = Level.Department;
//            dep2.Parent = div2;
//            div2.Children.Add(dep2);

//            //Roger the Shrubber's Fine Shrubberies
//            Entity top1b = new Entity();
//            top1b.Description = "Roger the Shrubber's Fine Shrubberies";
//            top1b.Parent = null;
//            top1b.EntityLevel = Level.Company;
//            entityTree.Add(top1b);

//            Entity div1b = new Entity();
//            div1b.Description = "Manufacturing";
//            div1b.EntityLevel = Level.Division;
//            div1b.Parent = top1;
//            top1b.Children.Add(div1);

//            Entity dep1b = new Entity();
//            dep1b.Description = "Design Department";
//            dep1b.EntityLevel = Level.Department;
//            dep1b.Parent = div1b;
//            div1b.Children.Add(dep1b);

//            Entity dep2b = new Entity();
//            dep2b.Description = "Arranging Department";
//            dep2b.EntityLevel = Level.Department;
//            dep2b.Parent = div1b;
//            div1b.Children.Add(dep2b);

//            Entity div2b = new Entity();
//            div2b.Description = "Sales";
//            div2b.EntityLevel = Level.Division;
//            div2b.Parent = top1;
//            top1b.Children.Add(div2b);

//            List<Entity> entityTreeCopy = Common.CloneWithSerialization(entityTree);

//            if (!_compare.Compare(entityTree, entityTreeCopy))
//                throw new Exception(_compare.DifferencesString);
//        }

//        [Test]
//        public void TestEntityTreeNegative()
//        {
//            List<Entity> entityTree = new List<Entity>();

//            //Brave Sir Robin Security Company
//            Entity top1 = new Entity();
//            top1.Description = "Brave Sir Robin Security Company";
//            top1.Parent = null;
//            top1.EntityLevel = Level.Company;
//            entityTree.Add(top1);

//            Entity div1 = new Entity();
//            div1.Description = "Minstrils";
//            div1.EntityLevel = Level.Division;
//            div1.Parent = top1;
//            top1.Children.Add(div1);

//            Entity div2 = new Entity();
//            div2.Description = "Sub Contracted Fighting";
//            div2.EntityLevel = Level.Division;
//            div2.Parent = top1;
//            top1.Children.Add(div2);

//            Entity dep2 = new Entity();
//            dep2.Description = "Trojan Rabbit Department";
//            dep2.EntityLevel = Level.Department;
//            dep2.Parent = div2;
//            div2.Children.Add(dep2);

//            //Roger the Shrubber's Fine Shrubberies
//            Entity top1b = new Entity();
//            top1b.Description = "Roger the Shrubber's Fine Shrubberies";
//            top1b.Parent = null;
//            top1b.EntityLevel = Level.Company;
//            entityTree.Add(top1b);

//            Entity div1b = new Entity();
//            div1b.Description = "Manufacturing";
//            div1b.EntityLevel = Level.Division;
//            div1b.Parent = top1;
//            top1b.Children.Add(div1);

//            Entity dep1b = new Entity();
//            dep1b.Description = "Design Department";
//            dep1b.EntityLevel = Level.Department;
//            dep1b.Parent = div1b;
//            div1b.Children.Add(dep1b);

//            Entity dep2b = new Entity();
//            dep2b.Description = "Arranging Department";
//            dep2b.EntityLevel = Level.Department;
//            dep2b.Parent = div1b;
//            div1b.Children.Add(dep2b);

//            Entity div2b = new Entity();
//            div2b.Description = "Sales";
//            div2b.EntityLevel = Level.Division;
//            div2b.Parent = top1;
//            top1b.Children.Add(div2b);

//            List<Entity> entityTreeCopy = Common.CloneWithSerialization(entityTree);

//            entityTreeCopy[1].Children[1].Description = "Retail";

//            Assert.IsFalse(_compare.Compare(entityTree, entityTreeCopy));
//            Console.WriteLine(_compare.ElapsedMilliseconds);
//        }

//        #endregion

//        #region Private Property Tests
//        [Test]
//        public void PrivatePropertyPositive()
//        {
//            RecipeDetail detail1 = new RecipeDetail(true, "Toffee");
//            detail1.Ingredient = "Crunchy Chocolate";

//            RecipeDetail detail2 = new RecipeDetail(true, "Toffee");
//            detail2.Ingredient = "Crunchy Chocolate";

//            _compare.ComparePrivateProperties = true;
//            Assert.IsTrue(_compare.Compare(detail1, detail2));
//            _compare.ComparePrivateProperties = false;
//        }

//        [Test]
//        public void PrivatePropertyNegative()
//        {
//            RecipeDetail detail1 = new RecipeDetail(true, "Toffee");
//            detail1.Ingredient = "Crunchy Chocolate";

//            RecipeDetail detail2 = new RecipeDetail(true, "Crunchy Frogs");
//            detail2.Ingredient = "Crunchy Chocolate";

//            _compare.ComparePrivateProperties = true;
//            Assert.IsFalse(_compare.Compare(detail1, detail2));
//            _compare.ComparePrivateProperties = false;
//        }
//        #endregion

//        #region Private Field Tests
//        [Test]
//        public void PrivateFieldPositive()
//        {
//            RecipeDetail detail1 = new RecipeDetail(true, "Toffee");
//            detail1.Ingredient = "Crunchy Chocolate";

//            RecipeDetail detail2 = new RecipeDetail(true, "Toffee");
//            detail2.Ingredient = "Crunchy Chocolate";

//            _compare.ComparePrivateFields = true;
//            Assert.IsTrue(_compare.Compare(detail1, detail2));
//            _compare.ComparePrivateFields = false;
//        }

//        [Test]
//        public void PrivateFieldNegative()
//        {
//            RecipeDetail detail1 = new RecipeDetail(true, "Toffee");
//            detail1.Ingredient = "Crunchy Chocolate";

//            RecipeDetail detail2 = new RecipeDetail(true, "Crunchy Frogs");
//            detail2.Ingredient = "Crunchy Chocolate";

//            _compare.ComparePrivateFields = true;
//            Assert.IsFalse(_compare.Compare(detail1, detail2));
//            _compare.ComparePrivateFields = false;
//        }

//        [Test]
//        public void PrivateFieldInBaseClassPositive()
//        {
//            Movie movie1 = new Movie();
//            movie1.Name = "Jaws";
//            movie1.SetPrivateString("Boca Grande");

//            Movie movie2 = new Movie();
//            movie2.Name = "Jaws";
//            movie2.SetPrivateString("Boca Grande");

//            _compare.ComparePrivateFields = true;
//            Assert.IsTrue(_compare.Compare(movie1, movie2));
//            _compare.ComparePrivateFields = false;
//        }

//        [Test]
//        public void PrivateFieldInBaseClassNegative()
//        {
//            Movie movie1 = new Movie();
//            movie1.Name = "Jaws";
//            movie1.SetPrivateString("Boca Grande");

//            Movie movie2 = new Movie();
//            movie2.Name = "Jaws";
//            movie2.SetPrivateString("Boca Pequeno");

//            _compare.ComparePrivateFields = true;
//            Assert.IsFalse(_compare.Compare(movie1, movie2));
//            _compare.ComparePrivateFields = false;
//        }
//        #endregion

//        #region Ignore Read Only Tests
//        [Test]
//        public void IgnoreReadOnlyPositive()
//        {
//            RecipeDetail detail1 = new RecipeDetail(true, "Toffee");
//            detail1.Ingredient = "Crunchy Chocolate";

//            RecipeDetail detail2 = new RecipeDetail(false, "Toffee");
//            detail2.Ingredient = "Crunchy Chocolate";

//            _compare.CompareReadOnly = false;
//            Assert.IsTrue(_compare.Compare(detail1, detail2));
//            _compare.CompareReadOnly = true;
//        }

//        [Test]
//        public void IgnoreReadOnlyNegative()
//        {
//            RecipeDetail detail1 = new RecipeDetail(true, "Toffee");
//            detail1.Ingredient = "Crunchy Chocolate";

//            RecipeDetail detail2 = new RecipeDetail(false, "Toffee");
//            detail2.Ingredient = "Crunchy Chocolate";

//            Assert.IsFalse(_compare.Compare(detail1, detail2));
//        }
//        #endregion

//        #region Ignore Children Tests
//        [Test]
//        public void IgnoreChildDifferencesPositiveTest()
//        {
//            List<Entity> entityTree = new List<Entity>();

//            Entity top1 = new Entity();
//            top1.Description = "Brave Sir Robin Security Company";
//            top1.Parent = null;
//            top1.EntityLevel = Level.Company;
//            entityTree.Add(top1);

//            Entity div1 = new Entity();
//            div1.Description = "Minstrils";
//            div1.EntityLevel = Level.Division;
//            div1.Parent = top1;
//            top1.Children.Add(div1);

//            List<Entity> entityTreeCopy = Common.CloneWithSerialization(entityTree);

//            entityTreeCopy[0].Children[0].EntityLevel = Level.Department;

//            _compare.CompareChildren = false;
//            Assert.IsTrue(_compare.Compare(entityTree, entityTreeCopy));
//            _compare.CompareChildren = true;
//        }

//        [Test]
//        public void IgnoreChildDifferencesNegativeTest()
//        {
//            List<Entity> entityTree = new List<Entity>();

//            Entity top1 = new Entity();
//            top1.Description = "Brave Sir Robin Security Company";
//            top1.Parent = null;
//            top1.EntityLevel = Level.Company;
//            entityTree.Add(top1);

//            Entity div1 = new Entity();
//            div1.Description = "Minstrils";
//            div1.EntityLevel = Level.Division;
//            div1.Parent = top1;
//            top1.Children.Add(div1);

//            List<Entity> entityTreeCopy = Common.CloneWithSerialization(entityTree);

//            entityTreeCopy[0].Children[0].EntityLevel = Level.Department;

//            _compare.CompareChildren = true;
//            Assert.IsFalse(_compare.Compare(entityTree, entityTreeCopy));
//        }

//        #endregion

//        #region Generic Entity List Test
//        [Test]
//        public void GenericEntityListTest()
//        {
//            GenericEntity<IEntity> genericEntity = new GenericEntity<IEntity>();
//            genericEntity.MyList = new List<IEntity>();

//            //Brave Sir Robin Security Company
//            Entity top1 = new Entity();
//            top1.Description = "Brave Sir Robin Security Company";
//            top1.Parent = null;
//            top1.EntityLevel = Level.Company;
//            genericEntity.MyList.Add(top1);

//            GenericEntity<IEntity> genericEntityCopy = new GenericEntity<IEntity>();
//            genericEntityCopy.MyList = new List<IEntity>();

//            //Brave Sir Robin Security Company
//            Entity top2 = new Entity();
//            top2.Description = "Brave Sir Robin Security Company";
//            top2.Parent = null;
//            top2.EntityLevel = Level.Company;
//            genericEntityCopy.MyList.Add(top2);

//            Assert.IsTrue(_compare.Compare(genericEntity, genericEntityCopy));

//            genericEntityCopy.MyList[0].Description = "When danger reared its ugly head Brave Sir Robin fled.";

//            Assert.IsFalse(_compare.Compare(genericEntity, genericEntityCopy));
//        }

//        [Test]
//        public void GenericEntityListMultipleItemsTest()
//        {
//            GenericEntity<IEntity> genericEntity = new GenericEntity<IEntity>();
//            genericEntity.MyList = new List<IEntity>();

//            //Brave Sir Robin Security Company
//            Entity top1 = new Entity();
//            top1.Description = "Brave Sir Robin Security Company";
//            top1.Parent = null;
//            top1.EntityLevel = Level.Company;

//            GenericEntity<IEntity> genericEntityCopy = new GenericEntity<IEntity>();
//            genericEntityCopy.MyList = new List<IEntity>();

//            //Brave Sir Robin Security Company
//            Entity top2 = new Entity();
//            top2.Description = "Brave Sir Robin Security Company";
//            top2.Parent = null;
//            top2.EntityLevel = Level.Company;


//            Entity top3 = new Entity();
//            top3.Description = "May I obey all your commands with equal pleasure, Sire!";
//            top3.Parent = null;
//            top3.EntityLevel = Level.Department;


//            genericEntity.MyList.Add(top1);
//            genericEntity.MyList.Add(top3);
//            genericEntityCopy.MyList.Add(top2);
//            genericEntityCopy.MyList.Add(top3);

//            Assert.IsTrue(_compare.Compare(genericEntity, genericEntityCopy));

//            genericEntityCopy.MyList[0].Description = "When danger reared its ugly head Brave Sir Robin fled.";

//            Assert.IsFalse(_compare.Compare(genericEntity, genericEntityCopy));
//        }

//        [Test]
//        public void GenericEntityListMultipleItemsOddOrderTest()
//        {
//            GenericEntity<IEntity> genericEntity = new GenericEntity<IEntity>();
//            genericEntity.MyList = new List<IEntity>();

//            GenericEntity<IEntity> genericEntityCopy = new GenericEntity<IEntity>();
//            genericEntityCopy.MyList = new List<IEntity>();

//            //Brave Sir Robin Security Company
//            Entity top1 = new Entity();
//            top1.Description = "Brave Sir Robin Security Company";
//            top1.Parent = null;
//            top1.EntityLevel = Level.Company;

//            //Brave Sir Robin Security Company
//            Entity top2 = new Entity();
//            top2.Description = "Brave Sir Robin Security Company";
//            top2.Parent = null;
//            top2.EntityLevel = Level.Company;

//            Entity top3 = new Entity();
//            top3.Description = "May I obey all your commands with equal pleasure, Sire!";
//            top3.Parent = null;
//            top3.EntityLevel = Level.Department;

//            Entity top4 = new Entity();
//            top4.Description = "Overtaxed, overworked and paid off with a knife, a club or a rope.";
//            top4.Parent = null;
//            top4.EntityLevel = Level.Department;


//            genericEntity.MyList.Add(top4);
//            genericEntity.MyList.Add(top3);
//            genericEntity.MyList.Add(top1);
//            genericEntity.MyList.Add(top2);
//            genericEntityCopy.MyList.Add(top2);
//            genericEntityCopy.MyList.Add(top1);
//            genericEntityCopy.MyList.Add(top3);
//            genericEntityCopy.MyList.Add(top4);

//            _compare.IgnoreCollectionOrder = true;

//            Assert.IsTrue(_compare.Compare(genericEntity, genericEntityCopy));

//            genericEntityCopy.MyList[0].Description = "When danger reared its ugly head Brave Sir Robin fled.";

//            Assert.IsFalse(_compare.Compare(genericEntity, genericEntityCopy));
//        }

//        [Test]
//        public void GenericEntityListMultipleItemsWithIgnoreCollectionOrderTest()
//        {
//            GenericEntity<IEntity> genericEntity = new GenericEntity<IEntity>();
//            genericEntity.MyList = new List<IEntity>();

//            //Brave Sir Robin Security Company
//            Entity top1 = new Entity();
//            top1.Description = "Brave Sir Robin Security Company";
//            top1.Parent = null;
//            top1.EntityLevel = Level.Company;

//            GenericEntity<IEntity> genericEntityCopy = new GenericEntity<IEntity>();
//            genericEntityCopy.MyList = new List<IEntity>();

//            //Brave Sir Robin Security Company
//            Entity top2 = new Entity();
//            top2.Description = "Brave Sir Robin Security Company";
//            top2.Parent = null;
//            top2.EntityLevel = Level.Company;


//            Entity top3 = new Entity();
//            top3.Description = "May I obey all your commands with equal pleasure, Sire!";
//            top3.Parent = null;
//            top3.EntityLevel = Level.Department;


//            genericEntity.MyList.Add(top3);
//            genericEntity.MyList.Add(top1);
//            genericEntityCopy.MyList.Add(top2);
//            genericEntityCopy.MyList.Add(top3);

//            _compare.IgnoreCollectionOrder = true;

//            Assert.IsTrue(_compare.Compare(genericEntity, genericEntityCopy));

//            genericEntityCopy.MyList[0].Description = "When danger reared its ugly head Brave Sir Robin fled.";

//            Assert.IsFalse(_compare.Compare(genericEntity, genericEntityCopy));
//        }

//        #endregion

//        #region Cachine Tests
//        [Test]
//        public void CachingTest()
//        {
//            List<Person> list1 = new List<Person>();
//            List<Person> list2 = new List<Person>();

//            for (int i = 1; i <= 10000; i++)
//            {
//                Person person = new Person();
//                person.DateCreated = DateTime.Now;
//                person.Name = "Robot " + i;
//                list1.Add(person);
//                list2.Add(Common.CloneWithSerialization(person));
//            }

//            _compare.Caching = false;
//            Stopwatch watch = new Stopwatch();
//            watch.Start();
//            Assert.IsTrue(_compare.Compare(list1, list2));
//            watch.Stop();
//            long timeWithNoCaching = watch.ElapsedMilliseconds;
//            Console.WriteLine("Compare 10000 objects no caching: {0} milliseconds", timeWithNoCaching);

//            _compare.Caching = true;
//            watch.Reset();
//            watch.Start();
//            Assert.IsTrue(_compare.Compare(list1, list2));
//            watch.Stop();
//            long timeWithCaching = watch.ElapsedMilliseconds;
//            Console.WriteLine("Compare 10000 objects with caching: {0} milliseconds", timeWithCaching);

//            Assert.IsTrue(timeWithCaching < timeWithNoCaching);
//        }

//        #endregion

//        #region Ignore Object Types Tests

//        [Test]
//        public void IgnoreObjectTypesPositive()
//        {
//            RecipeDetail detail1 = new RecipeDetail(true, "Toffee");
//            detail1.Ingredient = "Crunchy Chocolate";

//            IndianRecipeDetail detail2 = new IndianRecipeDetail(true, "Toffee");
//            detail2.Ingredient = "Crunchy Chocolate";

//            _compare.IgnoreObjectTypes = true;
//            var result = _compare.Compare(detail1, detail2);

//            Assert.IsTrue(result, _compare.DifferencesString);
//            _compare.IgnoreObjectTypes = false;
//        }

//        [Test]
//        public void IgnoreObjectTypesNegative()
//        {
//            RecipeDetail detail1 = new RecipeDetail(true, "Toffee");
//            detail1.Ingredient = "Crunchy Chocolate";

//            IndianRecipeDetail detail2 = new IndianRecipeDetail(true, "Toffee");
//            detail2.Ingredient = "Curry sauce";

//            _compare.IgnoreObjectTypes = true;
//            var result = _compare.Compare(detail1, detail2);

//            Assert.IsFalse(result, _compare.DifferencesString);
//            _compare.IgnoreObjectTypes = false;
//        }



//        #endregion

//        #region Type of Type Tests
//        [Test]
//        public void TypeOfTypePositiveTest()
//        {
//            Table table1 = new Table();
//            table1.TableName = "Person";
//            table1.ClassType = typeof(Person);

//            Table table2 = new Table();
//            table2.TableName = "Person";
//            table2.ClassType = typeof(Person);

//            if (!_compare.Compare(table1, table2))
//                Assert.Fail(_compare.DifferencesString);
//        }

//        [Test]
//        public void TypeOfTypeNegativeTest()
//        {
//            Table table1 = new Table();
//            table1.TableName = "Person";
//            table1.ClassType = typeof(Person);

//            Table table2 = new Table();
//            table2.TableName = "Person";
//            table2.ClassType = typeof(RecipeDetail);

//            Assert.IsFalse(_compare.Compare(table1, table2));
//        }

//        #endregion

//        #region Uri Tests
//        [Test]
//        public void UriPostive()
//        {
//            Uri uri1 = new Uri("http://www.kellermansoftware.com");
//            Uri uri2 = new Uri("http://www.kellermansoftware.com");

//            if (!_compare.Compare(uri1, uri2))
//                Assert.Fail(_compare.DifferencesString);
//        }

//        [Test]
//        public void UriNegative()
//        {
//            Uri uri1 = new Uri("http://www.kellermansoftware.com");
//            Uri uri2 = new Uri("http://www.codeplex.com");
//            Assert.IsFalse(_compare.Compare(uri1, uri2));
//        }
//        #endregion

//        #region HashSet Tests

//        [Test]
//        public void HashSetsDifferent()
//        {
//            HashSetWrapper hashSet1 = new HashSetWrapper
//            {
//                StatusId = 1,
//                Name = "Paul"
//            };
//            HashSetWrapper hashSet2 = new HashSetWrapper
//            {
//                StatusId = 1,
//                Name = "Paul"
//            };

//            HashSetClass secondClassObject1 = new HashSetClass
//            {
//                Id = 1
//            };
//            HashSetClass secondClassObject2 = new HashSetClass
//            {
//                Id = 2
//            };

//            hashSet1.HashSetCollection.Add(secondClassObject1);
//            hashSet2.HashSetCollection.Add(secondClassObject2);

//            Assert.IsFalse(_compare.Compare(hashSet1, hashSet2));
//        }

//        [Test]
//        public void HashSetsSame()
//        {
//            HashSetWrapper hashSet1 = new HashSetWrapper
//            {
//                StatusId = 1,
//                Name = "Paul"
//            };
//            HashSetWrapper hashSet2 = new HashSetWrapper
//            {
//                StatusId = 1,
//                Name = "Paul"
//            };

//            HashSetClass secondClassObject1 = new HashSetClass
//            {
//                Id = 1
//            };
//            HashSetClass secondClassObject2 = new HashSetClass
//            {
//                Id = 1
//            };

//            hashSet1.HashSetCollection.Add(secondClassObject1);
//            hashSet2.HashSetCollection.Add(secondClassObject2);

//            if (!_compare.Compare(hashSet1, hashSet2))
//                Assert.Fail(_compare.DifferencesString);
//        }

//        [Test]
//        public void HashSetsMultipleItemsWithIgnoreCollectionOrderTest()
//        {
//            HashSetWrapper hashSet1 = new HashSetWrapper
//            {
//                StatusId = 1,
//                Name = "Paul"
//            };
//            HashSetWrapper hashSet2 = new HashSetWrapper
//            {
//                StatusId = 1,
//                Name = "Paul"
//            };

//            HashSetClass secondClassObject1 = new HashSetClass
//            {
//                Id = 1
//            };
//            HashSetClass secondClassObject2 = new HashSetClass
//            {
//                Id = 2
//            };

//            HashSetClass secondClassObject3 = new HashSetClass
//            {
//                Id = 3
//            };
//            HashSetClass secondClassObject4 = new HashSetClass
//            {
//                Id = 4
//            };


//            hashSet1.HashSetCollection.Add(secondClassObject3);
//            hashSet1.HashSetCollection.Add(secondClassObject1);
//            hashSet1.HashSetCollection.Add(secondClassObject2);
//            hashSet1.HashSetCollection.Add(secondClassObject4);

//            hashSet2.HashSetCollection.Add(secondClassObject2);
//            hashSet2.HashSetCollection.Add(secondClassObject4);
//            hashSet2.HashSetCollection.Add(secondClassObject3);
//            hashSet2.HashSetCollection.Add(secondClassObject1);

//            _compare.IgnoreCollectionOrder = true;

//            if (!_compare.Compare(hashSet1, hashSet2))
//                Assert.Fail(_compare.DifferencesString);
//        }

//        [Test]
//        public void HashSetsMultipleItemsWithIgnoreCollectionOrderNegativeTest()
//        {
//            HashSetWrapper hashSet1 = new HashSetWrapper
//            {
//                StatusId = 1,
//                Name = "Paul"
//            };
//            HashSetWrapper hashSet2 = new HashSetWrapper
//            {
//                StatusId = 1,
//                Name = "Paul"
//            };

//            HashSetClass secondClassObject1 = new HashSetClass
//            {
//                Id = 1
//            };
//            HashSetClass secondClassObject2 = new HashSetClass
//            {
//                Id = 2
//            };

//            HashSetClass secondClassObject3 = new HashSetClass
//            {
//                Id = 3
//            };
//            HashSetClass secondClassObject4 = new HashSetClass
//            {
//                Id = 4
//            };


//            hashSet1.HashSetCollection.Add(secondClassObject3);
//            hashSet1.HashSetCollection.Add(secondClassObject1);
//            hashSet1.HashSetCollection.Add(secondClassObject2);
//            hashSet1.HashSetCollection.Add(secondClassObject4);

//            hashSet2.HashSetCollection.Add(secondClassObject2);
//            hashSet2.HashSetCollection.Add(secondClassObject4);
//            hashSet2.HashSetCollection.Add(secondClassObject3);
//            hashSet2.HashSetCollection.Add(secondClassObject1);

//            _compare.IgnoreCollectionOrder = false;

//            Assert.IsFalse(_compare.Compare(hashSet1, hashSet2));
//        }
//        #endregion

//        #region IgnoreByAttributeTest
//        [Test]
//        public void IgnorePropertyAttribute()
//        {
//            Movie movie1 = new Movie();
//            movie1.Name = "Mission Impossible 13, Ethan Gets Unlucky";
//            movie1.PaymentForTomCruise = 20000000;

//            Movie movie2 = new Movie();
//            movie2.Name = "Mission Impossible 13, Ethan Gets Unlucky";
//            movie2.PaymentForTomCruise = 20000001;

//            //The difference for PaymentForTomCruise will be ignored becuase it is marked with the ExcludeFromEquality
//            _compare.AttributesToIgnore.Add(typeof(ExcludeFromEquality));
//            Assert.IsTrue(_compare.Compare(movie1, movie2));

//            _compare.AttributesToIgnore.Clear();
//        }

//        [Test]
//        public void IgnorePropertyAttributeDifferent()
//        {
//            Movie movie1 = new Movie();
//            movie1.Name = "Mission Impossible 13, Ethan Gets Unlucky";
//            movie1.PaymentForTomCruise = 20000000;

//            Movie movie2 = new Movie();
//            movie2.Name = "Mission Impossible 14, Ethan Gets Unlucky";
//            movie2.PaymentForTomCruise = 20000001;

//            //The difference for PaymentForTomCruise will be ignored becuase it is marked with the ExcludeFromEquality
//            _compare.AttributesToIgnore.Add(typeof(ExcludeFromEquality));
//            Assert.IsFalse(_compare.Compare(movie1, movie2));

//            _compare.AttributesToIgnore.Clear();
//        }
//        #endregion

//        #region UseCustomComparerTest

//        [Test]
//        public void UseCustomComparer()
//        {
//            SpecificTenant tenant1 = new SpecificTenant();
//            tenant1.Name = "wire";
//            tenant1.Amount = 37;

//            SpecificTenant tenant2 = new SpecificTenant();
//            tenant2.Name = "wire";
//            tenant2.Amount = 155;

//            Assert.IsFalse(_compare.Compare(tenant1, tenant2));

//            //specify custom selector
//            _compare.IsUseCustomTypeComparer = type => type == typeof(SpecificTenant);
//            _compare.CustomComparer = (compareObj, object1, object2, breadCrumb) =>
//                                          {
//                                              var st1 = (SpecificTenant)object1;
//                                              var st2 = (SpecificTenant)object2;

//                                              if (st1.Name != st2.Name || st1.Amount > 100 || st2.Amount < 100)
//                                              {
//                                                  Difference difference = new Difference
//                                                      {
//                                                          ExpectedName = compareObj.ExpectedName,
//                                                          ActualName = compareObj.ActualName,
//                                                          PropertyName = breadCrumb,
//                                                          Object1Value = object1.ToString(),
//                                                          Object2Value = object2.ToString()
//                                                      };

//                                                  compareObj.Differences.Add(difference);
//                                              }
//                                          };

//            Assert.IsTrue(_compare.Compare(tenant1, tenant2));

//            tenant2.Amount = 42;
//            Assert.IsFalse(_compare.Compare(tenant1, tenant2));

//            //restore
//            _compare.IsUseCustomTypeComparer = type => false;
//            _compare.CustomComparer = null;
//        }

//        #endregion

//        #region Weak Reference Test

//        [Test]
//        public void WeakReferenceNegativeTest()
//        {
//            var jane = new Person { Name = "Jane" };
//            var mary = new Person { Name = "Mary" };
//            var jack = new Person { Name = "Jack" };

//            var nameList1 = new List<Person>() { jane, jack, mary };
//            var nameList2 = new List<Person>() { jane, mary, jack };

//            _compare.Compare(nameList1, nameList2);
//            _compare.MaxDifferences = int.MaxValue;

//            Console.WriteLine(_compare.DifferencesString);

//            Assert.IsTrue(_compare.Differences[0].Object1.IsAlive);
//            Assert.IsTrue(_compare.Differences[0].Object2.IsAlive);

//            Assert.AreNotEqual(_compare.Differences[0].Object1.Target, _compare.Differences[0].Object2.Target);
//        }


//        #endregion
//    }
//}
