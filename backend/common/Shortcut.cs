namespace common;

public class Shortcut {
    public string[] Keys { get; set; }
    public string Description { get; set; }

    public Shortcut(string[] keys, string description) {
        Keys = keys;
        Description = description;
    }
}