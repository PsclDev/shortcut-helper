using System;
using dotenv.net;
using dotenv.net.Utilities;
using WebSocketSharp.Server;

namespace Shortcuts_Helper_Server {
    class Program {
        static void Main() {
            DotEnv.Load();
            
            var port = EnvReader.GetIntValue("PORT");
            var wssv = new WebSocketServer(port);
            wssv.AddWebSocketService<ShortcutBehavior>("/shortcuts");
            wssv.Start();
            
            Console.ReadKey(true);
            wssv.Stop();
        }
    }
}