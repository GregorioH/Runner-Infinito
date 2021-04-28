using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class CambioEscena : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Juego");
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
