using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderUpdater : MonoBehaviour
{
    private Mesh mesh;
    private MeshCollider meshCollider;

    private void Start ()
    {
        mesh = GetComponent<MeshFilter> ().mesh;
        meshCollider = GetComponent<MeshCollider> ();
    }

    private void Update ()
    {
        meshCollider.sharedMesh = mesh;
    }
}
