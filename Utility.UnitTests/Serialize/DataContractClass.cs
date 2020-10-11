using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System;

namespace jktoiuhito.Utility.UnitTests
{
    [DataContract]
    public sealed class DataContractClass : IEquatable<DataContractClass>
    {
        [DataMember(IsRequired = true)]
        public string Name { get; private set; }

        public DataContractClass (string name) => Name = name;

        public bool Equals ([AllowNull] DataContractClass other) =>
            other != null && other.Name == Name;
    }
}
