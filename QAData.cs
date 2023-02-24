using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityQuestions
{
    public class QAData
    {
        public static string GetName()
        {
            Console.WriteLine("Hi, what is your name?");
            string name = Console.ReadLine();
            return name;
        }

        public static bool HasStoredQuestions(string name)
        {
            string fileName = $"{name}.txt";
            return File.Exists(fileName);
        }

        public static void StoreQuestions(string name)
        {
            Console.WriteLine("Would you like to store answers to security questions? (y/n)");
            string answer = Console.ReadLine();

            if (answer.Equals("y", StringComparison.InvariantCultureIgnoreCase))
            {
                List<string> allQuestions = new List<string>
                {
                    "In what city were you born?",
                    "What is the name of your favorite pet?",
                    "What is your mother's maiden name?",
                    "What high school did you attend?",
                    "What was the mascot of your high school?",
                    "What was the make of your first car?",
                    "What was your favorite toy as a child?",
                    "Where did you meet your spouse?",
                    "What is your favorite meal?",
                    "Who is your favorite actor/actress?",
                    "What is your favorite album?"
                };

                List<string> selectedQuestions = new List<string>();
                Random random = new Random();

                for (int i = 0; i < 3; i++)
                {
                    int index = random.Next(allQuestions.Count);
                    selectedQuestions.Add(allQuestions[index]);
                    allQuestions.RemoveAt(index);
                }

                Console.WriteLine("Please answer the following questions:");

                using (StreamWriter sw = new StreamWriter($"{name}.txt"))
                {
                    foreach (string question in selectedQuestions)
                    {
                        Console.WriteLine(question);
                        string answerText = Console.ReadLine();
                        sw.WriteLine($"{question}: {answerText}");
                    }
                }

                Console.WriteLine("Security questions stored successfully.");
            }
        }

        public static void AnswerQuestions(string name)
        {
            string fileName = $"{name}.txt";

            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                int correctAnswers = 0;

                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');

                    Console.WriteLine(parts[0]);
                    string answerText = Console.ReadLine();

                    if (answerText.Trim().Equals(parts[1].Trim(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        correctAnswers++;
                    }

                    if (correctAnswers == 3)
                    {
                        Console.WriteLine("Congratulations! You have answered all security questions correctly.");
                        return;
                    }
                }

                Console.WriteLine("You have run out of security questions.");
            }
            else
            {
                Console.WriteLine("No security questions found for this name.");
            }
        }
    }
}
