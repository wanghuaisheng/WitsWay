namespace WitsWay.Utilities.Dap.LambdaSqlBuilder.Builder
{
  
    partial class Builder
    {
        /// <summary>
        /// 添加<![CDATA[ ( ]]>
        /// </summary>
        public void BeginExpression()
        {
            _conditions.Add("(");
        }

        /// <summary>
        /// 添加<![CDATA[ ) ]]>
        /// </summary>
        public void EndExpression()
        {
            _conditions.Add(")");
        }
        /// <summary>
        /// 添加<![CDATA[ AND ]]>
        /// </summary>
        public void And()
        {
            if (_conditions.Count > 0)
                _conditions.Add(" AND ");
        }
        /// <summary>
        /// 添加<![CDATA[ OR ]]>
        /// </summary>
        public void Or()
        {
            if (_conditions.Count > 0)
                _conditions.Add(" OR ");
        }
        /// <summary>
        /// 添加<![CDATA[ NOT ]]>
        /// </summary>
        public void Not()
        {
            _conditions.Add(" NOT ");
        }
    }
}
