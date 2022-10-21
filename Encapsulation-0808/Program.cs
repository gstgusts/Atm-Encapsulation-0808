namespace Encapsulation_0808
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var atm = new Atm("Some address", 5000);

            atm.AddAccount(new Account("111", 100, 1111));
            atm.AddAccount(new Account("222", 300, 2222));
            atm.AddAccount(new Account("333", 1000, 3333));

            atm.ConnectToAccount("", 1111);
        }
    }
}