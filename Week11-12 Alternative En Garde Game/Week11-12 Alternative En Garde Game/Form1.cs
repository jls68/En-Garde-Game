using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week11_12_Alternative_En_Garde_Game
{
    public partial class Form1 : Form
    {
        //James Sheaf-Morrison
        //ID: 1314151

        public Form1()
        {
            InitializeComponent();
        }

        Random rand = new Random();

        //The cards in players' hands
        int[] userHand = new int[5];
        int[] compHand = new int[5];

        //The list of cards in the deck
        List<int> deck = new List<int>() {1, 2, 3, 4, 5, 1, 2, 3, 4, 5,
            1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };

        //Keeps track of how many cards have been picked up
        int drawnCards = 0;

        //Constant for mat size
        const int MAT_SIZE = 23;

        //Constant for deck size
        const int DECK_SIZE = 25;

        //Constant for pen size
        const int PEN_SIZE = 5;

        //Constant for wait time
        const int WAIT = 500;

        //Constants for mat colours
        Color Colour1 = Color.White;
        Color Colour2 = Color.DarkGray;
        Color ColourEnds = Color.Black;

        //Colours of pieaces
        Color USER = Color.Blue;
        Color USER_LIGHT = Color.LightBlue;
        Color COMP = Color.Red;
        Color COMP_LIGHT = Color.Pink;

        //Colour to turn mat if it is a draw
        Color DRAW = Color.Black;

        //Colour array for mat spaces
        Color[] MatColour = new Color[MAT_SIZE];

        //Positions of pieces
        int userPiece = 0;
        int compPiece = MAT_SIZE;

        //Value of picked card in hand
        int cardValue = 0;

        //Index of picked card in hand
        int selectedCard = 0;


        //Booleans to tell when a move is possible
        bool moveLeftPossible = false;
        bool moveRightPossible = false;
        bool compTurn = false;
        bool lastTurn = false;

        //Holds the code name of the computer adversary
        string opponent = "No-one";

        //Tells program when it is game over
        bool gameOver = false;

        //Sets application to use parry or not
        bool parryOn = true;


        /// <summary>
        /// Draw a card at random from the deck
        /// </summary>
        /// <returns>Return int value of card drawn</returns>
        private int DrawRandomCard()
        {
            //Declare variables
            int newCardValue = 0, cardIndex = 0;

            try
            {
                if (drawnCards < DECK_SIZE)
                {
                    //Pick index of card in list at random
                    cardIndex = rand.Next(0, DECK_SIZE - drawnCards);
                    //Set cardValue as value in deck list at index
                    newCardValue = deck[cardIndex];
                    //Remove drawn card from deck
                    deck.RemoveAt(cardIndex);
                    //Increase value of drawn cards
                    drawnCards++;
                    //Display number of cards left in deck
                    textBoxDeckCount.Text = (DECK_SIZE - drawnCards).ToString();
                }
                else if (lastTurn)
                {
                    MessageBox.Show("No more cards are left. Winner will be decided by " +
                        "whomever is furthest from their starting position.");
                    //Tall GameDaw method when the last move has been made 
                    GameDraw(); 
                }
                else
                {
                    //When all cards have been drawn warn it is the last move of the opponent
                    MessageBox.Show("Last card has been drawn. One final move is left.");
                    lastTurn = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return newCardValue;
        }

        /// <summary>
        /// Reset the array for the colour code of the mat
        /// </summary>
        private void ResetMatColourArray()
        {
            //Declare variable
            Color Colour = Colour1;
            //for every 6th space except the first and last
            for (int i = 3; i < MAT_SIZE - 1; i += 3)
            {
                if (i % 6 == 0)
                {
                    Colour = Colour2;
                }
                else
                {
                    Colour = Colour1;
                }
                MatColour[i] = Colour;
                MatColour[i - 1] = Colour;
                MatColour[i - 2] = Colour;
            }
            //Set the ends colour
            MatColour[0] = ColourEnds;
            MatColour[MAT_SIZE - 1] = ColourEnds;
        }

        /// <summary>
        /// Draw the pieces in their positions on the mat
        /// </summary>
        private void DisplayPieces()
        {
            //Declare variables
            Graphics mat = pictureBoxMat.CreateGraphics();
            SolidBrush userBrush = new SolidBrush(USER), compBrush = new SolidBrush(COMP);
            int spacewidth = pictureBoxMat.Width / MAT_SIZE, height = pictureBoxMat.Height / 4,
                bodywidth = spacewidth / 4;

            //Draw the pieces head
            mat.FillEllipse(compBrush, compPiece * spacewidth, height + height / 4, spacewidth, height);
            mat.FillEllipse(userBrush, userPiece * spacewidth, height + height / 4, spacewidth, height);
            //Draw the pieces body
            mat.FillRectangle(compBrush, compPiece * spacewidth + ((spacewidth - bodywidth) / 2),
                height + height / 2, bodywidth, height * 2);
            mat.FillRectangle(userBrush, userPiece * spacewidth + ((spacewidth - bodywidth) / 2),
                height + height / 2, bodywidth, height * 2);
        }

        /// <summary>
        /// Update listBox showing users hand of cards
        /// </summary>
        private void DisplayHand()
        {
                //Clear old hand
                listBoxUserHand.Items.Clear();
            //For each five cards add to the list box
            for (int n = 0; n < 5; n++)
            {
                listBoxUserHand.Items.Add(userHand[n]);
            }
            
        }

        /// <summary>
        /// Redraws the mat
        /// </summary>
        private void UpdateMat()
        {
            Graphics mat = pictureBoxMat.CreateGraphics();
            SolidBrush Brush = new SolidBrush(Color.White);
            Pen pen = new Pen(Color.Black, PEN_SIZE);
            int x = 0, spaceWidth = pictureBoxMat.Width / MAT_SIZE, spaceHeight = pictureBoxMat.Height;
            //Draw each space on the mat
            for (int space = 0; space < MAT_SIZE; space++)
            {
                //Set the colour of space
                Brush.Color = MatColour[space];
                //Draw the space on the mat
                mat.FillRectangle(Brush, x, 0, spaceWidth, spaceHeight);
                mat.DrawRectangle(pen, x, 0, spaceWidth, spaceHeight);
                //Shift x to next space
                x += spaceWidth;
            }
            //Call method to display the pieces
            DisplayPieces();
        }

        /// <summary>
        /// Sets up a new game
        /// </summary>
        private void InitialiseGame()
        {
            try
            {
                //Move pieces back to their respective sides
                userPiece = 0;
                compPiece = MAT_SIZE - 1;

                //Reset the deck
                List<int> newDeck = new List<int>() {1, 2, 3, 4, 5, 1, 2, 3, 4, 5,
                    1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };
                deck = newDeck;
                lastTurn = false;
                drawnCards = 0;

                //Set new five cards to the players' hands
                for (int number = 0; number < 5; number++)
                {
                    userHand[number] = DrawRandomCard();
                    compHand[number] = DrawRandomCard();
                }

                //Reset Mat
                ResetMatColourArray();

                //Call method to update mat
                UpdateMat();

                //Call method to display users hand
                DisplayHand();

                //Say the game is ready to play
                gameOver = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Decalre winner from whom ever turn it is now
        /// </summary>
        private void GameWon()
        {
            //Check whom's turn it is now indicating who lost
            if (compTurn)
            {
                //Make the board match user's colour
                for (int i = 0; i < MAT_SIZE; i++)
                {
                    MatColour[i] = USER;
                }
                UpdateMat();
                //Display message of user win
                MessageBox.Show("Congratualtions! You won!");
            }
            else
            {
                //Make the board match comp's colour
                for (int i = 0; i < MAT_SIZE; i++)
                {
                    MatColour[i] = COMP;
                }
                UpdateMat();
                //Display message of computer win
                MessageBox.Show("The computer has won.");
            }
            gameOver = true;
        }

        /// <summary>
        /// Decide who moved the furthest hence who one if a draw occurs
        /// </summary>
        private void GameDraw()
        {
            //Check if user moved further than comp from their respective starting position
            if (userPiece > MAT_SIZE - compPiece)
            {
                //Indicate user won by declaring it is comp's turn
                compTurn = true;
                GameWon();
            }
            //Else if comp moved further set it to wi
            else if (userPiece < MAT_SIZE - compPiece)
            {
                //Indicate comp won by declaring it is not comp's turn
                compTurn = false;
                GameWon();
            }
            //Else it is a draw
            else
            {
                //Make the board match draw colour
                for (int i = 0; i < MAT_SIZE; i++)
                {
                    MatColour[i] = DRAW;
                }
                UpdateMat();
                //Display message of computer win
                MessageBox.Show("It is a draw");
            }
            gameOver = true;
        }

        /// <summary>
        /// Allow for a parry
        /// </summary>
        private void ParryChance()
        {
            //Declare variables
            bool noMatchFound = true;
            int parryValue = cardValue;

            //Check parry is on
            if (parryOn)
            {
                //If it is comp's turn
                if (compTurn)
                {
                    //For each card in comp's hand or until found one that matches cardValue
                    for (int p = 0; p < 5 && parryValue == compHand[p]; p++)
                    {
                        //Check if can move right
                        if (compHand[p] == parryValue)
                        {
                            //Replenish hand
                            compHand[p] = DrawRandomCard();
                            //Tell application card was found
                            noMatchFound = false;
                            //Write to console what is happening
                            Console.WriteLine(opponent + " parrys with a " +
                                parryValue);
                        }
                        else
                        {
                            noMatchFound = true;
                            //Write to console what is happening
                            Console.WriteLine(opponent + " concedes as he lacks a " +
                                parryValue);
                        }

                    }
                }
                //Else it is user's turn
                else
                {
                    //For each card in comp's hand or until found one that matches cardValue
                    for (int p = 0; p < 5 && parryValue == compHand[p]; p++)
                    {
                        //Check if can move right
                        if (compHand[p] == parryValue)
                        {
                            //Replenish hand
                            compHand[p] = DrawRandomCard();
                            //Tell application card was found
                            noMatchFound = false;
                            //Write to console what is happening
                            Console.WriteLine("You use your " + parryValue +
                                " card to parry the attck");
                        }
                        else
                        {
                            noMatchFound = true;
                            //Write to console what is happening
                            Console.WriteLine("No " + parryValue + "in your hand. " +
                                opponent + " has bested you");
                        }

                    }
                }
                //If no match was found
                if (noMatchFound)
                {
                    //If no match was found then no parry so call GameWon method
                    GameWon();
                }
                //Else report a succesful parry
                else
                {
                    MessageBox.Show("A parry was made. En Garde!");
                }
            }
            //Else call GameWon method
            else
            {
                GameWon();
            }
        }

        /// <summary>
        /// Method that is used for both go forward and go back buttons
        /// </summary>
        /// <param name="movePossible">given either left or right</param>
        /// <param name="right">used to be passed onto MovePiece method</param>
        private void UserPressedToMove(bool movePossible, bool right)
        {
            if (!gameOver)
            {
                //If no move is possible declare comp as winner
                if (userPiece < 5 && compPiece - userPiece < 6)
                {
                    bool noMoveFound = true;
                    //For each card in hand or until a possible move is found
                    for (int c = 0; c < 5 && noMoveFound; c++)
                    {
                        if (userHand[c] > 0)
                        {
                            //If can move back/left
                            if (userPiece - userHand[c] >= 0)
                            {
                                //Can move
                                noMoveFound = false;
                            }
                            //Else if can move forward/right
                            else if (userPiece + userHand[c] <= compPiece)
                            {
                                //Can move
                                noMoveFound = false;
                            }
                        }
                    }
                    if (noMoveFound)
                    {
                        //Comp wins
                        GameWon();
                    }
                }

                //Call method to move piece
                MovePiece(movePossible, right, true);

                if (compTurn)
                {
                    //Call for comp's turn
                    CompsTurn();
                }
            }
        }

        /// <summary>
        /// Move desired piece if allowed
        /// </summary>
        /// <param name="movePossible">given either left or right</param>
        /// <param name="right">checks if need to minus or add card value</param>
        /// <param name="user">checks is it is user or comp piece bveing moved</param>
        private void MovePiece(bool movePossible, bool right, bool user)
        {
            //Wait for a move right to be possible
            if (movePossible == true && cardValue > 0)
            {
                if (user)
                {
                    if (right)
                    {
                        userPiece += cardValue;
                    }
                    else
                    {
                        userPiece -= cardValue;
                    }
                    compTurn = true;
                    //Replace used card
                    userHand[selectedCard] = DrawRandomCard();
                }
                else
                {
                    if (right)
                    {
                        compPiece += cardValue;
                    }
                    else
                    {
                        compPiece -= cardValue;
                    }
                    compTurn = false;
                    //Replace used card
                    compHand[selectedCard] = DrawRandomCard();
                }
                //Check if pieces overlap
                if (userPiece == compPiece)
                {
                    //Call method to end game
                    ParryChance();
                }
                else
                {
                    //Call method to update mat
                    UpdateMat();
                    //call method to update hand
                    DisplayHand();
                }
                //Reset for next turn
                moveLeftPossible = false;
                moveRightPossible = false;
            }
        }

        /// <summary>
        /// The computer's turn
        /// </summary>
        private void CompsTurn()
        {
            try
            {
                if (!gameOver)
                {
                    //Decalre variables
                    int untriedCards = 5, index = 0, temp = 0;
                    //While it's still the computer's turn
                    while (compTurn && untriedCards > 0)
                    {
                        if (opponent == "Ronzo")
                        {
                            //Randomily pick a card in hand
                            index = rand.Next(untriedCards);
                            cardValue = compHand[index];
                        }
                        else
                        {
                            //Sort comp's hand into ascending order
                            Array.Sort<int>(compHand);
                            //Declare a list to store the index of possible choices to be made
                            List<int> cardChoicesList = new List<int>();
                            //FOR each card in hand
                            for (int i = 0; i < 5; i++)
                            {
                                //Pick any cards that will result in victory
                                if (compPiece - compHand[i] == userPiece)
                                {
                                    cardChoicesList.Add(i);
                                }
                                //Pick any double cards in hand, only if i is greater than 0 to avoid errors
                                else if (i > 0)
                                {
                                    //IF duplicate card is found THEN
                                    if (compHand[i] == compHand[i - 1])
                                    {
                                        //Add index to list
                                        cardChoicesList.Add(i);
                                    }
                                }
                            }
                            //Ranomily pick an index from the cardChoiceList
                            index = rand.Next(untriedCards);
                            cardValue = compHand[index];
                        }

                        //Check if can move left
                        if (compPiece - cardValue >= userPiece)
                        {
                            MatColour[compPiece - cardValue] = COMP_LIGHT;
                            UpdateMat();
                            ResetMatColourArray();
                            System.Threading.Thread.Sleep(WAIT);
                            MovePiece(true, false, false);
                        }
                        //Check if can move right
                        else if (compPiece + cardValue < MAT_SIZE)
                        {
                            MatColour[compPiece + cardValue] = COMP_LIGHT;
                            UpdateMat();
                            ResetMatColourArray();
                            System.Threading.Thread.Sleep(WAIT);
                            MovePiece(true, true, false);
                        }
                        //Else forget that card for now
                        else
                        {
                            //Reduce the numbe rof cards to try
                            untriedCards--;
                            if (opponent == "Ronzo")
                            {
                                temp = compHand[index];
                                compHand[index] = compHand[4];
                                compHand[4] = temp;
                            }
                            else
                            {

                            }
                        }
                    }
                    if (untriedCards == 0)
                    {
                        MessageBox.Show(opponent + " has ran out of possible moves");
                        //User wins
                        GameWon();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Reset for a new game with Ronzo (Random picking opponent)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Call method to start a new game
                InitialiseGame();

                opponent = "Ronzo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Store index of card selected from listBoxUserHand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxUserHand_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (gameOver == false)
                {
                    //Store index of selected card
                    selectedCard = listBoxUserHand.SelectedIndex;

                    //Remove past card results
                    moveLeftPossible = false;
                    moveRightPossible = false;
                    //Remove highlights on mat
                    ResetMatColourArray();

                    //Display area piece can move to
                    cardValue = userHand[selectedCard];
                    if (userPiece - cardValue >= 0)
                    {
                        //Highlight possible move
                        MatColour[userPiece - cardValue] = USER_LIGHT;
                        UpdateMat();
                        moveLeftPossible = true;
                    }
                    if (userPiece + cardValue <= compPiece)
                    {
                        //Highlight possible move
                        MatColour[userPiece + cardValue] = USER_LIGHT;
                        UpdateMat();
                        moveRightPossible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// When button clicked move user piece forward if possible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGoForward_Click(object sender, EventArgs e)
        {
            try
            {
                UserPressedToMove(moveRightPossible, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// When button clicked move user piece backward if possible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGoBack_Click(object sender, EventArgs e)
        {
            try
            {
                UserPressedToMove(moveLeftPossible, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Turns on or off the parry mechanic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonParryOn_CheckedChanged(object sender, EventArgs e)
        {
            parryOn = !parryOn;
        }

        /// <summary>
        /// Exit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
