﻿using System;
using log4net;

namespace OpenAM.Core.Exceptions
{
    public class ExceptionShield : IExceptionShield
    {
        private readonly ILog _log;

        public ExceptionShield(ILog log)
        {
            _log = log;
        }

        public void Process(Action action)
        {
            Process<object>(
                () =>
                {
                    action();
                    return null;
                });
        }

        public T Process<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (AggregateException ex)
            {
                ex.Handle(
                    x =>
                    {
                        _log.Fatal("Unexpected error: " + x);
                        return false;
                    });

                throw;
            }
            catch (Exception ex)
            {
                _log.Fatal("Unexpected error: " + ex);
                throw;
            }
        }
    }
}
