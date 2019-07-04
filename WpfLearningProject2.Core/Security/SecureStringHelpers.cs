using System;
using System.Runtime.InteropServices;
using System.Security;

namespace WpfLearningProject2.Core
{
    public static class SecureStringHelpers
    {
        public static string Unsecure(this SecureString securePassword)
        {

            if (securePassword == null)
                return string.Empty;

            var unmanagedString = IntPtr.Zero;

            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
