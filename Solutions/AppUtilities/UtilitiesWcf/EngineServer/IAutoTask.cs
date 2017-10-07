
namespace WitsWay.Utilities.Wcf.EngineServer
{
    /// <summary>
    /// 自动任务接口
    /// </summary>
    public interface IAutoTask
    {
        /// <summary>
        /// 开始任务
        /// </summary>
        void Start();

        /// <summary>
        /// 停止任务
        /// </summary>
        void Stop();
    }
}
