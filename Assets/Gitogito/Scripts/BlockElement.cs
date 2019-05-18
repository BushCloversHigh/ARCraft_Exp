using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlockElement : MonoBehaviour, IPointerClickHandler
{
    public Material colorMat;
    private Image back;
    private CraftController controller;

    private void Awake ()
    {
        back = GetComponent<Image> ();
        controller = GameObject.FindWithTag ("GameController").GetComponent<CraftController> ();
    }

    public void SetBlockColor (Material color)
    {
        colorMat = color;
        transform.GetChild (0).GetComponent<Image> ().color = colorMat.color;
    }

    public void UnSelect ()
    {
        back.color = new Color (1, 1, 1, 0.2f);
    }

    public void OnPointerClick (PointerEventData eventData)
    {
        back.color = new Color (1, 1, 1, 0.7f);
        controller.ChangeBlock (colorMat, int.Parse (gameObject.name));
    }
}
