using InfoSellers.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoSellers.Model.Entities
{
    public class Role
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RoleCommissionType CommissionType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double ComissionValue { get; set; }    

    }
}
