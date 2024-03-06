using Capivara.Backend.Types;

namespace Capivara.Backend.Models;

public class Folder(
    // TODO hash?
    Guid id,
    string schema,
    string folderName
)
{
    public Guid Id { get; set; } = id;
    public string Schema { get; set; } = schema;
    public string FolderName { get; set; } = folderName;
    public Serial[] Summary { get; set; } = [];
    public int TotalDocuments { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }
}