using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CaveGenerator : MonoBehaviour
{
    [Header("Map Settings")] public int width = 50;

    public int height = 50;

    [Range(0, 100)] public int fillPercent = 40;

    [Header("Cellular Automata")] public int smoothInteraction = 3;

    [Header("Visualization")] public GameObject wallPrefab;
    public GameObject floorPrefab;
    public float cellSize = 1;

    private int[,] map;

    
    void Start()
    {
        GenerateMap();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
                                        GenerateMap();
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
                                    SmoothMap();
                                    RenderMap();
        }
    }

   
    void GenerateMap()
    {
        map = new int[width, height];
        RandomFillMap();

        for (int i = 0; i < smoothInteraction; i++)
        {
            SmoothMap();
        }

        RenderMap();
    }

    private void RandomFillMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    map[x, y] = 1;
                }
                else
                {
                    map[x, y] = (Random.Range(0, 100) < fillPercent) ? 1 : 0;
                }
            }
        }

    }

    private void SmoothMap()
    {
        int[,] newMap = new int[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int neighborCount = GetSorroundingWallCount(x, y);
                if (neighborCount > 4)
                {
                    newMap[x, y] = 1;
                }
                else if (neighborCount < 4)
                {
                    newMap[x, y] = 0;
                }
                else
                {
                    newMap[x, y] = map[x, y];
                }
            }
        }

        map = newMap;
    }


    public int GetSorroundingWallCount(int gridX, int gridY)
    {
        int wallCount = 0;
        for (int nx = gridX-1; nx <= gridX + 1; nx++)
        {
            for (int ny = gridY-1; ny <= gridY+1; ny++)
            {
                if (nx >= 0 && nx < width && ny<height && ny>=0 )
                {
                    if (nx!=gridX || ny !=gridY)
                    {
                        wallCount += map[nx, ny];
                    }
                }
                else
                {
                    wallCount++;
                }
            }
        }

        return wallCount;
    }

    private void RenderMap()
    {
        foreach (Transform child in transform)
        {
                          Destroy(child.gameObject);
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 pos = new Vector3(x * cellSize, 0, y * cellSize);
                if (map[x,y]==1)
                {
                    Instantiate(wallPrefab, pos, quaternion.identity, transform);
                }
                else
                {
                    Instantiate(floorPrefab, pos, quaternion.identity, transform);

                }
            }
        }
    }
}
