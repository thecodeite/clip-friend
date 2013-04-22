using System.Collections.Generic;
using System.Linq;

namespace ClipChanger
{
    public static class Rot18
    {
        private static readonly char[] _source = ("abcdefghijklmnopqrstuvwxyz" +
                                   "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                                   "0123456789").ToCharArray();

        private static Dictionary<char, char> _map = _source.Select((x, i) => new {x, i})
                                                         .ToDictionary(y => y.x,
                                                                       y =>
                                                                       _source[(y.i + (_source.Length/2))%_source.Length]);

        public static string Convert(string input)
        {
            return new string(input.Select(Convert).ToArray());
        }

        public static char Convert(char input)
        {
            if (_map.ContainsKey(input))
            {
                return _map[input];
            }

            return input;
        }
    }
}