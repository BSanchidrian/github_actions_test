using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Benchmark
{
    public class DictionaryVsHashset
    {
        private readonly Dictionary<string, string> dictionary = new Dictionary<string, string>();
        private readonly HashSet<string> hashSet = new HashSet<string>();

        [Params(100, 10000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            this.dictionary.Clear();
            for (int i = 0; i < this.N; i++)
            {
                this.dictionary.Add(i.ToString(), i.ToString());
                this.hashSet.Add(i.ToString());
            }
        }

        [Benchmark]
        public void DictionaryAddMany()
        {
            var index = this.N / 2 - 7;
            _ = this.dictionary[index.ToString()];
        }

        [Benchmark]
        public void HashSet_ElementAt()
        {
            var index = this.N / 2 - 7;
            _ = this.hashSet.ElementAt(index);
        }

        [Benchmark]
        public void HashSet_FirstOrDefault()
        {
            var index = this.N / 2 - 7;
            _ = this.hashSet.FirstOrDefault(x => x == index.ToString());
        }

        [Benchmark]
        public void HashSet_Contains()
        {
            var index = this.N / 2 - 7;
            _ = this.hashSet.TryGetValue(index.ToString(), out _);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<DictionaryVsHashset>();
        }

    }
}