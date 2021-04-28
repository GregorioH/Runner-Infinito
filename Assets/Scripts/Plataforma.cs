using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public Transform puntoInicio;
    public Transform puntoFinal;
    public GameObject[] obstaculos;

    public void ActivarObstaculos()
    {
        DesactivarObstaculos();

        System.Random random = new System.Random();
        int numeroAleatorio = random.Next(0, obstaculos.Length);
        obstaculos[numeroAleatorio].SetActive(true);
    }

    public void DesactivarObstaculos()
    {
        for (int i = 0; i < obstaculos.Length; i++)
        {
            obstaculos[i].SetActive(false);
        }
    }
}