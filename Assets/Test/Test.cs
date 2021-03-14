using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Grid grid;

    public Transform transform;

    private void Start()
    {
        for (var x = -500; x < 500; x++)
        {
            for (var y = 500; y < 500; y++)
            {
                CreateWorldText(this.transform, x + "," + y, grid.CellToLocal(new Vector3Int(x, y, 0)), 15, TextAnchor.MiddleCenter, TextAlignment.Center,
                Color.white, 100);
            }
        }
    }
    private void Update()
    {
    
        // Debug.Log($"{grid.WorldToCell(transform.position)}");
    }

    private void OnDrawGizmos()
    {
        for (var x = -500; x < 500; x++)
        {
            Debug.DrawLine(grid.CellToWorld(new Vector3Int(x, -500, 0)), grid.CellToWorld(new Vector3Int(x, 500, 0)), Color.white);
        }
        for (var y = -500; y < 500; y++)
        {
            Debug.DrawLine(grid.CellToWorld(new Vector3Int(-500, y, 0)), grid.CellToWorld(new Vector3Int(500, y, 0)), Color.white);
        }
    }

    public static TextMesh CreateWorldText(Transform parent, string text,Vector3 localPosition, int fontSize, TextAnchor textAnchor, 
    TextAlignment textAlignment, Color color, int sortingOrder)
    {
        Debug.Log("ttt");
        GameObject gameObject = new GameObject("World Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
Debug.Log("tssstt");
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        var textMesh = transform.GetComponent<TextMesh>();
        textMesh.fontSize = fontSize;
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;

        return textMesh;
    }
}
