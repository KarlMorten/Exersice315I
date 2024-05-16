namespace Exersice315I
{
    internal class Program
    {
        static readonly Random Random = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("Hei! Dette programmet genererer passord.");
            Console.WriteLine("Kor mange teikn skal passordet bestå av?");
            string theLength = Console.ReadLine();
            int passwordLength = Convert.ToInt32(theLength);

            Console.WriteLine("Er det eit krav om at passordet skal innehalde siffer (d), store bokstavar (L), " +
                              "spesialteikn (s) eller små bokstavar (l)? Dersom du for eksempel vil ha to siffer " +
                              "og tre spesialteikn skriv du 'ddsss'. Dersom du vil ha to store bokstavar og eitt " +
                              "spesialteikn skriv du 'LLs'. Dersom det ikkje er noko krav skriv du berre 'l'.");
            string shouldContain = Console.ReadLine();

            while (!IsValid(shouldContain, passwordLength))
            {
                Console.WriteLine("Det du skreiv vart ikkje godkjent. Skriv inn om du vil ha siffer (d), store " +
                                  "bokstavar (L), spesialteikn (s) eller små bokstavar (l) ein gong til.");
                shouldContain = Console.ReadLine();
            }

            int[] charsInUse = passwordShouldContain(passwordLength,shouldContain);
            string theFinalPassword = generatePassword(charsInUse,passwordLength);
            Console.WriteLine("");
            Console.WriteLine($"Ditt passord: {theFinalPassword}");
        }

        static bool IsValid(string value, int theLength)
        {
            if (value.Length > theLength)
            {
                return false;
            }
            foreach (char x in value)
            {
                if (x != 'l' && x != 'L' && x != 'd' && x != 's')
                {
                    return false;
                }
            }
            return true;
        }

        static int[] passwordShouldContain(int passwordLength, string characters)
        {
            int[] container = { 0, 0, 0, 0 };
            foreach (char x in characters)
            {
                if (x == 'L') container[1]++;
                if (x == 'd') container[2]++;
                if (x == 's') container[3]++;
            }

            container[0] = (passwordLength - container[1] - container[2] - container[3]);
            return container;
        }

        static char generateNewCharacter(int whatKind)
        {
            string[] allCharacters =
                { "abcdefghijklmnopqrstuvwxyz", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "0123456789", "!#¤£¤$%&/()=?[}{]" };
            int n = Random.Next(0, allCharacters[whatKind].Length);
            return allCharacters[whatKind][n];
        }
        static string generatePassword(int[] requirements, int theLength)
        {
            string thePassword = "";
            int[] toBeUsed = requirements;
            int t = theLength;
            while (thePassword.Length < theLength)
            {
                int m = Random.Next(0, t);
                int counter = 0;
                for (int i = 0; i < toBeUsed.Length; i++)
                {
                    counter += toBeUsed[i];
                    if (m < counter)
                    {
                        thePassword += generateNewCharacter(i);
                        toBeUsed[i]--;
                        break;
                    }
                }
                t--;
            }
            return thePassword;
        }
    }
}
