namespace Dialysis.Common
{
    public static class CommConstant
    {
        #region JPush
        public const string JPushAppKeyDoctor = "19b822b3eaa1e1c1ebfd63bb";
        public const string JPushMasterSecretDoctor = "4af24858bbecca48962f1026";
        public const string JPushAppKeyPatient = "67c944395912fdb77c61de08";
        public const string JPushMasterSecretPatient = "d10ad9ad7dac6f7c061c8054";
        #endregion

        /// <summary>
        /// 英文逗号
        /// </summary>
        public const string Comma = ",";

        /// <summary>
        /// 初始密码
        /// </summary>
        public const string InitialPassword = "E10ADC3949BA59ABBE56E057F20F883E";

        public const string ShortDateFormatString = "yyyy-MM-dd";
        public const string DateTimeFormatString = "yyyy-MM-dd HH:mm";
        public const string TimeFormatString = "HH:mm";
        public const string FullTimeFormatString = "yyyyMMddHHmmssfff";

        public const int FoodNutritionParentValue = 101;//101代表食物速查
        public const int PatientEduParentValue = 102;//102代表课程

        public const int PatientEduOutIdLength = 53;

        #region OSS
        /// <summary>
        /// OssUrl
        /// </summary>
        public const string OssUrl = @"https://dialysis.oss-cn-qingdao.aliyuncs.com/";

        /// <summary>
        /// OssAccessKeyId
        /// </summary>
        public const string OssAccessKeyId = "n0I3BGQU130HZcmC";

        /// <summary>
        /// OssAccessKeySecret
        /// </summary>
        public const string OssAccessKeySecret = "GclO9qY81I9UIxiPg1kxkgob5mJCI2";

        /// <summary>
        /// OssBucket(dialysis)
        /// </summary>
        public const string OssBucket = "dialysis";

        /// <summary>
        /// OssRegion
        /// </summary>
        public const string OssRegion = "oss-cn-qingdao";

        /// <summary>
        /// OssAvatarDir
        /// </summary>
        public const string OssAvatarDir = "avatar/";
        #endregion

        /// <summary>
        /// 后台登录当前用户
        /// </summary>
        public const string AdminLoginCurrentUser = "CurrentUser";

        public const string OneselfRelationship = "本人";
    }
}
