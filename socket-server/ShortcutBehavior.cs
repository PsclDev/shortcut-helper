using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using dotenv.net.Utilities;
using Newtonsoft.Json;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Shortcuts_Helper_Server {
    public class ShortcutBehavior : WebSocketBehavior {
        private bool _initialized;
        private App[] Apps;

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        private void Init() {
            var filePath = EnvReader.GetStringValue("SHORTCUTS_FILEPATH");
            var fileContent = File.ReadAllText(filePath);
            Apps = JsonConvert.DeserializeObject<App[]>(fileContent);

            Console.WriteLine("Initialized Shortcuts");
            _initialized = true;
        }

        protected override void OnMessage(MessageEventArgs e) {
            if (!_initialized)
                Init();

            Console.WriteLine("New Client connected");
            Send("Connected to Server");

            var activeWindow = string.Empty;

            while (true) {
                try {
                    IntPtr hWnd = GetForegroundWindow();
                    uint proccessId = 0;
                    GetWindowThreadProcessId(hWnd, out proccessId);

                    var process = Process.GetProcessById((int)proccessId);
                    var windowName = process.MainModule.ModuleName;

                    Console.WriteLine("Checking if new Window is Active => " + activeWindow + " | " + windowName);
                    if (activeWindow != windowName) {
                        activeWindow = windowName;
                        Console.WriteLine("New Active => " + activeWindow);

                        var shortcuts = Apps.Where(app => app.ProcessName == activeWindow).ToList();
                        if (shortcuts.Count > 0) {
                            var json = JsonConvert.SerializeObject(shortcuts[0]);
                            Send(json);
                            Console.WriteLine("Data sent");
                        }
                    }

                }
                catch (Exception exc) {
                    Console.WriteLine("Exception triggered");
                    Console.WriteLine(exc.ToString());
                }

                Console.WriteLine("Waiting 5 seconds...");
                Thread.Sleep(5000);
            }
        }
    }
}