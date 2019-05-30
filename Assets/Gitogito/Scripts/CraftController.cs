using UnityEngine;

public class CraftController : MonoBehaviour
{

    [SerializeField] private GameObject currentBlock;
    private Renderer meshRenderer;

    [SerializeField] private GameObject blocksContent;

    private Transform blocksParent;

    private Transform mainCam;

    private float blockScale = 1f;

    private Message message;
    
    private void Awake ()
    {
        meshRenderer = currentBlock.GetComponent<Renderer> ();
        mainCam = Camera.main.transform;

        blocksParent = GameObject.FindWithTag ("BlocksParent").transform;

        message = GameObject.Find ("UI/Panel").GetComponent<Message> ();
    }

    public void ChangeBlock (Material colorMat)
    {
        meshRenderer.material = colorMat;
    }

    public void PutBlock (Vector3 touchPos)
    {
        Ray camRay = Camera.main.ScreenPointToRay (touchPos);

        if (Physics.Raycast (camRay, out RaycastHit hit))
        {
            if (blocksParent.transform.position == Vector3.zero)
            {
                blocksParent.transform.position = hit.point;
            }
            GameObject go_block = Instantiate (currentBlock, blocksParent);
            go_block.transform.eulerAngles = Vector3.zero;
            go_block.transform.localScale = Vector3.one * 1.0001f;
            go_block.transform.position = hit.point;
            Vector3 localPos = go_block.transform.localPosition;
            if (hit.collider.CompareTag ("ARPlane"))
            {
                localPos = new Vector3 (Round (localPos.x), Round (localPos.y) + 0.5f, Round (localPos.z));
            }
            else if(hit.collider.CompareTag ("Block"))
            {
                localPos = new Vector3 (Round (localPos.x), Floor (localPos.y) + 0.5f, Round (localPos.z));
            }
            go_block.transform.localPosition = localPos;
        }
    }

    private float t = 0;
    private GameObject deleteBlock;
    public void DestroyBlock (Vector3 touchPos)
    {
        Ray camRay = Camera.main.ScreenPointToRay (touchPos);

        if (Physics.Raycast (camRay, out RaycastHit hit))
        {
            if (hit.collider.gameObject.CompareTag ("Block") && deleteBlock == hit.collider.gameObject)
            {
                t += Time.deltaTime;
                if (t > 0.5f)
                {
                    Destroy (deleteBlock);
                    deleteBlock = null;
                    t = 0;
                }
            }
            else
            {
                t = 0;
                deleteBlock = hit.collider.gameObject;
            }

        }
    }

    public void ChangeScale (float scaleDelta)
    {
        blockScale = Mathf.Clamp (blockScale + scaleDelta * 0.002f, 0.05f, 1f);
        float scaleRound = Round (blockScale * 100f);
        message.Show (string.Format ("Scale : {0:d} %", (int)scaleRound));
        blocksParent.localScale = Vector3.one * scaleRound * 0.01f;
    }

    private Vector3 ClampXYZ (Vector3 vector3, float min, float max)
    {
        vector3.x = Mathf.Clamp (vector3.x, min, max);
        vector3.y = Mathf.Clamp (vector3.y, min, max);
        vector3.z = Mathf.Clamp (vector3.z, min, max);
        return vector3;
    }

    private float Round (float f)
    {
        return Mathf.Round (f);
    }

    private float Floor (float f)
    {
        return Mathf.Floor (f);
    }
}
