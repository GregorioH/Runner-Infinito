using UnityEngine.UI;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{
    public Text Puntaje;
    public Text MejorPuntaje;

    private void Start()
    {
        Puntaje.text = "Puntaje actual: " + GeneradorPiso.puntajeRedondo;
        MejorPuntaje.text = "Mejor Puntaje: " + PlayerPrefs.GetFloat("Mejor Puntaje");
    }
}