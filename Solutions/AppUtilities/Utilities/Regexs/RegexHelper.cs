using System.Collections.Generic;
using MSRegex = System.Text.RegularExpressions;

namespace WitsWay.Utilities.Regexs
{
    /// <summary>
    /// ΪЭ������ṩ����ƥ������
    /// ���ƥ���ַ��������ɶ���
    /// </summary>
    public class RegexHelper
    {
        /// <summary>
        /// ����ƥ��
        /// </summary>
        public static T Match<T>(ref string processStr, bool delMatchStr) where T : new() 
        {
            var matchObject = new T();
            return Match(matchObject, ref processStr, delMatchStr) ? matchObject : default(T);
        }

        /// <summary>
        /// ƥ��ָ������
        /// </summary>
        /// <param name="matchObject">ƥ������ɵĽ������</param>
        /// <param name="processStr"></param>
        /// <param name="delMatchStr"></param>
        /// <returns></returns>
        public static bool Match(object matchObject,ref string processStr,bool delMatchStr)
        {
            var  info = RegexClassFactory.GetRegexClass(matchObject);
            return info != null && info.SetPropertyValue(ref processStr,matchObject,delMatchStr);
        }

        /// <summary>
        /// ƥ��������
        /// </summary>
        /// <typeparam name="T">ƥ������</typeparam>
        /// <param name="processStr">�����ַ���</param>
        /// <param name="delMatchStr">�Ƿ�ɾ���Ѿ�ƥ����ַ���</param>
        /// <returns>����ƥ��Ķ����б�</returns>
        public static IList<T> MatchList<T>(ref string processStr, bool delMatchStr) where T : new()
        {
            var temValue = processStr;
            IList<T> resultList = new List<T>();
            T v;
            do
            {
                v = Match<T>(ref temValue, true);
                if (v != null)
                {
                    resultList.Add(v);
                }
            }
            while (v != null);
            if (delMatchStr)
            {
                processStr = temValue;
            }
            return resultList;
        }

        /// <summary>
        /// ��ȡ������ʽ
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static MSRegex.Regex GetClassRegex<T>() where T : new()
        {
            var matchObject = new T();
            var info = RegexClassFactory.GetRegexClass(matchObject);
            return info?.RegexInfo;
        }

    }
}
