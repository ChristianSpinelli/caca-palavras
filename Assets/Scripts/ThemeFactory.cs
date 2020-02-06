using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ThemeFactory 
{
  
    public static Theme CreateTheme(string theme)
    {
        if (theme.ToLower() == "fruits")
        {
            Fruits fruits = new Fruits(5,20,20);
            return fruits;
        }
        else
        {
            return null;
        }

    }
}
