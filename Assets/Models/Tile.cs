using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile 
{
    public enum TileType { Empty, Floor }

    private LooseObject m_looseObject;
    private InstalledObject m_installedObject;
    private TileType m_type;
    private Action<Tile> actOnTileTypeChanged;
    
    public TileType Type
    {
        get => m_type;
        set
        {
            if (m_type != value)
            {
                m_type = value;
                actOnTileTypeChanged?.Invoke(this);
            }
        }
    }

    private World m_world;
    private int m_x;
    private int m_y;

    public Tile(World world, int x, int y)
    {
        m_world = world;
        m_x = x;
        m_y = y;
    }

    public void RegisterTileChangedAction(Action<Tile> action)
    {
        actOnTileTypeChanged += action;
    }

    public void UnregisterOnTileChangedAction(Action<Tile> action)
    {
        actOnTileTypeChanged -= action;
    }

}
