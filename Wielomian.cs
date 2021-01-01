using System;

namespace Wielomian
{
    public class Wielomian
    {
        private int[] a;
        public Wielomian(int[] tab) 
        {
            a = new int[tab.Length];
            Array.Copy(tab, a, tab.Length);
        }
        public Wielomian DodajWielomian(Wielomian input)
        {
            Wielomian output = new Wielomian(new int[0]);
            if (a.Length == 0)
            {
                output.a = new int[input.a.Length];
                Array.Copy(input.a, output.a, input.a.Length);
                return output;
            }
            if (input.a.Length == 0)
            {
                output.a = new int[a.Length];
                Array.Copy(a, output.a, a.Length);
                return output;
            }
            if (a.Length == input.a.Length)
            {
                output.a = new int[a.Length];
                for (int j = 0; j < a.Length; j++)
                    output.a[j] = a[j] + input.a[j];
                return output;
            }

            int shortLength, longLength;

            if (a.Length > input.a.Length)
            {
                longLength = a.Length;
                shortLength = input.a.Length;
            }
            else
            {
                longLength = input.a.Length;
                shortLength = a.Length;
            }

           output.a = new int[longLength];
            int i = 0;
            for (; i < shortLength; i++) 
                output.a[i] = a[i] + input.a[i];
            for (; i < longLength; i++)
            {
                if (a.Length > input.a.Length)
                    output.a[i] = a[i];
                else if (a.Length < input.a.Length)
                    output.a[i] = input.a[i];
            } 
            return output;
        }
        public Wielomian Pomnoz(int input)
        {
            for(int i = 0; i < a.Length; i++)
                a[i] *= input;
            return this;
        }
        public override string ToString()
        {
            if (a.Length == 0)
                return "0 * x^0";
            string output="";
            for (int i = 0; i < a.Length; i++)
            {
                if (output == "" && a[i] != 0)
                    output += $"{a[i]} * x^{i}";
                else if (a[i] != 0)
                    output += $" + {a[i]} * x^{i}";
            }                
            return output;
        }
        
        public static void Test()
        {
            // Czy puste tablice sa prawidlowo obslugowane? (ini i wyp)
            Wielomian w1 = new Wielomian(new int[0]);
            Console.WriteLine("ini w1: " + w1.ToString());

            // Czy niepuste tablice sa prawidlowo obslugowane? (ini i wyp)
            int[] wsp1 = new int[] { 1, 2, 3, 4, 5 };
            Wielomian w2 = new Wielomian(wsp1);
            Console.WriteLine("ini w2: " + w2.ToString());

            // Czy dziala mnozenie? Czy dziala wypisywanie ujemnych wspolczynnikow?
            w2.Pomnoz(-2);
            Console.WriteLine("mnz: w2 = " + w2.ToString());

            // Czy dziala dodawanie wielomianow roznej dlugosci?
            Wielomian w3 = w2.DodajWielomian(w1);
            Console.WriteLine("dod: w3 = w2 + w1 = " + w3.ToString());

            // Czy konstruktor kopiuje tablice?
            for (int i = 0; i < wsp1.Length; i++)
                wsp1[i] = -wsp1[i];
            Console.WriteLine("tst: w2 = " + w2.ToString());

            // Czy dodawanie wielomianu samego do siebie nie powoduje bledow?
            Console.WriteLine("dod: w2 + w2 = " + w2.DodajWielomian(w2));

            // Czy dodawanie nie zmienia wielomianu?
            Console.WriteLine("tst: w2 = " + w2.ToString());
        }
    }
}
