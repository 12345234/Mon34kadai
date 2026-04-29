using UnityEngine;

public class Tile : MonoBehaviour
{
    private ObjectPool pool;
    private Transform player;

    public void Init(ObjectPool p, Transform pl)
    {
        pool = p;
        player = pl;
    }

    void Update()
    {
        if (transform.position.z < player.position.z - 20f)
        {
            pool.objectpool.Release(gameObject);
        }
    }
}