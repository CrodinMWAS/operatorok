namespace operatorok
{
    internal class Program
    {
        static List<string> values = new List<string>();
        static void Main(string[] args)
        {
            readFile();
            //7
            while (true)
            {
                Console.Write("7. Feladat: Kérek egy kifejezést (pl.: 1 + 1): ");
                string ans = Console.ReadLine();
                if (ans.ToLower() == "vége")
                {
                    break;
                }
                else
                {
                    Console.WriteLine(checkOperators(ans));
                }
            }

            toFile();
        }

        static void readFile()
        {
            //1
            values = File.ReadAllLines("kifejezesek.txt").ToList();

            //2
            Console.WriteLine($"2. feladat: Kifejezések száma: {values.Count()}");

            //3
            Console.WriteLine($"3. feladat: Kifejezések maradékos osztással: {values.Count(x => x.Contains("mod"))}");

            //4
            Console.WriteLine($"4. feladat: {(values.Any(x => Convert.ToInt32(x.Split(" ")[0]) % 10 == 0 && Convert.ToInt32(x.Split(" ")[2]) % 10 == 0) ? "Van ilyen kifejezés!" : "Nincs ilyen kifejezés!")}");

            //5
            Console.WriteLine($"5. feladat: Statisztika \n mod -> {values.Count(x => x.Contains("mod"))} db \n / -> {values.Count(x => x.Contains("/"))} db \n div -> {values.Count(x => x.Contains("div"))} db \n - -> {values.Count(x => x.Contains("-"))} db \n * -> {values.Count(x => x.Contains("*"))} db \n + -> {values.Count(x => x.Contains("+"))} db");
        }

        //6
        static string checkOperators(string ans)
        {
            string ret = "";

            double firstNum = Convert.ToInt32(ans.Split(" ")[0]);
            string op = ans.Split(" ")[1];
            double secondNum = Convert.ToInt32(ans.Split(" ")[2]);

            if (secondNum != 0)
            {
                if (op == "mod")
                {
                    ret = $"{ans} = {firstNum % secondNum}";
                }
                else if (op == "/")
                {
                    ret = $"{ans} = {firstNum / secondNum}";
                }
                else if (op == "div")
                {
                    ret = $"{ans} = {Convert.ToInt32(firstNum / secondNum)}";
                }
                else if (op == "-")
                {
                    ret = $"{ans} = {firstNum - secondNum}";
                }
                else if (op == "*")
                {
                    ret = $"{ans} = {firstNum * secondNum}";
                }
                else if (op == "+")
                {
                    ret = $"{ans} = {firstNum + secondNum}";
                }
                else
                {
                    ret = $"{ans} = Hibás operátor!";
                }
            }
            else
            {
                ret = $"{ans} = Egyéb hiba!";
            }
            return ret;
        }

        static void toFile()
        {
            string fileName = "eredmenyek.txt";
            StreamWriter sw = new StreamWriter(fileName);
            values.Select(x => checkOperators(x)).ToList().ForEach(x => sw.WriteLine(x));
            sw.Close();
            Console.WriteLine($"8. feladat: {fileName}");
        }
    }
}