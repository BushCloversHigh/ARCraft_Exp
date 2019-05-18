﻿using UnityEditor;
using UnityEngine;

public class ColorBlockUISetting : MonoBehaviour
{
    [SerializeField] private GameObject elementObj;
    [SerializeField] private Material[] colorMats;

    public void GenerateBlockButtons ()
    {
        for (int i = 0 ; i < colorMats.Length ; i++)
        {
            GameObject go_element = Instantiate (elementObj, transform);
            BlockElement blockElement = go_element.GetComponent<BlockElement> ();
            blockElement.SetBlockColor (colorMats[i]);
            go_element.name = i.ToString ();
        }

    }
}