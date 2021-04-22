using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BSSceneToHotKey
{
    public class MessageEventArgs : EventArgs
    {
        public string Message;
    }

    class clsWebSocket
    {
        //IPAddress
        public string ClientIPAddress { set; get; } = "localhost";
        public string ServerIPAddress { set; get; } = "localhost";
        //Port
        public int ClientPort { set; get; } = 59650;
        public int ServerPort { set; get; } = 59651;
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
            var uri = new Uri("ws://" + ClientIPAddress + ":" + ClientPort + "/ws/");

            //サーバに対し、接続を開始
            await ws.ConnectAsync(uri, CancellationToken.None);
            var buffer = new byte[1024];

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
                    msge.Message = message;
                    MessageReturn(this, msge);
                }
            }
        }

        /// <summary>
        /// WebSocetServerスタート
        /// </summary>
        /// <returns></returns>
        public async Task WSServer()
        {
            //Httpリスナーを立ち上げ、クライアントからの接続を待つ
            HttpListener s = new HttpListener();
            s.Prefixes.Add("http://" + ServerIPAddress + ":" + ServerPort + "/ws/");
            s.Start();
            var hc = await s.GetContextAsync();

            //クライアントからのリクエストがWebSocketでない場合は処理を中断
            if (!hc.Request.IsWebSocketRequest)
            {
                //クライアント側にエラー(400)を返却し接続を閉じる
                hc.Response.StatusCode = 400;
                hc.Response.Close();
                return;
            }

            //WebSocketでレスポンスを返却
            var wsc = await hc.AcceptWebSocketAsync(null);
            var ws = wsc.WebSocket;

            var buffer = new byte[1024];

            //情報取得待ちループ
            while (true)
            {
                //所得情報確保用の配列を準備
                var segment = new ArraySegment<byte>(buffer);

                //クライアントからのレスポンス情報を取得
                var result = await ws.ReceiveAsync(segment, CancellationToken.None);

                //リスタート処理
                if (RestartServer)
                {
                    RestartServer = false;
                    await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Done", CancellationToken.None);
                    _ = Task.Run(WSServer);
                    return;
                }

                //エンドポイントCloseの場合、処理を中断
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "OK", CancellationToken.None);
                    return;
                }

                //バイナリの場合は、当処理では扱えないため、処理を中断
                if (result.MessageType == WebSocketMessageType.Binary)
                {
                    await ws.CloseAsync(WebSocketCloseStatus.InvalidMessageType, "I don't do binary", CancellationToken.None);
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
                    msge.Message = message;
                    MessageReturn(this, msge);
                }
            }

        }


    }
}
