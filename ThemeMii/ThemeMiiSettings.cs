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
    public string? NandBackupPath {get; init; }
    public bool SaveNandPath {get; init; } = true;
    public bool SaveWindowChanges {get; init; } = true;
    public bool ImageSizeFromTpl {get; init; }= true;
}