using WebSocketSharp.Server;

public class Client {
    public required WebSocketBehavior Websocket { get; set; }
    public string? Name { get; set; } = null;
}

public static class SocketHandler {
    public static List<Client> Clients = new();
}


public class ClientHandler {
    private static async Task Broadcast(string msg, WebSocketBehavior origin) {
        SocketHandler.Clients.Where(x => x.Websocket != origin).ToList().ForEach(x =>
            x.Websocket.Context.WebSocket.Send(msg)
        );

        await PushManager.PushToPhone("Broadcast", msg);
    }

    public static void HandleSend(string msg, string rec) {
        var client = SocketHandler.Clients.FirstOrDefault(
            x => x.Name == rec
        );

        client?.Websocket.Context.WebSocket.Send(
            msg.Split(" ")[2].Trim()
        );
    }


    public static async void HandleBroadcast(string msg, WebSocketBehavior origin) {
        await Broadcast(msg.Remove(0, 9).Trim(), origin);
    }

    public static void HandleOpen(string msg) {
    } 
}