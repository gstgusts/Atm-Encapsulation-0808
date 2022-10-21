namespace Encapsulation_0808
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var atm = new Atm("Some address", 1000);

            atm.AddAccount(new Account("111", 1500, 1111));
            atm.AddAccount(new Account("222", 300, 2222));
            atm.AddAccount(new Account("333", 1000, 3333));

            var result = atm.ConnectToAccount("111", 1111);

            Console.WriteLine(result);

            var r = atm.TakeOutMoney(1100);

            Console.WriteLine(r);

            atm.DisconnectFromAccount();

            Console.WriteLine("Session has ended");
        }
    }
}