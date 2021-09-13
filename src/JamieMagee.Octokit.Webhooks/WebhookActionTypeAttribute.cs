namespace JamieMagee.Octokit.Webhooks
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    internal class WebhookActionTypeAttribute : Attribute
    {
        public WebhookActionTypeAttribute(string actionType) => this.ActionType = actionType;

        public string ActionType { get; }
    }
}
