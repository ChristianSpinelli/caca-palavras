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
    private float spacing = 1.1f;
    
    //posição do grid no espaço
    private float gridPosX = 560, gridPosY = 700;

    private string[,] matrix;
    

    private string[] alphabet = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", 
        "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

    // Start is called before the first frame update
    void Start()
    {

        //inicia a matrix com o número de linhas e colunas
        matrix = new string[rows, cols];
       
        //gera a matriz proceduralmente
        GenerateMatrix(GameManager.instance.theme);

        //gera o grid de acordo com a matriz que foi produzida
        GenerateGrid();

    }

    
    //método para instanciar a letra escolhida e retorna um GameObject que representa o botão da letra que foir criado
    private GameObject InstantiateLetter(string letter, int posX, int posY)
    {
        GameObject newLetter = Instantiate(letterObj) as GameObject;
        newLetter.GetComponentInChildren<Text>().text = letter;
        newLetter.GetComponent<Letter>().posX = posX;
        newLetter.GetComponent<Letter>().posY = posY;
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
                GameObject newLetter = InstantiateLetter(matrix[row,col],col,row);

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
    private void GenerateMatrix(string txtTheme)
    {
        Theme theme = ThemeFactory.CreateTheme(txtTheme);


        //percorre linhas e colunas
        // para preencher a matriz com as palavras selecionadas
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                //percorre a lista de palavras selecionadas
                for (int i = 0; i < theme.SelectedWords.Count; i++)
                {
                    //verifica a posição da primeira letra de cada palavra
                    if (row == theme.SelectedWordsPosY[i] && col == theme.SelectedWordsPosX[i])
                    {
                        //verifica qual é a orientação da palavra na matriz
                        if (theme.WordsOrientation[i].ToLower() == "horizontal")
                        {
                            //percorre cada letra da palavra
                            for (int j = 0; j < theme.SelectedWords[i].Length; j++)
                            {

                                //verifica se o espaço que vai ser inserido a letra está vazio ou contém a mesma letra
                                if (matrix[row, col + j] == null || matrix[row, col + j] == theme.SelectedWords[i][j].ToString().ToUpper())
                                {

                                    matrix[row, col + j] = theme.SelectedWords[i][j].ToString().ToUpper();
                                    continue;

                                }
                                // se não, sorteia uma nova posição para a palavra onde ela não ocupe a mesma de alguma palavra existente
                                else
                                {
                                    theme.SelectedWordsPosX[i] = Random.Range(0, cols - theme.SelectedWords[i].Length);
                                    theme.SelectedWordsPosY[i] = Random.Range(0, rows);
                                    i--;
                                    row = 0;
                                    col = 0;
                                    break;
                                }
                            }

                        }
                        else if (theme.WordsOrientation[i].ToLower() == "vertical")
                        {
                            for (int j = 0; j < theme.SelectedWords[i].Length; j++)
                            {

                                if (matrix[row + j, col] == null || matrix[row + j, col] == theme.SelectedWords[i][j].ToString().ToUpper())
                                {

                                    matrix[row + j, col] = theme.SelectedWords[i][j].ToString().ToUpper();
                                    continue;

                                }
                                else
                                {
                                    theme.SelectedWordsPosX[i] = Random.Range(0, cols);
                                    theme.SelectedWordsPosY[i] = Random.Range(0, rows - theme.SelectedWords[i].Length);
                                    i--;
                                    row = 0;
                                    col = 0;
                                    break;
                                }
                            }

                        }
                        else if (theme.WordsOrientation[i].ToLower() == "diagonal")
                        {
                            for (int j = 0; j < theme.SelectedWords[i].Length; j++)
                            {

                                if (matrix[row + j, col + j] == null || matrix[row + j, col + j] == theme.SelectedWords[i][j].ToString().ToUpper())
                                {

                                    matrix[row + j, col + j] = theme.SelectedWords[i][j].ToString().ToUpper();
                                    continue;
                                }
                                else
                                {
                                    theme.SelectedWordsPosX[i] = Random.Range(0, cols - theme.SelectedWords[i].Length);
                                    theme.SelectedWordsPosY[i] = Random.Range(0, rows - theme.SelectedWords[i].Length);
                                    i--;
                                    row = 0;
                                    col = 0;
                                    break;
                                }
                            }
                        }


                    }

                }

            }
        }

        //preenche os espaços vazios da matriz com letras aleatórias.
        
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (matrix[row, col]==null)
                {
                    matrix[row, col] = alphabet[Random.Range(0, alphabet.Length)];
                }
            }
        }

        
    }



}
