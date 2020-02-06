using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Theme
{
    protected string name;
    protected List<string> wordPool = new List<string>(), selectedWords = new List<string>(), 
        wordsOrientation = new List<string>();
    protected List<int> selectedWordsPosX = new List<int>(), selectedWordsPosY = new List<int>();
    protected int qtdWords;


    protected Theme(string name, int qtdWords, string[] wordPool, int rows, int cols)
    {
        this.name = name;
        this.qtdWords = qtdWords;
        string[] orientation = {"horizontal","vertical","diagonal"};
        
        //lista de palavras do tema
        for (int i = 0; i < wordPool.Length; i++)
        {
            this.wordPool.Add(wordPool[i]);
        }

        //preenchendo as palavras que serão usadas no jogo e as posições dela na matriz do caça palavras.
        for (int i = 0; i < qtdWords; i++)
        {
            string randomWord = this.wordPool[Random.Range(0, this.wordPool.Count)];
            string randomOrientation = orientation[Random.Range(0, orientation.Length)];
            this.WordsOrientation.Add(randomOrientation);
            this.selectedWords.Add(randomWord);
            this.wordPool.Remove(randomWord);
            if (randomOrientation.ToLower() == "horizontal")
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

    public string Name
    {
        get{ return name; }
        set { name = value; }
    }

    public List<string> WordPool
    {
        get { return wordPool;}
        set { wordPool = value; }
    }

    public List<string> WordsOrientation
    {
        get { return wordsOrientation; }
        set { wordsOrientation = value;}
    }

    public List<string> SelectedWords
    {
        get { return selectedWords; }
        set { selectedWords = value; }
    }

    public List<int> SelectedWordsPosX
    {
        get { return selectedWordsPosX; }
        set { selectedWordsPosX = value; }
    }

    public List<int> SelectedWordsPosY
    {
        get { return selectedWordsPosY; }
        set { selectedWordsPosY = value; }
    }

    public int QtdWords
    {
        get { return qtdWords; }
        set { qtdWords = value; }
    }
}
