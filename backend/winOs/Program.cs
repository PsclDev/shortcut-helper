using common;
using DotEnv.Core;
using WebSocketSharp.Server;

namespace WinOs {
    class Programm {
        static void Main() {
            new EnvLoader().Load();
            var envs = new EnvReader();
            var port = Int32.Parse(envs["PORT"]);
            var listeningPath = envs["LISTENING_PATH"];

            var wssv = new WebSocketServer(port);
            wssv.AddWebSocketService<ShortcutBehavior>(listeningPath);
            wssv.Start();
            Console.WriteLine($"WebSocket server startet on port: {port}");
            Console.WriteLine($"WebSocket services listening on: {listeningPath}");

            Console.ReadKey(true);
            wssv.Stop();
        }
    }
}