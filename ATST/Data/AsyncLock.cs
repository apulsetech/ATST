using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATST.Data
{
    public sealed class AsyncLock
    {
        private readonly SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1,1);

        public async Task<IDisposable> LockAsync()
        {
            await semaphoreSlim.WaitAsync();
            return new Handler(semaphoreSlim);
        }
    }

    public sealed class Handler : IDisposable
    {
        private readonly SemaphoreSlim semaphore;
        private bool disposed = false;

        public Handler(SemaphoreSlim _semaphore)
        {
            semaphore = _semaphore;
        }

        public void Dispose()
        {
            if (!disposed)
            {
                semaphore.Release();
                disposed = true;
            }
        }
    }
}
