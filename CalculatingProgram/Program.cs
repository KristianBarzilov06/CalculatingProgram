namespace CalculatingProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> list = Console.ReadLine().Split(' ').Select(l => double.Parse(l)).ToList();

            var avg = list.Average();
            Console.WriteLine("Avarage is: " + avg);
            
            list.Sort();
            double median = 0;
            if (list.Count % 2 == 1)
            {
                median = list[(list.Count - 1) / 2];
            }
            if (list.Count % 2 == 0)
            {
                var index = list.Count / 2;
                median = (list[index] + list[index - 1]) / 2.0;
            }
            Console.WriteLine("Median is: " + median);

            var mode = list.GroupBy(x => x)
            .OrderByDescending(x => x.Count()).ThenBy(x => x.Key)
            .ThenBy(x => (int)x.Key)
            .FirstOrDefault();
            

            Console.WriteLine("Mode is " + mode);
        }
    }
}