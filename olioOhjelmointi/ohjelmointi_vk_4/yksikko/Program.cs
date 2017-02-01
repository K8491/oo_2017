using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ohjelmointi.VK5;

namespace ohjelmointi.VK5
{
        interface ICalculator
    {
        int Add(int number1, int number2);
        int Multiply(int number1, int number2);
        int Divide(int number1, int number2);
        int Subtract(int number1, int number2);
    }
    // jakolasku vähennyslasku (divide, substract)
    public class Calculator :ICalculator
    {
        public int Add(int n1, int n2)            
        {
            return n1 + n2;
        }

        public int Multiply(int n1, int n2)
        {
            return n1 * n2;
        }

        public int Divide(int n1, int n2)
        {
            return n1 / n2; 
        }

        public int Subtract(int n1, int n2)
        {
            return n1 - n2;
        }
        int ICalculator.Add(int number1, int number2)
        {
            throw new NotImplementedException();
        }

        int ICalculator.Multiply(int number1, int number2)
        {
            throw new NotImplementedException();
        }

        class Program
        {
            static void Main(string[] args)
            {

            }
        }
    }
}
