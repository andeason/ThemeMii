using Avalonia;
using Avalonia.Controls;

namespace ThemeMii;
public class ThemeMiiSettings
{
    public bool IgnoreMissing { get; init; } = true;
    public bool SourceManage  {get; init;}= true;
    public bool ContainerManage  {get; init; } = true;
    //This was basically just used for aesthetic.  It actually is tied to the PNG check.
    //IF ImageSizeFromPNG is false, AutoImageSize is true.
    //It is false otherwise.
    //Thus, this value should only be true IF ImageSizefromPng is the one.  
    public bool AutoImageSize {get; init; } = true;
    public bool KeepExtractedApp {get; init; } = true;
    public bool Lz77Containers {get; init; } = true;
    public bool SavePrompt {get; init; } = true;
    public string? NandBackupPath { get; set; }
    public bool SaveNandPath {get; init; } = true;
    public bool ImageSizeFromTpl {get; init; }= true;

    //There was a serialization issue when doing x and y, so I am just opting for the direct x/y coordinates.
    public int LastLocationX { get; set; }
    public int LastLocationY { get; set; }
    public WindowState LastWindowState { get; set; } = WindowState.Normal;
    public BaseApp LastExtracted { get; set; } = 0;
    public BaseApp StandardMenu { get; set; } = 0;
}