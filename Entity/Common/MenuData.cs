using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Common
{
   public class MenuData
    {
        /// <summary>
        /// 权限组的ID
        /// </summary>
        public int GroupID { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 定义MenuItem集合，菜单集合
        /// </summary>
        public IEnumerable<MenuItem> MenuItems { get; set; }
    }
}
