using InfoSellers.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoSellers.Model.Entities
{
    /// <summary>
    /// Represents a BikeSeller.
    /// </summary>
    public class BikeSeller
    {
        /// <summary>
        /// Gets or sets the BikeSeller id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the BikeSeller NIT.
        /// </summary>
        public string NIT { get; set; }

        /// <summary>
        /// Gets or sets the full name of a BikeSeller.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the address of a BikeSeller.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the phone of a BikeSeller.
        /// </summary>
        public long Phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// Gets or sets the Role of a BikeSeller.
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// Gets or sets the penalty percentage of a BikeSeller.
        /// </summary>
        public double PenaltyPercentage { get; set; }

        /// <summary>
        /// Gets or sets the status of a BikeSeller.
        /// </summary>
        public BikeSellerStatusType Status { get; set; }



        public void CalculateNewComission()
        {
            Role.ComissionValue += -(Role.ComissionValue * (PenaltyPercentage / 100));
        }

    }

}

