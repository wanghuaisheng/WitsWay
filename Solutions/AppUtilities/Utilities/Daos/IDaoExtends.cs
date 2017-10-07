/*******************************
 * 2017年3月31日 王怀生 添加
 * ****************************/

using System;
using System.Collections.Generic;
using System.Linq;
using WitsWay.Utilities.Entitys;
using WitsWay.Utilities.Errors;
using WitsWay.Utilities.Helpers;

namespace WitsWay.Utilities.Daos
{
    /// <summary>
    /// 数据访问标记接口
    /// </summary>
    public static class IDaoExtends
    {
        /// <summary>
        /// 检查状态参数
        /// </summary>
        /// <param name="dao">数据访问接口对象</param>
        /// <param name="states">装填列表</param>
        public static void CheckStatesInPara(this IDao dao, IList<int> states)
        {
            if (states == null)
                ExceptionHelper.ThrowProgramException("States为Null", UtilityErrors.ArgumentNullException);
            if (!states.Any()) ExceptionHelper.ThrowProgramException("States为空", UtilityErrors.ArgumentErrorException);
            if (states.Any(state => state == 0))
                ExceptionHelper.ThrowProgramException(UtilityErrors.StatesInStatesContainsZero);
        }

        /// <summary>
        /// 检查状态参数
        /// </summary>
        /// <param name="dao">数据访问接口对象</param>
        /// <param name="states">装填列表</param>
        public static void CheckStatesPara(this IDao dao, int states)
        {
            if (states < 0) ExceptionHelper.ThrowProgramException("状态必须大于等于“0”", UtilityErrors.ArgumentErrorException);
        }

        /// <summary>
        /// 检查语句参数
        /// </summary>
        /// <param name="dao">数据访问接口对象</param>
        /// <param name="clause">TSQL语句</param>
        public static void CheckClausePara(this IDao dao, string clause)
        {
            if (string.IsNullOrWhiteSpace(clause))
                ExceptionHelper.ThrowProgramException("Clause语句为空", UtilityErrors.ArgumentNullException);
            if (clause.StartsWith("WHERE", StringComparison.OrdinalIgnoreCase))
                ExceptionHelper.ThrowProgramException("Clause语句不能包含WHERE", UtilityErrors.ArgumentErrorException);
        }

        /// <summary>
        /// 检查主键列表参数
        /// </summary>
        /// <param name="dao">数据访问接口对象</param>
        /// <param name="keys">主键列表</param>
        public static void CheckKeysPara(this IDao dao, IList<string> keys)
        {
            if (keys == null || keys.Count == 0)
                ExceptionHelper.ThrowProgramException("主键列表为空", UtilityErrors.ArgumentNullException);
        }

        /// <summary>
        /// 检查语句参数
        /// </summary>
        /// <param name="dao">数据访问接口对象</param>
        /// <param name="key">主键</param>
        public static void CheckKeyPara(this IDao dao, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                ExceptionHelper.ThrowProgramException("主键为空", UtilityErrors.ArgumentNullException);
        }

        /// <summary>
        /// 检查主键列表参数
        /// </summary>
        /// <param name="dao">数据访问接口对象</param>
        /// <param name="keys">主键列表</param>
        public static void CheckKeysPara(this IDao dao, IList<int> keys)
        {
            if (keys == null || keys.Count == 0)
                ExceptionHelper.ThrowProgramException("主键列表为空", UtilityErrors.ArgumentNullException);
            if (keys.Any(key => key <= 0))
                ExceptionHelper.ThrowProgramException("主键必须大于0", UtilityErrors.ArgumentErrorException);
        }

        /// <summary>
        /// 检查语句参数
        /// </summary>
        /// <param name="dao">数据访问接口对象</param>
        /// <param name="key">主键</param>
        public static void CheckKeyPara(this IDao dao, int key)
        {
            if (key <= 0) ExceptionHelper.ThrowProgramException("主键必须大于0", UtilityErrors.ArgumentErrorException);
        }

        /// <summary>
        /// 检查分页参数
        /// </summary>
        /// <param name="dao">数据访问接口对象</param>
        /// <param name="pagePara">分页参数</param>
        public static void CheckPagePara(this IDao dao, PageParameter pagePara)
        {
            if (pagePara == null) ExceptionHelper.ThrowProgramException("分页参数为空", UtilityErrors.ArgumentNullException);
            if (pagePara.PageIndex <= 0)ExceptionHelper.ThrowProgramException("当前页码必须大于0", UtilityErrors.ArgumentErrorException);
            if(pagePara.PageSize<=0) ExceptionHelper.ThrowProgramException("每页条数必须大于0", UtilityErrors.ArgumentErrorException);
        }

    }
}