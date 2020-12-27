using System;
using System.Runtime.InteropServices;

namespace QLIBHelper
{
    public class QLIB
    {
        const string DllName = "QMSL_MSVC10R.dll";

        /// <summary>
        /// QLIB_TARGET_TYPE
        /// </summary>
        public enum TargetType
        {
            QLIB_TARGET_TYPE_MSM_MDM = 0,       // The target supports WWAN modem.   
            QLIB_TARGET_TYPE_APQ = 1,           // Application processor only type target (APQ).  No WWAN modem
            QLIB_TARGET_TYPE_MAX_INVALID = 2   // The invalid target type
        }

        [DllImport(DllName, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern UInt32 QLIB_ConnectServer(uint iComNum);

        [DllImport(DllName, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern UInt32 QLIB_ConnectServerWithWait(uint iComNum, ulong wait_ms);

        [DllImport(DllName, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern byte QLIB_DisconnectServer(UInt32 hResourceContext);

        [DllImport(DllName, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern byte QLIB_IsPhoneConnected(UInt32 hResourceContext);

        [DllImport(DllName, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern void QLIB_SetTargetType(byte targetType);

        [DllImport(DllName, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern byte QLIB_GetComPortNumber(UInt32 hResourceContext, ushort[] uPhysicalPort);

        [DllImport(DllName, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern byte QLIB_ConfigureTimeOut(UInt32 hResourceContext, ulong TimeOutId, ulong NewValue_ms);

        [DllImport(DllName, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern byte QLIB_DIAG_CONTROL_F(UInt32 hResourceContext, int iMode);

        [DllImport(DllName, SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        static extern byte QLIB_FlushRxBuffer(UInt32 hResourceContext);

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
        private readonly uint[] uComPortNum = new uint[4];

        /// <summary>
        /// QLIB_DisconnectServer
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public void DisconnectServer(int i)
        {
            QLIB_DisconnectServer(QlibHandle[i]);
            QlibHandle[i] = 0;
        }

        /// <summary>
        /// ConnectToServer
        /// </summary>
        /// <param name="i"></param>
        /// <param name="iComNum"></param>
        /// <param name="targetType"></param>
        public void ConnectToServer(int i, uint iComNum, TargetType targetType)
        {
            QLIB_SetTargetType((byte)targetType);
            ConnectToServerAutoDetect(i, iComNum);
        }

        public void ConnectToServer(int i, uint iComNum)
        {
            ConnectToServerAutoDetect(i, iComNum);
            QLIB_ConfigureTimeOut(QlibHandle[i], (ulong)QMSL_TimeOutType_Enum.QMSL_Timeout_General, 5000);
            QLIB_ConfigureTimeOut(QlibHandle[i], (ulong)QMSL_TimeOutType_Enum.QMSL_Timeout_IsPhoneConnected, 2000);
        }

        /// <summary>
        /// ConnectToServerAutoDetect
        /// </summary>
        /// <param name="i"></param>
        /// <param name="iComNum"></param>
        public void ConnectToServerAutoDetect(int i, uint iComNum)
        {
            ushort[] uPhysicalPort = new ushort[1];

            if (iComNum != PhoneConstants.AutoSearchComPort)
            {
                QlibHandle[i] = QLIB_ConnectServer(iComNum);
            }
            else
            {
                QlibHandle[i] = QLIB_ConnectServerWithWait(iComNum, 60 * 1000);
            }
            if (QlibHandle[i] != 0)
            {
                QLIB_GetComPortNumber(QlibHandle[i], uPhysicalPort);
                uComPortNum[i] = uPhysicalPort[0];
            }
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

        public void SendSync(int i, ref short respSize)
        {
            int iRetry = 5;
            for (int j = 0; j < iRetry; j++)
            {
                if (respSize == 0)
                {
                    respSize = PhoneConstants.DefaultRespSize;
                }
                short respBuffSize = respSize;
                byte[] respBuff = new byte[respSize];
                QLIB_FlushRxBuffer(QlibHandle[i]);
                if (!IsPhoneConnected(i))
                {
                    DisconnectServer(i);
                    ConnectToServer(i, uComPortNum[i]);
                }
            }
        }
    }
}
