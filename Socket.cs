using WebSocketSharp;
using WebSocketSharp.Net;
using WebSocketSharp.Server;


public class ClientJoinManager : WebSocketBehavior {
    protected override void OnOpen() {
        SocketHandler.Clients.Add(this);
        Log.Debug("New Client Connected");
    }

    protected override void OnMessage(MessageEventArgs e) {
        if (e.Data.ToLower().Contains("broadcast")) {
            ClientHandler.HandleBroadcast(e.Data);
        }
    }
}

