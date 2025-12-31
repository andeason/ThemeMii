namespace ThemeMii;
public class ThemeMiiSettings
{
    public bool IgnoreMissing { get; init; } = true;
    public bool SourceManage  {get; init;}= true;
    public bool ContainerManage  {get; init; } = true;
    public bool AutoImageSize {get; init; } = true;
    public bool KeepExtractedApp {get; init; } = true;
    public bool Lz77Containers {get; init; } = true;
    public bool SavePrompt {get; init; } = true;
    public string? NandBackupPath {get; init; }
    public bool SaveNandPath {get; init; } = true;
    public bool SaveWindowChanges {get; init; } = true;
    public bool ImageSizeFromTpl {get; init; }= true;
}