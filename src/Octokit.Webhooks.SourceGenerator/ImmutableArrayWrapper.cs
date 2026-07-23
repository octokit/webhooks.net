namespace Octokit.Webhooks.SourceGenerator;

using System;
using System.Collections.Immutable;
using System.Linq;

internal readonly struct ImmutableArrayWrapper<T>(ImmutableArray<T> array) : IEquatable<ImmutableArrayWrapper<T>>
{
    public ImmutableArray<T> Array => array;

    public static bool operator ==(ImmutableArrayWrapper<T> left, ImmutableArrayWrapper<T> right) => left.Equals(right);

    public static bool operator !=(ImmutableArrayWrapper<T> left, ImmutableArrayWrapper<T> right) => !(left == right);

    public override bool Equals(object? obj) => obj is ImmutableArrayWrapper<T> wrapper && this.Equals(wrapper);

    public bool Equals(ImmutableArrayWrapper<T> other) => this.Array.SequenceEqual(other.Array);

    public override int GetHashCode() => this.Array.Length;
}
