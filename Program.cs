EnvReader.Load(".env");

Console.WriteLine(Environment.GetEnvironmentVariable("API_KEY"));

var sv = new WebSocketSharp.Server.WebSocketServer("ws://127.0.0.1:6969");

sv.AddWebSocketService<ClientJoinManager>("/");
"Registered Client Join".Info();

sv.Start();

"Started Server".Info();
$"Listening On ws://{sv.Address.ToString()}:{sv.Port}".Debug();

Console.ReadKey(true);
sv.Stop();


class EnvReader
{
    public static void Load(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"The file '{filePath}' does not exist.");

        foreach (var line in File.ReadAllLines(filePath))
        {
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                continue; // Skip empty lines and comments

            var parts = line.Split('=', 2);
            if (parts.Length != 2)
                continue; // Skip lines that are not key-value pairs

            var key = parts[0].Trim();
            var value = parts[1].Trim();
            Environment.SetEnvironmentVariable(key, value);
        }
    }
}