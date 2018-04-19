using Microsoft.Win32.SafeHandles;
using SLAExemptionTool.DAL;
using System;
using System.Runtime.InteropServices;

namespace SLAExemptionTool.BLL
{
    public class UserBL : IDisposable
    {
        private UserDAL _userDAL;
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public UserBL()
        {
            _userDAL = new UserDAL();
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
        public bool SignIn(string userName, string password, string userType)
        {
            return _userDAL.isValid(userName,password,userType);
        }
    }
}