using UnityEngine;

public class Setflor : MonoBehaviour
{
    [SerializeField] ObjectPool pool;
    [SerializeField] float tileLength;//•\Ž¦‚·‚éŠÔŠu
    [SerializeField] int visibleTiles;

    private float spawnZ = -3;

    [SerializeField] private Transform player;

    void Start()
    {
        for (int i = 0; i < visibleTiles; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        if (player.position.z > spawnZ - (visibleTiles * tileLength))
        {
            SpawnTile();
        }
    }

    void SpawnTile()
    {
        GameObject obj = pool.objectpool.Get();

        obj.transform.position = new Vector3(0, 0, spawnZ);

        spawnZ += tileLength;

        Tile tile = obj.GetComponent<Tile>();
        tile.Init(pool, player);
    }
}