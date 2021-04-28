using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GeneradorPiso : MonoBehaviour
{
    public Camera mainCamera;
    public Transform puntoInicio;
    public Plataforma tilePrefab;
    public Text Puntos;
    public Text Advetencia;
    public float velocidadMovimiento = 12;
    public int preSpawnDePlataformas = 3;
    public int plataformasSinObstaculos = 3;

    List<Plataforma> plataformasSpawneadas = new List<Plataforma>();
    [HideInInspector]
    public bool gameOver = false;
    static bool empiezaElJuego = true;
    public static float puntaje = 0;

    public static float puntajeRedondo = 0;

    public static GeneradorPiso instancia;

    // Start is called before the first frame update
    void Start()
    {
        instancia = this;

        puntaje = 0;

        Vector3 posicionSpawn = puntoInicio.position;
        int plataformasSinObstaculosTmp = plataformasSinObstaculos;
        for (int i = 0; i < preSpawnDePlataformas; i++)
        {
            posicionSpawn -= tilePrefab.puntoInicio.localPosition;
            Plataforma plataformaSpawneada = Instantiate(tilePrefab, posicionSpawn, Quaternion.identity) as Plataforma;
            if (plataformasSinObstaculosTmp > 0)
            {
                plataformaSpawneada.DesactivarObstaculos();
                plataformasSinObstaculosTmp--;
            }
            else
            {
                plataformaSpawneada.ActivarObstaculos();
            }

            posicionSpawn = plataformaSpawneada.puntoFinal.position;
            posicionSpawn = plataformaSpawneada.puntoFinal.position;
            posicionSpawn = plataformaSpawneada.puntoFinal.position;
            plataformaSpawneada.transform.SetParent(transform);
            plataformasSpawneadas.Add(plataformaSpawneada);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver && empiezaElJuego)
        {
            transform.Translate(-plataformasSpawneadas[0].transform.forward * Time.deltaTime * (velocidadMovimiento + (puntaje / 500)), Space.World);
            puntaje += Time.deltaTime * velocidadMovimiento;
        }

        if (mainCamera.WorldToViewportPoint(plataformasSpawneadas[0].puntoFinal.position).z < 0)
        {
            Plataforma plataformaTmp = plataformasSpawneadas[0];
            plataformasSpawneadas.RemoveAt(0);
            plataformaTmp.transform.position = plataformasSpawneadas[plataformasSpawneadas.Count - 1].puntoFinal.position - plataformaTmp.puntoInicio.localPosition;
            plataformaTmp.ActivarObstaculos();
            plataformasSpawneadas.Add(plataformaTmp);
        }

        puntajeRedondo = (int)puntaje;

        if (puntajeRedondo == 260)
        {
            Advetencia.text = "";
        }

        Puntos.text = "puntaje:" + puntajeRedondo;

        if (gameOver)
        {
            if (puntajeRedondo >= PlayerPrefs.GetFloat("Mejor Puntaje"))
            {
                var mejorPuntaje = puntajeRedondo;
                PlayerPrefs.SetFloat("Mejor Puntaje", mejorPuntaje);
            }

            SceneManager.LoadScene("Game Over");
        }
    }
}
