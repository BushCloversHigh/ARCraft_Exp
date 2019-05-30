using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlockUIElement : MonoBehaviour, IPointerClickHandler
{
    public static int currentBlock = 0;

    public Material colorMat;
    private Image back;
    private CraftController controller;

    private Color unSelectColor = new Color (1, 1, 1, 0.2f), selectedColor = new Color (1, 1, 1, 0.7f);

    private void Awake ()
    {
        back = GetComponent<Image> ();
        controller = GameObject.FindWithTag ("GameController").GetComponent<CraftController> ();
    }

    public void SetBlockColor (Material color)
    {
        colorMat = color;
        transform.GetChild (0).GetComponent<Image> ().color = colorMat.color;
        if(gameObject.name == "0")
        {
            back.color = selectedColor;
        }
    }

    public void UnSelect ()
    {
        back.color = unSelectColor;
    }

    public void OnPointerClick (PointerEventData eventData)
    {
        transform.parent.GetChild (currentBlock).GetComponent<BlockUIElement> ().UnSelect ();
        currentBlock = int.Parse (gameObject.name);
        back.color = selectedColor;
        controller.ChangeBlock (colorMat);
    }
}
