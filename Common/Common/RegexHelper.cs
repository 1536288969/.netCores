using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Common
{
    /// <summary>
    /// 正则验证
    /// </summary>
    public class RegexHelper
    {
        /// <summary>
        /// 验证邮箱
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmail(string str)
        {
            var regex = new Regex(@"(^\s*)\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*(\s*$)");
            return regex.IsMatch(str);
        }

        /// <summary>
        /// 验证手机号码 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsMobile(string str)
        {
            var regex = new Regex(@"^0?[1][1-9]\d{9}$");
            return regex.IsMatch(str);
        }

        /// <summary>
        /// 验证固定号码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsTelephone(string str)
        {
            var regex = new Regex(@"^(0\d{2}-\d{8}(-\d{1,4})?)|(0\d{3}-\d{7,8}(-\d{1,4})?)$");
            return regex.IsMatch(str); ;
        }

        /// <summary>
        /// 数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumber(string str)
        {
            var regex = new Regex(@"^[0-9]*$");
            return regex.IsMatch(str);
        }

        /// <summary>
        /// 数字和字母
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumberAndLetter(string str)
        {
            var regex = new Regex(@"^[A-Za-z0-9]+$");
            return regex.IsMatch(str);
        }

        /// <summary>
        /// 是否是URL链接
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUrl(string str)
        {
            var regex = new Regex(@"^(https?|ftp|file|ws)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$");
            return regex.IsMatch(str);
        }

        /// <summary>
        /// 验证用户账号
        /// 以英文字母开头，由英文字母、数字、下划线组成的5-16位字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUserAccount(string str)
        {
            var regex = new Regex(@"^[a-zA-Z]\w{4,15}$");
            return regex.IsMatch(str);
        }

    }
}
