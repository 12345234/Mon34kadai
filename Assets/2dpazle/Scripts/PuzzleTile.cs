using UnityEngine;

public class PuzzleTile : MonoBehaviour
{
    private PuzzleManager p_manager;

    public int x;
    public int y;

    private Vector2 down;
    private Vector2 up;
    private Vector2 distance;

    private GameObject neighbortile;

    public bool ismatch;

    public Vector2 beffopos;

    private void Start()
    {
        p_manager = FindFirstObjectByType<PuzzleManager>();

        x = (int)transform.position.x;
        y = (int)transform.position.y;

        beffopos = new Vector2(x, y);
    }

    private void OnMouseDown()
    {
        down = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        up = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        distance = up - down;
        MoveTiles();
    }

    void MoveTiles()
    {
        if(distance.x>=0&&Mathf.Abs(distance.x)>Mathf.Abs(distance.y))
        {
            if(x<4)
            {
                neighbortile = p_manager.tilearray[x + 1, y];
                neighbortile.GetComponent<PuzzleTile>().x -= 1;
                x += 1;
            }
        }

        if (distance.x < 0 && Mathf.Abs(distance.x)>Mathf.Abs(distance.y))
        {
            if(x>0)
            {
                neighbortile = p_manager.tilearray[x - 1, y];
                neighbortile.GetComponent<PuzzleTile>().x += 1;
                x -= 1;
            }
        }

        if (distance.y >= 0 && Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
        {
            if(y<6)
            {
                neighbortile = p_manager.tilearray[x, y+1];

                neighbortile.GetComponent <PuzzleTile>().y -= 1;
                y += 1;
            }
        }

        if (distance.y < 0 && Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
        {
            if (y > 0)
            {
                neighbortile = p_manager.tilearray[x, y - 1];

                neighbortile.GetComponent<PuzzleTile>().y += 1;
                y -= 1;
            }
        }
    }

    void SetTileToArray()
    {
        p_manager.tilearray[x, y] = gameObject;
    }

    private void Update()
    {
        if(transform.position.x!=x||transform.position.y!=y)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(x, y), 0.3f);
            Vector2 dif = (Vector2)transform.position - new Vector2(x,y);

            if(Mathf.Abs(dif.magnitude)<0.1f)
            {
                transform.position = new Vector2(x, y);
                SetTileToArray();
            }
        }
    }
}