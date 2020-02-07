using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ThemeFactory
{ 
    
    public static Theme CreateTheme(string theme)
    {
        if (theme.ToLower() == "fruits")
        {
            string[] wordPool = { "Banana", "Watermelon", "Apple", "Strawberry", "Orange", "Coconut", "Carambola",
            "Grapes", "Lemon", "Mango", "Pear", "Pitanga", "Tangerine", "Plum", "Pitaya"};
            string[] hexColors = {"#FF0","#0F0","#F00","#F00","#E25822","#FFF","#FF0","#800080","#0F0","#FF0",
                "#0F0","#DAA520","#E25822","#800080","#DE3163" };
            if (GameManager.instance.fruits == null)
            {
                Fruits fruits = new Fruits(theme, 5, wordPool, hexColors, 20, 20);
                GameManager.instance.fruits = fruits;
            }

            return GameManager.instance.fruits;
        }
        else if (theme.ToLower() == "colors")
        {
            string[] wordPool = {"White", "Black", "Blue", "Yellow", "Brown", "Pink", "Purple", 
                "Orange", "Green", "Red", "Cyan", "Gold", "Salmon", "Gray", "Magenta"};

            string[] hexColors = {"#FFF","#000","#00F","#FF0","#964b00","#DE3163","#800080","#E25822","#0F0","#F00","0FF",
                "#DAA520", "#E55137","#666","#F0F" };
            if (GameManager.instance.colors == null)
            {
                Colors colors = new Colors(theme, 5, wordPool, hexColors, 20, 20);
                GameManager.instance.colors = colors;
            }

            return GameManager.instance.colors;
        }
        else
        {
            return null;
        }

    }
}
