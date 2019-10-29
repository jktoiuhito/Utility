using System.Runtime.Serialization;
using System.Collections.Generic;
using System;

namespace jktoiuhito.Utility.Hateoas
{
    /// <summary>
    /// A serializable class which contains an object and HATEOAS-links.
    /// </summary>
    [DataContract]
    public sealed class HateoasLinkWrapper : HateoasResponse
    {
        /// <summary>
        /// Name of the serialized <see cref="HateoasLinkWrapper"/>s
        /// <see cref="Content"/>.
        /// </summary>
        public const string ContentSerializedName = "content";

        /// <summary>
        /// Object contained in the <see cref="HateoasLinkWrapper"/>.
        /// Is never null.
        /// </summary>
        [DataMember(Name = ContentSerializedName)]
        public object Content { get; private set; }

        /// <summary>
        /// Create a new <see cref="HateoasLinkWrapper"/>.
        /// </summary>
        /// <param name="content">
        ///     Content of the <see cref="HateoasLinkWrapper"/>.
        /// </param>
        /// <param name="links">
        ///     <see cref="HateoasLink"/>s of 
        ///     the <see cref="HateoasLinkWrapper"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="content"/> is null.
        ///     <paramref name="links"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="links"/> is empty or contains nulls.
        /// </exception>
        public HateoasLinkWrapper (
            object content, IEnumerable<HateoasLink> links) : base(links)
        {
            Content =
                content ?? throw new ArgumentNullException(nameof(content));
        }
    }
}
