using System.Runtime.Serialization;
using System.Collections.Generic;
using System;

namespace jktoiuhito.Utility.Hateoas
{
    /// <summary>
    /// A serializable class which contains an object and HATEOAS-links.
    /// </summary>
    /// <typeparam name="T">Type of the contained object.</typeparam>
    [DataContract]
    public sealed class HateoasLinkWrapper<T> : HateoasResponse where T : class
    {
        public const string ContentSerializedName = "content";

        /// <summary>
        /// Object contained in the <see cref="HateoasLinkWrapper{T}"/>.
        /// Is never null.
        /// </summary>
        [DataMember(Name = ContentSerializedName)]
        public T Content { get; private set; }

        public HateoasLinkWrapper (
            T content, IEnumerable<HateoasLink> links) : base(links)
        {
            Content =
                content ?? throw new ArgumentNullException(nameof(content));
        }
    }
}
