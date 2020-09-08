using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using Android.Animation;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinHangMan2020
{
    public class Operations
    {
        //Array of words or Category made of categories
        string[] animalArr = { "COW", "HORSE", "LION", "CAT", "DOG", "COCO", "GAYCAT" };
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

        public bool FormCheck(string formValue)
        {
            if(formValue == "")
            {
                return false;
            }else {

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
            if(chosenWord.Contains(letter))
            {
                //add the letter inside the underscore array
                for(int i = 0; i < chosenWordArray.Length; i++)
                {
                    if(letter == chosenWordArray[i].ToString())
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
            }else
            {
                tries += 1;
            }

            return gameWord;
        }
    }
}