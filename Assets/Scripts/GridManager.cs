using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public GameObject backgroundObj, letterObj;

    //linhas e colunas da matriz 
    public int rows = 20, cols = 20;

    //espaçamento entre os objetos letras
    private float spacing = Screen.width/1280 + 0.1f;
    
    //posição do grid no espaço
    private float gridPosX = Screen.width * 0.45f, gridPosY = Screen.height * 0.96f;

    private string[,] matrix; 
    

    private string[] alphabet = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", 
        "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

    // Start is called before the first frame update
    void Start()
    {

        //inicia a matrix com o número de linhas e colunas
        matrix = new string[rows, cols];
       
        //gera a matriz proceduralmente
        GenerateMatrix();

        //gera o grid de acordo com a matriz que foi produzida
        GenerateGrid();
    

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    //método para instanciar a letra escolhida e retorna um GameObject que representa o botão da letra que foir criado
    private GameObject InstantiateLetter(string letter)
    {
        GameObject newLetter = Instantiate(letterObj) as GameObject;
        newLetter.GetComponentInChildren<Text>().text = letter;
        newLetter.transform.SetParent(backgroundObj.transform,false);
        
        return newLetter;
    }

    //método para instanciar as letras na tela de acordo com a matriz
    private void GenerateGrid()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject newLetter = InstantiateLetter(matrix[row,col]);

                //após inserir um elemento no grid atualiza a posição para o próximo
                /*calcula a posição baseado na posição do elemento na matriz, multiplicado pelo espaçamento entre
                os objetos e multiplicado pelo tamanho do objeto, 
                ao final soma com um valor para colocá-lo na posição desejada no espaço*/
                float letterSize = newLetter.GetComponent<RectTransform>().rect.width;

                float posX = (col * spacing * letterSize) +gridPosX;
                float posY = (row * spacing * (-1) * letterSize)+gridPosY;
                newLetter.transform.position = new Vector3(posX, posY, 0);
                
            }
        }
    }

    //método para preencher a matrix proceduralmente
    private void GenerateMatrix()
    {
        Fruits fruits = (Fruits) ThemeFactory.CreateTheme("fruits");
       
        Debug.Log(fruits.SelectedWords[0]);
        Debug.Log(fruits.WordsOrientation[0]);
        Debug.Log(fruits.SelectedWords[1]);
        Debug.Log(fruits.WordsOrientation[1]);
        Debug.Log(fruits.SelectedWords[2]);
        Debug.Log(fruits.WordsOrientation[2]);
        Debug.Log(fruits.SelectedWords[3]);
        Debug.Log(fruits.WordsOrientation[3]);
        Debug.Log(fruits.SelectedWords[4]);
        Debug.Log(fruits.WordsOrientation[4]);
        

        //percorre linhas e colunas
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                //percorre a lista de palavras selecionadas
                for (int i = 0; i < fruits.SelectedWords.Count; i++)
                {
                    //verifica a posição da primeira letra de cada palavra
                    if (row == fruits.SelectedWordsPosY[i] && col == fruits.SelectedWordsPosX[i])
                    {
                        //verifica qual é a orientação da palavra na matriz
                        if (fruits.WordsOrientation[i].ToLower() == "horizontal")
                        {
                            //preenche na tabela cada letra de acordo com a orientação.
                            for (int j = 0; j < fruits.SelectedWords[i].Length; j++)
                            {
                                matrix[row, col + j] = fruits.SelectedWords[i][j].ToString().ToUpper();
                            }
                        
                        }else if (fruits.WordsOrientation[i].ToLower() == "vertical")
                        {
                            for (int j = 0; j < fruits.SelectedWords[i].Length; j++)
                            {
                                matrix[row+j, col] = fruits.SelectedWords[i][j].ToString().ToUpper();
                            }
                        
                        }else if (fruits.WordsOrientation[i].ToLower() == "diagonal")
                        {
                            for (int j = 0; j < fruits.SelectedWords[i].Length; j++)
                            {
                                matrix[row + j, col + j] = fruits.SelectedWords[i][j].ToString().ToUpper();
                            }
                        }
                        

                    }
                    //preenche os espaços restantes com letras aleatórias
                    else if (matrix[row, col] == null)
                    {
                        matrix[row, col] = alphabet[Random.Range(0, alphabet.Length)];
                    }
                }             

            }
        }



    }



}
