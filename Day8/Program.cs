namespace Day8
{
    internal class Program
    {
        static bool IsTreeVisible(char[,] trees, int i, int j)
        {
            int visible = 4;
            for (int k = i-1; k >= 0; k--)
            {
                if (trees[k, j] >= trees[i,j])
                {
                    visible--;
                    break;
                }
            }
            for (int k = i + 1; k < trees.GetLength(1); k++)
            {
                if (trees[k, j] >= trees[i, j])
                {
                    visible--;
                    break;
                }
            }
            for (int k = j - 1; k >= 0; k--)
            {
                if (trees[i, k] >= trees[i, j])
                {
                    visible--;
                    break;
                }
            }
            for (int k = j + 1; k < trees.GetLength(0); k++)
            {
                if (trees[i, k] >= trees[i, j])
                {
                    visible--;
                    break;
                }
            }
            if (visible>0)
            {
                return true;
            }
            return false;
        }

        static int IsPlaceGood(char[,] trees, int i, int j)
        {
            int viewScore;
            int counter = 0;
            for (int k = i - 1; k >= 0; k--)
            {
                counter++;
                if (trees[k, j] >= trees[i, j])
                {
                    break;
                }
            }
            viewScore=counter;
            counter = 0;
            for (int k = i + 1; k < trees.GetLength(1); k++)
            {
                counter++;
                if (trees[k, j] >= trees[i, j])
                {
                    break;
                }
            }
            viewScore *= counter;
            counter = 0;
            for (int k = j - 1; k >= 0; k--)
            {
                counter++;
                if (trees[i, k] >= trees[i, j])
                {
                    break;
                }
            }
            viewScore *= counter;
            counter = 0;
            for (int k = j + 1; k < trees.GetLength(0); k++)
            {
                counter++;
                if (trees[i, k] >= trees[i, j])
                {
                    break;
                }
            }
            viewScore *= counter;
            return viewScore;
        }
        static void Main(string[] args)
        {
            string file = "trees.txt";
            StreamReader sr = new StreamReader($@"Data\{file}");

            List<string> strings = new List<string>();
            while(!sr.EndOfStream)
            {
                strings.Add(sr.ReadLine());
            }
            sr.Close();

            char[,] trees = new char[strings.Count, strings[0].Length];
            for (int j = 0; j < strings.Count; j++)
            {
                for (int i = 0; i < strings[j].Length; i++)
                {
                    trees[j,i] = strings[j][i];
                }
            }
            //PART 1
            int sum = (strings.Count*2)+((strings[0].Length-2)*2);

            for (int i = 1; i < trees.GetLength(1)-1; i++)
            {
                for (int j = 1; j < trees.GetLength(0)-1; j++)
                {
                    if(IsTreeVisible(trees, i, j))
                    {
                        sum++;
                    }
                }
            }
            Console.WriteLine("PART 1");
            Console.WriteLine(sum);
            //PART 2

            int max = 0;
            for (int i = 1; i < trees.GetLength(1) - 1; i++)
            {
                for (int j = 1; j < trees.GetLength(0) - 1; j++)
                {
                    int scoreview = IsPlaceGood(trees, i, j);
                    if (scoreview>max)
                    {
                        max=scoreview;
                    }
                }
            }
            Console.WriteLine("PART 2");
            Console.WriteLine(max);
        }
    }
}