using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public GameObject backgroundObj, letterObj;

    //linhas e colunas da matriz 
    public int rows = 10, cols = 10;

    //espaçamento entre os objetos letras
    public float spacing = 1.1f;
    
    //posição do grid no espaço
    public float gridPosX = 600f, gridPosY = 670f;

    public string word1, word2, word3, word4, word5;

    private string[] wordPool = {"Banana", "Apple", "Orange", "Pear", "Pineapple", "Lemon",
        "Strawberry", "Watermelon", "Coconut", "Papaya", "Kiwi", "Mango", "Mandarine", "Plum", "Carambola" };

    private List<string> wordPoolList = new List<string>();

    private string[,] matrix; 
    

    private string[] alphabet = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", 
        "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < wordPool.Length; i++)
        {
            wordPoolList.Add(wordPool[i]);
        }

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
        word1 = wordPoolList[Random.Range(0,wordPoolList.Count)];
        wordPoolList.Remove(word1);
        int word1PosX =   Random.Range(0, rows - word1.Length + 1);
        int word1PosY = Random.Range(0, cols);
        Debug.Log(word1PosX+" "+word1PosY);

        word2 = wordPoolList[Random.Range(0, wordPoolList.Count)];
        wordPoolList.Remove(word2);

        word3 = wordPoolList[Random.Range(0, wordPoolList.Count)];
        wordPoolList.Remove(word3);

        word4 = wordPoolList[Random.Range(0, wordPoolList.Count)];
        wordPoolList.Remove(word4);

        word5 = wordPoolList[Random.Range(0, wordPoolList.Count)];
        wordPoolList.Remove(word5);

        

        for (int row = 0; row < rows; row++ )
        {
            for (int col = 0; col < cols; col++)
            {
                if (row == word1PosY && col == word1PosX )
                {
                    for (int i = 0; i < word1.Length; i++)
                    {
                        matrix[row, col+i] = word1[i].ToString().ToUpper();
                    }
                }
                else if(matrix[row,col] == null )
                {
                    matrix[row, col] = alphabet[Random.Range(0, alphabet.Length)];
                }

                
                
                
            }
        }
    }
}
