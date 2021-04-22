using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BSSceneToHotKey
{
    public class MessageEventArgs : EventArgs
    {
        public clsJsonEventObject Event;
    }

    class clsWebSocket
    {
        //IPAddress
        public string ClientIPAddress { set; get; } = "localhost";
        public string ServerIPAddress { set; get; } = "localhost";
        //Port
        public int ClientPort { set; get; } = 6557;
        public int ServerPort { set; get; } = 59650;
        //Server使うかのフラグ
        public bool ServerOn { set; get; }

        //Clientリスタートフラグ
        public bool RestartClient { set; get; }

        //Serverリスタートフラグ
        public bool RestartServer { set; get; }


        //受信メッセージリターンイベント
        //MessageEventArgs型のオブジェクトを返すようにする
        public delegate void MessageEventHandler(object sender, MessageEventArgs e); 
        public event MessageEventHandler MessageReturn;

        /// <summary>
        /// WebSocketクライアント
        /// </summary>
        /// <returns></returns>
        public async Task WSClient()
        {
            //クライアント側のWebSocketを定義
            ClientWebSocket ws = new ClientWebSocket();

            //接続先エンドポイントを指定
            var uri = new Uri("ws://" + ClientIPAddress + ":" + ClientPort + "/socket");

            //サーバに対し、接続を開始
             await ws.ConnectAsync(uri, CancellationToken.None);
            var buffer = new byte[1016000];

            //情報取得待ちループ
            while (true)
            {
                //所得情報確保用の配列を準備
                var segment = new ArraySegment<byte>(buffer);

                //サーバからのレスポンス情報を取得
                var result = await ws.ReceiveAsync(segment, CancellationToken.None);

                //リスタート処理
                if (RestartClient)
                {
                    RestartClient = false;
                    await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "OK", CancellationToken.None);
                    _ = Task.Run(WSClient);
                    return;
                }

                //エンドポイントCloseの場合、処理を中断
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "OK",CancellationToken.None);
                    return;
                }

                //バイナリの場合は、当処理では扱えないため、処理を中断
                if (result.MessageType == WebSocketMessageType.Binary)
                {
                    await ws.CloseAsync(WebSocketCloseStatus.InvalidMessageType,"I don't do binary", CancellationToken.None);
                    return;
                }

                //メッセージの最後まで取得
                int count = result.Count;
                while (!result.EndOfMessage)
                {
                    if (count >= buffer.Length)
                    {
                        await ws.CloseAsync(WebSocketCloseStatus.InvalidPayloadData, "That's too long", CancellationToken.None);
                        return;
                    }
                    segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                    result = await ws.ReceiveAsync(segment, CancellationToken.None);


                    count += result.Count;
                }

                //メッセージを取得
                var message = Encoding.UTF8.GetString(buffer, 0, count);
                Console.WriteLine("> " + message);
                if (MessageReturn != null)
                {
                    MessageEventArgs msge = new MessageEventArgs();
                    try
                    {
                        var jobj = JObject.Parse(message);
                        jobj.Remove("status");
                        Console.WriteLine(jobj.ToString());
                        var deserialized = JsonConvert.DeserializeObject<clsJsonEventObject>(jobj.ToString());
                        Console.WriteLine(deserialized);
                        msge.Event = deserialized;
                        MessageReturn(this, msge);
                    }
                    catch
                    {

                    }

                    Console.WriteLine(message);
                }



            }
        }

    }
}
