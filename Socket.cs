using WebSocketSharp;
using WebSocketSharp.Net;
using WebSocketSharp.Server;


public class ClientJoinManager : WebSocketBehavior {
    protected override void OnOpen() {
        SocketHandler.Clients.Add(this);
        $"New Client Connected {this.Context.Origin}".Info();
    }

    protected override void OnMessage(MessageEventArgs e) {
        if (e.Data.ToLower().Contains("broadcast")) {
            ClientHandler.HandleBroadcast(e.Data);
        }
    }

    protected override void OnClose(CloseEventArgs e) {
        SocketHandler.Clients.Remove(this);
    }
}

