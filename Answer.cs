using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystemC42
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answer()
        {
            
        }
        public Answer(int _answerId,string _answerText)
        {
            AnswerId=_answerId;
            AnswerText=_answerText;
        }

        public override string ToString()
        {
            return $"{AnswerId} - {AnswerText}";
        }
    }
}
