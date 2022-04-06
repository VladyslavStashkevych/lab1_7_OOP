namespace lab1_7 {
	public class Money {
		public int AmountOf500 { get; set; }
		public int AmountOf200 { get; set; }
		public int AmountOf100 { get; set; }
		public int AmountOf50 { get; set; }
		public int AmountOf20 { get; set; }
		public int AmountOf10 { get; set; }
		public int AmountOf5 { get; set; }
		public int AmountOf2 { get; set; }
		public int AmountOf1 { get; set; }
		public int AmountOf50c { get; set; }
		public int AmountOf25c { get; set; }
		public int AmountOf10c { get; set; }
		public int AmountOf5c { get; set; }
		public int AmountOf2c { get; set; }
		public int AmountOf1c { get; set; }

		public double GetSum() => 500 * AmountOf500 + 200 * AmountOf200 +
				+100 * AmountOf100 + 50 * AmountOf50 +
				+20 * AmountOf20 + 10 * AmountOf10 +
				+5 * AmountOf5 + 2 * AmountOf2 + AmountOf1 +
				+0.5 * AmountOf50c + 0.25 * AmountOf25c +
				+0.1 * AmountOf10c + 0.05 * AmountOf5c +
				+0.02 * AmountOf2c + 0.01 * AmountOf1c;
		public void SetSum(double value) {
			int s = (int)(value * 100);
			AmountOf500 = s / 50000;
			s %= 50000;
			AmountOf200 = s / 20000;
			s %= 20000;
			AmountOf100 = s / 10000;
			s %= 10000;
			AmountOf50 = s / 5000;
			s %= 5000;
			AmountOf20 = s / 2000;
			s %= 2000;
			AmountOf10 = s / 1000;
			s %= 1000;
			AmountOf5 = s / 500;
			s %= 500;
			AmountOf2 = s / 200;
			s %= 200;
			AmountOf1 = s / 100;
			s %= 100;
			AmountOf50c = s / 50;
			s %= 50;
			AmountOf25c = s / 25;
			s %= 25;
			AmountOf10c = s / 10;
			s %= 10;
			AmountOf5c = s / 5;
			s %= 5;
			AmountOf2c = s / 2;
			s %= 2;
			AmountOf1c = s / 1;

		}

		public void Init(double s) {
			this.SetSum(s);
		}
		public void Read() {
			Console.WriteLine("Уведiть суму:");
			double s = Convert.ToDouble(Console.ReadLine());
			Init(s);
		}

		public Money Add(Money m) {
			Money result = new Money();
			result.Init(this.GetSum() + m.GetSum());
			return result;
		}
		public Money Multiply(double n) {
			Money result = new Money();
			result.Init(this.GetSum());
			result.SetSum(result.GetSum() * n);
			return result;
		}
		public Money Substract(Money m) => this.Add(m.Multiply(-1));
		public Money DivideByNum(double n) => this.Multiply(1.0 / n);
		public double Division(Money m) => this.GetSum() / m.GetSum();

		public bool IsGreaterThen(Money m) => this.GetSum() > m.GetSum();
		public bool IsLowerThen(Money m) => this.GetSum() < m.GetSum();
		public bool EqualsTo(Money m) => this.GetSum() == m.GetSum();

		public Money SumToDollars() => this.DivideByNum(29.45);
		public Money SumToEuros() => this.DivideByNum(32.46);

		public void Display() {
			Console.WriteLine($"{this.GetSum():0.00}");
		}
		public override string ToString() {
			string  result = "";
			string[] thousands = new string[] {
				"тисяч", "тисяча", "тисячі"
			};
			string[] hundreds = new string[] {
				"сто", "двiстi", "триста",
				"чотириста", "п'ятсот", "шiстсот",
				"сiмсот", "вiсiмсот", "дев'ятсот"
			};
			string[] tens = new string[] {
				"десять", "двадцять", "тридцять",
				"сорок", "п'ятдесят", "шiстдесят",
				"сiмдесят", "вiсiмдесят", "дев'яносто"
			};
			string[] ones = new string[] {
				"одна", "двi", "три",
				"чотири", "п'ять", "шiсть",
				"сiм", "вiсiм", "дев'ять"
			};

			if (GetSum() > 1000) {
				int lastChar = (int)(GetSum() / 1000) % 10;
				result += lastChar switch {
					1 => $"{ones[0]} {thousands[1]} ",
					2 => $"{ones[1]} {thousands[2]} ",
					3 => $"{ones[2]} {thousands[2]} ",
					4 => $"{ones[3]} {thousands[2]} ",
					5 => $"{ones[4]} {thousands[0]} ",
					6 => $"{ones[5]} {thousands[0]} ",
					7 => $"{ones[6]} {thousands[0]} ",
					8 => $"{ones[7]} {thousands[0]} ",
					9 => $"{ones[8]} {thousands[0]} ",
					_ => $"{lastChar} {thousands[0]} "
				};
			}
			if (GetSum() > 100) {
				int lastChar = (int)(GetSum() / 100) % 10;
				result += lastChar switch {
					1 => $"{hundreds[0]} ",
					2 => $"{hundreds[1]} ",
					3 => $"{hundreds[2]} ",
					4 => $"{hundreds[3]} ",
					5 => $"{hundreds[4]} ",
					6 => $"{hundreds[5]} ",
					7 => $"{hundreds[6]} ",
					8 => $"{hundreds[7]} ",
					9 => $"{hundreds[8]} ",
					_ => ""
				};
			}
			if (GetSum() > 10) {
				int lastChar = (int)(GetSum() / 10) % 10;
				result += lastChar switch {
					1 => $"{tens[0]} ",
					2 => $"{tens[1]} ",
					3 => $"{tens[2]} ",
					4 => $"{tens[3]} ",
					5 => $"{tens[4]} ",
					6 => $"{tens[5]} ",
					7 => $"{tens[6]} ",
					8 => $"{tens[7]} ",
					9 => $"{tens[8]} ",
					_ => ""
				};
			}
			if (GetSum() > 1) {
				int lastChar = (int)(GetSum() % 10);
				result += lastChar switch {
					1 => $"{ones[0]} ",
					2 => $"{ones[1]} ",
					3 => $"{ones[2]} ",
					4 => $"{ones[3]} ",
					5 => $"{ones[4]} ",
					6 => $"{ones[5]} ",
					7 => $"{ones[6]} ",
					8 => $"{ones[7]} ",
					9 => $"{ones[8]} ",
					_ => ""
				};
			}
			if (result != "")
				result += "грн.";
			if (GetSum() % 1.0 > 0)
				result += $"{(GetSum() % 1.0) * 100: 0} коп.";
			result = result[..1].ToUpper() + result[1..];
			return result;
		}
	}
}
