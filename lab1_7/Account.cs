namespace lab1_7 {
	public class Account {
		public string LastName { get; set; }
		public string AccountNumber { get; set; }
		public double Percent { get; set; }
		public Money Sum { get; set; }

		public void Init(string lastName, string accountNumber, double percent, Money sum) {
			this.LastName = lastName;
			this.AccountNumber = accountNumber;
			this.Percent = percent;
			this.Sum = sum;
		}
		public void Read() {
			Console.Write("Уведiть прiзвище власника: ");
			string lname = Console.ReadLine();
			Console.Write("Увадiть номер рахунку: ");
			string acnum = Console.ReadLine();
			Console.WriteLine("Уведiть вiдсоток нарахування: ");
			double perc = Convert.ToDouble(Console.ReadLine());
			Sum.Read();
			this.Init(lname, acnum, perc, Sum);
		}

		public void ChangeAccountOwner(string lastName) {
			LastName = lastName;
		}
		public void Withdraw(double amount) {
			Money mon = new Money();
			mon.Init(amount);
			Sum = Sum.Substract(mon);
		}
		public void Deposit(double amount) {
			Money mon = new Money();
			mon.Init(amount);
			Sum = Sum.Add(mon);
		}
		public void AddPercent() {
			Sum = Sum.Multiply(Percent);
		}

		public void Display() {
			Console.WriteLine(this.ToString());
		}
		public override string ToString()
			=> $"{LastName} - {AccountNumber}\n" +
			   $"Вiдсоток нарахування: {Percent}\n" +
			   $"Баланс рахунку: {Sum.GetSum():0.00}\n" +
			   $"{Sum}\n" +
			   $"У доларах(за курсом 29,45): {Sum.SumToDollars().GetSum():0.00}\n" +
			   $"У євро(за курсом 32,46): {Sum.SumToEuros().GetSum():0.00}";
	}
}
