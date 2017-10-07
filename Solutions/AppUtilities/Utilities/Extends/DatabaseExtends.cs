#region License(Apache Version 2.0)
/******************************************
 * Copyright ®2017-Now WangHuaiSheng.
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of the License at
 * http://www.apache.org/licenses/LICENSE-2.0
 * Unless required by applicable law or agreed to in writing, software distributed under the
 * License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language governing permissions
 * and limitations under the License.
 * Detail: https://github.com/WangHuaiSheng/WitsWay/LICENSE
 * ***************************************/
#endregion 
#region ChangeLog
/******************************************
 * 2017-10-7 OutMan Create
 * 
 * ***************************************/
#endregion
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using WitsWay.Utilities.Errors;
using WitsWay.Utilities.Helpers;

namespace WitsWay.Utilities.Extends
{
    /// <summary>
    /// Database扩展方法
    /// </summary>
    public static class DatabaseExtends
    {
        /// <summary>
        /// 获取DbCommand对象
        /// </summary>
        /// <param name="db"><see cref="Database"/>对象</param>
        /// <param name="cmdType"><see cref="CommandType"/>枚举</param>
        /// <param name="sql">TSQL语句</param>
        /// <returns><see cref="DbCommand"/>对象</returns>
        public static DbCommand GetDbCommand(this Database db, CommandType cmdType, string sql)
        {
            CheckCommandType(cmdType);
            var cmd =
                cmdType == CommandType.StoredProcedure ?
                db.GetStoredProcCommand(sql) : db.GetSqlStringCommand(sql);
            return cmd;
        }

        /// <summary>
        /// 读取列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="db"><see cref="Database"/>对象</param>
        /// <param name="mapper">映射对象</param>
        /// <param name="cmdType">CommandType</param>
        /// <param name="sql">CommandText</param>
        /// <returns>实体列表</returns>
        public static List<T> ReadList<T>(this Database db, IRowMapper<T> mapper, CommandType cmdType, string sql) where T : new()
        {
            CheckCommandType(cmdType);
            var infos = new List<T>();
            using (var dr = db.ExecuteReader(cmdType, sql))
            {
                while (dr.Read())
                {
                    var info = mapper.MapRow(dr);
                    infos.Add(info);
                }
            }
            return infos;
        }



        /// <summary>
        /// 读取列表
        /// 读取列表
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="db"><see cref="Database"/>对象</param>
        /// <param name="mapper">映射对象</param>
        /// <param name="cmd">DbCommand</param>
        /// <returns>实体列表</returns>
        public static List<T> ReadList<T>(this Database db, IRowMapper<T> mapper, DbCommand cmd) where T : new()
        {
            var infos = new List<T>();
            using (var dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    var info = mapper.MapRow(dr);
                    infos.Add(info);
                }
            }
            return infos;
        }


        /// <summary>
        /// 读取列表,使用默认Mapper
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="db"><see cref="Database"/>对象</param>
        /// <param name="cmdType">CommandType</param>
        /// <param name="sql">CommandText</param>
        /// <returns>实体列表</returns>
        public static List<T> ReadList<T>(this Database db, CommandType cmdType, string sql) where T : new()
        {
            CheckCommandType(cmdType);
            var infos = new List<T>();
            using (var dr = db.ExecuteReader(cmdType, sql))
            {
                var mapper = MapBuilder<T>.BuildAllProperties();
                while (dr.Read())
                {
                    var info = mapper.MapRow(dr);
                    infos.Add(info);
                }
            }
            return infos;
        }

        /// <summary>
        /// 读取列表,使用默认Mapper
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="db"><see cref="Database"/>对象</param>
        /// <param name="cmd">DbCommand</param>
        /// <returns>实体列表</returns>
        public static List<T> ReadList<T>(this Database db, DbCommand cmd) where T : new()
        {
            var infos = new List<T>();
            using (var dr = db.ExecuteReader(cmd))
            {
                var mapper = MapBuilder<T>.BuildAllProperties();
                while (dr.Read())
                {
                    var info = mapper.MapRow(dr);
                    infos.Add(info);
                }
            }
            return infos;
        }
        /// <summary>
        /// 读取一行数据，无数据返回null，不抛出异常
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="db"><see cref="Database"/>对象</param>
        /// <param name="mapper">映射对象</param>
        /// <param name="cmd"><see cref="DbCommand"/>对象</param>
        /// <returns>实体列表</returns>
        public static T ReadRow<T>(this Database db, IRowMapper<T> mapper, DbCommand cmd) where T : new()
        {
            using (var dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    return mapper.MapRow(dr);
                }
            }
            return default(T);
        }

        /// <summary>
        /// 读取一行数据，无数据返回null，不抛出异常，使用默认Mapper
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="db"><see cref="Database"/>对象</param>
        /// <param name="cmd"><see cref="DbCommand"/>对象</param>
        /// <returns>实体列表</returns>
        public static T ReadRow<T>(this Database db, DbCommand cmd) where T : new()
        {
            var mapper = MapBuilder<T>.BuildAllProperties();
            using (var dr = db.ExecuteReader(cmd))
            {
                while (dr.Read())
                {
                    return mapper.MapRow(dr);
                }
            }
            return default(T);
        }

        /// <summary>
        /// 检查CommandType参数
        /// </summary>
        /// <param name="cmdType">CommandType</param>
        private static void CheckCommandType(CommandType cmdType)
        {
            if (cmdType != CommandType.Text && cmdType != CommandType.StoredProcedure)
            {
                Logger.Write("当前只支持存储过程或TSQL语句。");
                ExceptionHelper.ThrowProgramException(UtilityErrors.ProgramNotImplement);
            }
        }

        /// <summary>
        /// 执行添加，添加影响行数0时抛出异常
        /// </summary>
        /// <param name="db"><see cref="Database"/>对象</param>
        /// <param name="cmd"><see cref="DbCommand"/>对象</param>
        /// <param name="msg">备注信息</param>
        [ContractAnnotation("=> stop")]
        public static void ExecuteNonQueryZeroThrow(this Database db, DbCommand cmd, string msg)
        {
            if (db.ExecuteNonQuery(cmd) == 0)
            {
                Logger.Write(msg);
                ExceptionHelper.ThrowProgramException(UtilityErrors.DatabaseAccessError);
            }
        }


    }
}
