using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Analizatori.Pagini
{
    public partial class UserControl3 : UserControl
    {
        List<Question> questionList = new List<Question>();

        List<string> lines=new List<string>();
        List<Label> questions=new List<Label>();
        List<ComboBox> answers=new List<ComboBox>();
        string[] correctAnswer=new string[9];

        public Action backToStartAction;
        public UserControl3()
        {
            InitializeComponent();
            testPanel.Hide();
            addQuestions();
        }
        private void addQuestions()
        {
            questions.Add(Question1Label);
            questions.Add(Question2Label);
            questions.Add(Question3Label);
            questions.Add(Question4Label);
            questions.Add(Question5Label);
            questions.Add(Question6Label);
            questions.Add(Question7Label);
            questions.Add(Question8Label);
            questions.Add(Question9Label);

            answers.Add(comboBox1);
            answers.Add(comboBox2);
            answers.Add(comboBox3);
            answers.Add(comboBox4);
            answers.Add(comboBox5);
            answers.Add(comboBox6);
            answers.Add(comboBox7);
            answers.Add(comboBox8);
            answers.Add(comboBox9);
        }
        public void reset()
        {
            foreach(ComboBox comboBox in answers)
                comboBox.Items.Clear();
            answers.RemoveRange(0,answers.Count);
            lines.Clear();
            questions.RemoveRange(0, questions.Count);
            for (int i = 0; i < 9; i++)
                correctAnswer[i] = "";
            addQuestions();
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            backToStartAction();
        }

        private void cutanatButton_Click(object sender, EventArgs e)
        {
            reset();
            parseFile(Properties.Resources.quiz_analizatorul_cutanat);
            parseLines();
            randomizeQuestions();
            testPanel.Show();
        }

        private void vizualButton_Click(object sender, EventArgs e)
        {
            reset();
            parseFile(Properties.Resources.quiz_analizatorul_vizual);
            parseLines();
            randomizeQuestions();
            testPanel.Show();
        }

        private void vestivularButton_Click(object sender, EventArgs e)
        {
            reset();
            parseFile(Properties.Resources.quiz_analizatorul_acustico_vestibular);
            parseLines();
            randomizeQuestions();
            testPanel.Show();
        }

        private void patologiiButton_Click(object sender, EventArgs e)
        {
            reset();
            parseFile(Properties.Resources.quiz_patologii);
            parseLines();
            randomizeQuestions();
            testPanel.Show();
        }
        void parseFile(string file)
        {
            string singleLine = "";
            for (int i = 0; i < file.Length; i++)
            {
                switch (file[i])
                {
                    case '\n':
                        lines.Add(singleLine);
                        singleLine = "";
                        break;
                    case '\r':
                        lines.Add(singleLine);
                        singleLine = "";
                        i++;
                        break;
                    case '\0':
                        lines.Add(singleLine);
                        singleLine = "";
                        break;
                    default:
                        singleLine += file[i];
                        break;        
                }
            }
            lines.Add(singleLine);
        }
        private void randomizeQuestions()
        {
            for (int i = 0; i < 9; i++) 
            {
                Random random = new Random();
                while(true)
                {
                    int temp = random.Next(0, questionList.Count);
                    if (questionList[temp].used==false)
                    {
                        questionList[temp].used = true;//trec intrebarea ca fiind folosita
                        //adaug datele in campuri
                        questions[i].Text = questionList[temp].text;
                        foreach(var answer in questionList[temp].answersList)
                            answers[i].Items.Add(answer);
                        correctAnswer[i] = questionList[temp].correctAnswer;
                        break;
                    }
                }
            }
        }
        private void parseLines()
        {
            int count = 0;
            while(lines.Count > count)
            {
                while (lines[count] == "")
                {
                    count++;
                    if (count == lines.Count)
                        break;
                }
                if (count == lines.Count)
                    break;
                Question question = new Question();
                question.text = lines[count++];
                question.answersCount = Convert.ToInt32(lines[count++]);
                for(int i=0;i<question.answersCount;i++)
                    question.answersList.Add(lines[count++]);
                question.correctAnswer = lines[count++];
                questionList.Add(question);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int score = 1;
            int count = 0;
            while (count < 9)
            {
                if (answers[count].Text == correctAnswer[count])
                    score++;
                count++;
            }
            MessageBox.Show("Scorul dumneavoastra este: " + score, "Scor!");
        }
    }
    public class Question
    {
        public string text;
        public List<string> answersList = new List<string>();
        public string correctAnswer;
        public int answersCount;
        public bool used = false;
    }
}
