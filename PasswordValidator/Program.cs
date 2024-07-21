namespace PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            while (true)
            {
                Console.WriteLine("Insert password: ");
                string input = Console.ReadLine();
                bool result = PasswordValidator.Check(input);
                Console.WriteLine(result);
            }
            

        }

        public static class PasswordValidator
        {
            public static bool Check(string password)
            {
                if (password.Length < 6 || password.Length > 13)
                {
                    return false;
                }

                bool hasUppercase = false;
                bool hasLowercase = false;
                bool hasNumber = false;

                foreach (char letter in password) {
                    if (letter == 'T' || letter == '&') {
                        return false;
                    }

                    if (char.IsUpper(letter)){
                        hasUppercase = true;
                    }
                    if (char.IsLower(letter))
                    {
                        hasLowercase = true;
                    }
                    if (char.IsDigit(letter))
                    {
                        hasNumber = true;
                    }
                }

                if (hasUppercase && hasLowercase && hasNumber) {
                    return true;
                }

                return false;
            }
        }
    }
}
