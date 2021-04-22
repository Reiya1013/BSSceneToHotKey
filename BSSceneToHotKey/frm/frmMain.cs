using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            this.Visible = false;
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
            this.Visible = true;
        }

        private void btnMenuKeyTest_Click(object sender, EventArgs e)
        {
            this.Visible = false;
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
            this.Visible = true;

        }

        private void btnStartKeyTest_Click(object sender, EventArgs e)
        {
            this.Visible = false;
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
            this.Visible = true;
        }

        private void btnEndKeyTest_Click(object sender, EventArgs e)
        {
            this.Visible = false;
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
            this.Visible = true;
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
    }
}
