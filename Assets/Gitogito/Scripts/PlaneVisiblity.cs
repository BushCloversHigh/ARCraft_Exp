using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlaneVisiblity : MonoBehaviour, IPointerClickHandler
{
    public static bool isVisible = false;

    private Image img;

    private void Awake ()
    {
        img = GetComponent<Image> ();
    }

    public void OnPointerClick (PointerEventData eventData)
    {
        isVisible = !isVisible;
        if (isVisible)
        {
            img.color = new Color (1, 1, 1, 0.8f);
        }
        else
        {
            img.color = new Color (0.2f, 0.2f, 0.2f, 0.4f);
        }
    }
}
