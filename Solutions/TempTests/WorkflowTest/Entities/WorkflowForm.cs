namespace WitsWay.TempTests.WorkflowTest.Entities
{

    /// <summary>
    /// 工作流表单
    /// </summary>
    public class WorkflowForm
    {
        /// <summary>
        /// 工作流Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 表单Id
        /// </summary>
        public string FormId { get; set; }
        /// <summary>
        /// 工作流表单数据
        /// </summary>
        public byte[] FormData { get; set; }


    }
}
