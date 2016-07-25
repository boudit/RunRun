// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILink.cs" Company="">
//   
// </copyright>
// <summary>
//   Defines the ILink type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Shared.Links
{
    public interface ILink
    {
        string GetUri { get; set; }

        string PutUri { get; set; }

        string PostUri { get; set; }
    }
}