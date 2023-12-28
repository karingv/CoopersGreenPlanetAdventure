using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorNivel : MonoBehaviour
{
    [SerializeField] private GameObject[] partesNivel;
    [SerializeField] private Transform puntoFinal;
    [SerializeField] private float distanciaMinima;
    [SerializeField] private int cantidadInicial;
    [SerializeField] private Transform personaje; 

    void Start()
    {
        personaje = GameObject.FindGameObjectWithTag("Personaje").transform;

        for (int i = 0; i < cantidadInicial; i++)
        {
            generarPartesNivel();
        }
    }


    void Update()
    {
        if (Vector2.Distance(personaje.position, puntoFinal.position) < distanciaMinima)
        {
            generarPartesNivel();
        }

    }

    private void generarPartesNivel()
    {
        int numAleatorio = Random.Range(0, partesNivel.Length);
        GameObject nivel = Instantiate(partesNivel[numAleatorio], puntoFinal.position, Quaternion.identity);
        puntoFinal = buscarPuntoFinal(nivel, "PuntoFinal");
    }

    private Transform buscarPuntoFinal(GameObject partesNivel, string etiqueta)
    {
        Transform punto = null;

        foreach (Transform ubicacion in partesNivel.transform)
        {
            if (ubicacion.CompareTag(etiqueta)){
                punto = ubicacion;
            }
            break;
        }

        return punto;
    }
}
