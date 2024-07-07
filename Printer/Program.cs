
namespace Printer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Algorithm.Backtracking backtracking = new();
            Top._100.Liked.Backtracking top100LikedBacktracking = new();

            var result = top100LikedBacktracking.Permute([2, 3, 6, 7]);

            PrintStringListList(result);
        }

        private static void PrintStringListList(IList<IList<int>> result)
        {
            foreach (var item in result)
            {
                Console.WriteLine(String.Join(",", item));
            }
        }

        public static void PrintStringList(IList<string> list)
        {
            foreach (string str in list)
            {
                Console.WriteLine(str);
            }
        }
    }
}
