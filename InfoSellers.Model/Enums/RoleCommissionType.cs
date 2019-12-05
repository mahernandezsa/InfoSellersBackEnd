using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoSellers.Model.Enums
{
    /// <summary>
    /// Types of Role's commission type.
    /// </summary>
    
    [JsonConverter(typeof(StringEnumConverter))] 
    public enum RoleCommissionType
    {
        /// <summary>
        /// junior comission type.
        /// </summary>
        junior,

        /// <summary>
        /// mid comission type.
        /// </summary>
        mid,

        /// <summary>
        /// expert comission type.
        /// </summary>
        expert

    }

}
