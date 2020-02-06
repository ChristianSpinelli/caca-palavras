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
            Fruits fruits = new Fruits(theme,5,wordPool,20,20);
            return fruits;
        }
        else if (theme.ToLower() == "colors")
        {
            string[] wordPool = {"White", "Black", "Blue", "Yellow", "Brown", "Pink", "Purple", 
                "Orange", "Green", "Red", "Cyan", "Gold", "Salmon", "Gray", "Magenta"};
            Colors colors = new Colors(theme,5,wordPool,20,20);
            return colors;
        }
        else
        {
            return null;
        }

    }
}
