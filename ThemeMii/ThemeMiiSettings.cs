namespace ThemeMii;
public class ThemeMiiSettings
{
    public bool IgnoreMissing { get; set; } = true;
    public bool SourceManage  {get; set;}= true;
    public bool ContainerManage  {get; set; } = true;
    public bool AutoImageSize {get; set; } = true;
    public bool KeepExtractedApp {get; set; } = true;
    public bool Lz77Containers {get; set; } = true;
    public bool SavePrompt {get; set; } = true;
    public string? NandBackupPath {get; set; }
    public bool SaveNandPath {get; set; } = true;
    public bool SaveWindowChanges {get; set; } = true;
    public bool ImageSizeFromTpl {get; set; }= true;
}