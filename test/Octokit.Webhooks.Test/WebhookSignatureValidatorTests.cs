namespace Octokit.Webhooks.Test;

using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using AwesomeAssertions;
using Xunit;

public class WebhookSignatureValidatorTests
{
    [Fact]
    public void NoSignatureAndNoSecret_ReturnsValid()
    {
        var result = WebhookSignatureValidator.Verify(null, null, "{}");

        result.Should().Be(WebhookSignatureValidationResult.Valid);
    }

    [Fact]
    public void EmptySignatureAndEmptySecret_ReturnsValid()
    {
        var result = WebhookSignatureValidator.Verify(string.Empty, string.Empty, "{}");

        result.Should().Be(WebhookSignatureValidationResult.Valid);
    }

    [Fact]
    public void NoSignatureButSecretExpected_ReturnsMissingSignature()
    {
        var result = WebhookSignatureValidator.Verify(null, "my-secret", "{}");

        result.Should().Be(WebhookSignatureValidationResult.MissingSignature);
    }

    [Fact]
    public void EmptySignatureButSecretExpected_ReturnsMissingSignature()
    {
        var result = WebhookSignatureValidator.Verify(string.Empty, "my-secret", "{}");

        result.Should().Be(WebhookSignatureValidationResult.MissingSignature);
    }

    [Fact]
    public void SignedButNoSecretConfigured_ReturnsMissingSecret()
    {
        var signature = ComputeSignature("my-secret", "{}");

        var result = WebhookSignatureValidator.Verify(signature, null, "{}");

        result.Should().Be(WebhookSignatureValidationResult.MissingSecret);
    }

    [Fact]
    public void SignedButEmptySecretConfigured_ReturnsMissingSecret()
    {
        var signature = ComputeSignature("my-secret", "{}");

        var result = WebhookSignatureValidator.Verify(signature, string.Empty, "{}");

        result.Should().Be(WebhookSignatureValidationResult.MissingSecret);
    }

    [Fact]
    public void ValidSignature_ReturnsValid()
    {
        var signature = ComputeSignature("my-secret", "{}");

        var result = WebhookSignatureValidator.Verify(signature, "my-secret", "{}");

        result.Should().Be(WebhookSignatureValidationResult.Valid);
    }

    [Fact]
    public void InvalidSignature_ReturnsSignatureMismatch()
    {
        var signature = ComputeSignature("wrong-secret", "{}");

        var result = WebhookSignatureValidator.Verify(signature, "my-secret", "{}");

        result.Should().Be(WebhookSignatureValidationResult.SignatureMismatch);
    }

    [Fact]
    public void MalformedSignature_ReturnsSignatureMismatch()
    {
        var result = WebhookSignatureValidator.Verify("not-a-valid-signature", "my-secret", "{}");

        result.Should().Be(WebhookSignatureValidationResult.SignatureMismatch);
    }

    [Theory]
    [InlineData("sha256=zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz")]
    [InlineData("sha256=000000000000000000000000000000000000000000000000000000000000000g")]
    [InlineData("sha256=g000000000000000000000000000000000000000000000000000000000000000")]
    [InlineData("sha256=0000000000000000000000000000000000000000000000000000000000000000")]
    [InlineData("sha256=000000000000000000000000000000000000000000000000000000000000000")]
    [InlineData("sha256=00000000000000000000000000000000000000000000000000000000000000000")]
    [InlineData("sha256=")]
    public void NonHexOrWrongLengthSignature_ReturnsSignatureMismatch(string signature)
    {
        var result = WebhookSignatureValidator.Verify(signature, "my-secret", "{}");

        result.Should().Be(WebhookSignatureValidationResult.SignatureMismatch);
    }

    [Fact]
    public void ValidSignatureWithUpperCaseHexAndPrefix_ReturnsValid()
    {
        var signature = ComputeSignature("my-secret", "{}");
        var upperCased = "SHA256=" + signature["sha256=".Length..].ToUpperInvariant();

        var result = WebhookSignatureValidator.Verify(upperCased, "my-secret", "{}");

        result.Should().Be(WebhookSignatureValidationResult.Valid);
    }

    [Fact]
    public void NullBody_ThrowsArgumentNullException()
    {
        var act = () => WebhookSignatureValidator.Verify(null, null, (string)null!);

        act.Should().Throw<ArgumentNullException>().WithMessage("*body*");
    }

    private static string ComputeSignature(string secret, string body)
    {
        var keyBytes = Encoding.UTF8.GetBytes(secret);
        var bodyBytes = Encoding.UTF8.GetBytes(body);
        var hash = HMACSHA256.HashData(keyBytes, bodyBytes);
        var hashHex = Convert.ToHexString(hash);
        return $"sha256={hashHex.ToLower(CultureInfo.InvariantCulture)}";
    }
}
