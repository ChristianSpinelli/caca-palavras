using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] words;
    public Text txtTheme;
    public Text txtWords;
    public GameObject endGame;
    public int maxLenWords = 10;

    private Theme theme;
    private string auxWord;
    private int qtdWords;
    private List<string> wordsMarked = new List<string>();
    

    
    // Start is called before the first frame update
    void Start()
    {
        theme = ThemeFactory.CreateTheme(GameManager.instance.theme);
        endGame.SetActive(false);

        qtdWords = theme.QtdWords;

        //colore as palavras com a cor determinada
        for (int i = 0; i < words.Length; i++)
        {
            words[i].text = theme.SelectedWords[i];
            Color newColor = new Color();
            ColorUtility.TryParseHtmlString(theme.SelectedColors[i], out newColor);
            words[i].color = newColor;
            
        }

        
        //inicializa lista de palavras marcadas
        for (int i = 0; i<words.Length; i++)
        {
          
            GameManager.instance.markedWords.Add(new List<string>() {"","","","","","","","","",""});
            
        }
        
        txtTheme.text = "Theme: " + GameManager.instance.theme;
        txtWords.text = "Words: " + qtdWords;


        
    }

    // Update is called once per frame
    void Update()
    {
        //atualiza na tela a quantidade de palavras restante
        txtWords.text = "Words: " + qtdWords;

        // fim de jogo ativa se achar todas as palavras
        if (qtdWords<=0)
        {
            endGame.SetActive(true);
        }

        // código para atualizar na tela as palavras que o jogador encontrou      
        for (int i = 0; i < words.Length; i++)
        {
            if (GameManager.instance.markedWords.Count > i)
            {
              //transforma a lista de letras em uma string e coloca na variável
                auxWord = string.Join("", GameManager.instance.markedWords[i]);
                
                if (auxWord == words[i].text.ToLower())
                {
                    if (!wordsMarked.Contains(auxWord))
                    {
                        words[i].color = new Color(words[i].color.r, words[i].color.g, words[i].color.b,0.5f);
                        qtdWords--;
                        wordsMarked.Add(auxWord);
                    }
                    
                    
                }
                
            }
           
        }
            
    
    
    }

}
