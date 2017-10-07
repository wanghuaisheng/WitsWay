namespace WitsWay.Utilities.Patterns
{
        /// <summary>
        /// 
        /// 线程安全的 Singleton 模式最佳实践
        /// 
        /// 例子:
        /// 
        /// public class Demo
        /// {
        ///		public static Form1 Instance1
        ///		{
        ///			get
        ///			{
        ///				return Singleton＜Form1＞.Instance;
        ///			}
        ///		}
        ///	}
        /// </summary>
        public sealed class Singleton<T> where T : new()
        {
            private Singleton()
            {
            }
            /// <summary>
            /// 
            /// </summary>
            public static T Instance
            {
                get { return Nested.instance; }
            }

            private class Nested
            {
                static Nested(){}
                internal static readonly T instance = new T();
            }
        }
}
