using UnityEngine;

public class BeltScroll : MonoBehaviour
{
    [Header("Belt Speed")]
    public float speed = 0.5f;

    private Material beltMaterial;
    private Vector2 offset;

    void Start()
    {
        // Get the belt material
        beltMaterial = GetComponent<Renderer>().material;

        // Get current texture offset
        offset = beltMaterial.GetTextureOffset("_BaseMap");
    }

    void Update()
    {
        // Move the texture forward
        offset.y -= speed * Time.deltaTime;

        // Apply the offset
        beltMaterial.SetTextureOffset("_BaseMap", offset);
    }
}