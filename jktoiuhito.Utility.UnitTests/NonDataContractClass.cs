using System.Collections.Generic;
using System.Text;
using System;
using System.Diagnostics.CodeAnalysis;

namespace jktoiuhito.Utility.UnitTests
{
    public sealed class NonDataContractClass : IEquatable<NonDataContractClass>
    {
        public string Name { get; private set; }

        public NonDataContractClass (string name) => Name = name;

        public bool Equals ([AllowNull] NonDataContractClass other) =>
            other != null && other.Name == Name;
    }
}
