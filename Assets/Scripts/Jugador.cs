using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Jugador : MonoBehaviour
{
    public float gravedad = 20.0f;
    public static float alturaSalto = 2.5f;

    Rigidbody r;
    bool tocaPiso = false;
    Vector3 escalaDefault;
    bool agachado = false;
    bool saltando = false;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
        r.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        r.freezeRotation = true;
        r.useGravity = false;
        escalaDefault = transform.localScale;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && tocaPiso)
        {
            r.velocity = new Vector3(r.velocity.x, CalcularVelocidadSaltoVertical(), r.velocity.z);
            saltando = true;
        }

        agachado = Input.GetKey(KeyCode.S);
        if (agachado && !saltando)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(escalaDefault.x * 0.4f, escalaDefault.y, escalaDefault.z), Time.deltaTime * 7);
            alturaSalto = 0f;
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, escalaDefault, Time.deltaTime * 7);
            alturaSalto = 2.5f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        r.AddForce(new Vector3(0, -gravedad * r.mass, 0));

        tocaPiso = false;
    }

    void OnCollisionStay()
    {
        tocaPiso = true;
    }

    float CalcularVelocidadSaltoVertical()
    {
        return Mathf.Sqrt(2 * alturaSalto * gravedad);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstaculo")
        {
            GeneradorPiso.instancia.gameOver = true;
        }

        if (collision.gameObject.tag == "Piso")
        {
            saltando = false;       
        }
    }
}