﻿using System;
using System.Collections;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        // Global variables
        bool turn = true; // true = X;false = O;
        bool winnerFound = false;
        bool globalTwoPlayer = false;

        int xy, x, y;

        int turns = 0;

        String mark = "";

        int[,] c4warray = new int[3, 3];
        int[,] mSquare3 = MagicSquare.createMagicSquare(3);
        object[,] gameField = new object[3, 3];
        object[] singleField;



        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By SG", "About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            buttonClick(sender);       
        }

        private void buttonClick(object sender)
        {
            Button b = (Button)sender;
            
            mark = turn ? "X" : "O";

            turn = !turn;

            b.Text = mark;
            b.Enabled = false;

            turns++;

            
            // keine trennung zwischen x + o
            if (checkForWinnerNew(sender) != checkForWinner())
                Console.WriteLine("error");

               
            

         //   checkForWinner();
            //if (!checkForWinner() && (globalTwoPlayer) && (!turn)) computerMove();
        }

        private bool checkForWinnerNew(object sender)
        {
            //throw new NotImplementedException();
            Button b = (Button)sender;
            x = 0;
            y = 0;
            xy = 0;
            String[] stringButtons = { "A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3" };
            //singleField = varsingleField;

            /*
            * using index of instead
            foreach (object btn in varsingleField)
            {
                Button a = (Button)btn;
                while(a.Name != b.Name)
                {
                    xy++;
                }
                break;
            }
            */
            
            xy = Array.IndexOf(stringButtons, b.Name);
            x = xy % 3;
            y = xy / 3;



            c4warray[x, y] = mSquare3[x, y];
            int sum;
            bool result = false;

            //horizontal
            for (int i = 0; i < 3; ++i)
            {
                sum = 0;
                for (int j = 0; j  < 3; ++j)
                {
                    sum += c4warray[i, j];
                    if (sum == 15) result = true;
                }
            }
            // vertical
            for (int i = 0; i < 3; ++i)
            {
                sum = 0;
                for (int j = 0; j < 3; ++j)
                {
                    sum += c4warray[j, i];
                    if (sum == 15) result = true;
                }
            }

            // diagonal
            for (int i = 0; i < 3; ++i)
            {
                sum = 0;
                sum += c4warray[i, i];
                if (sum == 15) result = true;     
            }
            for (int i = 0; i < 3; ++i)
            {
                sum = 0;
                sum += c4warray[i, 2-i];
                if (sum == 15) result = true;
            }

            return result;
        }

        private bool checkForWinner()
        {
            //horizontal check
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && !A1.Enabled) winnerFound = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && !B1.Enabled) winnerFound = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && !C1.Enabled) winnerFound = true;

            //vertical check
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && !A1.Enabled) winnerFound = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && !A2.Enabled) winnerFound = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && !A3.Enabled) winnerFound = true;

            // diagonal check
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && !A1.Enabled) winnerFound = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && !C1.Enabled) winnerFound = true;

            if (winnerFound)
            {
                if (turn)
                    o_count.Text = ((Int32.Parse(o_count.Text) + 1).ToString());
                else
                    x_count.Text = ((Int32.Parse(x_count.Text) + 1).ToString());
                MessageBox.Show(mark + " won.", "Yay");
                disableButtons();
                return true;
            }
            else if (turns == 9)
            {
                draw_count.Text = ((Int32.Parse(draw_count.Text) + 1).ToString());
                MessageBox.Show("Draw", "Bummer");
                disableButtons();
                return true;
            }
            return false;
        }

        public void disableButtons()
        {
            
            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    c.Enabled = false;
                }
                catch { }
            }
            
            MainMenuStrip.Enabled = true;
        }

        public void startNewGame(bool twoPlayer)
        {
            
            foreach (Control c in Controls)
            {
                try
                { 
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }
            }

            winnerFound = false;
            turns = 0;
            turn = true;
            
            globalTwoPlayer = twoPlayer ? true : false;

            gameField = createGameField();


            object[] varsingleField = { A1, A2, A3, B1, B2, B3, C1, C2, C3 };
            singleField = varsingleField;
        }

        private object[,] createGameField()
        {
        
            object[,] Matrix =
            {
                {A1, A2, A3},
                {B1, B2, B3},
                {C1, C2, C3}
            };
            return Matrix;
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Text = (b.Enabled && turn) ? "X" : "O";
        }

        private void button_leave(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;
                if (b.Enabled)
                    b.Text = "";
            }
            catch { }
        }

        private void resetCountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetCounts();
        }

        private void resetCounts()
        {
            x_count.Text = "0";
            o_count.Text = "0";
            draw_count.Text = "0";
        }

        private void playerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool twoPlayer = false;
            startNewGame(twoPlayer);
        }

        private void playerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool twoPlayer = true;
            startNewGame(twoPlayer);
            if ((!turn) && (!checkForWinner())) computerMove();
        }

        private void computerMove()
        {
            // always center
            if (B2.Enabled)
                buttonClick(B2);
            
            // check if x or o could win with the next move
            // horizontal
            // 1
            else if (A1.Text == B1.Text && C1.Enabled && !A1.Enabled)
                buttonClick(C1);
            else if (A1.Text == C1.Text && B1.Enabled && !A1.Enabled)
                buttonClick(B1);
            else if (B1.Text == C1.Text && A1.Enabled && !B1.Enabled)
                buttonClick(A1);
            // 2
            else if (A2.Text == B2.Text && C2.Enabled && !A2.Enabled)
                buttonClick(C2);
            else if (A2.Text == C2.Text && B2.Enabled && !A2.Enabled)
                buttonClick(B2);
            else if (B2.Text == C2.Text && A2.Enabled && !B2.Enabled)
                buttonClick(A2);
            // 3
            else if (A3.Text == B3.Text && C3.Enabled && !A3.Enabled)
                buttonClick(C3);
            else if (A3.Text == C3.Text && B3.Enabled && !A3.Enabled)
                buttonClick(B3);
            else if (B3.Text == C3.Text && A3.Enabled && !B3.Enabled)
                buttonClick(A3);
            // vertical
            // A
            else if (A1.Text == A2.Text && A3.Enabled && !A1.Enabled)
                buttonClick(A3);
            else if (A1.Text == A3.Text && A2.Enabled && !A1.Enabled)
                buttonClick(A2);
            else if (A2.Text == A3.Text && A1.Enabled && !A2.Enabled)
                buttonClick(A1);
            // B
            else if (B1.Text == B2.Text && B3.Enabled && !B1.Enabled)
                buttonClick(B3);
            else if (B1.Text == B3.Text && B2.Enabled && !B1.Enabled)
                buttonClick(B2);
            else if (B2.Text == B3.Text && B1.Enabled && !B2.Enabled)
                buttonClick(B1);
            // C
            else if (C1.Text == C2.Text && C3.Enabled && !C1.Enabled)
                buttonClick(A3);
            else if (C1.Text == C3.Text && C2.Enabled && !C1.Enabled)
                buttonClick(C2);
            else if (C2.Text == C3.Text && C1.Enabled && !C2.Enabled)
                buttonClick(C1);
            // diagonal
            // down  right
            else if (A1.Text == B2.Text && C3.Enabled && !A1.Enabled)
                buttonClick(C3);
            else if (A1.Text == C3.Text && B2.Enabled && !A1.Enabled)
                buttonClick(B2);
            else if (B2.Text == C3.Text && A1.Enabled && !B2.Enabled)
                buttonClick(A1);
            // down left
            else if (C1.Text == B2.Text && A3.Enabled && !C1.Enabled)
                buttonClick(A3);
            else if (C1.Text == A3.Text && B2.Enabled && !C1.Enabled)
                buttonClick(B2);
            else if (B2.Text == A3.Text && C1.Enabled && !B2.Enabled)
                buttonClick(C1);
            
            // Wenn keine Gewinnbedingung gefunden, dann die Ecken besetzen
            /*Todo: durch wählen zweier gegenüberliegenden ecke in z1 + z2 verliert ai*/
            else if (A1.Enabled || C1.Enabled || A3.Enabled || C3.Enabled)
            {
                object[] btnArray = { A1, A3, C1, C3 };
                ArrayList btnArrayList = new ArrayList();

                foreach (object btn in btnArray)
                {
                    Button b = (Button)btn;
                    if (b.Enabled)
                        btnArrayList.Add(b);
                }
                Random rnd = new Random();
                int randomMove = rnd.Next(0, btnArrayList.Count);
                buttonClick(btnArrayList[randomMove]);
            }

            // check if the next two moves could lead to a win
            // A
            else if (A1.Text == "O" && A2.Enabled && A3.Enabled)
                buttonClick(A2);
            else if (A3.Text == "O" && A2.Enabled && A1.Enabled)
                buttonClick(A2);
            else if (A2.Text == "O" && A1.Enabled && A3.Enabled)
            {
                if (B1.Enabled && C1.Enabled)
                    buttonClick(A1);
                else if (B3.Enabled && C3.Enabled)
                    buttonClick(A3);
            }
            // B
            else if (B1.Text == "O" && B2.Enabled && B3.Enabled)
                buttonClick(A2);
            else if (B3.Text == "O" && B2.Enabled && B1.Enabled)
                buttonClick(A2);
            else if (B2.Text == "O" && B1.Enabled && B3.Enabled)
            {
                if (A1.Enabled && C1.Enabled)
                    buttonClick(B1);
                else if (A3.Enabled && C3.Enabled)
                    buttonClick(B3);
            }
            // C
            else if (C1.Text == "O" && C2.Enabled && C3.Enabled)
                buttonClick(C2);
            else if (C3.Text == "O" && C2.Enabled && C1.Enabled)
                buttonClick(A2);
            else if (C2.Text == "O" && C1.Enabled && C3.Enabled)
            {
                if (A1.Enabled && B1.Enabled)
                    buttonClick(C1);
                else if (A3.Enabled && B3.Enabled)
                    buttonClick(C3);
            }
            // 1
            else if (A1.Text == "O" && B1.Enabled && C1.Enabled)
                buttonClick(C1);
            else if (C1.Text == "O" && A1.Enabled && B1.Enabled)
                buttonClick(A1);
            else if (B1.Text == "O" && A1.Enabled && C1.Enabled)
            {
                if (A2.Enabled && A3.Enabled)
                    buttonClick(A1);
                else if (C2.Enabled && C3.Enabled)
                    buttonClick(C1);
            }
            // 2
            else if (A2.Text == "O" && B2.Enabled && C2.Enabled)
                buttonClick(C2);
            else if (C2.Text == "O" && A2.Enabled && B2.Enabled)
                buttonClick(A2);
            else if (B2.Text == "O" && A2.Enabled && C2.Enabled)
            {
                if (A1.Enabled && A3.Enabled)
                    buttonClick(A2);
                else if (C1.Enabled && C3.Enabled)
                    buttonClick(C2);
            }
            // 3
            else if (A3.Text == "O" && B3.Enabled && C3.Enabled)
                buttonClick(C3);
            else if (C3.Text == "O" && A3.Enabled && B3.Enabled)
                buttonClick(A3);
            else if (B3.Text == "O" && A3.Enabled && C3.Enabled)
            {
                if (A1.Enabled && A2.Enabled)
                    buttonClick(A1);
                else if (C1.Enabled && C2.Enabled)
                    buttonClick(C3);
            }
            // Diagonal
            // right down


          
            else
            {
                Random rnd = new Random();
                int randomMove = rnd.Next(0, 9);

                // 1 dimensional game field
                object[] btnArray = { A1, A2, A3, B1, B2, B3, C1, C2, C3 };
                buttonClick(btnArray[randomMove]);
            }

        }

    }
}
