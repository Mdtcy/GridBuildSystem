using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityExtensions.Tween;

public class SimplePopupText : PopupText
{
    [SerializeField]
    private TweenPlayer tween;

    [SerializeField] private TextMesh m_textMesh;
    public override void Play(string text)
    {
        m_textMesh.text = text;
        tween.SetForwardDirectionAndEnabled();

    }

    public void OmFinished()
    {
        Destroy(gameObject);
    }
}
