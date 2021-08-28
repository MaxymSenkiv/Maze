using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell
{
    public int X;
    public int Y;

    public bool WallLeft = true;
    public bool WallBot = true;
    public bool Plane = true;
    public bool Visited = false;
    public int DistanceFromStart;
}
public class MazeGenerator
{
    [SerializeField] private int _width = 5;
    [SerializeField] private int _height = 5;
    public MazeCell Furthest;

    public MazeCell[,] GenerateMaze()
    {
        MazeCell[,] maze = new MazeCell[_width, _height];

        for (int i = 0; i < maze.GetLength(0); i++)
        {
            for (int j = 0; j < maze.GetLength(1); j++)
            {
                maze[i, j] = new MazeCell { X = i, Y = j };
            }
        }

        for (int i = 0; i < maze.GetLength(0); i++)
        {
            maze[i, _height - 1].WallLeft = false;
            maze[i, _height - 1].Plane = false;
        }
        for (int i = 0; i < maze.GetLength(1); i++)
        {
            maze[_width - 1, i].WallBot = false;
            maze[_width - 1, i].Plane = false;
        }

        MazeCreation(maze);

        CreateMazeExit(maze);

        return maze;
    }

    public void MazeCreation(MazeCell[,] maze)
    {
        MazeCell current = maze[0, 0];
        current.Visited = true;
        Stack<MazeCell> stack = new Stack<MazeCell>();
        do
        {
            List<MazeCell> UnvisitedNeighbours = new List<MazeCell>();

            int x = current.X;
            int y = current.Y;

            if (x > 0 && !maze[x - 1, y].Visited) UnvisitedNeighbours.Add(maze[x - 1, y]);
            if (y > 0 && !maze[x, y-1].Visited) UnvisitedNeighbours.Add(maze[x, y-1]);
            if (x < _width-2 && !maze[x + 1, y].Visited) UnvisitedNeighbours.Add(maze[x + 1, y]);
            if (y < _height-2 && !maze[x, y+1].Visited) UnvisitedNeighbours.Add(maze[x, y+1]);

            if (UnvisitedNeighbours.Count > 0)
            {
                MazeCell chosen = UnvisitedNeighbours[UnityEngine.Random.Range(0, UnvisitedNeighbours.Count)];
                RemoveWall(current, chosen);

                chosen.Visited = true;
                stack.Push(chosen);
                current = chosen;
                chosen.DistanceFromStart = stack.Count;
            }
            else
            {
                current = stack.Pop();
            }
        }
        while (stack.Count > 0);
    }

    private void RemoveWall(MazeCell current, MazeCell chosen)
    {
        if(current.X == chosen.X)
        {
            if (current.Y > chosen.Y) current.WallBot = false;
            else chosen.WallBot = false;
        }
        if(current.Y == chosen.Y)
        {
            if (current.X > chosen.X) current.WallLeft = false;
            else chosen.WallLeft = false;
        }
    }

    private void CreateMazeExit(MazeCell[,] maze)
    {
        Furthest = maze[0, 0];

        for (int x = 0; x < _width; x++)
        {
            if (maze[x, _height - 2].DistanceFromStart > Furthest.DistanceFromStart) Furthest = maze[x, _height - 2];
            if (maze[x, 0].DistanceFromStart > Furthest.DistanceFromStart) Furthest = maze[x, 0];
        }
        for (int y = 0; y < _height; y++)
        {
            if (maze[_width - 2, y].DistanceFromStart > Furthest.DistanceFromStart) Furthest = maze[_width - 2, y];
            if (maze[0, y].DistanceFromStart > Furthest.DistanceFromStart) Furthest = maze[0, y];
        }
        if (Furthest.X == 0) Furthest.WallLeft = false;
        else if (Furthest.X == _width - 2) maze[_width-1, Furthest.Y].WallLeft = false;
        if (Furthest.Y == 0) Furthest.WallBot = false;
        else if (Furthest.Y == _height - 2) maze[Furthest.X, _height-1].WallBot = false;
    }
}
