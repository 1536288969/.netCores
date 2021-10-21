using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity.Manage
{
    [Table("RoleToModule")]
    public class RoleToModule
    {
        public int ID { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        public int MenuID { get; set; }

        /// <summary>
        /// 是否网站栏目,此字段正对于网站管理员对网站栏目的管理权限
        /// 1:是网站栏目 0:不是网站栏目
        /// </summary>
        public bool Flag { get; set; }

        public virtual Role Role { get; set; }
    }
}
