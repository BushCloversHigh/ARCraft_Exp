using UnityEngine;

public class CraftController : MonoBehaviour
{

    [SerializeField] private GameObject currentBlock;
    private MeshRenderer meshRenderer;

    [SerializeField] private GameObject blocksContent;
    private BlockElement[] blockElements;

    private Transform mainCam;

    private void Awake ()
    {
        meshRenderer = currentBlock.GetComponent<MeshRenderer> ();
        blockElements = blocksContent.GetComponentsInChildren<BlockElement> ();

        mainCam = Camera.main.transform;
    }

    public void ChangeBlock (Material colorMat, int which)
    {
        meshRenderer.material = colorMat;
        for (int i = 0 ; i < blockElements.Length ; i++)
        {
            if(i == which)
            {
                continue;
            }
            blockElements[i].UnSelect ();
        }
    }

    public void PutBlock ()
    {
        Touch touch = Input.GetTouch (0);
        Ray camRay = Camera.main.ScreenPointToRay (touch.position);
        RaycastHit hit;

        if(Physics.Raycast(camRay, out hit))
        {
            Vector3 putPos = hit.point;
            putPos.x = FloatToInt (putPos.x);
            putPos.y = FloatToInt (putPos.y);
            putPos.z = FloatToInt (putPos.z);

            Instantiate (currentBlock, putPos, Quaternion.Euler (Vector3.zero));
        }
    }

    private float FloatToInt (float f)
    {
        return Mathf.Round (f);
    }
}
