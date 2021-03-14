using UnityEngine;

public class PopupTextController: MonoBehaviour
{
    [SerializeField]
    private PopupText m_simplePopupText;

    public enum Type
    {
       SimpleText 
    }

    public void Create(string text, Vector3 position, Type type = Type.SimpleText)
    { 
        if(type == Type.SimpleText)
        {
            var popup = Instantiate(m_simplePopupText, position, Quaternion.identity);
            popup.Play(text);
        }
        else
        {
            Debug.LogError("[PopupTextController] Undefined Type");
        }
    }
}
