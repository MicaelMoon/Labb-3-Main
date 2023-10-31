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
        private TextBox statmentTextChange;
        private TextBox answer1TextChange;
        private TextBox answer2TextChange;
        private TextBox answer3TextChange;

        public Question selectedQuestionBox;
        public int oldQuestionId;

        CurrentMenu menu = new CurrentMenu();


        public MainWindow()
        {
            LoadInContent();
            InitializeComponent();
        }

        async Task LoadInContent()
        {
            string appdataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appdata");
            Directory.CreateDirectory(appdataPath);
            string localPath = Path.Combine(appdataPath, "local");
            Directory.CreateDirectory(localPath);
            string theQuizPath = Path.Combine(localPath, "The_Amazing_Quiz");
            Directory.CreateDirectory(theQuizPath);
            string quizPath = Path.Combine(theQuizPath, "Quizzes");
            string questionPath = Path.Combine(theQuizPath, "Questions");
            Directory.CreateDirectory(questionPath);

            string[] questionFIles = Directory.GetFiles(questionPath, "*Question.json");


            //Question question = null;
            //Quiz quiz = null;

            await Task.Run(async () =>
            {
                foreach (var q in questionFIles)
                {
                    string json = await File.ReadAllTextAsync(q);
                    var question = JsonConvert.DeserializeObject<Question>(json);
                    questionList.Add(question);
                }
            });
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            menu = CurrentMenu.Main;
            MainGrid.ShowGridLines = true;
            CreateGrid.Grid_Main(MainGrid);

            Button startQuizButton = new Button
            {
                Content = "Start Quiz",
                Width = 400,
                Height = 200,
                FontSize = 30
            };
            MainGrid.Children.Add(startQuizButton);
            startQuizButton.SetValue(Grid.RowProperty, 1);
            startQuizButton.SetValue(Grid.ColumnProperty, 1);
            startQuizButton.Click += StartQuiz_Click;

            Button settingsButton = new Button
            {
                Content = "Settings",
                Width = 400,
                Height = 200,
                FontSize = 30
            };
            MainGrid.Children.Add(settingsButton);
            settingsButton.SetValue(Grid.RowProperty, 1);
            settingsButton.SetValue(Grid.ColumnProperty, 2);
            settingsButton.Click += SettingsButton_Click;
        }

        private void StartQuiz_Click(object sender, RoutedEventArgs e)
        {
            CreateGrid.Grid_Play(MainGrid);
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            menu = CurrentMenu.Settings;
            CreateGrid.Grid_Settings(MainGrid);

            TextBlock title = new TextBlock();
            MainGrid.Children.Add(title);
            title.SetValue(Grid.RowProperty, 3);
            title.SetValue(Grid.ColumnProperty, 1);
            title.SetValue(Grid.ColumnSpanProperty, 4);
            title.Text = "Create your question";
            title.FontSize = 40;
            title.Height = 50;

            TextBlock titleChange = new TextBlock();
            MainGrid.Children.Add(titleChange);
            titleChange.SetValue(Grid.RowProperty, 9);
            titleChange.SetValue(Grid.ColumnProperty, 1);
            titleChange.SetValue(Grid.ColumnSpanProperty, 6);
            titleChange.Text = "Choose question to change";
            titleChange.FontSize = 40;
            titleChange.Height = 50;

            TextBlock question = new TextBlock();
            MainGrid.Children.Add(question);
            question.Text = "Question : ";
            question.SetValue(Grid.RowProperty, 4);
            question.SetValue(Grid.ColumnProperty, 1);
            question.SetValue(Grid.ColumnSpanProperty, 2);
            question.FontSize = 25;
            question.Height = 35;

            TextBlock answer1 = new TextBlock();
            MainGrid.Children.Add(answer1);
            answer1.Text = "Correct answer : ";
            answer1.SetValue(Grid.RowProperty, 5);
            answer1.SetValue(Grid.ColumnProperty, 1);
            answer1.SetValue(Grid.ColumnSpanProperty, 2);
            answer1.FontSize = 25;
            answer1.Height = 35;

            TextBlock answer2 = new TextBlock();
            MainGrid.Children.Add(answer2);
            answer2.Text = "Answer 2 : ";
            answer2.SetValue(Grid.RowProperty, 6);
            answer2.SetValue(Grid.ColumnProperty, 1);
            answer2.SetValue(Grid.ColumnSpanProperty, 2);
            answer2.FontSize = 25;
            answer2.Height = 35;

            TextBlock answer3 = new TextBlock();
            MainGrid.Children.Add(answer3);
            answer3.Text = "Answer 3 : ";
            answer3.SetValue(Grid.RowProperty, 7);
            answer3.SetValue(Grid.ColumnProperty, 1);
            answer3.SetValue(Grid.ColumnSpanProperty, 2);
            answer3.FontSize = 25;
            answer3.Height = 35;

            TextBlock statmentChange = new TextBlock();
            MainGrid.Children.Add(statmentChange);
            statmentChange.Text = "Statment : ";
            statmentChange.SetValue(Grid.RowProperty, 13);
            statmentChange.SetValue(Grid.ColumnProperty, 1);
            statmentChange.SetValue(Grid.ColumnSpanProperty, 2);
            statmentChange.FontSize = 25;
            statmentChange.Height = 35;

            TextBlock answer1Change = new TextBlock();
            MainGrid.Children.Add(answer1Change);
            answer1Change.Text = "Correct answer : ";
            answer1Change.SetValue(Grid.RowProperty, 14);
            answer1Change.SetValue(Grid.ColumnProperty, 1);
            answer1Change.SetValue(Grid.ColumnSpanProperty, 2);
            answer1Change.FontSize = 25;
            answer1Change.Height = 35;

            TextBlock answer2Change = new TextBlock();
            MainGrid.Children.Add(answer2Change);
            answer2Change.Text = "Answer 2 : ";
            answer2Change.SetValue(Grid.RowProperty, 15);
            answer2Change.SetValue(Grid.ColumnProperty, 1);
            answer2Change.SetValue(Grid.ColumnSpanProperty, 2);
            answer2Change.FontSize = 25;
            answer2Change.Height = 35;

            TextBlock answer3Change = new TextBlock();
            MainGrid.Children.Add(answer3Change);
            answer3Change.Text = "Answer 3 : ";
            answer3Change.SetValue(Grid.RowProperty, 16);
            answer3Change.SetValue(Grid.ColumnProperty, 1);
            answer3Change.SetValue(Grid.ColumnSpanProperty, 2);
            answer3Change.FontSize = 25;
            answer3Change.Height = 35;

            statment = new TextBox();
            MainGrid.Children.Add(statment);
            statment.SetValue(Grid.RowProperty, 4);
            statment.SetValue(Grid.ColumnProperty, 3);
            statment.SetValue(Grid.ColumnSpanProperty, 2);
            statment.FontSize = 20;
            statment.Width = 400;
            statment.Height = 30;

            answer1Text = new TextBox();
            MainGrid.Children.Add(answer1Text);
            answer1Text.SetValue(Grid.RowProperty, 5);
            answer1Text.SetValue(Grid.ColumnProperty, 3 );
            answer1Text.SetValue(Grid.ColumnSpanProperty, 2);
            answer1Text.FontSize = 20;
            answer1Text.Width = 400;
            answer1Text.Height = 30;

            answer2Text = new TextBox();
            MainGrid.Children.Add(answer2Text);
            answer2Text.SetValue(Grid.RowProperty, 6);
            answer2Text.SetValue(Grid.ColumnProperty, 3);
            answer2Text.SetValue(Grid.ColumnSpanProperty, 2);
            answer2Text.FontSize = 20;
            answer2Text.Width = 400;
            answer2Text.Height = 30;

            answer3Text = new TextBox();
            MainGrid.Children.Add(answer3Text);
            answer3Text.SetValue(Grid.RowProperty, 7);
            answer3Text.SetValue(Grid.ColumnProperty, 3);
            answer3Text.SetValue(Grid.ColumnSpanProperty, 2);
            answer3Text.FontSize = 20;
            answer3Text.Width = 400;
            answer3Text.Height = 30;

            statmentTextChange = new TextBox();
            MainGrid.Children.Add(statmentTextChange);
            statmentTextChange.SetValue(Grid.RowProperty, 13);
            statmentTextChange.SetValue(Grid.ColumnProperty, 3);
            statmentTextChange.SetValue(Grid.ColumnSpanProperty, 2);
            statmentTextChange.FontSize = 20;
            statmentTextChange.Width = 400;
            statmentTextChange.Height = 30;

            answer1TextChange = new TextBox();
            MainGrid.Children.Add(answer1TextChange);
            answer1TextChange.SetValue(Grid.RowProperty, 14);
            answer1TextChange.SetValue(Grid.ColumnProperty, 3);
            answer1TextChange.SetValue(Grid.ColumnSpanProperty, 2);
            answer1TextChange.FontSize = 20;
            answer1TextChange.Width = 400;
            answer1TextChange.Height = 30;

            answer2TextChange = new TextBox();
            MainGrid.Children.Add(answer2TextChange);
            answer2TextChange.SetValue(Grid.RowProperty, 15);
            answer2TextChange.SetValue(Grid.ColumnProperty, 3);
            answer2TextChange.SetValue(Grid.ColumnSpanProperty, 2);
            answer2TextChange.FontSize = 20;
            answer2TextChange.Width = 400;
            answer2TextChange.Height = 30;

            answer3TextChange = new TextBox();
            MainGrid.Children.Add(answer3TextChange);
            answer3TextChange.SetValue(Grid.RowProperty, 16);
            answer3TextChange.SetValue(Grid.ColumnProperty, 3);
            answer3TextChange.SetValue(Grid.ColumnSpanProperty, 2);
            answer3TextChange.FontSize = 20;
            answer3TextChange.Width = 400;
            answer3TextChange.Height = 30;

            if (selectedQuestionBox != null)
            {
                statmentTextChange.Text = selectedQuestionBox.Statment;
                answer1TextChange.Text = selectedQuestionBox.Answers[0];
                answer2TextChange.Text = selectedQuestionBox.Answers[1];
                answer3TextChange.Text = selectedQuestionBox.Answers[2];
            }

            Button submitButton = new Button
            {
                Content = "Submit",
                Width = 70,
                Height = 35,
                FontSize = 20
            };
            MainGrid.Children.Add(submitButton);
            submitButton.SetValue(Grid.RowProperty, 8);
            submitButton.SetValue(Grid.ColumnProperty, 3);
            submitButton.SetValue(Grid.RowSpanProperty, 2);
            submitButton.Click += SaveQuestion_Click;
            submitButton.Margin = new Thickness(0, 0, 0, 50);

            Button editQuestionButton = new Button
            {
                Content = "Edit",
                Width = 70,
                Height = 35,
                FontSize = 20
            };
            MainGrid.Children.Add(editQuestionButton);
            editQuestionButton.SetValue(Grid.RowProperty, 17);
            editQuestionButton.SetValue(Grid.ColumnProperty, 3);
            editQuestionButton.SetValue(Grid.RowSpanProperty, 2);
            editQuestionButton.Click += EditQuestion_Click;


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


            ComboBox questionBox = new ComboBox
            {
                Width = 400,
                Height = 20,
            };
            MainGrid.Children.Add(questionBox);
            questionBox.SetValue(Grid.ColumnProperty, 1);
            questionBox.SetValue(Grid.RowProperty, 10);
            questionBox.SetValue(Grid.ColumnSpanProperty, 4);


            ComboBoxItem titleItem = new ComboBoxItem
            {
                Content = "Questions",
                IsEnabled = false,
                FontWeight = FontWeights.Bold,
            };
            questionBox.Items.Add(titleItem);
            questionBox.SelectionChanged += QuestionBox_SelectionChanged;

            for (int i = 0; i < questionList.Count; i++)
            {
                questionBox.Items.Add(questionList[i].Statment);
            }
        }

        private void QuestionBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            string selectedItem = comboBox.SelectedItem.ToString();

            for (int i = 0; i < questionList.Count; i++)
            {
                if (questionList[i].Statment == selectedItem)
                {
                    selectedQuestionBox = questionList[i];
                    SettingsButton_Click(sender, e);
                }
            }
        } //Saves the object Question

        private void EditQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (selectedQuestionBox != null)
            {
                string[] changedAnswers = new string[] { answer1TextChange.Text, answer2TextChange.Text, answer3TextChange.Text };
                questionList[oldQuestionId] = new Question(statmentTextChange.Text, changedAnswers, 0);


                string appdataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appdata");
                Directory.CreateDirectory(appdataPath);
                string localPath = Path.Combine(appdataPath, "local");
                Directory.CreateDirectory(localPath);
                string quizPath = Path.Combine(localPath, "The_Amazing_Quiz");
                Directory.CreateDirectory(quizPath);
                string questionPath = Path.Combine(quizPath, "Questions");
                Directory.CreateDirectory(questionPath);

                for (int i = 0; i < questionList.Count; i++)
                {
                    string filePath = Path.Combine(questionPath, $"Nr_{i + 1}_Question.json");

                    string questionJson = JsonConvert.SerializeObject(questionList[i]);
                    File.WriteAllText(filePath, questionJson);
                }

                selectedQuestionBox = null;
                MessageBox.Show("You've succesfully changed the question");
                SettingsButton_Click(sender, e);
            }
            else
            {
                MessageBox.Show("You haven't selected a question");
            }
        }

        private void SaveQuestion_Click(object sender, RoutedEventArgs e) // saves submited question
        {
            SaveQuestion();
            
            SettingsButton_Click(sender, e);
        }
        async Task SaveQuestion()
        {
            if (statment.Text.Length < 1 || answer1Text.Text.Length < 1 || answer2Text.Text.Length < 1 || answer3Text.Text.Length < 1)
            {
                MessageBox.Show("Some fileds were left empty");
            }
            else
            {
                string[] answers = new string[] { answer1Text.Text, answer2Text.Text, answer3Text.Text };
                int id = questionList.Count + 1;
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

                await Task.Run(async () =>
                {
                    for (int i = 0; i < questionList.Count; i++)
                    {
                        string filePath = Path.Combine(questionPath, $"Nr_{i + 1}_Question.json");

                        string questionJson = JsonConvert.SerializeObject(questionList[i]);
                        File.WriteAllText(filePath, questionJson);
                    }
                });
                MessageBox.Show("Your question was submited");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            switch (menu)
            {
                case CurrentMenu.Settings:
                    MainButton_Click(sender, e);
                    break;
                case CurrentMenu.QuizSettings:
                    SettingsButton_Click(sender, e);
                    break;
                case CurrentMenu.QuestionSettings:
                    SettingsButton_Click(sender, e);
                    break;
                case CurrentMenu.CreateQuiz:
                    //QuizSettingsButton_Click(sender, e);
                    break;
                case CurrentMenu.CreateQuestion:
                    //QuestionSettingsButton_Click(sender, e);
                    break;
                case CurrentMenu.EditQuiz:
                    //QuizSettingsButton_Click(sender, e);
                    break;
                case CurrentMenu.EditQuestion:
                    //QuestionSettingsButton_Click(sender, e);
                    break;
            }
        }//Universal Back button
    }
}
