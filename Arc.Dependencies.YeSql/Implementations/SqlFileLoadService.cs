
using YeSql.Net;

namespace Arc.Dependencies.YeSql.Implementations;

public sealed class SqlFileLoadService
{
    public string Load(
        string fullFilePath,
        string tag
    )
    {
        var yeSqlLoader =
            new YeSqlLoader();

        var sqlStatements =
            yeSqlLoader
                .LoadFromFiles(
                    fullFilePath
                );

        var sqlCode =
            sqlStatements[tag];

        return
            sqlCode;
    }
}