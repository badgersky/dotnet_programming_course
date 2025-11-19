namespace Services;

public class UserInputService : IUserInputService
{
    public string ReadString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine()?.Trim();

            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }
            
            Console.WriteLine("This cannot be empty!");
        }
    }

    public int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = ReadString(prompt);

            if (int.TryParse(input, out var value) && value > 0)
            {
                return value;
            }

            Console.WriteLine("Enter a positive number!");
        }
    }

    public string ReadFormat(string prompt)
    {
        List<string> goodF = ["pdf", "epub", "mobi"];
        
        while (true)
        {
            var input = ReadString(prompt);

            if (goodF.Contains(input.ToLower()))
            {
                return input.ToLower();
            }
            
            Console.WriteLine("That's not a valid format!");
        }
    }

    public string ReadIsbn(string prompt)
    {
        while (true)
        {
            var input = ReadString(prompt);

            if (IsValidIsbn10(input) || IsValidIsbn13(input))
            {
                return input;
            }
            
            Console.WriteLine("Invalid ISBN!");
        }
    }

    public bool IsValidIsbn13(string isbn)
    {
        if (isbn.Length != 13)
            return false;

        if (isbn[12] < '0' || isbn[12] > '9')
            return false;
        
        var sum = 0;
        var index = 0;

        foreach (var c in isbn.Substring(0, 12))
        {
            if (c < '0' || c > '9')
                return false;

            var digit = c - '0';
            if (index % 2 == 0)
                sum += digit;
            else
                sum += digit * 3;
            index++;
        }

        var checksum = (10 - (sum % 10)) % 10;
        return checksum == (isbn[12] - '0');
    }

    public bool IsValidIsbn10(string isbn)
    {
        if (isbn.Length != 10)
            return false;

        var sum = 0;
        var multiplier = 1;

        foreach (var c in isbn.Substring(0, 9))
        {
            if (c < '0' || c > '9')
                return false;

            sum += multiplier * (c - '0');
            multiplier++;
        }

        var last = isbn[9];
        int checkDigit;

        if (last < '0' || last > '9')
        {
            return false;
        }
        if (last == 'X' || last == 'x')
        {
            checkDigit = 10;    
        }
        else
        {
            checkDigit = last - '0';
        }
        
        return sum % 11 == checkDigit;
    }
}