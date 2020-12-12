using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Addins.NFC
{
    class NFCHelper
    {
		uint NfcHandle;
		[DllImport("dcrf32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
		static extern uint dc_init(int port, Int32 baud);

		[DllImport("dcrf32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
		static extern Int16 dc_request(uint icdev, byte _Mode, ref uint TagType);

		[DllImport("dcrf32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
		static extern Int16 dc_anticoll(uint icdev, byte _Bcnt, ref uint _Snr);

		[DllImport("dcrf32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
		static extern Int16 dc_select(uint icdev, uint _Snr, StringBuilder _Size);

		/// <summary>
		/// NFC初始化
		/// </summary>
		/// <param name="port">端口</param>
		/// <param name="baud">波特率</param>
		/// <returns>句柄</returns>
		public uint BS_dc_init(int port, Int32 baud)
		{
			NfcHandle = dc_init(port, baud);
			return NfcHandle;
		}

        /// <summary>
        /// NFC D8测试
        /// </summary>
        /// <returns></returns>
        public Int16 BS_dc_test()
        {
            uint ttt = 0;
            StringBuilder sss = new StringBuilder(); ;
            byte b = new byte();
            b = 1;

            if (dc_request(NfcHandle, b, ref ttt) != 0)
            {
                return 0;
            }

            uint cardsnr = 0;
            b = 0;
            if (dc_anticoll(NfcHandle, b, ref cardsnr) != 0)
            {
                return 0;
            }

            if (dc_select(NfcHandle, cardsnr, sss) != 0)
            {
                return 0;
            }
            return 1;
        }
    }
}
