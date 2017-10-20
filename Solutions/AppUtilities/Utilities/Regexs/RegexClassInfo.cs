using System.Collections.Generic;
using MSRegex = System.Text.RegularExpressions;

namespace WitsWay.Utilities.Regexs
{
    /// <summary>
    /// ����ƥ������Ϣ
    /// <remarks>
    /// ���ڴ洢ʹ����ParseClassAttribute�������Ϣ
    /// </remarks>
    /// </summary>
    public class RegexClassInfo
    {

        #region [Property]

        /// <summary>
        /// Э���������
        /// </summary>
        public ParseClassAttribute CustomClassInfo { get; set; }

        private IDictionary<string, ParsePropertyAttribute> _parsePropertyMap;
        /// <summary>
        /// Ҫ���������������ֵ�
        /// key:���Ե�����
        /// value:���Ե��Զ�������ParsePropertyAttribute
        /// </summary>
        public IDictionary<string, ParsePropertyAttribute> PropertyMap => 
            _parsePropertyMap ?? (_parsePropertyMap = new Dictionary<string, ParsePropertyAttribute>());

        /// <summary>
        /// ��System.Text.RegularExpressions.Regexȡ����
        /// </summary>
        public MSRegex.Regex RegexInfo { get; private set; }

        /// <summary>
        /// ����ƥ���ַ���
        /// </summary>
        public string RegexPattern { get; set; }

        #endregion

        #region [Public Method]
        /// <summary>
        /// �ж��Ƿ�ʱЭ�������
        /// [�Ƿ�������ͷ][��Ҫ���������Դ�����]
        /// </summary>
        /// <returns></returns>
        public bool Available()
        {
            if (CustomClassInfo == null || PropertyMap == null) return false;
            return PropertyMap.Count > 0;
        }

        /// <summary>
        /// ����MS����Regex��
        /// </summary>
        /// <param name="pattern">����ƥ���ַ���</param>
        public void CreateRegex(string pattern)
        {
            var option =
                MSRegex.RegexOptions.IgnoreCase |
                MSRegex.RegexOptions.Multiline |
                MSRegex.RegexOptions.IgnorePatternWhitespace |
                MSRegex.RegexOptions.Compiled;
            RegexInfo = new MSRegex.Regex(pattern, option);
            RegexPattern = pattern;
        }
        #endregion

        #region [Internal Method]


        /// <summary>
        /// ����ƥ��ֵ
        /// </summary>
        /// <param name="processStr">Ҫ������ַ���</param>
        /// <param name="setObject">Ҫ����ֵ�Ķ���</param>
        /// <param name="deleteMatchString">�Ƿ�ɾ��ƥ����ַ�</param>
        /// <returns></returns>
        internal bool SetPropertyValue(ref string processStr, object setObject, bool deleteMatchString)
        {
            var match = Match(processStr);
            if (!match.Success) return false;
            for (var i = 0; i < match.Groups.Count; i++)
            {
                var name = RegexInfo.GroupNameFromNumber(i);
                if (SetValue(setObject, name, match.Groups[i]) == false)
                {
                    return false;
                }
            }
            if (deleteMatchString)
            {
                processStr = processStr.Remove(match.Index, match.Length);
            }
            return true;
        }

        /// <summary>
        /// ƥ��
        /// </summary>
        /// <param name="processStr">Ҫƥ����ַ���</param>
        /// <returns></returns>
        internal MSRegex.Match Match(string processStr)
        {
            return RegexInfo.Match(processStr);
        }
        /// <summary>
        /// ƥ�䲢����ֵ
        /// </summary>
        /// <param name="matchObject">Ҫƥ��Ķ���</param>
        /// <param name="name">��������</param>
        /// <param name="group"></param>
        /// <returns></returns>
        internal bool SetValue(object matchObject, string name, MSRegex.Group group)
        {
            ParsePropertyAttribute propertyAttribute;
            if (PropertyMap.TryGetValue(name, out propertyAttribute) != true) return true;
            return propertyAttribute.SetPropertyValue(matchObject, @group);
        }
        #endregion
    }
}
