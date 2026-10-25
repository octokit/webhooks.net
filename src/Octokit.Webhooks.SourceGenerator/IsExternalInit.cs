// Enables init-only setters and records when targeting netstandard2.0
namespace System.Runtime.CompilerServices;

using System.ComponentModel;

[EditorBrowsable(EditorBrowsableState.Never)]
internal static class IsExternalInit;
