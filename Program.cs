using System;
using System.Collections.Generic;
using System.IO;

namespace SecurityQuestions
{
    class Program
    {
        static void Main(string[] args)
        {

            string name = QAData.GetName();

            if (QAData.HasStoredQuestions(name))
            {
                Console.WriteLine("Do you want to answer a security question? (y/n)");
                string answer = Console.ReadLine();

                if (answer.Equals("y", StringComparison.InvariantCultureIgnoreCase))
                {
                    QAData.AnswerQuestions(name);
                }
                else
                {
                    QAData.StoreQuestions(name);
                }
            }
            else
            {
                QAData.StoreQuestions(name);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

}
