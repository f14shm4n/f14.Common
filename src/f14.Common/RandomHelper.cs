using System;

namespace f14
{
    /// <summary>
    /// Provides methods to generate randome values.
    /// </summary>
    public static class RandomHelper
    {
        private static readonly Random _rnd = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

        /// <summary>
        /// Returns the random integer number.
        /// </summary>
        /// <returns>Random integer number.</returns>
        public static int Next() => _rnd.Next();

        /// <summary>
        /// Returns the random non negative integer number which less than max.
        /// </summary>
        /// <param name="max">Max value.</param>
        /// <returns>Random integer number.</returns>
        public static int Next(int max) => _rnd.Next(max);

        /// <summary>
        /// Returns the random integer number in the specified range which less than max.
        /// </summary>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value.</param>
        /// <returns>Random integer number.</returns>
        public static int Next(int min, int max) => _rnd.Next(min, max);

        /// <summary>
        /// Returns the random integer number in the specified range with max.
        /// </summary>
        /// <param name="min">Min value.</param>
        /// <param name="max">Max value.</param>
        /// <returns>Random integer number.</returns>
        public static int NextWithMax(int min, int max) => _rnd.Next(min, max + 1);

        /// <summary>
        /// Returns the random double number which greater or equals 0,0 and less than 1,0.
        /// </summary>
        /// <returns>Random double number.</returns>
        public static double NextDouble() => _rnd.NextDouble();

        /// <summary>
        /// Generate random name-like string.
        /// </summary>
        /// <remarks>
        /// From: https://stackoverflow.com/a/49922533/3207043
        /// </remarks>
        /// <param name="len">Name length.</param>
        /// <returns></returns>
        public static string GenerateName(int len)
        {
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[Next(consonants.Length)].ToUpperInvariant();
            Name += vowels[Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[Next(consonants.Length)];
                b++;
                Name += vowels[Next(vowels.Length)];
                b++;
            }
            return Name;
        }
    }
}
