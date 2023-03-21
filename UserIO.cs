namespace Webshop
{
    internal class UserIO : IUI
    {
        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            System.Environment.Exit(0);
        }

        public string Input()
        {
            try
            {
                var input = Console.ReadLine();
                if (input == null)
                    throw new Exception("Inmatning fel");
                else
                    return input;
            }
            catch (Exception e)
            {
                return "Inmatning fel\n" + e.Message;
            }
        }

        public void Output(string output)
        {
            Console.WriteLine(output);
        }
    }
}