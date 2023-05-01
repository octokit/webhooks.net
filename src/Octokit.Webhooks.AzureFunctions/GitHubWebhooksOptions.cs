namespace Octokit.Webhooks.AzureFunctions;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public sealed record GitHubWebhooksOptions
{
    /// <summary>
    /// Gets or sets the secret to use to validate each webhook request's signature, or null if no
    /// signature is to be expected.
    /// </summary>
    /// <remarks>
    /// The property may not be set if <see cref="SecretsCallback"/> is set.
    /// </remarks>
    public string? Secret { get; set; }

    /// <summary>
    /// Gets or sets a callback delegate that will return the list of secrets to use to validate a
    /// request's signature.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The delegate will be invoked once for each request. If the delegate returns null, then no
    /// signature will be expected. If the delegate returns a list of one or more secrets, then the
    /// request's signature must match one of those secrets. If the delegate returns an empty list,
    /// then the request's signature will be considered invalid.
    /// </para>
    /// <para>
    /// Because the delegate is invoked separately for each request, the webhook secret can be
    /// changed without modifying the route. Returning bpth the old and the new secrets for some
    /// time will allow any webhook requests already in flight to validate against the old secret
    /// while any new requests will validate against the new secret.
    /// </para>
    /// <para>
    /// This property may not be set if <see cref="Secret"/> is set.
    /// </para>
    /// </remarks>
    public Func<Task<IEnumerable<string>?>>? SecretsCallback { get; set; }
}
