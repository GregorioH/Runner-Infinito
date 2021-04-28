using UnityEngine;

public class MovimientoCuerposCelestes : MonoBehaviour
{
    public float velocidadRotacion = 0;
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * velocidadRotacion);
    }
}
