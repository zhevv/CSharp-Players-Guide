namespace TheLockedDoor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert password: ");
            string password = Console.ReadLine();
            Door door = new Door(password);

            while (true)
            {
                Console.WriteLine("1. Open");
                Console.WriteLine("2. Close");
                Console.WriteLine("3. Lock");
                Console.WriteLine("4. Unlock");
                Console.WriteLine("5. Change password");
                string input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        door.Open();
                        break;

                    case "2":
                        door.Close();
                        break;

                    case "3":
                        door.Lock();
                        break;

                    case "4":
                        Console.Write("Insert password to unlock: ");
                        string input_password = Console.ReadLine();
                        door.Unlock(input_password);
                        break;

                    case "5":
                        Console.Write("Insert current password: ");
                        string current_password = Console.ReadLine();

                        Console.Write("Insert new password: ");
                        string new_password = Console.ReadLine();

                        door.ChangePassword(current_password, new_password);
                        break;

                }
            }
            

        }

        public class Door
        {
            private State state { get; set; } = State.Opened;
            private string Password { get; set; }

            public Door(string _password)
            {
                Password = _password;
            }
            public enum State
            {
                Opened,
                Closed,
                Locked,
            }

            public void Open()
            {
                if (state == State.Closed) {
                    state = State.Opened;
                    ShowState();
                }

                else
                {
                    Console.WriteLine($"Can't open the door, it is {state}");
                }
            }

            public void Close()
            {
                if (state == State.Opened) {
                    state = State.Closed;
                    ShowState();
                }

                else
                {
                    Console.WriteLine("Door is already closed");
                }
            }

            public void Lock()
            {
                if (state == State.Closed)
                {
                    state = State.Locked;
                    ShowState();
                }
                else
                {
                    Console.WriteLine($"Can't lock the door, it is {state}");
                }
            }

            public void Unlock(string password)
            {
                if (state == State.Locked && password == Password) {
                    state = State.Closed;
                    Console.WriteLine("Door is unlocked!");
                }
                else if (state == State.Locked && password != Password)
                {
                    Console.WriteLine("Wrong password");
                }
                else
                {
                    Console.WriteLine("Door is not locked");
                }
            }

            public void ChangePassword(string current_password, string new_password)
            {
                if (Password == current_password)
                {
                    Password = new_password;
                    Console.WriteLine("Password changed!");
                }
                else
                {
                    Console.WriteLine("Wrong password, unable to change");
                }
            }

            private void ShowState()
            {
                Console.WriteLine($"Door is {state}");
            }
        }
    }
}
