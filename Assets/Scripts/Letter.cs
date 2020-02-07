using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public int posX, posY;

    private Button btnLetter;
    private Text txtLetter;
    private bool selected = false;
    private Theme theme;
   

    // Start is called before the first frame update
    void Start()
    {
        btnLetter = gameObject.GetComponent<Button>();
        theme = ThemeFactory.CreateTheme(GameManager.instance.theme);
        txtLetter = gameObject.GetComponentInChildren<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void clickButton()
    {
        //percorre a primeira posição de cada palavra selecionada
        for (int i = 0; i < theme.SelectedWordsPosX.Count; i++)
        {
          //percorre cada palavra da lista de selecionadas
            for (int j = 0; j < theme.SelectedWords[i].Length; j++)
            {
                //verifica a orientação da palavra
                if (theme.WordsOrientation[i].ToLower() == "horizontal")
                {
                    //verifica se o botão atual é uma das letras da palavra 
                    if (theme.SelectedWordsPosX[i] + j == posX && theme.SelectedWordsPosY[i] == posY)
                    {

                        GameManager.instance.markedWords[i][j] = txtLetter.text.ToLower();
                        //se for marca o botão
                        selectButton();
                        
                        
                    }
                
                }else if (theme.WordsOrientation[i].ToLower() == "vertical")
                {
                    if (theme.SelectedWordsPosX[i] == posX && theme.SelectedWordsPosY[i] + j == posY)
                    {
                        GameManager.instance.markedWords[i][j] = txtLetter.text.ToLower();
                        selectButton();
                        
                    }
                }else if (theme.WordsOrientation[i].ToLower() == "diagonal")
                {
                    if (theme.SelectedWordsPosX[i] + j == posX && theme.SelectedWordsPosY[i] + j == posY)
                    {
                        GameManager.instance.markedWords[i][j] = txtLetter.text.ToLower();
                        selectButton();
                        
                    }
                }

            }
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
