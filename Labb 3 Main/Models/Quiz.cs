using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace Labb_3_Main.Models
{
    public class Quiz
    {
        public string Title { get; set; }
        public List<Question> _questions;
        public List<Question> _randomizedQuestions;

        public Quiz(string title)
        {
            Title = title;
            _questions = new List<Question>();
            _randomizedQuestions = new List<Question>();
        }

        public void RandomizeQuisions()
        {
            _randomizedQuestions.Clear();

            Random random = new Random();

            for (int i = 0; i < _questions.Count; i++) // Create the random order of questions
            {
                int r = 0;
                do
                {
                    r = random.Next(0, _questions.Count);
                }
                while (_randomizedQuestions.Contains(_questions[r]));

                _randomizedQuestions.Add(_questions[r]);
            }
        }
        public Question GetRandomQuestion()
        {
            throw new NotImplementedException("A random question needs to be returned here");
        }

        public void AddQuestion(Question question)
        {
            _questions.Add(question);

            if(MainWindow.menu != CurrentMenu.StartUp)
            {
                MessageBox.Show("Question was succesfully added to your quiz");
            }
        }


        public void RemoveQuestion(int index)
        {
            _questions.RemoveAt(index);
        }

        public static async Task UpdateFiles()
        {
            string appdataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appdata");
            Directory.CreateDirectory(appdataPath);
            string localPath = Path.Combine(appdataPath, "local");
            Directory.CreateDirectory(localPath);
            string quizPath = Path.Combine(localPath, "The_Amazing_Quiz");
            Directory.CreateDirectory(quizPath);
            string quizzesPath = Path.Combine(quizPath, "Quizzes");
            Directory.CreateDirectory(quizzesPath);

            await Task.Run(async () =>
            {
                for (int i = 0; i < MainWindow.quizList.Count; i++)
                {
                    string filePath = Path.Combine(quizzesPath, $"Nr_{i + 1}_Quiz.json");
                    string quizJson = JsonConvert.SerializeObject(MainWindow.quizList[i]);

                    File.WriteAllText(filePath, quizJson);
                }
            });
        }
    }
}
