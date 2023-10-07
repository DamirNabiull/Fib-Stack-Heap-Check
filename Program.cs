namespace FibCheck // Note: actual namespace depends on the project name.
{
    internal unsafe class Program
    {
        private const int SIZE = 100;
        
        private static void Main(string[] args)
        {
            int fibNumber;
            var line = Console.ReadLine();
            int.TryParse(line, out fibNumber);
            
            Console.WriteLine(FibRec(fibNumber));
            Console.WriteLine(FibCycle(fibNumber));
            Console.WriteLine(FibDp(fibNumber));
            Console.WriteLine(FibDpHeap(fibNumber));
        }

        private static int FibRec(int number)
        {
            return number switch
            {
                <= 0 => 0,
                1 or 2 => 1,
                _ => FibRec(number - 1) + FibRec(number - 2)
            };
        }

        private static int FibCycle(int number)
        {
            int value = 0;
            int next = 1;
            for (int i = 0; i < number; i++)
            {
                next += value;
                value = next - value;
            }

            return value;
        }
        
        private static int FibDp(int number)
        {
            int* dpArr = stackalloc int[SIZE];
            int* p = dpArr;
            *(p++) = 0;
            *(p++) = 1;

            //Console.WriteLine();
            //PrintArr(dpArr);
            
            for (int i = 2; i <= number; i++)
            {
                *(p++) = (*(p-1) + *(p-2));
            
                //Console.Write($"{*(p-1)} {*(p-2)}\n");
                //PrintArr(dpArr);
            }

            return *p;
        }
        
        private static int FibDpHeap(int number)
        {
            int[] dpArr = new int[SIZE];
            dpArr[0] = 0;
            dpArr[1] = 1;
            
            for (int i = 2; i <= number; i++)
            {
                dpArr[i] = dpArr[i-1] + dpArr[i-2];
            }

            return dpArr[number];
        }

        private static void PrintArr(int* arr)
        {
            for (int i = 0; i < SIZE; i++)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.Write("\n");
        }
    }
}