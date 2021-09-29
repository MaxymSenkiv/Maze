using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    public Transform CellPrefab;
    public Transform Deadlock;

    public static int _width = 3;
    public static int _height = 3;

    public Vector3 CellSize = new Vector3(1, 1, 0);

    public void SetMazeSize(float mazeSize)
    {
        _height = _width = (int)mazeSize;
    }

    void Start()
    {
        MazeGenerator generator = new MazeGenerator();

        MazeCell[,] maze = generator.GenerateMaze(_width, _height);

        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                Cell cell = Instantiate(CellPrefab, new Vector3(i * CellSize.x, j * CellSize.y, j * CellSize.z), Quaternion.identity).GetComponent<Cell>();

                cell.WallLeft.SetActive(maze[i, j].WallLeft);
                cell.WallBot.SetActive(maze[i, j].WallBot);
                cell.Plane.SetActive(maze[i, j].Plane);

                if(i == generator.Furthest.X && j == generator.Furthest.Y)
                {
                    cell.Plane.tag = "EndPoint";

                    maze[i, j].Deadlock = false;
                }

                if (maze[i, j].Deadlock)
                {
                    Instantiate(Deadlock, new Vector3(i * CellSize.x, j * CellSize.y + 1f, j * CellSize.z), Quaternion.identity);
                }
            }
        }
    }
}
