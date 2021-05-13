using UnityEngine;

public class moveOffset : MonoBehaviour
{
    private Material currentMaterial;
    private Renderer meshRender;


    public float velocidadeX, velocidadeY;
    public float incremento;
    private float offSet;

    public string sortingLayer;
    public int orderInLayer;

    // Start is called before the first frame update
    void Start()
    {
        meshRender = GetComponent<MeshRenderer>();

        meshRender.sortingLayerName = sortingLayer;
        meshRender.sortingOrder = orderInLayer;

        currentMaterial = meshRender.material;
    }

    // Update is called once per frame
    void Update()
    {
        offSet += incremento;
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(offSet * velocidadeX, offSet * velocidadeY));
    }
}
