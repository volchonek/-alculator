using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Сalculator
{
	class Program
	{
		static void Main(string[] args)
		{
			//Допилить факториал и числа с плавающей запятой + телефонный справочник

			//ввод данных
			Console.WriteLine("Программа калькулятор");
			Console.WriteLine("Программа умеет считать x*y, x/y, x+y, x-y, x!, x^y как по отдельности, так и в сочетании друг с другом ");
			Console.WriteLine("_______________________________________________________________________________________________________");
			Console.WriteLine("Введите пример, который необходимо посчитать");
			var s = Console.ReadLine().ToString();
			BigInteger r = Parse(s);
			Console.WriteLine("");
			Console.WriteLine("Результат");
			Console.WriteLine("{0} = {1}", s, r);
			Console.ReadKey();
		}
		//разбор строки
		static BigInteger Parse(string s)
		{
			//задаем начальный индекс
			int index = 0;
			//получаем число с номером 
			BigInteger v = GetNumber(s, ref index);
			while (index < s.Length)
			{
				switch (s[index])
				{
					case '+'://операция сложения
						index++;
						v += MulDiv(s, ref index);
						break;
					case '-'://операция вычитания
						index++;
						v -= MulDiv(s, ref index);
						break;
					case '*'://операция умножения
						index++;
						v *= StepenChislaFunction(s, ref index);
						break;
					case '/'://операция деления
						index++;
						v /= StepenChislaFunction(s, ref index);
						break;
					case '!'://операция вычисление факториала
						index++;
						v = Factorial(v);
						break;
					case '^'://операция вычисление "v" в степени "w"                            
						index++;
						BigInteger w = GetNumber(s, ref index);
						v = StepenChisla(v, w);
						break;
					default:
						Console.WriteLine("Error");
						break;
				}
			}
			return v;
		}
		static BigInteger GetNumber(string s, ref int index)
		{
			var tmp = "";
			//отсекаем строки
			foreach (char c in s.Substring(index))
			{
				//проверяем посимвольно каждый символ строки
				if (!char.IsDigit(c))
				{
					break;
				}
				index++;
				tmp += c;
			}
			return BigInteger.Parse(tmp);//формируем число из строки
		}
		static BigInteger MulDiv(string s, ref int index)
		{
			//получаем число с номером 
			BigInteger v = GetNumber(s, ref index);
			while (index < s.Length)
			{
				if (s[index] == '*')
				{
					//операция умножения
					index++;
					v *= StepenChislaFunction(s, ref index);
				}
				else if (s[index] == '/')
				{
					//операция деления
					index++;
					v /= StepenChislaFunction(s, ref index);
				}
				else if (s[index] == '^')
				{
					//операция вычисление "v" в степени "w"  
					index++;
					BigInteger w = GetNumber(s, ref index);
					v = StepenChisla(v, w);
				}
				else if (s[index] == '!')
				{
					//операция вычисление факториала 
					index++;
					v = Factorial(v);
				}
				else
				{
					break;
				}

			}
			return v;
		}
		//функция степени числа
		static BigInteger StepenChislaFunction(string s, ref int index)
		{
			//получаем число с номером 
			BigInteger v = FactorialFunction(s, ref index);
			while (index < s.Length)
			{
				if (s[index] == '^')
				{
					index++;
					//получаем число с номером 
					BigInteger w = FactorialFunction(s, ref index);
					//операция вычисление "v" в степени "w"                  
					v = StepenChisla(v, w);
				}
				else
				{
					break;
				}
			}
			return v;
		}
		//вычисление степени числа
		static BigInteger StepenChisla(BigInteger v, BigInteger w)
		{
			if (w == 0)
			{
				v = 1;
			}
			else if (w == 1)
			{
				return v;
			}
			else
			{
				var n = v;
				for (int i = 2; i <= w; i++)
				{
					v = v * n;
				};
			};
			return v;
		}
		//функция факториала
		static BigInteger FactorialFunction(string s, ref int index)
		{
			//получаем число с номером 
			BigInteger v = GetNumber(s, ref index);
			while (index < s.Length)
			{
				if (s[index] == '!')
				{
					//операция вычисление факториала 
					index++;
					v = Factorial(v);
				}
				else
				{
					break;
				}

			}
			return v;
		}
		//вычисление факториала
		static BigInteger Factorial(BigInteger v)
		{
			int f = 1;
			for (int i = 2; i < (v + 1); ++i)
			{
				f = f * i;
			}
			v = f;
			return v;
		}
	}
}
