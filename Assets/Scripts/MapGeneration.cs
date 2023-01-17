using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    const int MATRIX_ROWS = 11;
    const int MATRIX_COLUMNS = 11;
    double[,] matrix = new double[MATRIX_ROWS, MATRIX_COLUMNS];
    string printable = "";
    double up;
    double down;
    double right;
    double left;
    double up2 = 0;
    double down2 = 0;
    double right2 = 0;
    double left2 = 0;
    public GameObject gnd;
    public GameObject water;
    public GameObject valid;
    public GameObject invalid;
    int maxIter = 1000;
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
                if ((j == 0) | (j == MATRIX_COLUMNS-1) | (i == 0) | (i == MATRIX_ROWS-1)) //boundary
                {
                    finished = true;
                }
                else
                {
                    up =    matrix[i, j - 1];
                    down =  matrix[i, j + 1];
                    right = matrix[i + 1, j];
                    left =  matrix[i - 1, j];

                    // 1 = water
                    // 2 = valid for water
                    // 9 = not valid for water / (is land)

                    if (up == 0)
                    {
                        if ((matrix[i - 1, j - 1] == 1) | (matrix[i, j - 2] == 1) | (matrix[i + 1, j - 1] == 1))
                        {
                            matrix[i, j - 1] = 9;
                        }
                        else
                        {
                            matrix[i, j - 1] = 2;
                        }
                    }
                    if (right == 0)
                    {
                        if ((matrix[i + 1, j + 1] == 1) | (matrix[i + 2, j] == 1) | (matrix[i + 1, j - 1] == 1))
                        {
                            matrix[i + 1, j] = 9;
                        }
                        else
                        {
                            matrix[i + 1, j] = 2;
                        }
                    }
                    if (down == 0)
                    {
                        if ((matrix[i - 1, j + 1] == 1) | (matrix[i, j - 2] == 1) | (matrix[i + 1, j + 1] == 1))
                        {
                            matrix[i, j + 1] = 9;
                        }
                        else
                        {
                            matrix[i, j + 1] = 2;
                        }
                    }
                    if (left == 0)
                    {
                        if ((matrix[i - 1, j - 1] == 1) | (matrix[i - 2, j] == 1) | (matrix[i - 1, j + 1] == 1))
                        {
                            matrix[i - 1, j] = 9;
                        }
                        else
                        {
                            matrix[i - 1, j] = 2;
                        }
                    }
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