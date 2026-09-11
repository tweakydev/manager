using WebSocketSharp;
using WebSocketSharp.Server;


public class ClientJoinManager : WebSocketBehavior {
    protected override void OnOpen() {
        SocketHandler.Clients.Add(new() { Websocket = this });
    }

    protected override void OnMessage(MessageEventArgs e) {
        if (e.Data.ToLower().Contains("broadcast")) {
            ClientHandler.HandleBroadcast(e.Data, this);
        }

        else if(e.Data.ToLower().Contains("name")) {
            SocketHandler.Clients.First(x => x.Websocket == this).Name = e.Data.Remove(0, 4).Trim();
            $"New Client Connected: {e.Data.Remove(0, 4).Trim()}".Info();
        }

        else if(e.Data.ToLower().Contains("send")) {
            var d = e.Data.Split(" ");
            Console.WriteLine($"Sending {d[2]} to {d[1]}");
            ClientHandler.HandleSend(e.Data, e.Data.Split(" ")[2]);
        }
    }

    protected override void OnClose(CloseEventArgs e) {
        SocketHandler.Clients.RemoveAll(x => x.Websocket == this);
        $"Client Disconnected: {Context.RequestUri}".Info();
    }
}

