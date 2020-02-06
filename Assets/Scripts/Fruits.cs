using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : Theme
{
    public Fruits(int qtdWords, int rows, int cols)
    {
        this.name = "Fruits";
        this.qtdWords = qtdWords;
        string[] orientation = { "Vertical", "Horizontal", "Diagonal" };

        //preenchendo a lista de palavras do tema fruta
        string[] fruits = { "Banana", "Apple", "Orange", "Pear", "Pineapple", "Lemon",
        "Strawberry", "Watermelon", "Coconut", "Papaya", "Kiwi", "Mango", "Mandarine", "Plum", "Carambola" };
        for (int i = 0; i < fruits.Length; i++)
        {
            this.wordPool.Add(fruits[i]);
        }


        //preenchendo as palavras que serão usadas no jogo e as posições dela na matriz do caça palavras.
        for (int i = 0; i < qtdWords; i++)
        {
            string randomWord = this.wordPool[Random.Range(0,this.wordPool.Count)];
            string randomOrientation = orientation[Random.Range(0,orientation.Length)];
            this.WordsOrientation.Add(randomOrientation);
            this.selectedWords.Add(randomWord);
            this.wordPool.Remove(randomWord);
            if (randomOrientation.ToLower() == "horizontal" )
            {
                this.selectedWordsPosX.Add(Random.Range(0, cols - randomWord.Length));
                this.selectedWordsPosY.Add(Random.Range(0, rows));

            }
            
            else if (randomOrientation.ToLower() == "vertical")
            {
                this.selectedWordsPosX.Add(Random.Range(0, cols));
                this.selectedWordsPosY.Add(Random.Range(0, rows - randomWord.Length));

          
            }
            
            else if (randomOrientation.ToLower() == "diagonal")
            {
             
                this.selectedWordsPosX.Add(Random.Range(0, cols - randomWord.Length));
                this.selectedWordsPosY.Add(Random.Range(0, rows - randomWord.Length));
            }
            
        }

        
       
        
    }
}
