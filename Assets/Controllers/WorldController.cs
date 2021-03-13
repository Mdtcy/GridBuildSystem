using System;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    private World m_world;
    
    [SerializeField]
    private Sprite m_spFloor;
    private void Start()
    {
        m_world = new World(100, 100);
        for (int x = 0; x < m_world.Width; x++)
        {
            for (int y = 0; y < m_world.Height; y++)
            {
                Tile tileData = m_world.GetTile(x, y);
                GameObject tileGo = new GameObject("tile" + x + y);
                tileGo.AddComponent<SpriteRenderer>();
                tileGo.transform.position = new Vector3(x, y, 0);
                tileData.RegisterTileChangedAction((tile) =>
                {
                    OnTileTypeChanged(tile, tileGo);
                });
                
            }
        }
        m_world.RandomizeTile();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            m_world.RandomizeTile();
        }
    }

    public void OnTileTypeChanged(Tile tile, GameObject tileGo)
    {
        if (tile.Type == Tile.TileType.Floor)
        {
            tileGo.GetComponent<SpriteRenderer>().sprite = m_spFloor;
        }
        else if (tile.Type == Tile.TileType.Empty)
        {
            tileGo.GetComponent<SpriteRenderer>().sprite = null;
        }
        else
        {
            Debug.LogError("xxx");
        }
        
    }
}
