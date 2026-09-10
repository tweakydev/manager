var sv = new WebSocketSharp.Server.WebSocketServer("ws://127.0.0.1:6969");

sv.AddWebSocketService<ClientJoinManager>("/join");
"Registered Client Join".Info();

sv.Start();

"Started Server".Info();
$"Listening On ws://{sv.Address.ToString()}:{sv.Port}".Debug();

Console.ReadKey(true);
sv.Stop();
