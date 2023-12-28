using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoDeVida : MonoBehaviour
{
    [SerializeField] private float tiempoVida;
    void Start()
    {
        Destroy(gameObject, tiempoVida);
        
    }

   
}
