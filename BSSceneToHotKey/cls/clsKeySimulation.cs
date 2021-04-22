using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace BSSceneToHotKey
{
    class clsKeySimulation
    {
        [DllImport("user32.dll")]
        public static extern uint keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        /// <summary>
        /// キー入力一覧をエミュレートで出力
        /// </summary>
        /// <param name="keys"></param>
        public void sendKeystroke(List<byte> keys)
        {
            if (keys == null) return;

            //キープッシュ
            foreach (byte pi in keys)
            {

                    // キーの押し下げをシミュレートする。
                    keybd_event(pi, 0, 0, (UIntPtr)0);
            }

            Thread.Sleep(10);

            //キーアップ
            foreach (byte pi in keys)
            {
                // キーの解放をシミュレートする。
                keybd_event(pi, 0, 2/*KEYEVENTF_KEYUP*/, (UIntPtr)0);
            }
        }

    }
}
