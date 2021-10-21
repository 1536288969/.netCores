using Entity.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity.Manage
{
    [Table("Role")]
    public class Role : Base
    {
        /// <summary>
        /// 角色名
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 角色描述
        /// </summary>
        public string Description { get; set; }

        public virtual List<Manager> Managers { get; set; }

        public virtual List<RoleToModule> RoleToModules { get; set; }
    }
}
