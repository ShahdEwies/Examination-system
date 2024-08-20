using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystemC42
{
    public class PracticalExam : Exam
    {

        public PracticalExam(int time, int numberOfQuestions) : base(time, numberOfQuestions)
        {

        }
        public override void CreateListOfQuestion()
        {

            ListOfQuestions = new MCQQuestion[NumberOfQuestions];
            for (int i = 0; i < ListOfQuestions.Length; i++)
            {
                ListOfQuestions[i] = new MCQQuestion();
                ListOfQuestions[i].AddQuestions();
                Console.Clear();
            }

        }

        public override void ShowExam()
        {
            foreach (var question in ListOfQuestions)
            {
                //question
                Console.WriteLine(question);
                //Answers
                for (int i = 0; i < question.AnswerList.Length; i++)
                {

                    Console.WriteLine(question.AnswerList[i]);
                }
                Console.WriteLine("----------------------");

                //User Answer
                int userAnserId;
                do
                {
                    Console.WriteLine("Enter The Number Of Your Answer");
                } while (!int.TryParse(Console.ReadLine(), out userAnserId) || userAnserId < 1 || userAnserId > 3);

                Console.WriteLine("----------------------");

            }
            Console.Clear();
            Console.WriteLine("Right Answer");
            for (int i = 0; i < ListOfQuestions.Length; i++)
            {
                Console.WriteLine($"Right Answer Of Question {i+1} :{ListOfQuestions[i].RightAnswer.AnswerText}");

            }
        }
    }
}
