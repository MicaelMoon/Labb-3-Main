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
        StartUp,
        Main,
        Settings,
        ScoreBord
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
        private TextBox quizTitleText;

        TextBlock questionText;
        Button answerButton1;
        Button answerButton2;
        Button answerButton3;

        public Quiz quizPlay;
        public ComboBoxItem chooseQuiz = new ComboBoxItem();
        public ComboBoxItem titleItem2 = new ComboBoxItem();
        ProgressBar answersRight;

        public Question selectedQuestionBox;
        public Quiz selectedQuizBox;

        public int oldQuestionId;
        public int selectedQuizBoxID;
        public int currentQuestion = 0;
        public int rAnswer = 0;
        public int points = 0;
        public double progressBarIncrement;
        public bool quizIsSelected = false;

        public static CurrentMenu menu;


        public MainWindow()
        {
            LoadInContent();
            InitializeComponent();
        }

        async Task LoadInContent() // Får nästa gån rad måste nog lägga till dessa frågor i mappen pga System.ArgumentOutOfRangeException: på rad 975
        {
            menu = CurrentMenu.StartUp;
            string appdataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appdata");
            Directory.CreateDirectory(appdataPath);
            string localPath = Path.Combine(appdataPath, "local");
            Directory.CreateDirectory(localPath);
            string theQuizPath = Path.Combine(localPath, "The_Amazing_Quiz");
            Directory.CreateDirectory(theQuizPath);
            string quizPath = Path.Combine(theQuizPath, "Quizzes");
            Directory.CreateDirectory(quizPath);
            string questionPath = Path.Combine(theQuizPath, "Questions");
            Directory.CreateDirectory(questionPath);

            string[] questionFiles = Directory.GetFiles(questionPath, "*Question.json");
            string[] quizzesFiles = Directory.GetFiles(quizPath, "*Quiz.json");

            if(questionFiles.Length == 0 || quizzesFiles.Length == 0) // if its your fist time opening the application it will add the set number of base questions and quizzes to json i chosen files
            {
                string[] answers1 = new string[3];
                string[] answers2 = new string[3];
                string[] answers3 = new string[3];
                string[] answers4 = new string[3];
                string[] answers5 = new string[3];
                string[] answers6 = new string[3];
                string[] answers7 = new string[3];
                string[] answers8 = new string[3];
                string[] answers9 = new string[3];
                string[] answers10 = new string[3];
                string[] answers11 = new string[3];
                string[] answers12 = new string[3];
                string[] answers13 = new string[3];
                string[] answers14 = new string[3];
                string[] answers15 = new string[3];
                string[] answers16 = new string[3];
                string[] answers17 = new string[3];
                string[] answers18 = new string[3];

                //Creates Haloween themed questions
                string statment = "Why did the skeleton go to the pary alone?";
                answers1[0] = "Because he had no body to go with";
                answers1[1] = "Because he had no backbone";
                answers1[2] = "Because he was ugly, fat and nobody liked him";
                Question question1 = new Question(statment, answers1, 0);
                questionList.Add(question1);

                statment = "Why dont mummies take vacation?";
                answers2[0] = "They're afraid they'll relax and unwind.";
                answers2[1] = "They cant fine their tomb passport.";
                answers2[2] = "They're afrain they'll get wrapped up in the details";
                Question question2 = new Question(statment, answers2, 0);
                questionList.Add(question2);

                statment = "What kind of monster loves to disco?";
                answers3[0] = "The Boggie man.";
                answers3[1] = "The pumpkin king.";
                answers3[2] = " The ghostly grove.";
                Question question3 = new Question(statment, answers3, 0);
                questionList.Add(question3);

                statment = "What do you call a witch who lives at the beach?";
                answers4[0] = "A sandy witch.";
                answers4[1] = "A sea witch.";
                answers4[2] = "A beatch hag.";
                Question question4 = new Question(statment, answers4, 0);
                questionList.Add(question4);

                statment = "What do you get if you cross a vampire with a snowman?";
                answers5[0] = "Frostbite.";
                answers5[1] = "Frosty the Fangman.";
                answers5[2] = "Count Chocula";
                Question question5 = new Question(statment, answers5, 0);
                questionList.Add(question5);

                statment = "Why was the skeleton so calm?";
                answers6[0] = "Because nothing gets under its skin.";
                answers6[1] = "FBecause it had a good body image.";
                answers6[2] = "Because it had no guts no to be nervous";
                Question question6 = new Question(statment, answers6, 0);
                questionList.Add(question6);

                statment = "What's a vampires favorite fruit?";
                answers7[0] = "Blood orange.";
                answers7[1] = "Vampberry.";
                answers7[2] = "Fangtastic fruit";
                Question question7 = new Question(statment, answers7, 0);
                questionList.Add(question7);

                statment = "Why did the scarecrow win and award?";
                answers8[0] = "Because it was outstanding in its field.";
                answers8[1] = "Because it had a straw-some personality.";
                answers8[2] = "Because it had a pumpkin for a head.";
                Question question8 = new Question(statment, answers8, 0);
                questionList.Add(question8);

                statment = "What do you get if you cross a mummy and a vampire?";
                answers9[0] = "A coffin dodger.";
                answers9[1] = "A very wrapped up vampire.";
                answers9[2] = "A pain in the neck";
                Question question9 = new Question(statment, answers9, 0);
                questionList.Add(question9);

                statment = "Why did the ghost go to the party?";
                answers10[0] = "To have a hauntingly good time.";
                answers10[1] = "To find its boo.";
                answers10[2] = "To scare up some fun.";
                Question question10 = new Question(statment, answers10, 0);
                questionList.Add(question10);

                //Adds the chrismas themed questions
                statment = "Why did the christmas tree go to the barber?";
                answers11[0] = "It wanted a trim.";
                answers11[1] = "It had to many needles.";
                answers11[2] = "It needed a new hairstylefor the holidays.";
                Question question11 = new Question(statment, answers11, 0);
                questionList.Add(question11);

                statment = "What do you get when you cross a snowman with a dog?";
                answers12[0] = "Frosty paws.";
                answers12[1] = "Frostbite.";
                answers12[2] = "Snowy barks.";
                Question question12 = new Question(statment, answers12, 0);
                questionList.Add(question12);

                statment = "Why was the math book sad at christmas?";
                answers13[0] = "Because it had to many problems.";
                answers13[1] = "Because it was on the naughty list.";
                answers13[2] = "Because it couldnt count on santa.";
                Question question13 = new Question(statment, answers13, 0);
                questionList.Add(question13);

                statment = "What do call a snowman with a sixpack?";
                answers14[0] = "Snow Abs.";
                answers14[1] = "Frost the Fit man.";
                answers14[2] = "An abdominal snowman.";
                Question question14 = new Question(statment, answers14, 0);
                questionList.Add(question14);

                statment = "Why was the Christmas tree so bad at knitting?";
                answers15[0] = "Because it kept dropping its needles.";
                answers15[1] = "Because it couldn't purl properly.";
                answers15[2] = "Because it was always tangled up in its work.";
                Question question15 = new Question(statment, answers15, 0);
                questionList.Add(question15);

                statment = "What did one ornament say to the other?";
                answers16[0] = "You light up my life.";
                answers16[1] = "You're a real ball.";
                answers16[2] = "You're hanging around again.";
                Question question16 = new Question(statment, answers16, 0);
                questionList.Add(question16);

                statment = "What do you call a snowman with a carrot nose, a scarf, and a top hat?";
                answers17[0] = "Frosty.";
                answers17[1] = "Well-dressed";
                answers17[2] = "Stylish snowman";
                Question question17 = new Question(statment, answers17, 0);
                questionList.Add(question17);

                statment = "Why did the gingerbread man go to the doctor?";
                answers18[0] = "Because he felt crumby.";
                answers18[1] = "Because he had a sugar rush.";
                answers18[2] = "Because he was running away from the frosting.";
                Question question18 = new Question(statment, answers18, 0);
                questionList.Add(question18);

                //Creates quiz, adds to the quizList and adds the questions to the quiz
                Quiz quiz1 = new Quiz("Spooky quiz");
                Quiz quiz2 = new Quiz("Happy holidays");
                quiz1.AddQuestion(question1);
                quiz1.AddQuestion(question2);
                quiz1.AddQuestion(question3);
                quiz1.AddQuestion(question4);
                quiz1.AddQuestion(question5);
                quiz1.AddQuestion(question6);
                quiz1.AddQuestion(question7);
                quiz1.AddQuestion(question8);
                quiz1.AddQuestion(question9);
                quiz1.AddQuestion(question10);
                quiz2.AddQuestion(question11);
                quiz2.AddQuestion(question12);
                quiz2.AddQuestion(question13);
                quiz2.AddQuestion(question14);
                quiz2.AddQuestion(question15);
                quiz2.AddQuestion(question16);
                quiz2.AddQuestion(question17);
                quiz2.AddQuestion(question18);

                quizList.Add(quiz1);
                quizList.Add(quiz2);

                await Task.Run(async () =>
                {
                    for (int i = 0; i < questionList.Count; i++)
                    {
                        string filePath = Path.Combine(questionPath, $"Nr_{i + 1}_Question.json");
                        string questionJson = JsonConvert.SerializeObject(questionList[i]);

                        File.WriteAllText(filePath, questionJson);
                    }

                    for (int i = 0; i < quizList.Count; i++)
                    {
                        string filePath = Path.Combine(quizPath, $"Nr_{i + 1}_Quiz.json");
                        string quizJson = JsonConvert.SerializeObject(quizList[i]);

                        File.WriteAllText(filePath, quizJson);
                    }
                });
            }

            questionFiles = Directory.GetFiles(questionPath, "*Question.json");
            quizzesFiles = Directory.GetFiles(quizPath, "*Quiz.json");

            //Question question = null;
            //Quiz quiz = null;

            try
            {
                await Task.Run(async () =>
                {
                    foreach (var q in questionFiles)
                    {
                        string json = await File.ReadAllTextAsync(q);
                        var question = JsonConvert.DeserializeObject<Question>(json);
                        questionList.Add(question);
                    }
                    foreach (var q in quizzesFiles)
                    {
                        string json = await File.ReadAllTextAsync(q);
                        var quiz = JsonConvert.DeserializeObject<Quiz>(json);
                        quizList.Add(quiz);
                    }
                });
            }
            catch
            {

            }
        }

        private void MainButton_Click(object sender, RoutedEventArgs e)
        {
            menu = CurrentMenu.Main;
            CreateGrid.Grid_Main(MainGrid);
            currentQuestion = 0;
    

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

            TextBlock chooseQuizText = new TextBlock
            {
                Text = "Choose your quiz",
                Width = 200,
                Height = 200,
                FontSize = 20,
                Margin = new Thickness(25, 0, 0, 220)
            };
            MainGrid.Children.Add(chooseQuizText);
            chooseQuizText.SetValue(Grid.RowProperty, 1);
            chooseQuizText.SetValue(Grid.ColumnProperty, 1);


            ComboBox chooseQuiz = new ComboBox();
            MainGrid.Children.Add(chooseQuiz);
            chooseQuiz.Width = 400;
            chooseQuiz.Height = 20;
            chooseQuiz.Margin = new Thickness(0, 0, 0, 350);
            chooseQuiz.SetValue(Grid.ColumnProperty, 1);
            chooseQuiz.SetValue(Grid.RowProperty, 1);


            ComboBoxItem titleItem = new ComboBoxItem
            {
                Content = "Quizzes",
                IsEnabled = false,
                FontWeight = FontWeights.Bold,
            };
            chooseQuiz.Items.Add(titleItem);
            chooseQuiz.SelectionChanged += ChosenQuiz_SelectionChanged;
            chooseQuiz.SelectionChanged += (sender, e) =>
            {

            };

            try
            {
                for (int i = 0;i < quizList.Count; i++)
                {
                    chooseQuiz.Items.Add(quizList[i].Title);
                }
            }
            catch
            {

            }
        }

        private void ChosenQuiz_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            string data = comboBox.SelectedItem.ToString();

            foreach (var q in quizList)
            {
                if (q.Title == data)
                {
                    quizPlay = q;
                }
            }
            quizIsSelected = true;
        }

        private void StartQuiz_Click(object sender, RoutedEventArgs e)
        {
            if(quizIsSelected == false)
            {
                MessageBox.Show("You need to select a quiz to start");
            }
            else
            {
                CreateGrid.Grid_Play(MainGrid);

                List<int> alreadyTaken = new List<int>();

                Random random = new Random();

                alreadyTaken.Clear();

                rAnswer = random.Next(0, 3);

                quizPlay.RandomizeQuisions();
                progressBarIncrement = 100 /(quizPlay._randomizedQuestions.Count);

                answersRight = new ProgressBar
                {
                    Width = 400,
                    Height = 30
                };
                MainGrid.Children.Add(answersRight);
                answersRight.SetValue(Grid.RowProperty, 1);
                answersRight.SetValue(Grid.ColumnProperty, 2);

                questionText = new TextBlock
                {
                    Text = quizPlay._randomizedQuestions[currentQuestion].Statment,
                    Width = 1300,
                    Height = 200,
                    FontSize = 40,
                    Margin = new Thickness(0, 0, 0, 300)
                };
                MainGrid.Children.Add(questionText);
                questionText.SetValue(Grid.RowProperty, 1);
                questionText.SetValue(Grid.ColumnProperty, 1);
                questionText.SetValue(Grid.ColumnSpanProperty, 3);
                questionText.SetValue(Grid.RowSpanProperty, 3);


                do
                {
                    rAnswer = random.Next(0, 3);
                }
                while (alreadyTaken.Contains(rAnswer));
                alreadyTaken.Add(rAnswer);


                answerButton1 = new Button
                {
                    Content = quizPlay._randomizedQuestions[currentQuestion].Answers[rAnswer],
                    Width = 650,
                    Height = 80,
                    FontSize = 25,
                    Margin = new Thickness(0, 0, 0, 200)
                };
                MainGrid.Children.Add(answerButton1);
                answerButton1.SetValue(Grid.RowProperty, 2);
                answerButton1.SetValue(Grid.ColumnProperty, 1);
                answerButton1.Click += AnwerButton1_CLick;

                do
                {
                    rAnswer = random.Next(0, 3);
                }
                while (alreadyTaken.Contains(rAnswer));

                alreadyTaken.Add(rAnswer);


                answerButton2 = new Button
                {
                    Content = quizPlay._randomizedQuestions[currentQuestion].Answers[rAnswer],
                    Width = 650,
                    Height = 80,
                    FontSize = 25,
                };
                MainGrid.Children.Add(answerButton2);
                answerButton2.SetValue(Grid.RowProperty, 2);
                answerButton2.SetValue(Grid.ColumnProperty, 1);
                answerButton2.Click += AnwerButton2_CLick;

                do
                {
                    rAnswer = random.Next(0, 3);
                }
                while (alreadyTaken.Contains(rAnswer));

                alreadyTaken.Add(rAnswer);

                answerButton3 = new Button
                {
                    Content = quizPlay._randomizedQuestions[currentQuestion].Answers[rAnswer],
                    Width = 650,
                    Height = 80,
                    FontSize = 25,
                    Margin = new Thickness(0, 200, 0, 0)
                };
                MainGrid.Children.Add(answerButton3);
                answerButton3.SetValue(Grid.RowProperty, 2);
                answerButton3.SetValue(Grid.ColumnProperty, 1);
                answerButton3.Click += AnwerButton3_CLick;

            }
        }

        private void UpdateQuestionValues()
        {
            try 
            {
                List<int> alreadyTaken = new List<int>();

                Random random = new Random();
                questionText.Text = quizPlay._randomizedQuestions[currentQuestion].Statment;// Updates the statnebt text

                for (int i = 0; i < 3; i++)
                {
                    do
                    {
                        rAnswer = random.Next(0, 3);
                    }
                    while (alreadyTaken.Contains(rAnswer));

                    if (i == 0)
                    {
                        answerButton1.Content = quizPlay._randomizedQuestions[currentQuestion].Answers[rAnswer];
                    }
                    else if (i == 1)
                    {
                        answerButton2.Content = quizPlay._randomizedQuestions[currentQuestion].Answers[rAnswer];
                    }
                    else if (i == 2)
                    {
                        answerButton3.Content = quizPlay._randomizedQuestions[currentQuestion].Answers[rAnswer];
                    }
                    alreadyTaken.Add(rAnswer);
                }
            }
            catch(System.ArgumentOutOfRangeException)
            {
                GameFinished();
            }

        }

        private void GameFinished()
        {
            menu = CurrentMenu.ScoreBord;

            CreateGrid.Grid_Play(MainGrid);

            TextBlock textBlock = new TextBlock
            {
                Text = "Concratulations, You've finished the quiz\n" +
                $"You answered {Math.Round(progressBarIncrement * points,2)}% of the questions right\n" +
                $"Scoring a total of {points} out of {quizPlay._randomizedQuestions.Count}.",
                FontSize = 50,
                
            };
            MainGrid.Children.Add(textBlock);
            textBlock.SetValue(Grid.RowProperty, 1);
            textBlock.SetValue(Grid.ColumnProperty, 1);
            textBlock.SetValue(Grid.ColumnSpanProperty, 2);

            Button button = new Button
            {
                Content = "Menu",
                Width = 400,
                Height = 200,
                FontSize = 30,
                Margin = new Thickness(0, 0, 0, 0)
            };
            MainGrid.Children.Add(button);
            button.SetValue(Grid.RowProperty, 2);
            button.SetValue(Grid.ColumnProperty, 1);
            button.SetValue(Grid.ColumnSpanProperty, 2);
            button.Click += BackButton_Click;

            points = 0;
        }

        private void AnwerButton1_CLick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button.Content == quizPlay._randomizedQuestions[currentQuestion].Answers[quizPlay._randomizedQuestions[currentQuestion].CorrectAnswer])
            {
                //MessageBox.Show("Correct answer");
                answersRight.Value += progressBarIncrement;
                points++;
            }
            else
            {
                //MessageBox.Show("Wrong answer");
            }
            currentQuestion++;
            UpdateQuestionValues();
            //button.Content = quizPlay._randomizedQuestions[currentQuestion].Answers[rAnswer];
            //StartQuiz_Click(sender, e);
        }

        private void AnwerButton2_CLick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button.Content == quizPlay._randomizedQuestions[currentQuestion].Answers[quizPlay._randomizedQuestions[currentQuestion].CorrectAnswer])
            {
                //MessageBox.Show("Correct answer");
                answersRight.Value += progressBarIncrement;
                points++;
            }
            else
            {
                //MessageBox.Show("Wrong answer");
            }
            currentQuestion++;
            UpdateQuestionValues();
            //button.Content = quizPlay._randomizedQuestions[currentQuestion].Answers[rAnswer];
            //StartQuiz_Click(sender, e);
        }

        private void AnwerButton3_CLick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button.Content == quizPlay._randomizedQuestions[currentQuestion].Answers[quizPlay._randomizedQuestions[currentQuestion].CorrectAnswer])
            {
                //MessageBox.Show("Correct answer");
                answersRight.Value += progressBarIncrement;
                points++;
            }
            else
            {
                //MessageBox.Show("Wrong answer");
            }
            currentQuestion++;
            UpdateQuestionValues();
            //button.Content = quizPlay._randomizedQuestions[currentQuestion].Answers[rAnswer];
            //StartQuiz_Click(sender, e);
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            menu = CurrentMenu.Settings;
            CreateGrid.Grid_Settings(MainGrid);

            TextBlock title = new TextBlock();
            MainGrid.Children.Add(title);
            title.Text = "Create your question";
            title.SetValue(Grid.RowProperty, 3);
            title.SetValue(Grid.ColumnProperty, 1);
            title.SetValue(Grid.ColumnSpanProperty, 4);
            title.FontSize = 40;
            title.Height = 50;

            TextBlock chooseQuiz = new TextBlock();
            MainGrid.Children.Add(chooseQuiz);
            chooseQuiz.Text = "Create your quiz";
            chooseQuiz.SetValue(Grid.RowProperty, 3);
            chooseQuiz.SetValue(Grid.ColumnProperty, 5);
            chooseQuiz.SetValue(Grid.ColumnSpanProperty, 4);
            chooseQuiz.FontSize = 40;
            chooseQuiz.Height = 50;

            TextBlock quizTitle = new TextBlock();
            MainGrid.Children.Add(quizTitle);
            quizTitle.Text = "Title : ";
            quizTitle.SetValue(Grid.RowProperty, 4);
            quizTitle.SetValue(Grid.ColumnProperty, 5);
            quizTitle.SetValue(Grid.ColumnSpanProperty, 2);
            quizTitle.FontSize = 25;
            quizTitle.Height = 35;

            TextBlock comboboxTitle1 = new TextBlock();
            MainGrid.Children.Add(comboboxTitle1);
            comboboxTitle1.Text = "Select question";
            comboboxTitle1.SetValue(Grid.RowProperty, 1);
            comboboxTitle1.SetValue(Grid.ColumnProperty, 3);
            comboboxTitle1.SetValue(Grid.ColumnSpanProperty, 4);
            comboboxTitle1.Margin = new Thickness(0,0,0,20);
            comboboxTitle1.FontSize = 25;
            comboboxTitle1.Height = 25;

            quizTitleText = new TextBox();
            MainGrid.Children.Add(quizTitleText);
            quizTitleText.SetValue(Grid.RowProperty, 4);
            quizTitleText.SetValue(Grid.ColumnProperty, 5);
            quizTitleText.SetValue(Grid.ColumnSpanProperty, 6);
            quizTitleText.FontSize = 20;
            quizTitleText.Width = 400;
            quizTitleText.Height = 30;

            TextBlock titleChange = new TextBlock();
            MainGrid.Children.Add(titleChange);
            titleChange.SetValue(Grid.RowProperty, 9);
            titleChange.SetValue(Grid.ColumnProperty, 1);
            titleChange.SetValue(Grid.ColumnSpanProperty, 6);
            titleChange.Text = "Edit selected question";
            titleChange.FontSize = 40;
            titleChange.Height = 50;

            TextBlock question = new TextBlock();
            MainGrid.Children.Add(question);
            question.Text = "Statment : ";
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
            if (selectedQuizBox != null)
            {
                quizTitleText.Text = selectedQuizBox.Title;
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

            Button addButton = new Button
            {
                Content = "Create",
                Width = 70,
                Height = 35,
                FontSize = 20
            };
            MainGrid.Children.Add(addButton);
            addButton.SetValue(Grid.RowProperty, 8);
            addButton.SetValue(Grid.ColumnProperty, 5);
            addButton.SetValue(Grid.RowSpanProperty, 2);
            addButton.Click += SaveQuiz_Click;
            addButton.Margin = new Thickness(0, 0, 0, 50);

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

            Button AddQuestionToQuizButton = new Button
            {
                Content = "Add",
                Width = 70,
                Height = 35,
                FontSize = 20
            };
            MainGrid.Children.Add(AddQuestionToQuizButton);
            AddQuestionToQuizButton.SetValue(Grid.RowProperty, 17);
            AddQuestionToQuizButton.SetValue(Grid.ColumnProperty, 4);
            AddQuestionToQuizButton.SetValue(Grid.RowSpanProperty, 2);
            AddQuestionToQuizButton.Click += AddQuestionToQuiz_Click;

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
            questionBox.SetValue(Grid.RowProperty, 2);
            questionBox.SetValue(Grid.ColumnSpanProperty, 4);


            ComboBoxItem titleItem = new ComboBoxItem
            {
                Content = "Questions",
                IsEnabled = false,
                FontWeight = FontWeights.Bold,
            };
            questionBox.Items.Add(titleItem);
            questionBox.SelectionChanged += QuestionBox_SelectionChanged;


            ComboBox quizBox = new ComboBox
            {
                Width = 400,
                Height = 20,
            };
            MainGrid.Children.Add(quizBox);
            quizBox.SetValue(Grid.ColumnProperty, 5);
            quizBox.SetValue(Grid.RowProperty, 2);
            quizBox.SetValue(Grid.ColumnSpanProperty, 4);

            ComboBoxItem titleItem2 = new ComboBoxItem
            {
                Content = "Quizzes",
                IsEnabled = false,
                FontWeight = FontWeights.Bold,
            };
            quizBox.Items.Add(titleItem2);
            quizBox.SelectionChanged += QuizBox_SelectionChanged;


            try
            {
                for (int i = 0; i < questionList.Count; i++)
                {
                    questionBox.Items.Add(questionList[i].Statment);
                }
            }
            catch
            {

            }

            try
            {
                for (int i = 0; i < quizList.Count; i++)
                {
                    quizBox.Items.Add(quizList[i].Title);
                }
            }
            catch
            {

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
                    oldQuestionId = i;
                    SettingsButton_Click(sender, e);
                }
            }
        } //Saves the object Question

        private void QuizBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            string selectedItem = comboBox.SelectedItem.ToString();

            for (int i = 0; i < quizList.Count; i++)
            {
                if (quizList[i].Title == selectedItem)
                {
                    selectedQuizBox = quizList[i];
                    selectedQuizBoxID = i;
                    SettingsButton_Click(sender, e);
                }
            }
        }

        private void AddQuestionToQuiz_Click(object sender, RoutedEventArgs e)
        {
            quizList[selectedQuizBoxID].AddQuestion(selectedQuestionBox);
            Quiz.UpdateFiles();
        }

        private void EditQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (selectedQuestionBox != null)
            {
                string[] changedAnswers = new string[] { answer1TextChange.Text, answer2TextChange.Text, answer3TextChange.Text };
                Question question = new Question(statmentTextChange.Text, changedAnswers, 0);
                questionList[oldQuestionId] = question;



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

        private void SaveQuiz_Click(object sender, RoutedEventArgs e)
        {
            SaveQuiz(sender, e);

            SettingsButton_Click(sender, e);
        }

        async Task SaveQuiz(object sender, RoutedEventArgs e)
        {
            if (quizTitleText.Text.Length < 1)
            {
                MessageBox.Show("You need to enter a title for your quiz");
            }
            else
            {
                Quiz quiz = new Quiz(quizTitleText.Text);



                for (int i = 0; i < questionList.Count; i++)
                {
                    if (questionList[i] == selectedQuestionBox)
                    {
                        quiz._questions.Add(questionList[i]);
                    }
                }

                if(quiz._questions.Count < 1)
                {
                    MessageBox.Show("You need to add at least one question to your quiz");
                    SettingsButton_Click(sender, e);
                }
                else
                {

                    quizList.Add(quiz);

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
                        for (int i = 0; i < quizList.Count; i++)
                        {
                            string filePath = Path.Combine(quizzesPath, $"Nr_{i + 1}_Quiz.json");
                            string quizJson = JsonConvert.SerializeObject(quizList[i]);

                            File.WriteAllText(filePath, quizJson);
                        }
                    });

                    MessageBox.Show("Quiz was succesfully added");
                }
            }
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
                questionList.Add(question);

                string appdataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appdata");
                Directory.CreateDirectory(appdataPath);
                string localPath = Path.Combine(appdataPath, "local");
                Directory.CreateDirectory(localPath);
                string quizPath = Path.Combine(localPath, "The_Amazing_Quiz");
                Directory.CreateDirectory(quizPath);
                string questionPath = Path.Combine(quizPath, "Questions");
                Directory.CreateDirectory(questionPath);


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
                case CurrentMenu.ScoreBord:
                    MainButton_Click(sender, e);
                    break;
            }
        }//Universal Back button
    }
}
