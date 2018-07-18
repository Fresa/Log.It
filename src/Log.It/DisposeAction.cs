using System;

namespace Log.It
{
    internal class DisposeAction : IDisposable
    {
        private readonly Action _dispose;

        public DisposeAction(Action dispose)
        {
            _dispose = dispose;
        }

        public void Dispose()
        {
            _dispose();
        }
    }
}