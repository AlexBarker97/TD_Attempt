using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    const int MATRIX_ROWS = 11;
    const int MATRIX_COLUMNS = 11;
    int[,] matrix = new int[MATRIX_ROWS, MATRIX_COLUMNS];
    int[] neighbour = new int[4];
    List<int> validCoordsX = new List<int>();
    List<int> validCoordsY = new List<int>();
    int x1;
    int y1;
    int x2;
    int y2;
    int rand;
    public GameObject gnd;
    public GameObject water;
    public GameObject valid;
    public GameObject invalid;
    int maxIter = 10000;
    int iter = 0;

    private void Start()
    {
        int i = 5;
        int j = 5; 
        matrix[i, j] = 1;
        bool finished = false;

        while (finished != true)
        {
            if (matrix[i, j] == 1)
            {
                if ((j == 1) | (j == MATRIX_COLUMNS - 2) | (i == 1) | (i == MATRIX_ROWS - 2))   //boundary
                {
                    finished = true;
                }
                else
                {
                    neighbour[0] = matrix[i, j - 1];    //up
                    neighbour[1] = matrix[i, j + 1];   //right
                    neighbour[2] = matrix[i + 1, j];    //down
                    neighbour[3] = matrix[i - 1, j];   //left

                    //-1 = no data
                    //0 = gnd
                    //1 = water
                    //2 = valid
                    //9 = invalid

                    for (int num = 0; num <= neighbour.Length - 1; num++) //FOR EACH NEIGHBOUR
                    {
                        switch (num)                                    //Set x1,y1 coord to the neighbour being looked at
                        {
                            case 0:
                                x1 = i;
                                y1 = j - 1;
                                break;
                            case 1:
                                x1 = i + 1;
                                y1 = j;
                                break;
                            case 2:
                                x1 = i;
                                y1 = j + 1;
                                break;
                            case 3:
                                x1 = i - 1;
                                y1 = j;
                                break;
                        }

                        if (matrix[x1, y1] == 0)                        //If the neighbour being looked at is ground label it with it's validity of being water (2=valid, 9=invalid)
                        {
                            switch (num)
                            {
                                case 0:
                                    if ((matrix[x1 - 1, y1] == 1) | (matrix[x1, y1 - 1] == 1) | (matrix[x1 + 1, y1] == 1))
                                    {
                                        matrix[x1, y1] = 9;
                                    }
                                    else
                                    {
                                        matrix[x1, y1] = 2;
                                        validCoordsX.Add(x1);
                                        validCoordsY.Add(y1);
                                    }
                                    break;
                                case 1:
                                    if ((matrix[x1, y1 - 1] == 1) | (matrix[x1 + 1, y1] == 1) | (matrix[x1, y1 + 1] == 1))
                                    {
                                        matrix[x1, y1] = 9;
                                    }
                                    else
                                    {
                                        matrix[x1, y1] = 2;
                                        validCoordsX.Add(x1);
                                        validCoordsY.Add(y1);
                                    }
                                    break;
                                case 2:
                                    if ((matrix[x1 + 1, y1] == 1) | (matrix[x1, y1 + 1] == 1) | (matrix[x1 - 1, y1] == 1))
                                    {
                                        matrix[x1, y1] = 9;
                                    }
                                    else
                                    {
                                        matrix[x1, y1] = 2;
                                        validCoordsX.Add(x1);
                                        validCoordsY.Add(y1);
                                    }
                                    break;
                                case 3:
                                    if ((matrix[x1, y1 + 1] == 1) | (matrix[x1 - 1, y1] == 1) | (matrix[x1, y1 - 1] == 1))
                                    {
                                        matrix[x1, y1] = 9;
                                    }
                                    else
                                    {
                                        matrix[x1, y1] = 2;
                                        validCoordsX.Add(x1);
                                        validCoordsY.Add(y1);
                                    }
                                    break;
                            }
                        }
                    }
                    rand = Random.Range(0, validCoordsX.Count);
                    x2 = validCoordsX[rand];
                    y2 = validCoordsY[rand];
                    matrix[x2, y2] = 1;
                    /*
                    validCoordsX.Remove(x2);
                    validCoordsX.Remove(y2);
                    */
                }
            }
            i++;
            if (i == MATRIX_ROWS)
            {
                i = 0;
                j++;
                if (j == MATRIX_COLUMNS)
                {
                    j = 0;
                }
            }
            iter++;
            if (iter >= maxIter)
            {
                finished = true;
            }
        }

        for (int x = 0; x < MATRIX_ROWS; x++)
        {
            for (int y = 0; y < MATRIX_COLUMNS; y++)
            {
                if (matrix[x, y] == 0)
                {
                    Instantiate(gnd, new Vector3(x*4, 0.0f, y*4), Quaternion.Euler(0, 0, 0));
                }
                if (matrix[x, y] == 1)
                {
                    Instantiate(water, new Vector3(x * 4, -1.5f, y * 4), Quaternion.Euler(0, 0, 0));
                }
                if (matrix[x, y] == 2)
                {
                    Instantiate(valid, new Vector3(x * 4, 0.0f, y * 4), Quaternion.Euler(0, 0, 0));
                }
                if (matrix[x, y] == 9)
                {
                    Instantiate(invalid, new Vector3(x * 4, 0.0f, y * 4), Quaternion.Euler(0, 0, 0));
                }
            }
        }
    }
}
