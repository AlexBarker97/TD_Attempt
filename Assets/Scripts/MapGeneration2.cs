using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration2 : MonoBehaviour
{
    const int MATRIX_ROWS = 11;
    const int MATRIX_COLUMNS = 11;
    int[,] matrix = new int[MATRIX_ROWS, MATRIX_COLUMNS];
    List<int> validCoordsX = new List<int>();
    List<int> validCoordsY = new List<int>();
    public const float spacing = 4.2f;
    int x1;
    int y1;
    int x2;
    int y2;
    public GameObject gnd;
    public GameObject water;
    public GameObject valid;
    public GameObject invalid;
    int rand;
    int maxIter = 100;
    int iter = 0;
    int wataFak = 0;
    int minTiles = 46;
    int tiles = 0;
    bool accepted = false;

    private void Start()
    {
        int i = 5;
        int j = 5; 
        bool finished = false;
        if (!accepted)
        {
            matrix = new int[MATRIX_ROWS, MATRIX_COLUMNS];
            matrix[i, j] = 1;
            tiles = 0;
            while (finished != true)
            {
                for (int num = 0; num <= 3; num++) //FOR EACH NEIGHBOUR
                {
                    switch (num)
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

                    if (!((x1 == 0) | (y1 == 0) | (x1 == MATRIX_ROWS - 1) | (y1 == MATRIX_COLUMNS - 1)))
                    {
                        wataFak = matrix[x1, y1 + 1] + matrix[x1 + 1, y1] + matrix[x1, y1 - 1] + matrix[x1 - 1, y1];
                        Debug.Log(wataFak);
                        if (wataFak < 2)
                        {
                            validCoordsX.Add(x1);
                            validCoordsY.Add(y1);
                        }
                    }
                }

                rand = Random.Range(0, validCoordsX.Count - 1);
                if (validCoordsX.Count > 0)
                {
                    x2 = validCoordsX[rand];
                    y2 = validCoordsY[rand];
                    matrix[x2, y2] = 1;
                    i = x2;
                    j = y2;
                    tiles++;
                    wataFak = 0;
                    validCoordsX.Clear();
                    validCoordsY.Clear();
                }
                else
                {

                }
                iter++;
                if (iter >= maxIter)
                {
                    finished = true;
                }
            }
            if (tiles < minTiles)
            {
                finished = false;
                accepted = false;
            }
        }

        for (int x = 0; x < MATRIX_ROWS; x++)
        {
            for (int y = 0; y < MATRIX_COLUMNS; y++)
            {
                if (matrix[x, y] == 0)
                {
                    Instantiate(gnd, new Vector3(x * spacing, 0.0f, y * spacing), Quaternion.Euler(0, 0, 0));
                }
                if (matrix[x, y] == 1)
                {
                    Instantiate(water, new Vector3(x * spacing, -1.5f, y * spacing), Quaternion.Euler(0, 0, 0));
                }
                if (matrix[x, y] == 2)
                {
                    Instantiate(valid, new Vector3(x * spacing, 0.0f, y * spacing), Quaternion.Euler(0, 0, 0));
                }
                if (matrix[x, y] == 9)
                {
                    Instantiate(invalid, new Vector3(x * spacing, 0.0f, y * spacing), Quaternion.Euler(0, 0, 0));
                }
            }
        }
    }
}
