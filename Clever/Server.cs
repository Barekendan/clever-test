using System.Threading;

namespace Clever
{
    public static class Server
    {
        private static int _count;

        private static ReaderWriterLockSlim _countLock = new ReaderWriterLockSlim();

        public static int GetCount()
        {
            _countLock.EnterReadLock();
            try
            {
                return _count;
            }
            finally
            {
                _countLock.ExitReadLock();
            }
        }

        public static void AddToCount(int value)
        {
            _countLock.EnterWriteLock();
            try
            {
                checked
                {
                    _count += value;
                }
            }
            finally
            {
                _countLock.ExitWriteLock();
            }
        }
    }
}
