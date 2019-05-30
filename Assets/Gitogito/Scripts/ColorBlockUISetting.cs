using UnityEditor;
using UnityEngine;

public class ColorBlockUISetting : MonoBehaviour
{
    [SerializeField] private GameObject elementObj;
    [SerializeField] private Material[] colorMats;

    public void GenerateBlockButtons ()
    {
        while (transform.childCount != 0)
        {
            for (int i = 0 ; i < transform.childCount ; i++)
            {
                DestroyImmediate (transform.GetChild (i).gameObject);
            }
        }

        for (int i = 0 ; i < colorMats.Length ; i++)
        {
            GameObject go_element = Instantiate (elementObj, transform);
            BlockUIElement blockElement = go_element.GetComponent<BlockUIElement> ();
            blockElement.SetBlockColor (colorMats[i]);
            go_element.name = i.ToString ();
        }
    }

}
