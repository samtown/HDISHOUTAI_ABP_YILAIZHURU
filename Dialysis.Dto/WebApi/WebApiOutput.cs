namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// WebApiOutput
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public sealed class WebApiOutput<TValue> : OutputBase
    {
        private TValue _resultValue;
        /// <summary>
        /// ResultValue
        /// </summary>
        public TValue ResultValue
        {
            get { return _resultValue; }
            set { _resultValue = value; }
        }

        /// <summary>
        ///无参构造函数 
        /// </summary>
        public WebApiOutput()
        {

        }

        private WebApiOutput(bool isSuccess, string message, TValue resultValue)
        {
            IsSuccess = isSuccess;
            Message = message ?? string.Empty;
            ResultValue = resultValue;
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="resultValue">返回值</param>
        /// <returns></returns>
        public static WebApiOutput<TValue> Success(TValue resultValue)
        {
            return new WebApiOutput<TValue>(true, string.Empty, resultValue);
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="resultValue">返回值</param>
        /// <param name="message">message</param>
        /// <returns></returns>
        public static WebApiOutput<TValue> Success(TValue resultValue, string message)
        {
            return new WebApiOutput<TValue>(true, message, resultValue);
        }

        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="message">message</param>
        /// <returns></returns>
        public new static WebApiOutput<TValue> Fail(string message)
        {
            return new WebApiOutput<TValue>(false, message, default(TValue));
        }
    }
}
