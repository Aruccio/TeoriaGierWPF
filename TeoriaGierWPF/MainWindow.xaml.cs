using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Xaml;

namespace TeoriaGierWPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Operating opera = new Operating();
        List<List<Button>> buttons = new List<List<Button>>();
        List<List<CheckBox>> cbs = new List<List<CheckBox>>();
        public MainWindow()
        {
            InitializeComponent();
            Operating opera = new Operating();
        }

        public void ClearEv()
        {
            siatka.Children.RemoveRange(0, siatka.Children.Count);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            switch (button.Name)
            {
                case "startB":
                    //TODO nie ma kiedy użytkownik nic nie wpisze i bedzie n albo k nullem
                    //TODO nie ma innych zabezpieczeń.
                    int n = Convert.ToInt32(nVal.Text);
                    int k = Convert.ToInt32(kVal.Text);
                    if (k > 30 || n > 20) MessageBox.Show("Skąd masz tyle zapałek?!");
                    else
                    {
                        //włączenie rozgrywki
                        GetBoardReady(n,k);
                        GetSticksReady(n, k);
                        CreateLooseText(n, k);
                        //tutaj zmieniają się komponenty w oknie, te wszystkie buttony
                        //TODO click ma zmienić kolor konkretnego przycisku



                        //TODO funkcja, która usunie wszystkie przyciski ze zmienionym kolorem
                        //TODO przycisk następnej tury
                        //reszta później


                    }
                    break;
                case "clearB":
                    ClearEv();
                    break;
            }
        

        }

        private void CreateButton(int row, int col)
        {
            Button button = new Button();
            button.Height = 20;
            button.Width = 40;
            button.HorizontalAlignment = HorizontalAlignment.Center;
            button.VerticalAlignment = VerticalAlignment.Center;
            button.SetValue(Grid.RowProperty, row);
            button.SetValue(Grid.ColumnProperty, col);
            button.Background = Brushes.DarkBlue;
            button.Content = $"{col}/{row}";
            button.Foreground = Brushes.White;
        //    button.Margin = new Thickness(-5,-5,-5,-5);
            buttons[row-1][col-1]=button;

            siatka.Children.Add(button);

        }


        public void CreateTextBlock(string content, int row, int col)
        {
            TextBlock tb = new TextBlock();
            tb.Height = 30;
            tb.Width = 50;
            tb.HorizontalAlignment = HorizontalAlignment.Center;
            tb.VerticalAlignment = VerticalAlignment.Center;
            tb.SetValue(Grid.RowProperty, row);
            tb.SetValue(Grid.ColumnProperty, col);
            tb.Foreground = Brushes.DarkBlue;
            tb.Background = Brushes.LightGreen;
            tb.Text = content;
            siatka.Children.Add(tb);
        }

       public void CreateLooseText(int n, int k) //nie zapałki, a jedynie zerowe kolumny i rzędy
        {
            for (int i = 0; i < n; i++)
            {
                CreateTextBlock(Convert.ToString($"S: {i+1}"), 0,i+1);
            }

            // następne wiersze, tyle ile jest zapałek na stosie
            for (int i = 0; i < k; i++)
            {
                CreateTextBlock(Convert.ToString($"Z: {i+1}"), i+1,0);
            }

        }

       

        //wyczyszczenie całej planszy po starcie i podzielenie na kolumny i wiersze
        private void GetBoardReady(int n, int k)
        {
            ClearEv();
            siatka.RowDefinitions.Clear();
            siatka.ColumnDefinitions.Clear();
            
            //górny wiersz -- czyli liczba stosów i tak dalej -> row 1
            RowDefinition gridRow = new RowDefinition();
            gridRow.Name = "scores";
            gridRow.Height = new GridLength(40, GridUnitType.Pixel);                  //to z "1*" zamiast pikselowo
            siatka.RowDefinitions.Add(gridRow);

            //lewa kolumna na jakieś fajne rzeczy -> column 1
            ColumnDefinition gridCol = new ColumnDefinition();
            gridCol = new ColumnDefinition();
            gridCol.Name = Convert.ToString("menu");
            gridCol.Width = new GridLength(50, GridUnitType.Pixel);               //to z "2*" zamiast pikselowo
            siatka.ColumnDefinitions.Add(gridCol);


            //następne kolumny, tyle ile jest stosów
            for (int i = 0; i < n; i++)
            {
                //column i+1
                gridCol = new ColumnDefinition();
                gridCol.Name = Convert.ToString("Column" + (i+1));
                gridCol.Width = new GridLength(3, GridUnitType.Star);               //to z "2*" zamiast pikselowo
                siatka.ColumnDefinitions.Add(gridCol);
               
            }

           // następne wiersze, tyle ile jest zapałek na stosie
            for (int i = 0; i < k; i++)
            {
                //row i+1
                gridRow = new RowDefinition();
                gridRow.Name = Convert.ToString("Row" + (i+1));
                gridRow.Height = new GridLength(3, GridUnitType.Star);              //to z "2*" zamiast pikselowo
                siatka.RowDefinitions.Add(gridRow);
           }

        }
        
        //dodanie wszystkich zapałek-przycisków
        private void GetSticksReady(int n, int k)
        {
            for (int i = 0; i < k; i++)
            {
                buttons.Add(new List<Button>());
                for (int j=0; j < n; j++)
                    buttons[i].Add(new Button());
            }

            for (int i = 1; i <= k; i++)
                for (int j = 1; j <= n; j++)
                    CreateButton(i, j);



        }
    }
}
    
