using UnityEngine;

public class CraftController : MonoBehaviour
{

    [SerializeField] private GameObject currentBlock;
    private MeshRenderer meshRenderer;

    [SerializeField] private GameObject blocksContent;
    private BlockElement[] blockElements;

    [SerializeField] private Transform putedBlocks;

    private Transform mainCam;

    private bool firstPut = false;

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

    public void PutBlock (Vector3 touchPos)
    {
        Ray camRay = Camera.main.ScreenPointToRay (touchPos);
        RaycastHit hit;

        if(Physics.Raycast(camRay, out hit))
        {
            if (!firstPut)
            {
                firstPut = true;
                putedBlocks.transform.position = hit.point;
            }
            GameObject go_block = Instantiate (currentBlock, putedBlocks);
            go_block.transform.eulerAngles = Vector3.zero;
            go_block.transform.localScale = Vector3.one + Vector3.one * 0.001f;
            go_block.transform.position = hit.point;
            Vector3 localPos = go_block.transform.localPosition;
            localPos = new Vector3 (RoundToInt (localPos.x), FloorToInt (localPos.y) + 0.5f, RoundToInt (localPos.z));
            go_block.transform.localPosition = localPos;
        }
    }

    public void ChangeScale (float scaleDelta)
    {
        Vector3 scale = putedBlocks.localScale + Vector3.one * scaleDelta * 0.01f;
        scale.x = Mathf.Clamp (scale.x, 0.1f, 1f);
        scale.y = Mathf.Clamp (scale.y, 0.1f, 1f);
        scale.z = Mathf.Clamp (scale.z, 0.1f, 1f);

        putedBlocks.localScale = scale;
    }

    private float RoundToInt (float f)
    {
        return Mathf.Round (f);
    }

    private float FloorToInt (float f)
    {
        return Mathf.Floor (f);
    }
}
