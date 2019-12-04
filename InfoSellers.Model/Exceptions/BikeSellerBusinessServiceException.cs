using System;
using System.Collections.Generic;
using System.Text;

namespace InfoSellers.Model.Exceptions
{
     public class BikeSellerBusinessServiceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BikeSellerServiceException"/> class.
        /// </summary>
        public BikeSellerBusinessServiceException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BikeSellerServiceException"/> class.
        /// </summary>
        /// <param name="code">HTTP response code.</param>
        /// <param name="reason">HTTP error reason.</param>
        public BikeSellerBusinessServiceException(int code, string reason)
        {
            Code = code;
            Reason = reason;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BikeSellerServiceException"/> class.
        /// </summary>
        /// <param name="code">HTTP response code.</param>
        /// <param name="reason">HTTP error reason.</param>
        /// <param name="description">HTTP error description.</param>
        public BikeSellerBusinessServiceException(int code, string reason, string description)
        {
            Code = code;
            Reason = reason;
            Description = description;
        }

        /// <summary>
        /// Gets HTTP Status code.
        /// </summary>
        public int Code { get; }

        /// <summary>
        /// Gets HTTP fail reason.
        /// </summary>
        public string Reason { get; }

        /// <summary>
        /// Gets the error description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        public dynamic Content { get; set; }

    }
}
