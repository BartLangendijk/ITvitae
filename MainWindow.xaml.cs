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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Yahtzee2
{ 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
public partial class MainWindow : Window
    {

    #region ints bools strings, weet ik t

    bool Roll_clicked = false;
    bool Player1_turn = true;
    bool End_clicked = false;
    int Score = 0;
    int Pl1Score = 0;
    int Pl2Score = 0;
    bool Roll_clicked2 = false;
    bool Roll_clicked3 = false;
    int value1 = 0;
    int count1 = 0;
    int value2 = 0;
    int count2 = 0;
    int value3 = 0;
    int count3 = 0;
    int value4 = 0;
    int count4 = 0;
    int value5 = 0;
    int count5 = 0;
    int value6 = 0;
    int count6 = 0;


    #endregion

    public MainWindow()
    {
        InitializeComponent();
    }

    /// <summary>
    /// dit gedrocht telt de dobbelstenen
    /// </summary>
    private void same()
    {
        var list = new List<int>
            {
                int.Parse(Die1.Content.ToString()),
                int.Parse(Die2.Content.ToString()),
                int.Parse(Die3.Content.ToString()),
                int.Parse(Die4.Content.ToString()),
                int.Parse(Die5.Content.ToString())
            };

        var q = list.GroupBy(x => x)
        .Select(g => new { Value = g.Key, Count = g.Count() })
        .OrderByDescending(x => x.Count);

        foreach (var x in q)
        {
            Console.WriteLine("Value: " + x.Value + " Count: " + x.Count);

            switch (x.Value)
            {
                case 1:
                    value1 += 1;
                    count1 += x.Count;
                    break;
                case 2:
                    value2 += 2;
                    count2 += x.Count;
                    break;
                case 3:
                    value3 += 3;
                    count3 += x.Count;
                    break;
                case 4:
                    value4 += 4;
                    count4 += x.Count;
                    break;
                case 5:
                    value5 += 5;
                    count5 += x.Count;
                    break;
                case 6:
                    value6 += 6;
                    count6 += x.Count;
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// klik op een dobbelsteen
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Die_Click(object sender, RoutedEventArgs e)
    {
        //verander de achtergrond naar groen en wit
        if ((((Button)sender).Background == Brushes.White) && (Roll_clicked != false))
        {
            ((Button)sender).Background = Brushes.Green;
        }
        else
        {
            ((Button)sender).Background = Brushes.White;
        }
        //Score += Convert.ToInt32(((Button)sender).Content);
    }

    /// <summary>
    /// het begin van een pot
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        Player1Score.Background = Brushes.Green;
        Player1Score.Text = Player2Score.Text = "0";
        Die1.Content = Die2.Content = Die3.Content = Die4.Content = Die5.Content = 0;
    }

    /// <summary>
    /// klik de roll knop
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (Roll_clicked2 == true)
        {
            RollButton.Content = "End Turn";
        }

        if (Roll_clicked3 == true)
        {
            return;
        }

        Random Rnd = new Random();

        if (Die1.Background != Brushes.Green)
        {
            Die1.Content = Rnd.Next(1, 7);
        }
        if (Die2.Background != Brushes.Green)
        {
            Die2.Content = Rnd.Next(1, 7);
        }
        if (Die3.Background != Brushes.Green)
        {
            Die3.Content = Rnd.Next(1, 7);
        }
        if (Die4.Background != Brushes.Green)
        {
            Die4.Content = Rnd.Next(1, 7);
        }
        if (Die5.Background != Brushes.Green)
        {
            Die5.Content = Rnd.Next(1, 7);
        }

        if (Roll_clicked2 == true)
        {
            Roll_clicked3 = true;
        }

        if (Roll_clicked == true)
        {
            Roll_clicked2 = true;
        }

        Roll_clicked = true;
    }

    /// <summary>
    /// klik de end turn knop
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void End_Click(object sender, RoutedEventArgs e)
    {
        same();

        if (Roll_clicked == false)
        {
            RollButton.Content = "Roll";
            return;
        }

        #region Chance
        //Chance score
        Player1Score.Text = Pl1Score.ToString();
            if (Type.SelectedItem == Chance)
            {
                Score += int.Parse(Die1.Content.ToString()) +
                int.Parse(Die2.Content.ToString()) +
                int.Parse(Die3.Content.ToString()) +
                int.Parse(Die4.Content.ToString()) +
                int.Parse(Die5.Content.ToString());
            }

            #endregion

            #region Count the 1's
            // telt de 1en
            Player1Score.Text = Pl1Score.ToString();

            if (Type.SelectedItem == Ones)
            {
                Score += 1 * count1;
            }

            #endregion

            #region Count the 2's
            // telt de 2en
            Player1Score.Text = Pl1Score.ToString();

            if (Type.SelectedItem == Twos)
            {
                Score += 2 * count2;
            }

            #endregion

            #region Count the 3's
            // telt de 3en
            Player1Score.Text = Pl1Score.ToString();

            if (Type.SelectedItem == Threes)
            {
                Score += 3 * count3;
            }

            #endregion

            #region Count the 4's
            // telt de 4en
            Player1Score.Text = Pl1Score.ToString();

            if (Type.SelectedItem == Fours)
            {
                Score += 4 * count4;
            }

            #endregion

            #region Count the 5's
            // telt de 5en
            Player1Score.Text = Pl1Score.ToString();

            if (Type.SelectedItem == Fives)
            {
                Score += 5 * count5;
            }

            #endregion

            #region Count the 6's
            // telt de 6en
            Player1Score.Text = Pl1Score.ToString();

            if (Type.SelectedItem == Sixes)
            {
                Score += 6 * count6;
            }

            #endregion

            #region Three of a kind
            //Three of a kind score
            Player1Score.Text = Pl1Score.ToString();

            if (Type.SelectedItem == ThreeOfAKind)
            {
                if (count1 == 3)
                {
                    Score += 3;
                }

                if (count2 == 3)
                {
                    Score += 6;
                }

                if (count3 == 3)
                {
                    Score += 9;
                }

                if (count4 == 3)
                {
                    Score += 12;
                }

                if (count5 == 3)
                {
                    Score += 15;
                }

                if (count6 == 3)
                {
                    Score += 18;
                }
            }
            #endregion

            #region Carré
            //Carré score
            Player1Score.Text = Pl1Score.ToString();

            if (Type.SelectedItem == Carré)
            {
                if (count1 == 4)
                {
                    Score += 4;
                }

                if (count2 == 4)
                {
                    Score += 8;
                }

                if (count3 == 4)
                {
                    Score += 12;
                }

                if (count4 == 4)
                {
                    Score += 16;
                }

                if (count5 == 4)
                {
                    Score += 20;
                }

                if (count6 == 4)
                {
                    Score += 24;
                }
            }
            #endregion

            #region Full House
            //Full House score
            Player1Score.Text = Pl1Score.ToString();
            if (Type.SelectedItem == FullHouse)
            {
                Score += 25;
            }
            #endregion

            #region Small Straight
            //Small Straight score
            Player1Score.Text = Pl1Score.ToString();
            if (Type.SelectedItem == SmallStraight)
            {
                Score += 30;
            }
            #endregion

            #region Large Straight
            //Large Straight score
            Player1Score.Text = Pl1Score.ToString();
            if (Type.SelectedItem == LargeStraight)
            {
                Score += 40;
            }
            #endregion

            #region Yahtzee
            //Yahtzee score
            Player1Score.Text = Pl1Score.ToString();
            if (Type.SelectedItem == Yahtzee)
            {
                Score += 50;
            }
            #endregion

            #region score

            //voeg de punten aan de juiste spelers score toe
            if (Player1_turn == true)
            {
                Pl1Score += Score;
                Player1Score.Text = Pl1Score.ToString();
            }
            else
            {
                Pl2Score += Score;
                Player2Score.Text = Pl2Score.ToString();
            }
            Score = 0;

            #endregion

            //beëindig de huidige speler zijn beurt
            Player1_turn ^= true;

            //laat zien wie er aan de beurt is
            if (Player1_turn == true)
            {
                Player1Score.Background = Brushes.Green;
                Player2Score.Background = Brushes.White;
            }
            else
            {
                Player2Score.Background = Brushes.Green;
                Player1Score.Background = Brushes.White;
            }

            #region End turn

            //het einde van de beurt, alles weer resetten
            Die1.Background = Die2.Background = Die3.Background = Die4.Background = Die5.Background = Brushes.White;
            Roll_clicked = false;
            RollButton.Content = "Roll";
            Die1.Content = Die2.Content = Die3.Content = Die4.Content = Die5.Content = "0";
            Roll_clicked = Roll_clicked2 = Roll_clicked3 = false;
            value1 = 0;
            count1 = 0;
            value2 = 0;
            count2 = 0;
            value3 = 0;
            count3 = 0;
            value4 = 0;
            count4 = 0;
            value5 = 0;
            count5 = 0;
            value6 = 0;
            count6 = 0;

            #endregion
        }
    }
}
