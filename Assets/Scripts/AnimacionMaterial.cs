using UnityEngine;

public class AnimacionMaterial : MonoBehaviour
{
    public float AnimacionX = 0f;
    public float AnimacionY = 0f;
    // Update is called once per frame
    void Update()
    {
        float CompensacionX = Time.time * AnimacionX;
        float CompensacionY = Time.time * AnimacionY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(CompensacionX, CompensacionY);
    }
}
