using System;
using System.ComponentModel;
using System.Net;
using System.Reflection;

namespace OpGg
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class OpGgClientBase : IDisposable
    {
        #region User-Agent

        private static readonly string USER_AGENT;

        static OpGgClientBase()
        {
            var opGgUa = UserAgent.From(typeof(OpGgClientBase).Assembly);
            opGgUa.DependentProduct = UserAgent.From(Assembly.GetEntryAssembly());
            USER_AGENT = opGgUa.ToString();
        }

        #endregion User-Agent

        #region Construction

        protected readonly HttpClient HttpClient;

        private OpGgClientBase()
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Add("User-Agent", USER_AGENT);
        }

        protected OpGgClientBase(string subdomain) : this()
        {
            HttpClient.BaseAddress = new Uri($"https://{subdomain.ToLower()}.op.gg");
        }

        #endregion Construction

        public void Dispose() => HttpClient.Dispose();
    }
}