using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Engine.Repositories
{
    internal abstract class RepositoryBase<T>
    {
        internal readonly Lazy<IReadOnlyList<T>> SourceData;

        protected RepositoryBase(string sourceFile)
        {
            SourceData = new(() => LoadDataFromSource(sourceFile));
        }

        private IReadOnlyList<T> LoadDataFromSource(string sourceFile)
        {
            if (!File.Exists(sourceFile))
            {
                throw new Exception($"File not found {sourceFile}");
            }

            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            using var file = File.OpenRead(sourceFile);
            return JsonSerializer.Deserialize<List<T>>(file, options)!;
        }
    }
}