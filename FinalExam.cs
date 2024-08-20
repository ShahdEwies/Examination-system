using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystemC42
{
    public class FinalExam : Exam
    {

        public FinalExam(int time,int numberOfQuestions):base(time, numberOfQuestions) 
        {
            
        }
        public override void CreateListOfQuestion()
        {
            ListOfQuestions = new Question[NumberOfQuestions];
            for (int i = 0; i < ListOfQuestions.Length; i++)
            {

                int choice;
                do
                {
                    Console.WriteLine("Enter 1 for MCQ or 2 For True/False Question :");
                }while(!int.TryParse(Console.ReadLine(), out choice)||choice<1||choice>2);
                Console.Clear();

                if(choice == 1)
                {
                    ListOfQuestions[i] = new MCQQuestion();
                    ListOfQuestions[i].AddQuestions();
                }
                else if(choice==2) {
                    ListOfQuestions[i] = new TFQuestion();
                    ListOfQuestions[i].AddQuestions();
                }
            }


        }

        public override void ShowExam()
        {
            int totalMarks = 0, grade = 0;
            //question
            foreach (var question in ListOfQuestions)
            {
                Console.WriteLine(question);
                //Answers
                for (int i = 0; i < question.AnswerList.Length; i++)
                {

                    Console.WriteLine(question.AnswerList[i]);
                }
                Console.WriteLine("----------------------");

                //User Answer
                int userAnserId;
                if(question.Header== "MCQ Question")
                {
                    do
                    {
                        Console.WriteLine("Enter The Number Of Your Answer");
                    } while (!int.TryParse(Console.ReadLine(), out userAnserId) || userAnserId < 1 || userAnserId > 3);
                    question.UserAnswer.AnswerId = userAnserId;
                    question.UserAnswer.AnswerText = question.AnswerList[userAnserId-1].AnswerText;
                    Console.WriteLine("----------------------");

                }
                else if(question.Header== "True/False Question")
                {
                    do
                    {
                        Console.WriteLine("Enter The Number Of Your Answer");
                    } while (!int.TryParse(Console.ReadLine(), out userAnserId) || userAnserId < 1 || userAnserId > 2);
                    question.UserAnswer.AnswerId = userAnserId;
                    question.UserAnswer.AnswerText = question.AnswerList[userAnserId - 1].AnswerText;
                    Console.WriteLine("----------------------");
                }
                Console.WriteLine("-----------------------------");

                Console.Clear();
                totalMarks += question.Marks;
            }
            for (int i = 0; i < ListOfQuestions.Length; i++)
            { // user anser equal right anser or not 

                if (ListOfQuestions[i].RightAnswer.AnswerId == ListOfQuestions[i].UserAnswer.AnswerId) {
                    grade += ListOfQuestions[i].Marks;
                }
                Console.WriteLine($"Question {i+1} : {ListOfQuestions[i].Body}");
                Console.WriteLine($"Your Answer : {ListOfQuestions[i].UserAnswer.AnswerText}");
                Console.WriteLine($"User Answer : {ListOfQuestions[i].RightAnswer.AnswerText}");

            }

            Console.WriteLine($"Your Grade Is {grade}/{totalMarks}");

        }
    }
}
