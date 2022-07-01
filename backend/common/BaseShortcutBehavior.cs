using DotEnv.Core;
using Newtonsoft.Json;
using WebSocketSharp;
using WebSocketSharp.Server;
// ReSharper disable MemberCanBeProtected.Global

namespace common;

public abstract class BaseShortcutBehavior : WebSocketBehavior {
    private bool _initialized;
    private EnvReader _envs;
    private App[] _apps = null!;
    
    public abstract Func<string?> CheckActiveWindow { get; set; }
    public abstract string ProcessNameToCheck { get; set; }
    private void Init() {
        try {
            var prop = new App().GetType().GetProperty(ProcessNameToCheck);
            if (prop == null)
                throw new KeyNotFoundException($"Property with the name of {ProcessNameToCheck} could not be found");
            
            new EnvLoader().Load();
            _envs = new EnvReader();
            
            var filePath = _envs["SHORTCUTS_FILEPATH"];
            var fileContent = File.ReadAllText(filePath);
            
            _apps = JsonConvert.DeserializeObject<App[]>(fileContent) ?? throw new InvalidOperationException();
            _initialized = true;
            Console.WriteLine("Initialized shortcuts");
        }
        catch (Exception e) {
            Console.WriteLine("Exception while init()");
            Console.WriteLine(e.ToString());
            throw;
        }
    }

    protected override void OnMessage(MessageEventArgs e) {
        if (!_initialized) {
            Init();
        }
        
        Console.WriteLine("New Client connected");
        Send("Connected to Server");

        var activeWindow = string.Empty;
        while (true) {
            try {
                var currentWindow = CheckActiveWindow();

                Console.WriteLine("Checking if new window is active");
                if (currentWindow != null && activeWindow != currentWindow) {
                    activeWindow = currentWindow;
                    Console.WriteLine($"Set new active window: + {activeWindow}");
                    
                    var shortcuts = _apps.Where(app => (string)app.GetType().GetProperty(ProcessNameToCheck)?.GetValue(app, null)! == currentWindow).ToList();
                    if (shortcuts.Any()) {
                        var json = JsonConvert.SerializeObject(shortcuts[0]);
                        Send(json);
                        Console.WriteLine("Send new data for active window");
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
        // ReSharper disable once FunctionNeverReturns
    }
}