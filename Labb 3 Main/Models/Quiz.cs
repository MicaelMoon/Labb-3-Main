using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3_Main.Models
{
    public class Quiz
    {
        private IEnumerable<Question> _questions;
        private string _title = string.Empty;
        public IEnumerable<Question> Questions => _questions;
        public string Title => _title;

        public Quiz()
        {
            _questions = new List<Question>();
        }

        public Question GetRandomQuestion()
        {
            throw new NotImplementedException("A random question needs to be returned here");
        }

        public void AddQuestion(string statment, int correctAnswer, params string[] answers)
        {
            throw new NotImplementedException("Question need to be instantiated and added to list of questions here");
        }

        public void RemoveQuestion(int index)
        {
            throw new NotSupportedException("Question at requested index need to be removed here");
        }
    }
}
