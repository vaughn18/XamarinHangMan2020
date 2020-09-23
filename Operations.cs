using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Android.Animation;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinHangMan2020
{
    public class Operations
    {
        //Array of words or Category made of categories
        string[] animalArr = {
            "COW",
            "HORSE", 
            "LION", 
            "CAT", 
            "DOG",
            "EAGLE",
            "TIGER",
            "ALLIGATOR",
            "DUNKER" };
        //the word chosen
        string chosenWord;
        //an array based of chosenWord's number of characters
        char[] chosenWordArray;
        //an array of uunderscores based on the number of characters of the chosen word
        char[] underscoreArray;
        //word that will be used for gameplay
        string gameWord;
        //variable to show how many tries the player has left
        int tries = 0;
        //save the name of the user playing
        string name;
        //score 
        int score = 0;


        //getter for tries
        public int getTries() { 
            return tries;
        }

        //getter for name
        public string getName()
        {
            return name;
        }
        //getter for score
        public int getScore()
        {
            return score;
        }

        //restarts the score
        public void restartScore()
        {
            score = 0;
        }


        //restart game
        public void RestartGame()
        {
            chosenWord = null;
            Array.Clear(chosenWordArray, 0, chosenWordArray.Length);
            Array.Clear(underscoreArray, 0, underscoreArray.Length);
            gameWord = null;
            tries = 0;
        }

        //checks if there is a name to proceed before playing
        public bool FormCheck(string formValue)
        {
            if(formValue == "")
            {
                return false;
            }else {

                name = formValue;
                return true;            
            }
        
        }

        //returns a random number to return a random word
        public int RandomNumber(int arrLength)
        {
            Random myRandom = new Random();
            int rnd = myRandom.Next(1, arrLength);
            return rnd;
        }

        //Chooses a word to play for the game
        public string ChooseWord(string category)
        {
            switch (category)
            {
                case "animal":
                     chosenWord = animalArr[RandomNumber(animalArr.Length)];
                    break;
            }
            chosenWordArray = chosenWord.ToCharArray();
            underscoreArray = new char[chosenWordArray.Length];
            for(int i = 0; i < chosenWordArray.Length; i++)
            {
                underscoreArray[i] = '_';
                gameWord += underscoreArray[i] + " ";
            }

            return gameWord;
        }
        
        //Gameplay method
        public string GamePlay(string letter)
        {
           //the chosen letter exists inside the chosen word array
            if (!chosenWord.Contains(letter))
            {
                tries  += 1;

            }else
            {
                //add the letter inside the underscore array
                for (int i = 0; i < chosenWordArray.Length; i++)
                {
                    if (letter == chosenWordArray[i].ToString())
                    {
                        underscoreArray[i] = Convert.ToChar(letter);
                    }
                }
                //replace the gameWord and return the word being revealed
                gameWord = null;
                foreach (var item in underscoreArray)
                {
                    gameWord += item.ToString() + " ";
                }
                if(isWin(gameWord))
                {
                    score += 1;
                    return gameWord = "win";
                }
            }
                return gameWord;
        }

        //function to check if the word is already solved or not
        public bool isWin(string word)
        {
           if(word.Contains("_"))
            {
                return false;
            }else
            {
                return true;
            }
        }

        public string winMessage()
        {
            return "Congrats, " + name + ". Your score is " + score + ".";
        }
    }
}