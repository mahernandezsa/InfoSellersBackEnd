using InfoSellers.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [MaxLength(15,ErrorMessage ="Max 15 characters for NIT")]
        [Required(ErrorMessage="NIT is required")]
        public string NIT { get; set; }

        /// <summary>
        /// Gets or sets the full name of a BikeSeller.
        /// </summary>
        [MaxLength(100, ErrorMessage = "Max 100 characters for a Full name")]
        [Required(ErrorMessage="Full name is required")]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the address of a BikeSeller.
        /// </summary>
        [MaxLength(100, ErrorMessage = "Max 100 characters for a address")]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the phone of a BikeSeller.
        /// </summary>       
        [Range(1, long.MaxValue, ErrorMessage = "Phone is required")]
        [Required(ErrorMessage = "Phone is required")]
        public long Phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Range (1,double.MaxValue, ErrorMessage = "RoleId is required")]
        [Required(ErrorMessage = "RoleId is required")]
        public int RoleId { get; set; }
        /// <summary>
        /// Gets or sets the Role of a BikeSeller.
        /// </summary>        
        public Role Role { get; set; }

        /// <summary>
        /// Gets or sets the penalty percentage of a BikeSeller.
        /// </summary>        
        [Range(0.0, 100.0, ErrorMessage = "Range 0 - 100")]        
        [Required(ErrorMessage = "PenaltyPercentage is required")]
        public double PenaltyPercentage { get; set; }

        /// <summary>
        /// Gets or sets the status of a BikeSeller.
        /// </summary>
        [Required(ErrorMessage = "Status is required")]
        public BikeSellerStatusType Status { get; set; }



        public void CalculateNewComission()
        {
            Role.ComissionValue += -(Role.ComissionValue * (PenaltyPercentage / 100));
        }

    }

}

