using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One
{
    static class Extensions
    {
        public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }

        //public Dictionary<string, int> GetWordFrequency(params string[] files)
        //{
        //    return files.SelectMany(x => File.ReadLines(x))
        //                .SelectMany(x => x.Split())
        //                .Where(x => x != string.Empty)
        //                .GroupBy(x => x)
        //                .ToDictionary(x => x.Key, x => x.Count());
        //}
    }


}
