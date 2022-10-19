

using System.Text.RegularExpressions;


//string[] str = @"стен43а, 0 ок2355но двер344563ь 2 потол35656565653ок 356565656534 9 потол35656565653ок. 
//сколько? да! да было время. заказ и маразм.".Split(' ');

Console.WriteLine("Введите предложение и нажмите на Enter.");
string[] str = Console.ReadLine().Split();
do
{
    Console.WriteLine("Номер меню, введите цифру и нажмите на Enter");
    Console.WriteLine("1 MaxNumberDigitsInWord\n2 LongWord\n3 ReplacingWords\n4 ReplacingTheSign\n5 ReplacingTheSign2\n6 NoComma\n7 TheSameLetter\n8 Exit");
int i = int.Parse(Console.ReadLine());
switch (i)
{
    case 1:
       
            MaxNumberDigitsInWord(str);
            break;
    case 2:
            LongWord(str);
        break;
    case 3:
            ReplacingWords(str);
        break;
    case 4:
            ReplacingTheSign(str);
            break;
        case 5:
            ReplacingTheSign2(str);
            break;
        case 6:
            NoComma(str);
            break;
        case 7:
            TheSameLetter(str);
            break;
        case 8:
            Console.WriteLine("выход");
            return;
            
        default:
        Console.WriteLine("Ошибка");
        break;
    }
} while (true);


    

    static void MaxNumberDigitsInWord(string[] ArrayStr)
    {
        int Max = 0;
        int Index = 0;
        for (int i = 0; i < ArrayStr.Length; i++)
        {
            int currmax = 0;
            for (int k = 0; k < ArrayStr[i].Length; k++)
            {
                if (char.IsNumber(ArrayStr[i][k]))
                {
                    currmax++;

                }
            }
            if (currmax > Max)
            {
                Max = currmax;
                Index = i;
            }
        }
        
        Console.WriteLine("Наибольшее количество цифр в слове " + ArrayStr[Index]);
        Console.WriteLine("Нажмите Enter.");
        Console.ReadKey();
    }
    static void LongWord(string[] ArrayStr)
    {
        Stack<string> stack = new Stack<string>();
        string input3 = string.Join(" ", ArrayStr);
        string[] words = input3.Split(new string[] { " ", ".", "!", "?", "\r\n", "\t" }, StringSplitOptions.RemoveEmptyEntries);
        int maxlength = 0;
        for (int i = 0; i < words.Length; i++)
            if (maxlength < words[i].Length) maxlength = words[i].Length;
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length == maxlength && !stack.Contains(words[i])) stack.Push(words[i]);
        }
        string[] maxwords = stack.ToArray();
        int count;
        for (int i = 0; i < maxwords.Length; i++)
        {
            count = 0;
            foreach (string x in words)
            {
                if (x == maxwords[i]) ++count;
            }
            Console.WriteLine("Самое длинное слово: {0}\n   Число вхождений: {1}", maxwords[i], count, i); //выводим результаты
        }
        Console.WriteLine("Нажмите Enter.");
        Console.ReadKey();
    }



    static void ReplacingWords(string[] ArrayStr)
    {
        Console.WriteLine("Меняем цифыры на слова:");
        string input = string.Join(" ", ArrayStr);
        string[] digits = { "ноль", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
        for (int i = 0; i < 10; i++)
        {

            input = input.Replace(i.ToString(), digits[i]);

        }
        Console.WriteLine(input);
    Console.WriteLine("Нажмите Enter.");
    Console.ReadKey(); //нажмите любую клавишу для продолжения
    }
    static void ReplacingTheSign(string[] ArrayStr)
    {
        Console.WriteLine("Предложения заканчивающиеся на вопросительный знак:");
        string input2 = string.Join(" ", ArrayStr);
        var pattern = @"[^\.\?\!][\w ]+\?";
        var matches = Regex.Matches(input2, pattern);
        foreach (Match item in matches)
        {
            Console.WriteLine(item.ToString().TrimStart());
        }
        Console.WriteLine("Нажмите Enter.");
        Console.ReadKey();
    }
    static void ReplacingTheSign2(string[] ArrayStr)
    {
        Console.WriteLine("Предложения заканчивающиеся на восклицательный знак:");
        string input2 = string.Join(" ", ArrayStr);
        var pattern2 = @"[^\.\?\!][\w ]+\!";
        var matches2 = Regex.Matches(input2, pattern2);
        foreach (Match item in matches2)
        {
            Console.WriteLine(item.ToString().TrimStart());
        }
        Console.WriteLine("Нажмите Enter.");
        Console.ReadKey();
    }

    static void NoComma(string[] ArrayStr)
    {
        Console.WriteLine("Предложения, которые не содержат запятую:");
        string input3 = string.Join(" ", ArrayStr);
        string text = input3;
        while (text.Length > 0)
        {
            int startIndex = text.IndexOfAny(new char[] { '.', '!', '?' }) + 1;
            if (startIndex == 0) break;
            string sentence = text.Remove(startIndex, text.Length - startIndex);
            text = text.Remove(0, sentence.Length);
            if (sentence.IndexOf(',') == -1)
                Console.WriteLine(sentence);
        }
        Console.WriteLine("Нажмите Enter.");
        Console.ReadLine();
    }
    static void TheSameLetter(string[] ArrayStr)
    {
        Console.WriteLine("Слова начинающиеся и заканчивающиеся на одну и ту же букву:");
        string input3 = string.Join(" ", ArrayStr);
        foreach (Match match in Regex.Matches(input3, @"\b([A-zА-яЁё])[A-zА-яЁё]+?\1\b"))
        {
            if (match.Value.Length > 1)
                Console.WriteLine(match.Value);
        }
        Console.WriteLine("Нажмите Enter.");
        Console.ReadLine();
    }
