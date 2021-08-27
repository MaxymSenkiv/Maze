using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    public Transform CellPrefab;

    void Start()
    {
        MazeGenerator generator = new MazeGenerator();
        MazeCell[,] maze = generator.GenerateMaze();
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                Cell cell = Instantiate(CellPrefab, new Vector2(i, j), Quaternion.identity).GetComponent<Cell>();
                cell.WallLeft.SetActive(maze[i, j].WallLeft);
                cell.WallBot.SetActive(maze[i, j].WallBot);
            }
        }
    }
}
