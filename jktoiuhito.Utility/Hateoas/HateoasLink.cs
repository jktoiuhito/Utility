using jktoiuhito.Utility.Extensions.String;
using System.Runtime.Serialization;
using System;

namespace jktoiuhito.Utility.Hateoas
{
    /// <summary>
    /// A link with a relevancy, used in dynamic
    /// service discovery in RESTful API's.
    /// </summary>
    [DataContract(Name = LinkSerializedName)]
    public sealed class HateoasLink
    {
        public const string LinkSerializedName = "link";
        public const string LinkHrefSerializedName = "href";
        public const string LinkRelSerializedName = "rel";
        public const string RelSelf = "self";

        /// <summary>
        /// <see cref="Uri"/> the <see cref="HateoasLink"/> points to.
        /// Is never null.
        /// </summary>
        [DataMember(
            Name = LinkHrefSerializedName, IsRequired = true, Order = 1)]
        public Uri Href { get; private set; }

        /// <summary>
        /// Relevancy of the <see cref="HateoasLink"/>.
        /// Is never null, empty or whitespace.
        /// </summary>
        [DataMember(
            Name = LinkRelSerializedName, IsRequired = true, Order = 2)]
        public string Rel { get; private set; }

        /// <param name="href">
        ///     <see cref="Uri"/> the <see cref="HateoasLink"/> points to
        ///     as a <see cref="string"/>.
        /// </param>
        /// <param name="rel">
        ///     Relevancy of the <see cref="HateoasLink"/>.
        /// </param>
        /// <exception cref="UriFormatException">
        ///     <paramref name="href"/> cannot be parsed
        ///     into a <see cref="Uri"/>
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="rel"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="rel"/> is empty or whitespace.
        /// </exception>
        public HateoasLink (string href, string rel)
            : this(new Uri(href), rel) { }

        /// <param name="href">
        ///     <see cref="Uri"/> the <see cref="HateoasLink"/> points to.
        /// </param>
        /// <param name="rel">
        ///     Relevancy of the <see cref="HateoasLink"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="href"/> is null.
        ///     <paramref name="rel"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="rel"/> is empty or whitespace.
        /// </exception>
        public HateoasLink (Uri href, string rel)
        {
            Href = href ?? throw new ArgumentNullException(nameof(href));
            Rel = rel.NotNullEmptyWhitespace(nameof(rel));
        }

        /// <summary>
        /// Create a new <see cref="HateoasLink"/> with the
        /// relevancy of <see cref="RelSelf"/>
        /// </summary>
        /// <param name="href">
        ///     <see cref="Uri"/> the <see cref="HateoasLink"/> points to.
        /// </param>
        /// <returns>A new <see cref="HateoasLink"/>.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="href"/> is null.
        /// </exception>
        public static HateoasLink Self (Uri href) =>
            new HateoasLink(href, RelSelf);

        /// <summary>
        /// Create a new <see cref="HateoasLink"/> with the
        /// relevancy of <see cref="RelSelf"/>
        /// </summary>
        /// <param name="href">
        ///     <see cref="Uri"/> the <see cref="HateoasLink"/> points to.
        /// </param>
        /// <returns>A new <see cref="HateoasLink"/>.</returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="href"/> is null.
        /// </exception>
        /// <exception cref="UriFormatException">
        ///     <paramref name="href"/> cannot be parsed
        ///     into a <see cref="Uri"/>.
        /// </exception>
        public static HateoasLink Self (string href) =>
            new HateoasLink(href, RelSelf);
    }
}
