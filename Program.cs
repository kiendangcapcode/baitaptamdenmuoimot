using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        while (true)
        {
            Console.WriteLine("\nChọn số bài tập (8, 9, 10) hoặc nhấn 'q' để thoát:");
            Console.WriteLine("8: ASCII và UTF-8");
            Console.WriteLine("9: Xử lý chuỗi");
            Console.WriteLine("10: Quản lý sinh viên");
            string mainChoice = Console.ReadLine();
            if (mainChoice == "q") break;

            switch (mainChoice)
            {
                case "8":
                    ShowMenuBai8();
                    break;
                case "9":
                    ShowMenuBai9();
                    break;
                case "10":
                    StudentInfo();
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    break;
            }
        }
    }

    static void ShowMenuBai8()
    {
        Console.WriteLine("Bài 8 - Bảng mã ASCII và UTF-8:");
        Console.WriteLine("a: Hiển thị bảng mã ASCII");
        Console.WriteLine("b: Hiển thị bảng mã UTF-8");
        Console.WriteLine("c: Phát tiếng beep khi nhấn phím space");
        Console.WriteLine("d: Đếm số lần xuất hiện của mỗi kí tự trong chuỗi");
        Console.Write("Chọn phần (a, b, c, d): ");
        switch (Console.ReadLine())
        {
            case "a":
                DisplayAscii();
                break;
            case "b":
                DisplayUtf8();
                break;
            case "c":
                BeepOnSpace();
                break;
            case "d":
                CountCharacters();
                break;
            default:
                Console.WriteLine("Lựa chọn không hợp lệ.");
                break;
        }
    }

    static void ShowMenuBai9()
    {
        Console.WriteLine("Bài 9 - Xử lý chuỗi:");
        Console.WriteLine("a: Đảo ngược chuỗi");
        Console.WriteLine("b: Đếm số lượng từ trong chuỗi");
        Console.Write("Chọn phần (a, b): ");
        switch (Console.ReadLine())
        {
            case "a":
                ReverseString();
                break;
            case "b":
                CountWords();
                break;
            default:
                Console.WriteLine("Lựa chọn không hợp lệ.");
                break;
        }
    }

    static void DisplayAscii()
    {
        Console.WriteLine("Bảng mã ASCII:");
        for (int i = 0; i < 128; i++)
        {
            Console.WriteLine($"{i} = {(char)i}");
        }
    }

    static void DisplayUtf8()
    {
        Console.WriteLine("Bảng mã UTF-8:");
        for (int i = 0; i <= 255; i++)
        {
            Console.WriteLine($"{i} = {(char)i}");
        }
    }

    static void BeepOnSpace()
    {
        Console.WriteLine("Nhấn phím space để phát tiếng beep, 'x' để thoát:");
        char key;
        do
        {
            key = Console.ReadKey(true).KeyChar;
            if (key == ' ') Console.Beep();
        } while (key != 'x');
    }

    static void CountCharacters()
    {
        Console.WriteLine("Nhập vào một chuỗi:");
        string input = Console.ReadLine();
        Dictionary<char, int> characterCounts = new Dictionary<char, int>();
        foreach (char c in input)
        {
            if (characterCounts.ContainsKey(c))
                characterCounts[c]++;
            else
                characterCounts[c] = 1;
        }

        foreach (var item in characterCounts)
        {
            Console.WriteLine($"Kí tự '{item.Key}' xuất hiện {item.Value} lần.");
        }
    }

    static void ReverseString()
    {
        Console.WriteLine("Nhập vào một chuỗi để đảo ngược:");
        string input = Console.ReadLine();
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        string reversed = new string(charArray);
        Console.WriteLine($"Chuỗi đảo ngược: {reversed}");
    }

    static void CountWords()
    {
        Console.WriteLine("Nhập vào một chuỗi để đếm số từ:");
        string input = Console.ReadLine();
        int count = input.Split(new char[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries).Length;
        Console.WriteLine($"Số lượng từ: {count}");
    }

    static void StudentInfo()
    {
        List<(string Name, double Score)> students = new List<(string, double)>();
        string name;
        double score, average = 0;

        while (true)
        {
            Console.WriteLine("Nhập tên sinh viên (hoặc nhấn 'q' để thoát và hiển thị kết quả):");
            name = Console.ReadLine();
            if (name == "q") break;

            Console.WriteLine("Nhập điểm của sinh viên:");
            if (!double.TryParse(Console.ReadLine(), out score))
            {
                Console.WriteLine("Điểm không hợp lệ. Nhập lại:");
                continue;
            }

            students.Add((name, score));
        }

        foreach (var student in students)
        {
            Console.WriteLine($"Tên: {student.Name}, Điểm: {student.Score}");
            average += student.Score;
        }

        if (students.Count > 0)
        {
            average /= students.Count;
            Console.WriteLine($"Điểm trung bình của lớp: {average:F2}");
        }
    }
}
