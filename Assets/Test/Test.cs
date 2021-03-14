using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class Test : MonoBehaviour
{
    public Grid grid;

    public Transform root;

    public bool showDebugLine;
    [Button]
    private void Start()
    {
        for (var x = 0; x < 50; x++)
        {
            for (var y = 0; y < 50; y++)
            {
                CreateWorldText(transform, x + "," + y, grid.CellToLocal(new Vector3Int(x, y, 0))+grid.cellSize / 2, 20, TextAnchor.MiddleCenter, TextAlignment.Center,
                Color.white, 100);
            }
        }
    }

    [Inject]
    private PopupTextController m_popupTextController;
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            m_popupTextController.Create(grid.WorldToCell(pos).ToString(), pos);
        }
    }

    private void OnDrawGizmos()
    {
        if (showDebugLine)
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

    }

    public static TextMesh CreateWorldText(Transform parent, string text,Vector3 localPosition, int fontSize, TextAnchor textAnchor, 
    TextAlignment textAlignment, Color color, int sortingOrder)
    {
        GameObject gameObject = new GameObject("World Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        gameObject.transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        var textMesh = transform.GetComponent<TextMesh>();
        textMesh.fontSize = fontSize;
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.color = color;
        textMesh.text = text;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;

        return textMesh;
    }
}
