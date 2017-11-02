using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Common
{
    /// <summary>
    /// 辅助类
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// 计算报警记录颜色类型
        /// </summary>
        /// <param name="weightOverflow">体重超值</param>
        /// <param name="postDialysisWeight">透后体重</param>
        /// <returns>颜色类型</returns>
        public static int CalculateColour(decimal weightOverflow, decimal postDialysisWeight)
        {
            int colourType = 0;
            var percentage = Math.Abs(weightOverflow / postDialysisWeight);
            if (percentage >= 0.03m && percentage <= 0.05m)
            {
                colourType = 1;
            }
            else if (percentage > 0.05m)
            {
                colourType = 2;
            }

            return colourType;
        }

        /// <summary>
        /// 根据出生日期计算年龄
        /// </summary>
        /// <param name="birthDate">出生日期</param>
        /// <returns></returns>
        public static int CalculateAge(DateTime birthDate)
        {
            var now = DateTime.Today;
            int age = now.Year - birthDate.Year;
            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day)) age--;
            return age;
        }

        /// <summary>
        /// 获取用户状态Css
        /// </summary>
        /// <param name="userStatus">用户状态</param>
        /// <returns></returns>
        public static string GetUserStatusCss(int userStatus)
        {
            var css = string.Empty;
            switch (userStatus)
            {
                case 0:
                    css = "default";
                    break;
                case 1:
                    css = "info";
                    break;
                case 2:
                    css = "warning";
                    break;
                case 3:
                    css = "danger";
                    break;
                case 4:
                    css = "success";
                    break;
                default:
                    break;
            }

            return css;
        }

        /// <summary>
        /// 获取首字母拼音
        /// </summary>
        /// <param name="source">原字符串</param>
        /// <returns></returns>
        public static string GetFirstPY(string source)
        {
            string r = string.Empty;
            foreach (char item in source)
            {
                try
                {
                    //ChineseChar chineseChar = new ChineseChar(item);
                    //if (ChineseChar.IsValidChar(item))
                    //{
                    //    string t = chineseChar.Pinyins[0].ToString();
                    //    r += t.Substring(0, 1);
                    //}
                    //else
                    //{
                    //    r += item.ToString();
                    //}
                }
                catch
                {
                    r += item.ToString();
                }
            }
            return r;
        }
    }
}
