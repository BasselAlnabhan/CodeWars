using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Linq;

namespace CodeWarsExcecises
{
    public static class Programm
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Add the method you want here!");
            _ = Console.ReadKey();
        }

      

        public static bool ValidParentheses(string input)
        {
            int c = 0;
            return !input.Select(x => c += x == '(' ? 1 : x == ')' ? -1 : 0).Any(i => i < 0) && c == 0;
        }
        public static Dictionary<string, List<int>> GetPeaks(int[] arr)
        {
            arr.ToList().ForEach(s => Console.Write(" " + s));
            Console.WriteLine();
            var result = new Dictionary<string, List<int>>
            {
                { "Pos", new List<int>() },
                { "Peaks", new List<int>() }
            };
            if (arr.Length > 2)
            {
                for (int i = 1; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i - 1])
                    {
                        if (arr[i] > arr[i + 1])
                        {
                            result["Pos"].Add(i);
                            result["Peaks"].Add(arr[i]);
                        }
                        else if (arr[i] == arr[i + 1])
                        {
                            var plateaus = i;
                            for (int j = i + 1; j < arr.Length - 1; j++)
                            {
                                if (arr[j] > arr[j + 1])
                                {
                                    result["Pos"].Add(plateaus);
                                    result["Peaks"].Add(arr[plateaus]);
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        public static string Rot13(string input)
        {
            var uppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var lowers = "abcdefghijklmnopqrstuvwxyz";
            var result = "";
            input.ToList().ForEach(x =>
            {
                if (char.IsLetter(x))
                {
                    var used = char.IsLower(x) ? lowers : uppers;
                    var c = (used.IndexOf(x) + 13) % used.Length;
                    result += used[c];
                }
                else result += x;
            });
            return result;
        }

        public static int Multiples(int value)
        {
            return Enumerable.Range(0, value).Where(n => ((n % 3 == 0) || (n % 5 == 0))).Sum();
        }

        public static bool IsPrime(int value)
        {
            if (value < 1 || value % 2 == 0) return false;
            if (value == 2) return true;

            var boundary = (int)Math.Round(Math.Sqrt(value));

            for (var i = 3; i < boundary; i += 2)
            {
                if (value % i == 0) return false;
            }
            return true;
        }

        public static string ToJadenCase(this string phrase)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(phrase.ToLower());
        }

        public static bool XO(string input)
        {
            return input.Count(e => char.ToLower(e) == 'x') == input.Count(f => char.ToLower(f) == 'o');
        }

        public static string PigIt(string str)
        {
            var result = new List<string>();
            var newString = str.Split(" ");
            foreach (var word in newString)
            {
                if (word.Length > 1)
                {
                    var newWord = string.Join("", word.Skip(1)) + word[0] + "ay";
                    result.Add(newWord);
                }
                else
                {
                    result.Add(word);
                }
            }
            return string.Join(" ", result);


            //return Regex.Replace(str, @"((\S)(\S+))", "$3$2ay");
        }

        public static int DuplicateCount(string str)
        {
            return str.ToLower().GroupBy(c => c).Where(g => g.Count() > 1).Count();
        }

        public static int Find(int[] integers)
        {
            return integers.GroupBy(x => x % 2, x => x)
                  .OrderBy(x => x.Count())
                  .First().First();
            // Another solution
            // (integers.Where(x => x % 2 == 0).Count() > integers.Where(y => y % 2 != 0).Count()) ? integers.Where(x => x % 2 == 1).First() : integers.Where(x => x % 2 == 0).First();
        }

        public static long digPow(int n, int p)
        {
            double res = 0;
            int[] digits = n.ToString().Select(q => int.Parse(new string(q, 1))).ToArray();
            foreach (var d in digits)
            {
                res += Math.Pow(d, p);
                p++;
            }
            if (res % n == 0) return Convert.ToInt32(res / n);
            return -1;

            //var sum = Convert.ToInt64(n.ToString().Select(s => Math.Pow(int.Parse(s.ToString()), p++)).Sum());
            //return sum % n == 0 ? sum / n : -1;
        }

        public static int FibonacciSeries(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return FibonacciSeries(n - 1) + FibonacciSeries(n - 2);
        }

        public static string ToCamelCase(string str)
        {
            return Regex.Replace(str, @"[_-](\w)", m => m.Groups[1].Value.ToUpper());
        }

        public static string Likes(string[] names)
        {
            switch (names.Length)
            {
                case 0: return "no one likes this";
                case 1: return $"{names[0]} likes this";
                case 2: return $"{names[0]} and {names[1]} like this";
                case 3: return $"{names[0]}, {names[1]} and {names[2]} like this";
                default: return $"{names[0]}, {names[1]} and {names.Length - 2} others like this";
            }
        }

        public static int MaxSequence(int[] arr)
        {
            int max = 0, res = 0, sum = 0;
            foreach (var item in arr)
            {
                sum += item;
                max = sum > max ? max : sum;
                res = res > sum - max ? res : sum - max;
            }
            return res;
        }

        public static bool IsPangram(string str) => str.ToLower()
                                                   .Where(Char.IsLetter)
                                                   .Distinct()
                                                  .Count() == 26;

        public static string AlphabetPosition(string text) => string.Join(" "
            , text
            .ToLower()
            .Where(char.IsLetter)
            .Select(x => x - ('a' - 1)));

        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable) =>
            iterable.Where((x, i) => i == 0 || !Equals(x, iterable.ElementAt(i - 1)));

        public static double[] Tribonacci(double[] signature, int n)
        {
            if (n == 0) return new double[] { };

            var tribonacci = signature.ToList();
            for (int i = 3; i < n; i++)
                tribonacci.Add(tribonacci[i - 3] + tribonacci[i - 2] + tribonacci[i - 1]);
            return tribonacci.Take(n).ToArray();

        }

        public static String LongestConsec(string[] strarr, int k) => strarr.Length == 0 || strarr.Length < k || k <= 0 ? ""
             : Enumerable.Range(0, strarr.Length - k + 1)
                         .Select(x => string.Join("", strarr.Skip(x).Take(k)))
                         .OrderByDescending(x => x.Length)
                         .First();

        public static int CountSmileys(string[] smileys) => (smileys.Length > 0)
                                                                    ? new Regex(@"[:;][-~]?[)D]").Matches(string.Join(" ", smileys)).Count
                                                                    : 0;

        public static List<string> SinglePermutations(this string s) =>
            s.AsEnumerable().Permutate().Select(a => new string(a)).Distinct().ToList();

        public static IEnumerable<T[]> Permutate<T>(this IEnumerable<T> source)
        {
            return permutate(source, Enumerable.Empty<T>());
            IEnumerable<T[]> permutate(IEnumerable<T> reminder, IEnumerable<T> prefix) =>
                !reminder.Any() ? new[] { prefix.ToArray() } :
                reminder.SelectMany((c, i) => permutate(
                    reminder.Take(i).Concat(reminder.Skip(i + 1)).ToArray(),
                    prefix.Append(c)));
        }

        public static int IsInteresting(int number, List<int> awesomePhrases)
        {
            /*
                "7777...8?!??!", exclaimed Bob, "I missed it again! Argh!" Every time there's an interesting number coming up, he notices and then promptly forgets. Who doesn't like catching those one-off interesting mileage numbers?

                Let's make it so Bob never misses another interesting number. We've hacked into his car's computer, and we have a box hooked up that reads mileage numbers. We've got a box glued to his dash that lights up yellow or green depending on whether it receives a 1 or a 2 (respectively).

                It's up to you, intrepid warrior, to glue the parts together. Write the function that parses the mileage number input, and returns a 2 if the number is "interesting" (see below), a 1 if an interesting number occurs within the next two miles, or a 0 if the number is not interesting.

                Note: In Haskell, we use No, Almost and Yes instead of 0, 1 and 2.

                "Interesting" Numbers
                Interesting numbers are 3-or-more digit numbers that meet one or more of the following criteria:

                Any digit followed by all zeros: 100, 90000
                Every digit is the same number: 1111
                The digits are sequential, incementing†: 1234
                The digits are sequential, decrementing‡: 4321
                The digits are a palindrome: 1221 or 73837
                The digits match one of the values in the awesomePhrases array
                † For incrementing sequences, 0 should come after 9, and not before 1, as in 7890.
                ‡ For decrementing sequences, 0 should come after 1, and not before 9, as in 3210.
             */
            const int YES = 2, ALMOST = 1, NO = 0;

            if (number < 99) return NO;
            if (isMatchRegex() || awesomePhrases.Contains(number)) return YES;
            if (isAwesome(number)) return ALMOST;
            return NO;

            bool isAwesome(int number)
            {
                if (awesomePhrases.Contains(number)) return false;
                if ((awesomePhrases.FirstOrDefault(x => Math.Abs(number - x) <= 2) > 0)) return true;
                for (var i = number - 2; i <= number + 2; i++)
                {
                    if (Math.Abs(reverseNumber(i) - number) <= 2 && i != number) return true;
                }
                return false;
            }
            bool isMatchRegex() => Regex.IsMatch($"{number}", @"^(?:0(?=1|$))?(?:1(?=2|$))?(?:2(?=3|$))?(?:3(?=4|$))?(?:4(?=5|$))?(?:5(?=6|$))?(?:6(?=7|$))?(?:7(?=8|$))?(?:8(?=9|$))?9?$")
                || Regex.IsMatch($"{number}", @"^(?:9(?=8|$))?(?:8(?=7|$))?(?:7(?=6|$))?(?:6(?=5|$))?(?:5(?=4|$))?(?:4(?=3|$))?(?:3(?=2|$))?(?:2(?=1|$))?(?:1(?=0|$))?0?$")
                || Regex.IsMatch($"{number}", @"^(\d)((\d)\d+\1)\1+$")
                || Regex.IsMatch($"{number}", @"^(\d)\1{2,}$")
                || Regex.IsMatch($"{number}", @"^(\d0{2,})$");
            static int reverseNumber(int number)
            {
                string numberAsString = $"{number}";
                int reversedNumber = Int32.Parse(string.Join("", numberAsString.Reverse()));
                return reversedNumber;
            }
        }

       
        public static int? chooseBestSum(int t, int k, List<int> ls)
        {
            /*John and Mary want to travel between a few towns A, B, C ... Mary has on a sheet of paper a list of distances between these towns.
               ls = [50, 55, 57, 58, 60]. John is tired of driving and he says to Mary that he doesn't want to drive more than t = 174 miles and he will visit only 3 towns.

                Which distances, hence which towns, they will choose so that the sum of the distances is the biggest possible to please Mary and John?

                Example:
                With list ls and 3 towns to visit they can make a choice between: [50,55,57],[50,55,58],[50,55,60],[50,57,58],[50,57,60],[50,58,60],[55,57,58],[55,57,60],[55,58,60],[57,58,60].

                The sums of distances are then: 162, 163, 165, 165, 167, 168, 170, 172, 173, 175.

                The biggest possible sum taking a limit of 174 into account is then 173 and the distances of the 3 corresponding towns is [55, 58, 60].

                The function chooseBestSum (or choose_best_sum or ... depending on the language) will take as parameters t (maximum sum of distances, integer >= 0), k (number of towns to visit, k >= 1) and ls (list of distances, all distances are positive or null integers and this list has at least one element). The function returns the "best" sum ie the biggest possible sum of k distances less than or equal to the given limit t, if that sum exists, or otherwise nil, null, None, Nothing, depending on the language.

                With C++, C, Rust, Swift, Go, Kotlin, Dart return -1.

                Examples:
                ts = [50, 55, 56, 57, 58] choose_best_sum(163, 3, ts) -> 163

                xs = [50] choose_best_sum(163, 3, xs) -> nil (or null or ... or -1 (C++, C, Rust, Swift, Go)

                ys = [91, 74, 73, 85, 73, 81, 87] choose_best_sum(230, 3, ys) -> 228 */

            throw new NotImplementedException();
        }


        public static string WhoIsNext(string[] names, long n)
        {
            var length = names.Length;
            return n <= length ? names[n - 1] : WhoIsNext(names, (n - length + 1) / 2);
        }


        public static string GenerateRandomString(Random rnd, int length, bool JustAlphabet)
        {
            string allowedCharset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            var usedChars = JustAlphabet ? allowedCharset.Length : allowedCharset.Length - 9;
            string generatedString = "";
            for (int i = 0; i < length; i++)
            {
                generatedString += (i == 0) ? allowedCharset[rnd.Next(26, usedChars)] : allowedCharset[rnd.Next(0, 26)];
            }

            return generatedString;
        }
        public static string Extract(int[] args)
        {
            ///*
            // * A format for expressing an ordered list of integers is to use a comma separated list of either:
            //    * individual integers
            //    * or a range of integers denoted by the starting integer separated from the end integer in the range by a dash, '-'.
            //    The range includes all integers in the interval including both endpoints. It is not considered a range unless it spans
            //    at least 3 numbers. For example "12,13,15-17"
            //    Complete the solution so that it takes a list of integers in increasing order 
            //    and returns a correctly formatted string in the range format.
            // */
            return "";
        }

        public static string StripComments(string text, string[] commentSymbols)
        {
            //Complete the solution so that it strips all text that follows any of 
            // a set of comment markers passed in. Any whitespace at the end of 
            //the line should also be stripped out.
            //Example:

            // Given an input string of:

            //apples, pears # and bananas
            //grapes
            //bananas!apples
            //The output expected would be:

            //apples, pears
            //grapes
            //bananas
            //Console.WriteLine($"The whole string: {text}");
            string[] lines = text.Split(new[] { "\n" }, StringSplitOptions.None);
            lines = lines.Select(x => x.Split(commentSymbols, StringSplitOptions.None).First().TrimEnd()).ToArray();
            return string.Join("\n", lines);


            //var pattern = $"[ ]*([{string.Concat(commentSymbols)}].*)?$";
            //return string.Join("\n", text.Split('\n').Select(x => Regex.Replace(x, pattern, "")));
        }
    }

    public class PagnationHelper<T>
    {
        private IList<T> collection;
        private int itemsPerPage;

        public PagnationHelper(IList<T> collection, int itemsPerPage)
        {
            this.collection = collection;
            this.itemsPerPage = itemsPerPage;
        }
        public int ItemCount => collection.Count;
        public int PageCount => (int)Math.Ceiling((decimal)collection.Count / itemsPerPage);

        public int ItemsPerPage { get => itemsPerPage; set => itemsPerPage = value; }

        public int PageItemCount(int pageIndex) =>
            pageIndex >= PageCount || pageIndex < 0
                ? -1
                : collection.Count - pageIndex * itemsPerPage > itemsPerPage
                    ? itemsPerPage
                    : collection.Count - pageIndex * itemsPerPage;

        public int PageIndex(int itemIndex) => itemIndex >= ItemCount || itemIndex < 0 ? -1 : (int)Math.Floor((decimal)itemIndex / itemsPerPage);
    }
}
