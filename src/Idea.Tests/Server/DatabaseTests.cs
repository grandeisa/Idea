namespace Idea.Tests.Server;

using Idea.Server;

public class DatabaseTests
{
    [Theory]
    [InlineData(@"_CopyToOutput/a.db")]
    [InlineData(@"_CopyToOutput/c-_1q.db")]
    [InlineData(@"_CopyToOutput/e7r78dcg.db")]
    public void NewDatabase_FileDoesNotExist_NewEmptyFile(string path)
    {
        
        Database db = new Database(path);

        bool createdFile = File.Exists(path);

        Assert.True(createdFile);

        string contents = File.ReadAllText(path);
        
        Assert.Empty(contents);
    }

    [Theory]
    [InlineData(@"_CopyToOutput/empty/1.db")]
    [InlineData(@"_CopyToOutput/empty/2.db")]
    [InlineData(@"_CopyToOutput/empty/3.db")]
    public void NewDatabase_FileExistsAndEmpty_EmptyFile(string path)
    {
        Database db = new Database(path);

        string contents = File.ReadAllText(path);
        
        Assert.Empty(contents);
    }

    [Theory]
    [InlineData(@"_CopyToOutput/c.db")]
    [InlineData(@"_CopyToOutput/d.db")]
    [InlineData(@"_CopyToOutput/a/a1/a.db")]
    public void NewDatabase_FileExistsAndNotEmpty_Exception(string path)
    {
        Assert.Throws<InvalidDatabasePathException>(delegate() { new Database(path); });
    }

    [Theory]
    [InlineData(@"_CopyToOutput/a/")]
    [InlineData(@"_CopyToOutput/a/a1/")]
    [InlineData(@"_CopyToOutput/empty/")]
    public void NewDatabase_PathIsDirectory_Exception(string path)
    {
        Assert.Throws<InvalidDatabasePathException>(delegate() { new Database(path); });
    }
}