using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Common
{
    public class MenuItem
    {
        /// <summary>
        /// 菜单名
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        /// 菜单URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 关联的ID
        /// </summary>
        public int ID { get; set; }
    }
}
