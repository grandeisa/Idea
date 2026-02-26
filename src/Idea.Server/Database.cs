namespace Idea.Server;

public class Database
{
    private string _path;

    /// <summary>
    /// Creates/Empties file for the database.
    /// </summary>
    /// <param name="path">Path of file to store the new database file.</param>
    /// <exception cref="InvalidDatabasePathException">
    /// Throw when the specified file path is a directory or is not empty.
    /// </exception>
    public Database(string path)
    {
        if(File.Exists(path))
        {
            
            if(!string.IsNullOrEmpty(File.ReadAllText(path))) // Cannot make already existing file into database file
            {
                throw new InvalidDatabasePathException(
                    $"Cannot create database file in path \"{path}\", because path is not empty."
                );
            }

            // File is empty
        }
        
        FileAttributes pathAttributes = File.GetAttributes(path);
        if((pathAttributes & FileAttributes.Directory) == FileAttributes.Directory) // Cannot make directory into database file
        {
            throw new InvalidDatabasePathException(
                $"Cannot create database file in path \"{path}\", because path is file."
            );
        }else
        {
            File.Create(path);
        }

            
        _path = path;
    }

}