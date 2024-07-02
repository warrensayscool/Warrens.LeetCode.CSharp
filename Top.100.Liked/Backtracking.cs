using System.Collections.Generic;

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

            Backtrack(digits, phoneMap, 0, [], result);

            return result;
        }

        private void Backtrack(string digits, Dictionary<char, string> phoneMap, int index, List<char> currentCombination, IList<string> result)
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
                Backtrack(digits, phoneMap, index + 1, currentCombination, result);
                currentCombination.RemoveAt(currentCombination.Count - 1);
            }
        }
    }
}
