using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public PuzzleTile[] answerTiles;   
    public PuzzleTile[] playerTiles;   

    private PuzzleTile[,] tiles = new PuzzleTile[3, 3];

    int[,] answer =
    {
        {0,1,2},
        {3,4,5},
        {6,7,8}
    };

    int[,] player;

    Vector2Int? selected = null;

    void Start()
    {
        player = new int[,]
        {
            {2,7,6},
            {5,4,1},
            {0,8,3}
        };

        SetupTiles();
        UpdateAll();
    }

    void SetupTiles()
    {
        for (int i = 0; i < playerTiles.Length; i++)
        {
            int x = i % 3;
            int y = i / 3;

            tiles[y, x] = playerTiles[i];
            playerTiles[i].x = x;
            playerTiles[i].y = y;
            playerTiles[i].manager = this;
        }
    }

    public void OnTileClick(int x, int y)
    {
        Debug.Log($"クリック {x},{y}");
        if (selected == null)
        {
            selected = new Vector2Int(x, y);
        }
        else
        {
            Swap(selected.Value, new Vector2Int(x, y));
            selected = null;

            if (Check())
            {
                Debug.Log("クリア！");
            }
        }
    }

    void Swap(Vector2Int a, Vector2Int b)
    {
        int temp = player[a.y, a.x];
        player[a.y, a.x] = player[b.y, b.x];
        player[b.y, b.x] = temp;

        UpdatePlayer();
    }

    bool Check()
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (answer[y, x] != player[y, x])
                    return false;
            }
        }
        return true;
    }

    void UpdateAll()
    {
        for (int i = 0; i < answerTiles.Length; i++)
        {
            int x = i % 3;
            int y = i / 3;
            answerTiles[i].SetColor(answer[y, x]);
        }

        UpdatePlayer();
    }

    void UpdatePlayer()
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                tiles[y, x].SetColor(player[y, x]);
            }
        }
    }
}