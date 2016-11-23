// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopWebClient.cs" company="https://github.com/StyleCop">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. If you cannot locate the  
//   Microsoft Public License, please send an email to dlr@microsoft.com. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
// <summary>
//   Extends the default WebClient.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Net;

    /// <summary>
    /// Extends the default WebClient.
    /// </summary>
    public class StyleCopWebClient : WebClient
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopWebClient"/> class.
        /// </summary>
        public StyleCopWebClient()
        {
            this.Timeout = 100000; // the standard HTTP Request Timeout default
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Timeout.
        /// </summary>
        public int Timeout { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The get web request.
        /// </summary>
        /// <param name="address">
        /// The address.
        /// </param>
        /// <returns>
        /// An instance of a WebRequest.
        /// </returns>
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request != null)
            {
                request.Timeout = this.Timeout;
            }

            return request;
        }

        #endregion
    }
}