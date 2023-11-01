using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3_Main.Models
{
    public class Question
    {
        public string Statment { get; set; }
        public string[] Answers { get; set; }
        public int CorrectAnswer { get; set; }

        public Question(string statment, string[] answers, int correctAnswer)
        {
            Statment = statment;
            Answers = answers;
            CorrectAnswer = correctAnswer;
        }
    }
}
