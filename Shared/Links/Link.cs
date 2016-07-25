// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Link.cs" Company="">
//   
// </copyright>
// <summary>
//   The link.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Shared.Links
{
    /// <summary>
    ///     The link.
    /// </summary>
    public class Link : ILink
    {
        #region Properties

        /// <summary>
        /// Gets or sets the get uri.
        /// </summary>
        public string GetUri { get; set; }

        /// <summary>
        /// Gets or sets the put uri.
        /// </summary>
        public string PutUri { get; set; }

        /// <summary>
        /// Gets or sets the post uri.
        /// </summary>
        public string PostUri { get; set; }

        #endregion
    }
}