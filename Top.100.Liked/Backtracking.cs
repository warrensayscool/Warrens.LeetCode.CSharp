using System;
using System.Collections.Generic;
using System.Linq;

namespace Top._100.Liked
{
    //https://leetcode.com/studyplan/top-100-liked/
    public class Backtracking
    {
        /// <summary>
        /// https://leetcode.com/problems/letter-combinations-of-a-phone-number/description/?envType=study-plan-v2&envId=top-100-liked
        /// 17. Letter Combinations of a Phone Number
        /// </summary>
        /// <param name="digits">
        ///     0 <= digits.length <= 4
        ///     digits[i] is a digit in the range['2', '9']
        /// </param>
        /// <returns></returns>
        public IList<string> LetterCombinations(string digits)
        {
            if (string.IsNullOrEmpty(digits))
            {
                return [];
            }

            var phoneMap = new Dictionary<char, string> {
                {'2', "abc"}, {'3', "def"}, {'4', "ghi"}, {'5', "jkl"},
                {'6', "mno"}, {'7', "pqrs"}, {'8', "tuv"}, {'9', "wxyz"}};

            var result = new List<string>();

            LetterCombinationsBacktrack(digits, phoneMap, 0, [], result);

            return result;
        }

        private void LetterCombinationsBacktrack(string digits, Dictionary<char, string> phoneMap, int index, List<char> currentCombination, IList<string> result)
        {
            if (index == digits.Length)
            {
                result.Add(new string(currentCombination.ToArray()));
                return;
            }

            var possibleLetters = phoneMap[digits[index]];
            foreach (var letter in possibleLetters)
            {
                currentCombination.Add(letter);
                LetterCombinationsBacktrack(digits, phoneMap, index + 1, currentCombination, result);
                currentCombination.RemoveAt(currentCombination.Count - 1);
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/generate-parentheses/description/?envType=study-plan-v2&envId=top-100-liked
        /// 22. Generate Parentheses
        /// </summary>
        /// <param name="n">1 <= n <= 8</param>
        /// <returns></returns>
        public IList<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();
            char[] Parenthesis = ['(', ')'];
            string combination = "(";

            GenerateParenthesisBacktracking(n, Parenthesis, combination, 1, result);

            return result;
        }

        private bool GenerateParenthesisBacktracking(int n, char[] parenthesis, string combination, int openParenthesis, List<string> result)
        {
            if (combination.Length == n * 2)
            {
                if (openParenthesis == 0)
                {
                    result.Add(combination);
                }
                return openParenthesis == 0;
            }

            foreach (char c in parenthesis)
            {
                var newOpenParenthesis = openParenthesis;
                if (c == '(')
                {
                    newOpenParenthesis++;
                }
                else
                {
                    newOpenParenthesis--;
                }

                if (newOpenParenthesis >= 0 && newOpenParenthesis <= n)
                {
                    GenerateParenthesisBacktracking(n, parenthesis, combination + c, newOpenParenthesis, result);
                }
            }
            return false;
        }


        /// <summary>
        /// https://leetcode.com/problems/combination-sum/description/?envType=study-plan-v2&envId=top-100-liked
        /// 39. Combination Sum
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Array.Sort(candidates);
            CombinationSumBacktracking(candidates, target, result, [], 0);

            return result;

        }

        private void CombinationSumBacktracking(int[] candidates, int target, IList<IList<int>> result, List<int> combination, int start)
        {
            if (combination.Sum() >= target)
            {
                if (combination.Sum() == target)
                {
                    result.Add(new List<int>(combination));
                }
                return;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                combination.Add(candidates[i]);
                CombinationSumBacktracking(candidates, target, result, combination, i);
                combination.RemoveAt(combination.Count - 1);
            }
        }


        /// <summary>
        /// https://leetcode.com/problems/permutations/?envType=study-plan-v2&envId=top-100-liked
        /// 46. Permutations
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> result = [];

            PermuteBacktracking(result, nums, []);

            return result;
        }

        private void PermuteBacktracking(IList<IList<int>> result, int[] nums, IList<int> temp)
        {
            if (temp.Count == nums.Length)
            {
                result.Add(new List<int>(temp));
                return;
            }

            if (temp.Count > nums.Length)
            {
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (temp.Contains(nums[i]))
                {
                    continue;
                }
                temp.Add(nums[i]);
                PermuteBacktracking(result, nums, temp);
                temp.RemoveAt(temp.Count - 1);
            }
        }
    }
}
