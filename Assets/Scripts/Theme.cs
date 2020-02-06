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
