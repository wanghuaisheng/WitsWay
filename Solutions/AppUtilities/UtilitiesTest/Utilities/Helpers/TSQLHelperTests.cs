/******************************************
 * 2012年5月5日 王怀生 添加
 * 
 * ***************************************/

using System.Collections.Generic;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WitsWay.Utilities.Helpers;

namespace WitsWay.Utlities.Tests.Utilities.Helpers
{
    /// <summary>
    /// TSQL辅助类
    /// </summary>
    [TestClass]
    public class TSQLHelperTests
    {

        /// <summary>
        /// 取得数据集合对应的Xml序列化结果
        /// </summary>
        [TestMethod]
        public void CastListToDictionary()
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

            var obj = TsqlHelper.SerilizeListToXml(list);
            //此处仅判断是否已经完成序列化，具体请参考返回结果
            Assert.IsTrue(obj.Length>0);


            var list1 = new List<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list1.Add(4);

            obj = TsqlHelper.SerilizeListToXml(list1);
            //此处仅判断是否已经完成序列化，具体请参考返回结果
            Assert.IsTrue(obj.Length > 0);
        }

        /// <summary>
        /// 序列化对象到XML测试
        /// </summary>
        [TestMethod]
        public void SerilizeObjectToXMLTest()
        {
            var userInfo = new UserInfo();
            userInfo.UserId = 100021;
            userInfo.UserName = "小明";

            var obj = TsqlHelper.SerilizeObjectToXml(userInfo);
            //此处仅判断是否已经完成序列化，具体请参考返回结果
            Assert.IsTrue(obj.Length > 0);
        }
        
        /// <summary>
        /// 解析TSQL语句参数
        /// </summary>
        [TestMethod]
        public void AnalyseTSQLParametersTest()
        {
            //tsql实例语句
            var tsqlStr = "create proc p_JobSet@id int,            --要处理的sendTab的id@is_delete bit=0    --是否仅删除,为0则否,为1则是asdeclare @dbname sysname,@jobname sysname    ,@date int,@time intselect @jobname='定时发送作业_'+cast(@id as varchar)    ,@date=convert(varchar,SendTime,112)    ,@time=replace(convert(varchar,SendTime,108),':','')from sendTab where id=@idif exists(select 1 from msdb..sysjobs where name=@jobname)    exec msdb..sp_delete_job @job_name=@jobname if @is_delete=1 return";
            var result = TsqlHelper.AnalyseTsqlParameters(tsqlStr);
            Assert.IsTrue(result[0] == "@id");
        }
        
        /// <summary>
        /// SQLType转换为对应的DbType
        /// </summary>
        [TestMethod]
        public void SqlTypeStringToDbTypeTest()
        {
            var typeStr = "varchar(20)";
            var result = TsqlHelper.SqlTypeStringToDbType(typeStr);
            Assert.IsTrue(result == DbType.String);
        }
        

    }
}
