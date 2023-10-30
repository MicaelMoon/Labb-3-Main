using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Labb_3_Main.Models;
using Path = System.IO.Path;

namespace Labb_3_Main
{
    public enum CurrentMenu
    {
        Main,
        Settings,
        QuizSettings,
        CreateQuiz,
        EditQuiz,
        QuestionSettings,
        CreateQuestion,
        EditQuestion,


    }
    public partial class MainWindow : Window
    {
        public static List<Quiz> quizList = new List<Quiz>();
        public static List<Question> questionList = new List<Question>();

        private TextBox statment;
        private TextBox answer1Text;
        private TextBox answer2Text;
        private TextBox answer3Text;

        CurrentMenu menu = new CurrentMenu();

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            menu = CurrentMenu.Settings;
            MainGrid.ShowGridLines = true;

            CreateGrid.Grid_2_By_3(MainGrid);

            Button questionSettingsButton = new Button
            {
                Content = "Question settings",
                Width = 300,
                Height = 150,
                FontSize = 30
            };
            MainGrid.Children.Add(questionSettingsButton);
            questionSettingsButton.SetValue(Grid.RowProperty, 2);
            questionSettingsButton.SetValue(Grid.ColumnProperty, 2);
            questionSettingsButton.Click += QuestionSettingsButton_Click;

            Button quizSettingsButton = new Button
            {
                Content = "Quiz settings",
                Width = 300,
                Height = 150,
                FontSize = 30
            };
            MainGrid.Children.Add(quizSettingsButton);
            quizSettingsButton.SetValue(Grid.RowProperty, 4);
            quizSettingsButton.SetValue(Grid.ColumnProperty, 2);
            quizSettingsButton.Click += EditQuizButton_Click;


            Button backButton = new Button
            {
                Content = "Back",
                Width = 100,
                Height = 50,
                FontSize = 25
            };
            MainGrid.Children.Add(backButton);
            backButton.SetValue(Grid.RowProperty, 1);
            backButton.SetValue(Grid.ColumnProperty, 1);
            backButton.Click += BackButton_Click;
        }

        private void Start_Quiz_Click(object sender, RoutedEventArgs e)
        {

        }

        private void QuestionSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            menu = CurrentMenu.QuestionSettings;
            CreateGrid.Grid_2_By_3(MainGrid);

            Button createQuiestonButton = new Button
            {
                Content = "Create question",
                Width = 300,
                Height = 150,
                FontSize = 30
            };
            MainGrid.Children.Add(createQuiestonButton);
            createQuiestonButton.SetValue(Grid.RowProperty, 2);
            createQuiestonButton.SetValue(Grid.ColumnProperty, 2);
            createQuiestonButton.Click += CreateQuestionButton_Click;

            Button editQuestionButton = new Button
            {
                Content = "Edit question",
                Width = 300,
                Height = 150,
                FontSize = 30
            };
            MainGrid.Children.Add(editQuestionButton);
            editQuestionButton.SetValue(Grid.RowProperty, 4);
            editQuestionButton.SetValue(Grid.ColumnProperty, 2);
            editQuestionButton.Click += EditQuestionButton_Click;

