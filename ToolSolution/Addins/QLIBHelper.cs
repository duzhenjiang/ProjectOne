using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ToolSolution.Addins.QLIB
{
    class QLIBHelper
    {
        const string DllName = "QMSL_MSVC10R.dll";

        [DllImport(DllName, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern UInt32 QLIB_ConnectServer(int iComNum);

        [DllImport(DllName, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern byte QLIB_IsPhoneConnected(UInt32 hResourceContext);

        [DllImport(DllName, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern byte QLIB_DIAG_CONTROL_F(UInt32 hResourceContext, int iMode);

        /// <summary>
        /// Send Sync funtion. 
        /// </summary>
        /// <param name="hResourceContext"></param>
        /// <param name="requestSize">size of request buffer</param>
        /// <param name="requestBytes">byte buffer containing the diag cmd to be sent</param>
        /// <param name="responseSize">size of the response got back from the phone</param>
        /// <param name="responseBytes">byte buffer containing the diag cmd response</param>
        /// <param name="timeout">max time to wait for response from the phone</param>
        /// <returns>True =  diag cmd successfully received and executed by the phone, False = diag cmd execution failure</returns>
        [DllImport(DllName, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern byte QLIB_SendSync(uint hResourceContext,
            short requestSize,
            byte[] requestBytes,
            ref short responseSize,
            byte[] responseBytes,
            ulong timeout
            );

        public UInt32[] QlibHandle = new UInt32[4];

        /// <summary>
        /// QLIB_ConnectServer
        /// </summary>
        /// <param name="iComNum">端口</param>
        /// <returns></returns>
        public UInt32 ConnectServer(int iComNum)
        {
            return QLIB_ConnectServer(iComNum);
        }

        /// <summary>
        /// QLIB_IsPhoneConnected
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool IsPhoneConnected(int i)
        {
            return QLIB_IsPhoneConnected(QlibHandle[i]) == 1;
        }
    }
}
