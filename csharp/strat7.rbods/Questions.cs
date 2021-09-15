using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;

namespace strat7.rbods {
    public class Questions {

        /** Constants */
        private const double kilometersToMiles = 0.625;

        /// <summary>
        /// Given an enumerable of strings, attempt to parse each string and if
        /// it is an integer, add it to the returned enumerable.
        ///
        /// For example:
        ///
        /// ExtractNumbers(new List<string> { "123", "hello", "234" });
        ///
        /// ; would return:
        ///
        /// {
        ///   123,
        ///   234
        /// }
        /// </summary>
        /// <param name="source">An enumerable containing words</param>
        /// <returns></returns>
        public IEnumerable<int> ExtractNumbers(IEnumerable<string> source) {
            List<int> numbers = new List<int>();
            foreach( var item in source) {
                if(int.TryParse(item, out int value)) {
                    numbers.Add(value);
                }
            }
            return numbers;
        }

        /// <summary>
        /// Given two enumerables of strings, find the longest common word.
        ///
        /// For example:
        ///
        /// LongestCommonWord(
        ///     new List<string> {
        ///         "love",
        ///         "wandering",
        ///         "goofy",
        ///         "sweet",
        ///         "mean",
        ///         "show",
        ///         "fade",
        ///         "scissors",
        ///         "shoes",
        ///         "gainful",
        ///         "wind",
        ///         "warn"
        ///     },
        ///     new List<string> {
        ///         "wacky",
        ///         "fabulous",
        ///         "arm",
        ///         "rabbit",
        ///         "force",
        ///         "wandering",
        ///         "scissors",
        ///         "fair",
        ///         "homely",
        ///         "wiggly",
        ///         "thankful",
        ///         "ear"
        ///     }
        /// );
        ///
        /// ; would return "wandering" as the longest common word.
        /// </summary>
        /// <param name="first">First list of words</param>
        /// <param name="second">Second list of words</param>
        /// <returns></returns>
        public string LongestCommonWord(IEnumerable<string> first, IEnumerable<string> second) {
            int wordLength = 0;
            string word = "";
            foreach(var x in first) {
                wordLength = (x.Length > wordLength) ? x.Length : wordLength;
                foreach(var y in second) {
                    if(y.Length > wordLength) {
                        wordLength = y.Length;
                    }
                    if(y.Length == wordLength && x == y) {
                        word = y;
                    }
                }
            }
            return word;
        }

        /// <summary>
        /// Write a method that converts kilometers to miles, given that there are
        /// 1.6 kilometers per mile.
        ///
        /// For example:
        ///
        /// DistanceInMiles(16.00);
        ///
        /// ; would return 10.00;
        /// </summary>
        /// <param name="km">distance in kilometers</param>
        /// <returns></returns>
        
        public double DistanceInMiles(double km) {
            return Math.Round(km*kilometersToMiles, 2);
        }

        /// <summary>
        /// Write a method that converts miles to kilometers, give that there are
        /// 1.6 kilometers per mile.
        ///
        /// For example:
        ///
        /// DistanceInKm(10.00);
        ///
        /// ; would return 16.00;
        /// </summary>
        /// <param name="miles">distance in miles</param>
        /// <returns></returns>
        public double DistanceInKm(double miles) {
            return Math.Round(miles/kilometersToMiles, 2);
        }

        /// <summary>
        /// Write a method that returns true if the word is a palindrome, false if
        /// it is not.
        ///
        /// For example:
        ///
        /// IsPalindrome("bolton");
        ///
        /// ; would return false, and:
        ///
        /// IsPalindrome("Anna");
        ///
        /// ; would return true.
        ///
        /// Also complete the related test case for this method.
        /// </summary>
        /// <param name="word">The word to check</param>
        /// <returns></returns>
        public bool IsPalindrome(string word) {
            char[] array = word.ToCharArray();
            Array.Reverse(array);
            return String.Concat(array) == word;
        }

        /// <summary>
        /// Write a method that takes an enumerable list of objects and shuffles
        /// them into a different order.
        ///
        /// For example:
        ///
        /// Shuffle(new List<string>{ "one", "two" });
        ///
        /// ; would return:
        ///
        /// {
        ///   "two",
        ///   "one"
        /// }
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IEnumerable<object> Shuffle(IEnumerable<object> source) {
            // Uses GUID for randomness
            return (from item in source orderby Guid.NewGuid() ascending select item).ToList();
        }

        /// <summary>
        /// Write a method that sorts an array of integers into ascending
        /// order - do not use any built in sorting mechanisms or frameworks.
        ///
        /// Complete the test for this method.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public int[] Sort(int[] source) {
            return (from item in source orderby item descending select item).ToArray<int>();
        }

        /// <summary>
        /// Each new term in the Fibonacci sequence is generated by adding the
        /// previous two terms. By starting with 1 and 2, the first 10 terms will be:
        ///
        /// 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
        ///
        /// By considering the terms in the Fibonacci sequence whose values do
        /// not exceed four million, find the sum of the even-valued terms.
        /// </summary>
        /// <returns></returns>
        public int FibonacciSum() {
            const int valueToNotExceed = 4000000;
            List<int> fibonacci = new List<int>{ 0, 1 };
            List<int> fibonacciEvenNumbers = new List<int>();
            int firstNumber = 0, secondNumber = 1;
            for (int i = 2; (firstNumber + secondNumber) < valueToNotExceed; i++)
            {
                firstNumber = fibonacci[i-2];
                secondNumber = fibonacci[i-1];
                fibonacci.Add(firstNumber + secondNumber);
                if(IsEven(fibonacci[i])) {
                    fibonacciEvenNumbers.Add(fibonacci[i]);
                }
            }
            return fibonacciEvenNumbers.Sum();
        }

        private bool IsEven(int item) {
            return item % 2 == 0;
        }

        /// <summary>
        /// Generate a list of integers from 1 to 100.
        ///
        /// This method is currently broken, fix it so that the tests pass.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GenerateList() {
            var ret = new List<int>();
            var numThreads = 1;

            Thread[] threads = new Thread[numThreads];

            for (var i = 0; i < numThreads; i++) {
                
                threads[i] = new Thread(() => {
                    var complete = false;
                    
                    while (!complete) {
                        var next = ret.Count + 1;
                        Thread.Sleep(new Random().Next(1, 100));
                        Console.WriteLine(next);
                        if (next <= 100) {
                            ret.Add(next);
                        }

                        if (ret.Count >= 100) {
                            complete = true;
                        }
                    }
                });
                threads[i].Start();
            }

            for (var i = 0; i < numThreads; i++) {
                threads[i].Join();
            }

            return ret;
        }
    }
}
