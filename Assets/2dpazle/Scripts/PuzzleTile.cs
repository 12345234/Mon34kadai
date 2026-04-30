using UnityEngine;
using UnityEngine.EventSystems;

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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("“–‚½‚Á‚½: " + hit.collider.name);
                manager.OnTileClick(x,y);
            }
        }
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

}