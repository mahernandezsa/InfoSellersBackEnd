using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoSellers.Model.Enums
{
    /// <summary>
    /// Types of BikeSellers status.
    /// </summary>
    
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BikeSellerStatusType
    {
        /// <summary>
        /// deactivated status type.
        /// </summary>
        deactivated,

        /// <summary>
        /// activated status type.
        /// </summary>
        activated

    }
}
