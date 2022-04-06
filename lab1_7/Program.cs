using System;

namespace lab1_7 {
	static class Program {
		static void Main(string[] args) {
			Money money = new Money();
			money.Init(194.2);
			Account account = new Account();
			account.Init("Iваненко", "NN246789654112", 24, money);
			account.ChangeAccountOwner("Петренко");
			account.Deposit(240);
			account.Display();
		}
	}
}