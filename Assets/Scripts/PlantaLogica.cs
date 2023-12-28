using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlantaLogica : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Personaje")
        {
            other.gameObject.GetComponent<PersonajeLogica>().tomarPlantas();
            Destroy(gameObject);
        }
        
    }
}
