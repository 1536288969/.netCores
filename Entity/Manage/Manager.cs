using Entity.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity.Manage
{
    /// <summary>
    /// 网站后台管理员
    /// </summary>
    [Table("Manager")]
    public class Manager : Base
    {
        /// <summary>
        /// 管理员账户
        /// </summary>
       // [Required(ErrorMessage = "管理员账号不能为空")]
        //[Range(6, 20, ErrorMessage = "管理员账号必须大于6位字符并且小于20位字符")]
        public string ManagerAccount { get; set; }

        /// <summary>
        /// 管理员密码
        /// </summary>
       // [Required(ErrorMessage = "管理员密码不能为空")]
       // [Range(6, 20, ErrorMessage = "管理员密码必须大于6位字符并且小于20位字符")]
        public string ManagerPwd { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
       // [Required(ErrorMessage = "管理员姓名不能为空")]
        public string RealName { get; set; }

        /// <summary>
        /// 管理员邮箱
        /// </summary>
      ///  [Required(ErrorMessage = "管理员邮箱不能为空")]
       // [EmailAddress(ErrorMessage = "请填写正确的邮箱地址")]
        public string Email { get; set; }

        /// <summary>
        /// 管理员电话
        /// </summary>
       // [RegularExpression(@"^1[3458][0-9]{9}$", ErrorMessage = "手机号格式不正确")]
        public string Telephone { get; set; }

        /// <summary>
        /// 管理员所属角色
        /// </summary>
        //[Display(Name ="管理员所属角色")]
        public int RoleID { get; set; }

       // [Display(Name ="备注")]
        //[MaxLength(200,ErrorMessage ="{0}最大长度为{1}")]
        public string Remark { get; set; }
        public virtual Role Role { get; set; }
    }
}
