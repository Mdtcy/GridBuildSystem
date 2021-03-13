using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private Vector3 m_laseFramePos;

    [SerializeField]
    private GameObject m_goCussor;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curFramePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        curFramePos.z = 0;

        m_goCussor.transform.position = curFramePos;
        if (Input.GetMouseButton(2) || Input.GetMouseButton(1))
        {
            Vector3 diff = m_laseFramePos - curFramePos;
            Camera.main.transform.Translate(diff);
        }

        m_laseFramePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        m_laseFramePos.z = 0;
    }
}
