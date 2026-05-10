using UnityEngine;

[System.Serializable]
public class PuzzleManager : MonoBehaviour
{
    public GameObject[] tiles;

    private int x = 3;
    private int y = 3;

    public GameObject[,] tilearray = new GameObject[3, 3];

    private void Start()
    {
        CreateTiles();
    }

    void CreateTiles()
    {
        for (int i = 0;i<x;i++)
        {
            for (int j = 0; j < y; j++)
            {
                int r=Random.Range(0,5);
                var tile = Instantiate(tiles[r]);

                tile.transform.position = new Vector2(i, j);

                tilearray[i, j] = tile;
            }
        }
    }

}