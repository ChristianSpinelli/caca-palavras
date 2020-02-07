using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] words;
    public Text txtTheme;

    private Theme theme;
   
    // Start is called before the first frame update
    void Start()
    {
        theme = ThemeFactory.CreateTheme(GameManager.instance.theme);

        for (int i = 0; i < words.Length; i++)
        {
            //words[i].gameObject.SetActive(false);
            words[i].text = theme.SelectedWords[i];
            Color newColor = new Color();
            ColorUtility.TryParseHtmlString(theme.SelectedColors[i], out newColor);
            words[i].color = newColor;
            
        }

        txtTheme.text = "Theme: " + GameManager.instance.theme;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
