using UnityEngine;
using UnityEngine.EventSystems;

public class TouchPanel : MonoBehaviour, IPointerDownHandler
{

    private bool isTouching = false, isDouble = false;

    private CraftController craftController;

    private float scale1, scale2;

    float t = 0;

    private void Awake ()
    {
        craftController = GameObject.FindWithTag ("GameController").GetComponent<CraftController> ();
    }

    private void Update ()
    {
        if(Input.touchCount == 0)
        {
            t = 0;
            isTouching = false;
            isDouble = false;
            return;
        }

        if (!isTouching)
        {
            return;
        }

        if (Input.touchCount == 1)
        {
            if (isDouble)
            {
                return;
            }
            Touch touch = Input.GetTouch (0);
            t += Time.deltaTime;
            if (t < 0.2f)
            {
                if (touch.phase == TouchPhase.Ended)
                {
                    t = 0;
                    craftController.PutBlock (touch.position);
                }
            }
            else
            {
                craftController.DestroyBlock (touch.position);
            }
        }
        else if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch (0);
            Touch touch2 = Input.GetTouch (1);
            scale1 = Vector2.Distance (touch1.position, touch2.position);
            if (!isDouble)
            {
                isDouble = true;
                scale2 = scale1;
            }
            craftController.ChangeScale (scale1 - scale2);
            scale2 = scale1;
        }
    }

    private bool FloatTermZero (float f)
    {
        return System.Math.Abs (f) > Mathf.Epsilon;
    }

    public void OnPointerDown (PointerEventData eventData)
    {
        isTouching = true;
    }

}
