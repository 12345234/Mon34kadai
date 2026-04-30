using UnityEngine;

public class PuzzleTile : MonoBehaviour
{
    public int x;
    public int y;

    public PuzzleManager manager;

    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void SetColor(int id)
    {
        sr.color = GetColor(id);
    }
    

    Color GetColor(int id)
    {
        switch (id)
        {
            case 0: return Color.white;
            case 1: return Color.yellow;
            case 2: return Color.green;
            case 3: return Color.cyan;
            case 4: return new Color(1f, 0.5f, 0f);
            case 5: return Color.magenta;
            case 6: return Color.red;
            case 7: return Color.blue;
            case 8: return Color.black;
        }
        return Color.gray;
    }

    void OnMouseDown()
    {
        Debug.Log("aaa");
        manager.OnTileClick(x, y);
    }
}