using UnityEngine;

public class ColliderUpdater : MonoBehaviour
{
    private Mesh mesh;
    private Renderer renderer;
    private MeshCollider meshCollider;

    [SerializeField] private Material transparent, grid;

    private bool isVisible;

    private void Start ()
    {
        mesh = GetComponent<MeshFilter> ().mesh;
        renderer = GetComponent<Renderer> ();
        meshCollider = GetComponent<MeshCollider> ();

        isVisible = PlaneVisiblity.isVisible;
        if (isVisible)
        {
            renderer.material = grid;
        }
        else
        {
            renderer.material = transparent;
        }
    }

    private void Update ()
    {
        meshCollider.sharedMesh = mesh;

        if (isVisible != PlaneVisiblity.isVisible)
        {
            isVisible = PlaneVisiblity.isVisible;
            if (isVisible)
            {
                renderer.material = grid;
            }
            else
            {
                renderer.material = transparent;
            }
        }
    }
}
