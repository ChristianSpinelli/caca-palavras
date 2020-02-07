using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public int posX, posY;

    private Button btnLetter;
    private bool selected = false;
    private Theme theme;
     

    // Start is called before the first frame update
    void Start()
    {
        btnLetter = gameObject.GetComponent<Button>();
        theme = ThemeFactory.CreateTheme(GameManager.instance.theme);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickButton()
    {
        bool select = false;
        for (int i = 0; i < theme.SelectedWordsPosX.Count; i++)
        {
            for (int j = 0; j < theme.SelectedWords[i].Length; j++)
            {
                if (theme.WordsOrientation[i].ToLower() == "horizontal")
                {
                    if (theme.SelectedWordsPosX[i] + j == posX && theme.SelectedWordsPosY[i] == posY)
                    {
                        select = true;
                    }
                
                }else if (theme.WordsOrientation[i].ToLower() == "vertical")
                {
                    if (theme.SelectedWordsPosX[i] == posX && theme.SelectedWordsPosY[i] + j == posY)
                    {
                        select = true;
                    }
                }else if (theme.WordsOrientation[i].ToLower() == "diagonal")
                {
                    if (theme.SelectedWordsPosX[i] + j == posX && theme.SelectedWordsPosY[i] + j == posY)
                    {
                        select = true;
                    }
                }

            }
        }
        
        if (select)
        {
            selectButton();
        }
        

    }

    private void selectButton()
    {
        btnLetter.GetComponent<Image>().color = Color.red;
        selected = true;
        
        
    }

    public void unselectButton()
    {
       
       btnLetter.GetComponent<Image>().color = Color.white;
       selected = false;
        
        
    }

   

    public bool isSelected()
    {
        return selected;
    }
}
