using System;

namespace  WitsWay.Utilities.Compare
{
    /// <summary>
    /// Detailed information about the difference
    /// </summary>
    public class Difference
    {
        /// <summary>
        /// Name of Expected Object
        /// </summary>
        public string ExpectedName { get; set; }

        /// <summary>
        /// Name of Actual Object
        /// </summary>
        public string ActualName { get; set; }

        /// <summary>
        /// The breadcrumb of the property leading up to the value
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// The child property name
        /// </summary>
        public string ChildPropertyName { get; set; }

        /// <summary>
        /// Object1 Value as a string
        /// </summary>
        public string Object1Value { get; set; }

        /// <summary>
        /// Object2 Value as a string
        /// </summary>
        public string Object2Value { get; set; }

        /// <summary>
        /// Object1 as a reference
        /// </summary>
        public WeakReference Object1 { get; set; }

        /// <summary>
        /// Object2 as a reference
        /// </summary>
        public WeakReference Object2 { get; set; }

        /// <summary>
        /// Prefix to put on the beginning of the message
        /// </summary>
        public string MessagePrefix { get; set; }

        /// <summary>
        /// Nicely formatted string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string message;

            if (!String.IsNullOrEmpty(PropertyName))
            {
                if (String.IsNullOrEmpty(ChildPropertyName))
                    message = String.Format("{0}.{2} != {1}.{2} ({3},{4})", ExpectedName, ActualName,PropertyName,Object1Value, Object2Value);
                else
                    message = String.Format("{0}.{2}.{5} != {1}.{2}.{5} ({3},{4})", ExpectedName, ActualName, PropertyName, Object1Value, Object2Value, ChildPropertyName);
            }
            else
            {
                message = $"{ExpectedName} != {ActualName} ({Object1Value},{Object2Value})";
            }

            if (!String.IsNullOrEmpty(MessagePrefix))
                message = $"{MessagePrefix}: {message}";

            return message;
        }
    }
}