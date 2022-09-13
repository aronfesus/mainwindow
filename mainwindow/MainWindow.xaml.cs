using System;
using System.Collections.Generic;
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

namespace mainwindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           

            var questions = File.ReadAllLines("questions.txt");

            List <Questions> question_list = new List<Questions>();
            foreach (var question in questions)
            {
                var q = new Questions(question.Split(':')[0], question.Split(':')[1], question.Split(':')[2], 
                    question.Split(':')[3], question.Split(':')[4], question.Split(':')[5]);

                question_list.Add(q);
            }
            

            question_list.ForEach(t =>
           {
               Label l = new Label();
               l.Tag = t;
               l.Background = Brushes.LightBlue;
               l.Margin = new Thickness(20);
               l.Width = this.ActualWidth / 6;
               l.Height = this.ActualHeight / 6;
               wrap.Children.Add(l);

               l.MouseLeftButtonDown += L_MouseLeftButtonDown;
           });
        }

        private void L_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }

    internal class Questions
    {
        private string question;
        private string answer1;
        private string answer2;
        private string answer3;
        private string answer4;
        private string good_answer;
        private bool correct;

        public Questions(string q, string a1, string a2, string a3, string a4, string good_answer)
        {
            this.Question = q;
            this.Answer1 = a1;
            this.Answer2 = a2;
            this.Answer3 = a3;
            this.Answer4 = a4;
            this.Good_Answer = good_answer;
        }

        public string Question { get => question; set => question = value; }
        public string Answer1 { get => answer1; set => answer1 = value; }
        public string Answer2 { get => answer2; set => answer2 = value; }
        public string Answer3 { get => answer3; set => answer3 = value; }
        public string Answer4 { get => answer4; set => answer4 = value; }
        public string Good_Answer { get => good_answer; set => good_answer = value; }

        public bool Correct { get => correct; set => correct = value; }
    }
}
