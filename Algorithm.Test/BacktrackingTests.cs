namespace Algorithm.Test
{
    public class BacktrackingTests
    {
        private readonly Backtracking _backtracking;
        public BacktrackingTests()
        {
            _backtracking = new Backtracking();
        }

        [Theory]
        [InlineData(1)]
        public void TestKnightsTour_With_Input_1(int input)
        {
            var expected = new int[,] { { 1 } };
            var result = _backtracking.KnightsTourBacktracking(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void TestKnightsTour_Without_Solution(int input)
        {
            var expected = new int[input, input];
            var result = _backtracking.KnightsTourBacktracking(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5)]
        public void TestKnightsTour_With_Input_5(int input)
        {
            int[,] expected = new int[,]
            {
                {  1, 14, 19,  8, 25 },
                {  6,  9,  2, 13, 18 },
                { 15, 20,  7, 24,  3 },
                { 10,  5, 22, 17, 12 },
                { 21, 16, 11,  4, 23 }
            };

            var result = _backtracking.KnightsTourBacktracking(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(6)]
        public void TestKnightsTour_With_Input_6(int input)
        {
            int[,] expected = new int[,]
            {
                { 1, 22, 13, 30, 33, 36 },
                { 12, 29, 2, 35, 14, 31 },
                { 21, 8, 23, 32, 3, 34 },
                { 28, 11, 4, 17, 24, 15 },
                { 7, 20, 9, 26, 5, 18 },
                { 10, 27, 6, 19, 16, 25 }
            };

            var result = _backtracking.KnightsTourBacktracking(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(7)]
        public void TestKnightsTour_With_Input_7(int input)
        {
            int[,] expected = new int[,]
            {
                { 1, 38, 27, 42, 45, 20, 49 },
                { 28, 41, 2, 19, 48, 43, 46 },
                { 37, 26, 39, 44, 3, 18, 21 },
                { 40, 29, 36, 17, 22, 47, 4 },
                { 25, 10, 23, 32, 5, 16, 13 },
                { 30, 35, 8, 11, 14, 33, 6 },
                { 9, 24, 31, 34, 7, 12, 15 }
            };

            var result = _backtracking.KnightsTourBacktracking(input);
            Assert.Equal(expected, result);
        }
    }
}