using System;

namespace Calculator_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test if input arguments were supplied.
            if (args.Length == 0)
            {
                Console.WriteLine("Please pass the argument.");
                return;
            }
            try
            {
                // Try to split the arguments based on the expression.
                string[] splitArgs = args[0].Split('(', ')');
                int calculationValue = 0;

                for (int index = splitArgs.Length - 1; index > 0; index--)
                {
                    //Eliminating empty spaces,then iterating the values
                    if (splitArgs[index] != "")
                    {
                        calculationValue = Calculation(splitArgs[index], calculationValue);
                    }
                }
                Console.WriteLine(calculationValue);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Unexcepted Error! Please contact administrator"+exception.ToString());
            }
            Console.ReadLine();
        }

        public static int Calculation(string expression, int calculationValue)
        {
            //Spliting the expression based on empty space
            string[] splitExpression = expression.TrimEnd().Split(' ');
            try
            {
                switch (splitExpression[0])
                {
                    //If Operator is add,then it will iterate
                    case "add":
                        for (int index = splitExpression.Length - 1; index > 0; index--)
                        {
                            calculationValue = Add(calculationValue, splitExpression[index]);
                        }
                        break;
                    //If Operator is multiply,value should not be zero,So initalised to 1.
                    case "multiply":
                        if (calculationValue == 0)
                            calculationValue = 1;

                        for (int index = splitExpression.Length - 1; index > 0; index--)
                        {
                            calculationValue = Multiply(calculationValue, splitExpression[index]);
                        }
                        break;
                    default:
                        Console.WriteLine("Operator is invalid");
                        break;
                }             
            }
            catch(Exception exception)
            {
                Console.WriteLine("Unexcepted Error! Please contact administrator" + exception.ToString());
            }
            return calculationValue;
        }

        private static int Add(int calculationValue, string addtionValue)
        {
            calculationValue += int.Parse(addtionValue);
            return calculationValue;
        }

        private static int Multiply(int calculationValue, string multiplicationValue)
        {
            calculationValue *= int.Parse(multiplicationValue);
            return calculationValue;
        }
    }
}
