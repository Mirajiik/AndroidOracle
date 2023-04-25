using System;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AndroidOracle
{
    internal class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {
            GenerateAnswersCommand = new Command(GenerateAnswers);
            HistoryAnswers = new ObservableCollection<string>();
        }

        private string answer = "";
        public string Answer 
        {
            get => answer;
            set => Set(ref answer, value);
        }
        private bool answerSwitcher = false;
        public bool AnswerSwitcher
        {
            get => answerSwitcher;
            set => Set(ref answerSwitcher, value);
        }
        public ObservableCollection<string> HistoryAnswers { get; set; }
        public ICommand GenerateAnswersCommand { get;  }

        //Random rnd = new Random();
        RandomNumberGenerator rnd = RandomNumberGenerator.Create();
        byte[] result = new byte[1];
        private async void GenerateAnswers()
        { 
            int y = 0, n = 0;
            HistoryAnswers.Clear();
            Answer = "";
            if (answerSwitcher)
            {
                while ((y != 3) && (n != 3))
                {
                    rnd.GetBytes(result);
                    if (result[0] % 2 == 0)
                    {
                        n++;
                        HistoryAnswers.Add("Нет");
                    }
                    else
                    {
                        y++;
                        HistoryAnswers.Add("Да");
                    }
                    if ((y != 3) && (n != 3))
                        await Task.Delay(1000);
                    
                }
            }
            else
            {
                rnd.GetBytes(result);
                if (result[0] % 2 == 0)
                    n = 3;
                else
                    y = 3;
            }
            Answer = n == 3 ? "Нет" : "Да";            
        }
    }
}
