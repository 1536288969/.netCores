using Entity.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity.Manage
{
    /// <summary>
    /// 网站后台功能模块
    /// </summary>
    [Table("Module")]
    public class Module : Base
    {
        /// <summary>
        /// 模块名
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// 模块父ID
        /// </summary>
        public int ParentID { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 外接链接
        /// </summary>
        public string Url { get; set; }
    }
}
