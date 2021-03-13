using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class World
{
    private Tile[,] m_tiles;
    private int m_width;
    private int m_height;

    public int Width => m_width;

    public int Height => m_height;

    public World(int width = 100, int height = 100)
    {
        m_width = width;
        m_height = height;
        m_tiles = new Tile[width, height];

        // init
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                m_tiles[x, y] = new Tile(this, x, y);
            }
        }

    }

    public Tile GetTile(int x, int y)
    {
        if (x < 0 || x > m_width || y < 0 || y > m_height)
        {
            Debug.Log($"Tile [{x}{y}] is out fo range.");
            return null;
        }

        return m_tiles[x, y];
    }

    public void RandomizeTile()
    {
        for (int x = 0; x < m_width; x++)
        {
            for (int y = 0; y < m_height; y++)
            {
                if (Random.Range(0, 2) == 0)
                {
                    GetTile(x,y).Type = Tile.TileType.Floor;
                }
                else
                {
                    GetTile(x,y).Type = Tile.TileType.Empty;
                }
            }
        }
    }
}