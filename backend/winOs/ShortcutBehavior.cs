using System.Diagnostics;
using System.Runtime.InteropServices;
using common;

namespace WinOs; 

public class ShortcutBehavior : BaseShortcutBehavior {
    public sealed override Func<string?> CheckActiveWindow { get; set; }
    public sealed override string ProcessNameToCheck { get; set; }

    public ShortcutBehavior() {
        CheckActiveWindow = GetActiveWindow;
        ProcessNameToCheck = "WinName";
    }

    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();
    
    [DllImport("user32.dll", SetLastError = true)]
    static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    private string? GetActiveWindow() {
        IntPtr hWnd = GetForegroundWindow();
        GetWindowThreadProcessId(hWnd, out var proccessId);

        var process = Process.GetProcessById((int)proccessId);
        return process.MainModule?.ModuleName;
    }
}