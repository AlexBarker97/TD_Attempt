using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration2 : MonoBehaviour
{
    const int MATRIX_ROWS = 11;
    const int MATRIX_COLUMNS = 11;
    public const float spacing = 4f;
    int[,] matrix = new int[MATRIX_ROWS, MATRIX_COLUMNS];

    List<int> validCoordsX = new List<int>();
    List<int> validCoordsY = new List<int>();
    
    int x1;
    int y1;
    int x2;
    int y2;
    public GameObject gnd1;
    public GameObject gnd2;
    public GameObject water;
    int rand;
    int maxIter = 1000;
    int iter = 0;
    int wataFak = 0;
    int minTiles = 45; //49 works in half decent time, 40 fast and decent, 50 long but possible
    int tiles = 0;
    bool accepted = false;
    bool finished = false;
    int i;
    int j;

    private void Start()
    {
        (i,j) = randomStart(MATRIX_ROWS, MATRIX_COLUMNS);

        while (accepted != true)
        {
            while (finished != true)
            {
                matrix[i, j] = 1;
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
                        wataFak = matrix[x1, y1 + 1] + matrix[x1 + 1, y1] + matrix[x1, y1 - 1] + matrix[x1 - 1, y1] + matrix[x1, y1];
                        if (wataFak < 2)
                        {
                            validCoordsX.Add(x1);
                            validCoordsY.Add(y1);
                        }
                    }
                }

                rand = Random.Range(0, validCoordsX.Count);
                if (validCoordsX.Count > 0)
                {
                    x2 = validCoordsX[rand];
                    y2 = validCoordsY[rand];
                    matrix[x2, y2] = 1;
                    tiles++;
                    i = x2;
                    j = y2;
                    wataFak = 0;
                    validCoordsX.Clear();
                    validCoordsY.Clear();
                }
                iter++;
                if (iter >= maxIter)
                {
                    finished = true;
                }
            }
            if (tiles > minTiles)
            {
                finished = true;
                accepted = true;
            }
            else
            {
                finished = false;
                accepted = false;                
                matrix = new int[MATRIX_ROWS, MATRIX_COLUMNS];  //verified resetting
                iter = 0;
                tiles = 0;
                (i, j) = randomStart(MATRIX_ROWS, MATRIX_COLUMNS);
            }

            /*
            string test = "";
            for (int b = 0; b < MATRIX_COLUMNS; b++)
            {
                for (int v = 0; v < MATRIX_ROWS; v++)
                {
                    test = test + matrix[b, v].ToString();
                }
                Debug.Log(test);
                test = "";
            }
            Debug.Log("END");
            */
        }

        for (int x = 0; x < MATRIX_ROWS; x++)
        {
            for (int y = 0; y < MATRIX_COLUMNS; y++)
            {
                if (matrix[x, y] == 0)
                {
                    if ((x + y) % 2 == 0)
                    {
                        Instantiate(gnd1, new Vector3(x * spacing, 0.0f, y * spacing), Quaternion.Euler(0, 0, 0));
                    }
                    else
                    {
                        Instantiate(gnd2, new Vector3(x * spacing, 0.0f, y * spacing), Quaternion.Euler(0, 0, 0));
                    }
                }
                if (matrix[x, y] == 1)
                {
                    Instantiate(water, new Vector3(x * spacing, -1.5f, y * spacing), Quaternion.Euler(0, 0, 0));
                }
            }
        }
    }
    (int,int) randomStart(int MATRIX_ROWS, int MATRIX_COLUMNS)
    {
        int randStart;
        int x3 = 1;
        int y3 = 1;
        randStart = Random.Range(0, 3);
        switch (randStart)
        {
            case 0:
                x3 = 1;
                y3 = Random.Range(1, MATRIX_COLUMNS - 1);
                break;
            case 1:
                x3 = 9;
                y3 = Random.Range(1, MATRIX_COLUMNS - 1);
                break;
            case 2:
                x3 = Random.Range(1, MATRIX_ROWS - 1);
                y3 = 1;
                break;
            case 3:
                x3 = Random.Range(1, MATRIX_ROWS - 1);
                y3 = 9;
                break;
        }
        Debug.Log(x3);
        Debug.Log(y3);
        return (x3, y3);
    }
}