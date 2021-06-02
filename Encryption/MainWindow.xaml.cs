using Microsoft.Win32;
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


namespace Encryption
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        const int MinLowercaseLetter = 97;
        const int MinCapitalLetter = 65;
        const int MaxLowercaseLetter = 122;
        const int MaxCapitalLetter = 90;


        string NewString = "";
        string[] ArrayDecrypt = new string[1000];
        int k = 0;
        Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
        private void Save(object sender, RoutedEventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, MainTextBox.Text);
        }
        private void ClickOpenFile(object sender, EventArgs e)
        {
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.Filter = "Text documents (.txt)|*.txt|All Files (*.*)|*.*";
            dialog.FileName = "Filename.txt";
            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, MainTextBox.Text);
            }
        
        } 
        private void ExitProgram(object sender, EventArgs e)
        {
            App.Current.Shutdown();
        }
        private void MainButtonClick(object sender, RoutedEventArgs e)
        {
            

            string str = MainTextBox.Text;
            ArrayDecrypt[k] = str;


            int key = Convert.ToInt32(KeyTextBox.Text);

           
            string Phone_List_Item = phonesList.Text;

            if (Phone_List_Item == "Crypt")
            {


                foreach (char letter in str)
                {


                    int NewLetter = Convert.ToInt32(letter) + key;


                    if (
                        NewLetter > MinCapitalLetter & NewLetter < MaxCapitalLetter + key + 1
                        |
                        NewLetter > MinLowercaseLetter & NewLetter < MaxLowercaseLetter + key + 1
                        )
                    {
                        

                        if (NewLetter > MaxCapitalLetter & NewLetter < MinLowercaseLetter)
                            NewLetter = MinCapitalLetter + (NewLetter - MaxCapitalLetter);


                        if (NewLetter > MaxLowercaseLetter)
                            NewLetter = MinLowercaseLetter + (NewLetter - MaxLowercaseLetter);


                        NewString += Convert.ToChar(NewLetter);


                    }
                    else
                        NewString += Convert.ToChar(letter);

                }

               
                MainTextBox.Text = NewString;

                NewString = "";

                k++;

            }
            else
            {
                if (k > 0)
                {

                    k--;
                    MainTextBox.Text = ArrayDecrypt[k];


                    NewString = "";

                }
            }
        }
    }
}
