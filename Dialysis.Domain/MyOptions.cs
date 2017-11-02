namespace Dialysis.Domain
{
    /// <summary>
    /// MyOptions
    /// </summary>
    public class MyOptions
    {
        /// <summary>
        /// GeneratorId
        /// </summary>
        public int GeneratorId { get; set; }

        /// <summary>
        /// 是否是开发环境
        /// </summary>
        public bool IsDevModel { get; set; }

        #region OSS配置
        /// <summary>
        /// OssPatientDir
        /// </summary>
        public string OssPatientDir
        {
            get
            {
                if (IsDevModel)
                {
                    return "0-patient-dev/";
                }
                else
                {
                    return "patient/";
                }
            }
        }
        #endregion
    }
}
