using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Entitys;
using WitsWay.Utilities.Helpers;

namespace WitsWay.Utlities.Tests.Utilities.Helpers
{
    /// <summary>
    /// 显示转换辅助类
    /// </summary>
    [TestClass]
    public class ShowCastHelperTests
    {

        /// <summary>
        /// 列表转换测试
        /// </summary>
        [TestMethod]
        public void CastListTest()
        {
            var list = new List<UserInfo>();

            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "小明";

            list.Add(userInfo);

            var result = ShowCastHelper.CastList(list, a => {

                var _a = new UserInfo();
                _a.UserId = a.UserId;
                _a.UserName = "[" + a.UserId + "]" + a.UserName;//转换后格式为：[编号]名称

                return _a; 
            });

            Assert.IsTrue(result[0].UserName == "[100021]小明");

        }
        
        /// <summary>
        /// 转换分页结果集
        /// </summary>
        [TestMethod]
        public void CastPageResultTest()
        {

            var list = new List<UserInfo>();

            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "小明";
            list.Add(userInfo); 
            
            userInfo = new UserInfo();
            userInfo.UserId = 100022;
            userInfo.UserName = "小红";
            list.Add(userInfo);

            var pageResult = new PageResult<UserInfo>();
            pageResult.PageIndex = 2;
            pageResult.PageSize = 20;
            pageResult.Rows.AddRange(list);

            var result = ShowCastHelper.CastPageResult(pageResult, a =>
            {
                var _u = new UserInfo();
                _u.UserId = a.UserId;
                _u.UserName = "["+a.UserId+"]" + a.UserName;
                return _u;
            });

            Assert.IsTrue(result.Rows[0].UserName == "[100021]小明");
            Assert.IsTrue(result.Rows[1].UserName == "[100022]小红");

        }


        
        



      
    }
}