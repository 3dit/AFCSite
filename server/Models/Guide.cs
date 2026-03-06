namespace AFCSite.Server.Models;

public class Guide
{
    public required string Slug { get; set; }
    public required string Title { get; set; }
    public required string Category { get; set; }
    public required string ReadTime { get; set; }
    public required string Image { get; set; }
    public required string Intro { get; set; }
    public required List<GuideSection> Sections { get; set; }
}

public class GuideSection
{
    public required string Heading { get; set; }
    public required string Content { get; set; }
}
