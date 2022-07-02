using System.Diagnostics;
using System.Runtime.InteropServices;
using common;
using MonoMac.AppKit;
using MonoMac.CoreGraphics;

namespace MacOs;
public class ShortcutBehavior : BaseShortcutBehavior {
    public sealed override Func<string?> CheckActiveWindow { get; set; }
    public sealed override string ProcessNameToCheck { get; set; }

    public ShortcutBehavior() {
        CheckActiveWindow = GetActiveWindow;
        ProcessNameToCheck = "MacName";
    }
    
    private string? GetActiveWindow() {
        return NSWorkspace.SharedWorkspace.FrontmostApplication.LocalizedName;
    }
}