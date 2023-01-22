using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public GameObject gnd1;
    public GameObject gnd2;
    public GameObject water;
    public GameObject waypoint;
    public GameObject startPoint;

    public const int MATRIX_COLUMNS = 13;
    public const int MATRIX_ROWS = 11;
    public float spacing = 4f;
    int[,] matrix = new int[MATRIX_COLUMNS, MATRIX_ROWS];
    float minTiles = ((float)(MATRIX_COLUMNS - 2) * (float)(MATRIX_ROWS - 2)) / 1.8f;
    List<(int,int)> list = new List<(int, int)>();

    int tiles = 0;
    int wataFak = 0;
    
    int rand;
    int i;
    int j;
    int x1;
    int y1;
    int x2;
    int y2;
    List<int> validCoordsX = new List<int>();
    List<int> validCoordsY = new List<int>();
    bool accepted = false;
    bool finished = false;

    private void Awake()
    {
        //Debug.Log("minTiles: " + minTiles);
        (i,j) = randomStart(MATRIX_COLUMNS, MATRIX_ROWS);
        matrix[i, j] = 1;
        tiles++;

        while (accepted != true)
        {
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

                    if (!((x1 == 0) | (y1 == 0) | (x1 == MATRIX_COLUMNS - 1) | (y1 == MATRIX_ROWS - 1)))
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
                    list.Add((x2,y2));
                    tiles++;
                    i = x2;
                    j = y2;
                    wataFak = 0;
                    validCoordsX.Clear();
                    validCoordsY.Clear();
                }
                else
                {
                    finished = true;
                }
            }
            if (tiles >= minTiles)
            {
                finished = true;
                accepted = true;
                //Debug.Log("Tiles: " + tiles);
            }
            else
            {
                finished = false;
                accepted = false;                
                matrix = new int[MATRIX_COLUMNS, MATRIX_ROWS];  //verified resetting
                list = new List<(int, int)>();
                tiles = 0;
                (i, j) = randomStart(MATRIX_COLUMNS, MATRIX_ROWS);
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

        for (int x = 0; x < MATRIX_COLUMNS; x++)
        {
            for (int y = 0; y < MATRIX_ROWS; y++)
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
        for (int i = 0; i < list.Count; i++)
        {
            int x4;
            int y4;
            (x4, y4) = list[i];
            if (i == 0)
            {
                Instantiate(startPoint, new Vector3(x4 * spacing, -0.6f, y4 * spacing), Quaternion.Euler(0, 0, 0));
            }
            else
            {
                var myNewWayPoint = Instantiate(waypoint, new Vector3(x4 * spacing, -0.6f, y4 * spacing), Quaternion.Euler(0, 0, 0), GameObject.Find("Waypoints").transform);
            }
            
        }      
    }
    (int,int) randomStart(int MATRIX_COLUMNS, int MATRIX_ROWS)
    {
        int randStart;
        int x3 = 1;
        int y3 = 1;
        randStart = Random.Range(0, 3);
        switch (randStart)
        {
            case 0:
                x3 = 1;
                y3 = Random.Range(1, MATRIX_ROWS - 1);
                break;
            case 1:
                x3 = MATRIX_COLUMNS-2;
                y3 = Random.Range(1, MATRIX_ROWS - 1);
                break;
            case 2:
                x3 = Random.Range(1, MATRIX_COLUMNS - 1);
                y3 = 1;
                break;
            case 3:
                x3 = Random.Range(1, MATRIX_COLUMNS - 1);
                y3 = MATRIX_ROWS-2;
                break;
        }
        return (x3, y3);
    }
}