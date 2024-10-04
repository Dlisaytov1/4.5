using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [Header("Настройки генерации лабиринта")]
    [Space(10)]
    [Tooltip("Высота лабиринта")]
    [SerializeField] private int width = 10;
    [Space(3)]
    [Tooltip("Ширина лабиринта")]
    [SerializeField] private int height = 10;
    [Space(3)]
    [Tooltip("Префаб (из чего будет составляться сам лабиринт)")]
    [SerializeField] private GameObject wallPrefab;
    [Space(3)]
    [Tooltip("Размер ячейки лабиринта")]
    [SerializeField] private float cellSize = 1f;

    private int[,] maze;

    private void Start()
    {
        GenerateMaze();
        CreateMazeVisual();
    }

    private void GenerateMaze()
    {
        maze = new int[height, width];
        int[] sets = new int[width];
        int nextSet = 1;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (sets[x] == 0)
                {
                    sets[x] = nextSet++;
                }
            }

            for (int x = 0; x < width - 1; x++)
            {
                if (sets[x] != sets[x + 1] && Random.Range(0, 2) == 0)
                {
                    UnionSets(sets, sets[x], sets[x + 1]);
                }
                else
                {
                    maze[y, x] |= 1;
                }
            }

            bool[] hasDownPassage = new bool[width];
            for (int x = 0; x < width; x++)
            {
                if (Random.Range(0, 2) == 0 || y == height - 1)
                {
                    maze[y, x] |= 2;
                }
                else
                {
                    hasDownPassage[x] = true;
                }
            }

            if (y < height - 1)
            {
                for (int x = 0; x < width; x++)
                {
                    if (!hasDownPassage[x])
                    {
                        sets[x] = 0;
                    }
                }
            }
        }
    }

    private void UnionSets(int[] sets, int setA, int setB)
    {
        for (int i = 0; i < sets.Length; i++)
        {
            if (sets[i] == setB)
            {
                sets[i] = setA;
            }
        }
    }

    private void CreateMazeVisual()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector3 position = new Vector3(x * cellSize, y * cellSize, 0);

                if ((maze[y, x] & 1) != 0)
                {
                    Instantiate(wallPrefab, position + new Vector3(cellSize / 2, 0, 0), Quaternion.identity, transform);
                }

                if ((maze[y, x] & 2) != 0)
                {
                    Instantiate(wallPrefab, position + new Vector3(0, cellSize / 2, 0), Quaternion.Euler(0, 0, 90), transform);
                }

                if (x == width - 1)
                {
                    Instantiate(wallPrefab, position + new Vector3(cellSize, 0, 0), Quaternion.identity, transform);
                }
                if (y == height - 1)
                {
                    Instantiate(wallPrefab, position + new Vector3(0, cellSize, 0), Quaternion.Euler(0, 0, 90), transform);
                }
            }
        }
    }
}