            Button backButton = new Button
            {
                Content = "Back",
                Width = 100,
                Height = 50,
                FontSize = 25
            };
            MainGrid.Children.Add(backButton);
            backButton.SetValue(Grid.RowProperty, 1);
            backButton.SetValue(Grid.ColumnProperty, 1);
            backButton.Click += BackButton_Click;
        }

        private void CreateQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            menu = CurrentMenu.CreateQuestion;
            CreateGrid.Grid_3_By_3(MainGrid);

            TextBlock title = new TextBlock();
            MainGrid.Children.Add(title);
            title.SetValue(Grid.RowProperty, 2);
            title.SetValue(Grid.ColumnProperty, 3);
            title.SetValue(Grid.ColumnSpanProperty, 4);
            title.Text = "Create your question";
            title.FontSize = 80;
            title.Height = 100;


            TextBlock question = new TextBlock();
            MainGrid.Children.Add(question);
            question.Text = "Question : ";
            question.SetValue(Grid.RowProperty, 4);
            question.SetValue(Grid.ColumnProperty, 2);
            question.SetValue(Grid.ColumnSpanProperty, 2);
            question.FontSize = 50;
            question.Height = 70;

            TextBlock answer1 = new TextBlock();
            MainGrid.Children.Add(answer1);
            answer1.Text = "Correct answer : ";
            answer1.SetValue(Grid.RowProperty, 5);
            answer1.SetValue(Grid.ColumnProperty, 2);
            answer1.SetValue(Grid.ColumnSpanProperty, 2);
            answer1.FontSize = 50;
            answer1.Height = 70;

            TextBlock answer2 = new TextBlock();
            MainGrid.Children.Add(answer2);
            answer2.Text = "Answer 2 : ";
            answer2.SetValue(Grid.RowProperty, 6);
            answer2.SetValue(Grid.ColumnProperty, 2);
            answer2.SetValue(Grid.ColumnSpanProperty, 2);
            answer2.FontSize = 50;
            answer2.Height = 70;

            TextBlock answer3 = new TextBlock();
            MainGrid.Children.Add(answer3);
            answer3.Text = "Answer 3 : ";
            answer3.SetValue(Grid.RowProperty, 7);
            answer3.SetValue(Grid.ColumnProperty, 2);
            answer3.SetValue(Grid.ColumnSpanProperty, 2);
            answer3.FontSize = 50;
            answer3.Height = 70;


            statment = new TextBox();
            MainGrid.Children.Add(statment);
            statment.SetValue(Grid.RowProperty, 4);
            statment.SetValue(Grid.ColumnProperty, 4);
            statment.SetValue(Grid.ColumnSpanProperty, 3);
            statment.FontSize = 30;
            statment.Width = 700;
            statment.Height = 40;

            answer1Text = new TextBox();
            MainGrid.Children.Add(answer1Text);
            answer1Text.SetValue(Grid.RowProperty, 5);
            answer1Text.SetValue(Grid.ColumnProperty, 4);
            answer1Text.SetValue(Grid.ColumnSpanProperty, 3);
            answer1Text.FontSize = 30;
            answer1Text.Width = 700;
            answer1Text.Height = 40;

            answer2Text = new TextBox();
            MainGrid.Children.Add(answer2Text);
            answer2Text.SetValue(Grid.RowProperty, 6);
            answer2Text.SetValue(Grid.ColumnProperty, 4);
            answer2Text.SetValue(Grid.ColumnSpanProperty, 3);
            answer2Text.FontSize = 30;
            answer2Text.Width = 700;
            answer2Text.Height = 40;

            answer3Text = new TextBox();
            MainGrid.Children.Add(answer3Text);
            answer3Text.SetValue(Grid.RowProperty, 7);
            answer3Text.SetValue(Grid.ColumnProperty, 4);
            answer3Text.SetValue(Grid.ColumnSpanProperty, 3);
            answer3Text.FontSize = 30;
            answer3Text.Width = 700;
            answer3Text.Height = 40;

            Button submitButton = new Button
            {
                Content = "Submit",
                Width = 200,
                Height = 100,
                FontSize = 30
            };
            MainGrid.Children.Add(submitButton);
            submitButton.SetValue(Grid.RowProperty, 8);
            submitButton.SetValue(Grid.ColumnProperty, 5);
            submitButton.SetValue(Grid.RowSpanProperty, 2);
            submitButton.Click += SaveQuestion_Click;

            Button bbackButton = new Button
            {
                Content = "Back",
                Width = 200,
                Height = 100,
                FontSize = 30,
            };
            MainGrid.Children.Add(bbackButton);
            bbackButton.SetValue(Grid.RowProperty, 8);
            bbackButton.SetValue(Grid.ColumnProperty, 2);
            bbackButton.SetValue(Grid.RowSpanProperty, 2);

            Button backButton = new Button
            {
                Content = "Back",
                Width = 100,
                Height = 50,
                FontSize = 25
            };
            MainGrid.Children.Add(backButton);
            backButton.SetValue(Grid.RowProperty, 1);
            backButton.SetValue(Grid.ColumnProperty, 1);
            backButton.Click += BackButton_Click;

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            switch (menu)
            {
                case CurrentMenu.Settings:
                    break;
                case CurrentMenu.QuizSettings:
                    break;
                case CurrentMenu.QuestionSettings:
                    break;
                case CurrentMenu.CreateQuiz:
                    break;
                case CurrentMenu.CreateQuestion:
                    break;
                case CurrentMenu.EditQuiz:
                    break;
                case CurrentMenu.EditQuestion:
                    break;
            }
            QuestionSettingsButton_Click(sender, e);
        }//Universal Back button
        private void SaveQuestion_Click(object sender, RoutedEventArgs e) // saves submited question
        {
            if (statment.Text.Length < 1 || answer1Text.Text.Length < 1 || answer2Text.Text.Length < 1 || answer3Text.Text.Length < 1)
            {
                MessageBox.Show("Some fileds were left empty");
            }
            else
            {
                string[] answers = new string[] { answer1Text.Text, answer2Text.Text, answer3Text.Text };
                Question question = new Question(statment.Text, answers, 0);

                string appdataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appdata");
                Directory.CreateDirectory(appdataPath);
                string localPath = Path.Combine(appdataPath, "local");
                Directory.CreateDirectory(localPath);
                string quizPath = Path.Combine(localPath, "The_Amazing_Quiz");
                Directory.CreateDirectory(quizPath);
                string questionPath = Path.Combine(quizPath, "Questions");
                Directory.CreateDirectory(questionPath);

                questionList.Add(question);

                for (int i = 0; i < questionList.Count; i++)
                {
                    string filePath = Path.Combine(questionPath, $"Question_nr_{i + 1}.json");

                    string questionJson = JsonConvert.SerializeObject(questionList[i]);
                    File.WriteAllText(filePath, questionJson);
                }

                MessageBox.Show("Your question was subited");

                statment.Text = "";
                answer1Text.Text = "";
                answer2Text.Text = "";
                answer3Text.Text = "";
            }

        }

        private void EditQuestionButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditQuizButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Quiz_Click(object sender, RoutedEventArgs e)
        {

        }


        /* Grid creation
        private void Mall()
        {
            for (int i = 0; i < 8; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                MainGrid.ColumnDefinitions.Add(column);

                if (i == 0 || i == 7)
                {
                    column.Width = new GridLength(38);
                }
                else
                {
                    column.Width = new GridLength(200, GridUnitType.Pixel); 
                }
            }

            for (int i = 0; i < 10; i++)
            {
                RowDefinition row = new RowDefinition();
                MainGrid.RowDefinitions.Add(row);

                if (i == 0 || i == 9)
                {
                    row.Height = new GridLength(20, GridUnitType.Pixel);
                }
                else
                {
                    row.Height = new GridLength(0, GridUnitType.Auto);
                }
            }
        }
        */
    }
}
