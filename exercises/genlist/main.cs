using System;
using static System.Console;
using static System.Math;
class main{
	public static void Main(){
		genlist<double[]> list = new genlist<double[]>();
		char[] delimiters = {' ','\t'};
		var options = StringSplitOptions.RemoveEmptyEntries;
		for(string line = ReadLine(); line!=null; line = ReadLine()){
			var words = line.Split(delimiters,options);
			int n = words.Length;
			var numbers = new double[n];
			for(int i=0;i<n;i++) numbers[i] = double.Parse(words[i]);
			list.add(numbers);
				}
		for(int i=0;i<list.size;i++){
			var numbers = list[i];
			foreach(var number in numbers)Write($"{number : 0.00e+00;-0.00e+00} ");
			WriteLine();
				}
		
/*
		genlist<double> listd = new genlist<double>();
		listd.add(57.0);
		listd.add(4.0);
		listd.add(52.0);
		listd.add(35.0);
		listd.add(325.0);
		WriteLine();
		WriteLine("Remove the third entry of the list");
		for(int j=0;j<listd.size;j++){
			double x = listd[j];
			WriteLine($"List element {j}: {x} ");
		}
		listd.remove(2);
		for(int k=0; k<listd.size; k++){
			double y = listd[k];
			WriteLine($"List with removed 2nd element {k}: {y} ");
		}
*/
//		genlist<double> list_doubled = new genlist<double>();
//		list_doubled.add_double(24.0);
		/*
		list_doubled.add_double(236.0);
		list_doubled.add_double(26.0);
		list_doubled.add_double(234.0);
		list_doubled.add_double(2346.0);
		list_doubled.add_double(4.0);
		list_doubled.add_double(6.0);
		list_doubled.add_double(644.0);
		list_doubled.add_double(346.0);
		list_doubled.add_double(246.0);
		
		for(int l=0;l<list_doubled.size_double;l++){
			double x = list_doubled[l];
			WriteLine($"List element {l}: {x} ");
		}*/
	}
}
