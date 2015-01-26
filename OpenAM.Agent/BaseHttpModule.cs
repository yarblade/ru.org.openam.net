using System;
using System.Web;
using OpenAM.Core.Exceptions;

namespace OpenAM.Agent
{
    public abstract class BaseHttpModule : IHttpModule
    {
        private readonly IExceptionShield _shield;
        
        protected BaseHttpModule(IExceptionShield shield)
        {
            _shield = shield;
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += BeginRequest;
            context.AuthenticateRequest += AuthenticateRequest;
            context.EndRequest += EndRequest;
        }

        public void Dispose()
        {
        }

        public abstract void OnBeginRequest(HttpContextBase context);
        public abstract void OnAuthenticateRequest(HttpContextBase context);
        public abstract void OnEndRequest(HttpContextBase context);

        private void BeginRequest(object sender, EventArgs e)
        {
            _shield.Process(() => OnBeginRequest(new HttpContextWrapper(((HttpApplication) sender).Context)));
        }

        private void AuthenticateRequest(object sender, EventArgs e)
        {
            _shield.Process(() => OnAuthenticateRequest(new HttpContextWrapper(((HttpApplication)sender).Context)));
        }

        private void EndRequest(object sender, EventArgs e)
        {
            _shield.Process(() => OnEndRequest(new HttpContextWrapper(((HttpApplication)sender).Context)));
        }
    }
}