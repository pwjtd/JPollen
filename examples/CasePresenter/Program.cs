namespace CasePresenter;

public class CasePresenter
{
    public static void Main(string[] args)
    {
        int item = 0;
        ConsoleKeyInfo key;
        var cases = RegisterCases();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("========== MENU ==========");

            for (int i = 0; i < cases.Count; i++)
            {
                var caseItem = cases.ElementAt(i);
                Console.WriteLine((item == i ? "--> " : "    ") + $"{i+1}. {caseItem.Title}");
            }

            Console.WriteLine((item == cases.Count ? "--> " : "    ") + $"{cases.Count + 1}. Exit");
            
            key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.DownArrow)
                item = (item + 1) % (cases.Count + 1);
            else if (key.Key == ConsoleKey.UpArrow)
                item = (item - 1 + cases.Count) % (cases.Count + 1);
            else if (key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                
                if (item == cases.Count)
                {
                    Console.WriteLine("Exiting program");
                    return;
                }

                var caseItem = cases.ElementAt(item);
                caseItem.Run();
                
                Console.ReadKey();
            }
        }
    }

    private static List<CaseBase> RegisterCases()
    {
        var cases = new List<CaseBase>
        {
            new FoldJsonToSchemeCase(),
            new FoldJsonToSchemeCase(),
        };
        return cases;
    }
}