using System.Runtime.CompilerServices;

class Programm
{
	private static void OperatorExamples()
	{
		// эта команда объявляет переменную и присваивает ей значение 3
		int width = 3;

		// оператор ++ инкрементирует переменную (увеличивает ее на 1)
		width++;

		// объявляем еще две переменные int для хранения чисел
		// и используем оператор + и * для сложения и умножения значений
		int height = 2 + 4;
		int area = width * height;
		Console.WriteLine(area);

		// следующие 2 команды объявляют строковые переменные
		// и объединяют их оператором + (эта операция называется конкатенацией)
		string result = "The area";
		result = result + " is " + area;
		Console.WriteLine(result);

		// логическая переменная может содержать либо true, либо false
		bool truthValue = true;
		Console.WriteLine(truthValue);
	}
}
