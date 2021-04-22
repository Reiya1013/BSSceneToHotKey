using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSSceneToHotKey
{
    public partial class Form1 : Form
    {
        //Webソケット通信クラス
        private clsWebSocket ws = new clsWebSocket();
        //キー入力エミュレーション
        private clsKeySimulation key = new clsKeySimulation();
        //保存ディレクトリ
        private string ParamDirectry = Application.StartupPath + "\\Param";
        //パラメータ
        private clsParameter parameter = new clsParameter();
 
        public Form1()
        {
            InitializeComponent();

            clsJsonEventObject test = new clsJsonEventObject();
            string output = "";
            var deserialized = Newtonsoft.Json.JsonConvert.DeserializeObject<clsJsonEventObject>(output);




            Init();
        }

        /// <summary>
        /// 初期処理
        /// </summary>
        private void Init()
        {
            parameter = parameter.XmlLoad(ParamDirectry);
            if (parameter == null) parameter = new clsParameter();

            foreach (Keys val in typeof(Keys).GetEnumValues())
            {
                if ((byte)val <= byte.MaxValue) { 
                    cmbGameKeys.Items.Add(Enum.GetName(typeof(Keys), val));
                    cmbMenuKeys.Items.Add(Enum.GetName(typeof(Keys), val));
                    cmbStartKeys.Items.Add(Enum.GetName(typeof(Keys), val));
                    cmbEndKeys.Items.Add(Enum.GetName(typeof(Keys), val));
                    cmbKey.Items.Add(Enum.GetName(typeof(Keys), val));
                }
            }

            //選択していた値をセットする
            SetKey(parameter.Game, chkGemeAlt, chkGemeCtrl, chkGemeShift, cmbGameKeys);
            SetKey(parameter.Menu, chkMenuAlt, chkMenuCtrl, chkMenuShift, cmbMenuKeys);
            SetKey(parameter.Start, chkStartAlt, chkStartCtrl, chkStartShift, cmbStartKeys);
            SetKey(parameter.End, chkEndAlt, chkEndCtrl, chkEndShift, cmbEndKeys);
            txtClientIpAddress.Text =  parameter.ClientIPAddress ;
            nudPort.Value = parameter.ClientPort;
            nudStartTime.Value = parameter.StartTime;
            nudEndTime.Value = parameter.EndTime;


            ws.ClientIPAddress = parameter.ClientIPAddress;
            ws.ClientPort = parameter.ClientPort;


            //Webソケットのメッセージ受信イベントを紐づける
            ws.MessageReturn += new clsWebSocket.MessageEventHandler(this.MessageReturn);

            //クライアント接続開始
            Task.Run(ws.WSClient);
        }

        /// <summary>
        /// Webソケットからのメッセージ受信イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageReturn(object sender, MessageEventArgs e)
        {
            Console.WriteLine(e.Event.Event);
            if (e.Event.Event == "songStart")
                Task.Run(StartAction);

            else if (e.Event.Event == "menu")
                Task.Run(EndAction);
        }

        private async void StartAction()
        {
            if (parameter.StartTime != 0)
            {
                key.sendKeystroke(parameter.Start);
                await Task.Delay(parameter.StartTime * 1000);
            }
            key.sendKeystroke(parameter.Game);
        }

        private async void EndAction()
        {
            if (parameter.EndTime != 0)
            {
                key.sendKeystroke(parameter.End);
                await Task.Delay(parameter.StartTime * 1000);
            }
            key.sendKeystroke(parameter.Menu);
        }

        /// <summary>
        /// パラメータから最終選択値をセットする
        /// </summary>
        /// <param name="vs"></param>
        /// <param name="Alt"></param>
        /// <param name="Ctrl"></param>
        /// <param name="Shift"></param>
        /// <param name="comboBox"></param>
        private void SetKey(List<byte> vs, CheckBox Alt, CheckBox Ctrl, CheckBox Shift, ComboBox comboBox)
        {
            foreach (byte k in vs)
            {
                if (k == (byte)Keys.Menu)
                    Alt.Checked = true;

                else if (k == (byte)Keys.ControlKey)
                    Ctrl.Checked = true;

                else if (k == (byte)Keys.ShiftKey)
                    Shift.Checked = true;

                else
                    comboBox.SelectedIndex = comboBox.Items.IndexOf(((Keys)k).ToString());
            }
        }

        private void btnGameKeyTest_Click(object sender, EventArgs e)
        {
            List<byte> vs = new List<byte>();
            if (chkGemeAlt.Checked)
                vs.Add((byte)Keys.Menu);

            if (chkGemeCtrl.Checked)
                vs.Add((byte)Keys.ControlKey);

            if (chkGemeShift.Checked)
                vs.Add((byte)Keys.ShiftKey);

            KeysConverter kc = new KeysConverter();
            vs.Add((byte)(Keys)kc.ConvertFromString(cmbGameKeys.Text));

            key.sendKeystroke(vs);
        }

        private void btnMenuKeyTest_Click(object sender, EventArgs e)
        {
            List<byte> vs = new List<byte>();
            if (chkMenuAlt.Checked)
                vs.Add((byte)Keys.Menu);

            if (chkMenuCtrl.Checked)
                vs.Add((byte)Keys.ControlKey);

            if (chkMenuShift.Checked)
                vs.Add((byte)Keys.ShiftKey);

            KeysConverter kc = new KeysConverter();
            vs.Add((byte)(Keys)kc.ConvertFromString(cmbMenuKeys.Text));

            key.sendKeystroke(vs);
        }

        private void btnStartKeyTest_Click(object sender, EventArgs e)
        {
            List<byte> vs = new List<byte>();
            if (chkStartAlt.Checked)
                vs.Add((byte)Keys.Menu);

            if (chkStartCtrl.Checked)
                vs.Add((byte)Keys.ControlKey);

            if (chkStartShift.Checked)
                vs.Add((byte)Keys.ShiftKey);

            KeysConverter kc = new KeysConverter();
            vs.Add((byte)(Keys)kc.ConvertFromString(cmbStartKeys.Text));

            key.sendKeystroke(vs);
        }

        private void btnEndKeyTest_Click(object sender, EventArgs e)
        {
            List<byte> vs = new List<byte>();
            if (chkEndAlt.Checked)
                vs.Add((byte)Keys.Menu);

            if (chkEndCtrl.Checked)
                vs.Add((byte)Keys.ControlKey);

            if (chkEndShift.Checked)
                vs.Add((byte)Keys.ShiftKey);

            KeysConverter kc = new KeysConverter();
            vs.Add((byte)(Keys)kc.ConvertFromString(cmbEndKeys.Text));

            key.sendKeystroke(vs);
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            parameter.Game = GetData(chkGemeAlt, chkGemeCtrl, chkGemeShift, cmbGameKeys.Text);
            parameter.Menu = GetData(chkMenuAlt, chkMenuCtrl, chkMenuShift, cmbMenuKeys.Text);
            parameter.Start = GetData(chkStartAlt, chkStartCtrl, chkStartShift, cmbStartKeys.Text);
            parameter.End = GetData(chkEndAlt, chkEndCtrl, chkEndShift, cmbEndKeys.Text);


            parameter.XmlSave(ParamDirectry);
        }

        private List<byte> GetData(CheckBox Alt,CheckBox Ctrl,CheckBox Shift,string key)
        {
            List<byte> vs = new List<byte>();
            if (Alt.Checked)
                vs.Add((byte)Keys.Menu);

            if (Ctrl.Checked)
                vs.Add((byte)Keys.ControlKey);

            if (Shift.Checked)
                vs.Add((byte)Keys.ShiftKey);

            if (key != string.Empty)
            {
                KeysConverter kc = new KeysConverter();
                vs.Add((byte)(Keys)kc.ConvertFromString(key));
            }

            return vs;
        }

        private void btnClientReset_Click(object sender, EventArgs e)
        {
            parameter.ClientIPAddress = txtClientIpAddress.Text;
            parameter.ClientPort = (int)nudPort.Value;

            parameter.XmlSave(ParamDirectry);


            ws.ClientIPAddress = parameter.ClientIPAddress;
            ws.ClientPort = parameter.ClientPort;

            //再スタートフラグON
            ws.RestartClient = true;
        }

        private void btnSetMessage_Click(object sender, EventArgs e)
        {
            parameter.StartTime = (int)nudStartTime.Value;
            parameter.EndTime = (int)nudEndTime.Value;


            parameter.XmlSave(ParamDirectry);

        }




        #region ボタンエミュレーション

        // 仮想キーコードをスキャンコードに変換

        [DllImport("user32.dll", EntryPoint = "MapVirtualKeyA")]
        public extern static int MapVirtualKey(int wCode, int wMapType);
        // キー操作、マウス操作をシミュレート(擬似的に操作する)
        [DllImport("user32.dll")]
        private extern static void SendInput(int nInputs, ref INPUT pInputs, int cbsize);

        private const int INPUT_MOUSE = 0;                   // マウスイベント
        private const int INPUT_KEYBOARD = 1;                // キーボードイベント
        private const int INPUT_HARDWARE = 2;                // ハードウェアイベント

        private const int MOUSEEVENTF_MOVE = 0x1;            // マウスを移動する
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;     // 絶対座標指定
        private const int MOUSEEVENTF_LEFTDOWN = 0x2;        // 左　ボタンを押す
        private const int MOUSEEVENTF_LEFTUP = 0x4;          // 左　ボタンを離す
        private const int MOUSEEVENTF_RIGHTDOWN = 0x8;       // 右　ボタンを押す
        private const int MOUSEEVENTF_RIGHTUP = 0x10;        // 右　ボタンを離す
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x20;     // 中央ボタンを押す
        private const int MOUSEEVENTF_MIDDLEUP = 0x40;       // 中央ボタンを離す
        private const int MOUSEEVENTF_WHEEL = 0x800;         // ホイールを回転する
        private const int WHEEL_DELTA = 120;                 // ホイール回転値

        private const int  KEYEVENTF_KEYDOWN = 0x0;          // キーを押す
        private const int KEYEVENTF_KEYUP = 0x2;             // キーを離す
        private const int  KEYEVENTF_EXTENDEDKEY = 0x1;      // 拡張コード
        private const int VK_SHIFT = 0x10;                   // SHIFTキー
        private const int VK_CONTROL = 0x11;                 // Contlorキー
        private const int VK_ALT = 0x12;                     // Altキー

        // マウスイベント(mouse_eventの引数と同様のデータ)
        [StructLayout(LayoutKind.Sequential)]
        private struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public int dwExtraInfo;
        };

        // キーボードイベント(keybd_eventの引数と同様のデータ)
        [StructLayout(LayoutKind.Sequential)]
        private struct KEYBDINPUT
        {
            public short wVk;
            public short wScan;
            public int dwFlags;
            public int time;
            public int dwExtraInfo;
        };

        // ハードウェアイベント
        [StructLayout(LayoutKind.Sequential)]
        private struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        };

        // 各種イベント(SendInputの引数データ)
        [StructLayout(LayoutKind.Explicit)]
        private struct INPUT
        {
            [FieldOffset(0)] public int type;
            [FieldOffset(4)] public MOUSEINPUT mi;
            [FieldOffset(4)] public KEYBDINPUT ki;
            [FieldOffset(4)] public HARDWAREINPUT hi;
        };

        private void cmbKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButtonName();
        }
        private void SetButtonName()
        {
            btnPush.Text = string.Empty;
            if (chkCtrl.Checked) btnPush.Text += "Ctrl + ";
            if (chkAlt.Checked) btnPush.Text += "Alt + ";
            if (chkShift.Checked) btnPush.Text += "Shift + ";
            btnPush.Text += cmbKey.Text;
        }


        private void chkCtrl_CheckedChanged(object sender, EventArgs e)
        {
            SetButtonName();
        }

        private void chkAlt_CheckedChanged(object sender, EventArgs e)
        {
            SetButtonName();
        }

        private void chkShift_CheckedChanged(object sender, EventArgs e)
        {
            SetButtonName();
        }

        private async void KeyPush()
        {
            this.Visible = false;

            // キーボード操作実行用のデータ
            int num = 2;
            if (chkAlt.Checked) num += 2;
            if (chkCtrl.Checked) num += 2;
            if (chkShift.Checked) num += 2;
            INPUT[] input = new INPUT[num];
            int setNo = 0;

            //(1)キーボード(Ctrl)を押す
            if (chkCtrl.Checked)
            {
                input[setNo].type = INPUT_KEYBOARD;
                input[setNo].ki.wVk = VK_CONTROL;
                input[setNo].ki.wScan = (short)MapVirtualKey((int)Keys.Control, 0);
                input[setNo].ki.dwFlags = KEYEVENTF_EXTENDEDKEY ^ KEYEVENTF_KEYDOWN;
                input[setNo].ki.dwExtraInfo = 0;
                input[setNo].ki.time = 0;
                setNo += 1;
            }

            //(2)キーボード(Alt)を押す
            if (chkAlt.Checked)
            {
                input[setNo].type = INPUT_KEYBOARD;
                input[setNo].ki.wVk = VK_ALT;
                input[setNo].ki.wScan = (short)MapVirtualKey(input[setNo].ki.wVk, 0);
                input[setNo].ki.dwFlags = KEYEVENTF_EXTENDEDKEY ^ KEYEVENTF_KEYDOWN;
                input[setNo].ki.dwExtraInfo = 0;
                input[setNo].ki.time = 0;
                setNo += 1;
            }

            //(3)キーボード(SHIFT)を押す
            if (chkShift.Checked)
            {
                input[setNo].type = INPUT_KEYBOARD;
                input[setNo].ki.wVk = VK_SHIFT;
                input[setNo].ki.wScan = (short)MapVirtualKey(input[setNo].ki.wVk, 0);
                input[setNo].ki.dwFlags = KEYEVENTF_EXTENDEDKEY ^ KEYEVENTF_KEYDOWN;
                input[setNo].ki.dwExtraInfo = 0;
                input[setNo].ki.time = 0;
                setNo += 1;
            }

            //(4)キーボードを押す
            KeysConverter kc = new KeysConverter();
            input[setNo].type = INPUT_KEYBOARD;
            input[setNo].ki.wVk = (short)(Keys)kc.ConvertFromString(cmbKey.Text);
            input[setNo].ki.wScan = (short)MapVirtualKey(input[setNo].ki.wVk, 0);
            input[setNo].ki.dwFlags =  KEYEVENTF_KEYDOWN;
            input[setNo].ki.dwExtraInfo = 0;
            input[setNo].ki.time = 0;
            setNo += 1;

            //(5)キーボードを離す
            input[setNo].type = INPUT_KEYBOARD;
            input[setNo].ki.wVk = (short)(Keys)kc.ConvertFromString(cmbKey.Text);
            input[setNo].ki.wScan = (short)MapVirtualKey(input[setNo].ki.wVk, 0);
            input[setNo].ki.dwFlags = KEYEVENTF_KEYUP;
            input[setNo].ki.dwExtraInfo = 0;
            input[setNo].ki.time = 0;
            setNo += 1;

            //(6)キーボード(SHIFT)を離す
            if (chkShift.Checked)
            {
                input[setNo].type = INPUT_KEYBOARD;
                input[setNo].ki.wVk = VK_SHIFT;
                input[setNo].ki.wScan = (short)MapVirtualKey(input[setNo].ki.wVk, 0);
                input[setNo].ki.dwFlags = KEYEVENTF_EXTENDEDKEY ^ KEYEVENTF_KEYUP;
                input[setNo].ki.dwExtraInfo = 0;
                input[setNo].ki.time = 0;
                setNo += 1;
            }

            //(7)キーボード(Alt)を離す
            if (chkAlt.Checked)
            {
                input[setNo].type = INPUT_KEYBOARD;
                input[setNo].ki.wVk = VK_ALT;
                input[setNo].ki.wScan = (short)MapVirtualKey(input[setNo].ki.wVk, 0);
                input[setNo].ki.dwFlags = KEYEVENTF_EXTENDEDKEY ^ KEYEVENTF_KEYUP;
                input[setNo].ki.dwExtraInfo = 0;
                input[setNo].ki.time = 0;
                setNo += 1;
            }

            //(8)キーボード(Ctrl)を離す
            if (chkCtrl.Checked)
            {
                input[setNo].type = INPUT_KEYBOARD;
                input[setNo].ki.wVk = VK_CONTROL;
                input[setNo].ki.wScan = (short)MapVirtualKey((int)Keys.Control, 0);
                input[setNo].ki.dwFlags = KEYEVENTF_EXTENDEDKEY ^ KEYEVENTF_KEYUP;
                input[setNo].ki.dwExtraInfo = 0;
                input[setNo].ki.time = 0;
                setNo += 1;
            }

            // キーボード操作実行
            SendInput(num,ref input[0], Marshal.SizeOf(input[0]));

            await Task.Delay(1000);

            this.Visible = true;

        }
        private void btnPush_Click(object sender, EventArgs e)
        {
            KeyPush();
        }


        #endregion

    }
}
