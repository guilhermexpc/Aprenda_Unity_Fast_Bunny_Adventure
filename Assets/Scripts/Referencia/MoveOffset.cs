using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveOffset : MonoBehaviour
{
    private Renderer meshRenderer;
    private Material currentMaterial;

    public float incrementoOffSet;
    public float velocidade;

    public string sortingLayer;    
    public int orderInLayer;

    private float offSet;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        currentMaterial = meshRenderer.material;
        meshRenderer.sortingLayerName = sortingLayer;
        meshRenderer.sortingOrder = orderInLayer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        offSet += incrementoOffSet;
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(offSet * velocidade, 0));
    }
}
