namespace Top._100.Liked.Test
{
    public class BacktrackingTests
    {
        private readonly Backtracking _backtracking;
        public BacktrackingTests()
        {
            _backtracking = new Backtracking();
        }

        [Theory]
        [InlineData("", new string[] { })]
        [InlineData("2", new string[] { "a", "b", "c" })]
        [InlineData("23", new string[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" })]
        [InlineData("234", new string[]
        {
                "adg", "adh", "adi", "aeg", "aeh", "aei", "afg", "afh", "afi",
                "bdg", "bdh", "bdi", "beg", "beh", "bei", "bfg", "bfh", "bfi",
                "cdg", "cdh", "cdi", "ceg", "ceh", "cei", "cfg", "cfh", "cfi"
        })]
        public void TestLetterCombinations(string input, string[] expected)
        {
            var result = _backtracking.LetterCombinations(input);
            Assert.Equal(expected, result);
        }
    }
}