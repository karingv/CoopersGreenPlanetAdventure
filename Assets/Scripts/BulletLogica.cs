using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogica : MonoBehaviour
{

    //variables de la bala
    [SerializeField] private float velocidad;
    [SerializeField] private float daño;

    //variables del personaje y bala para la direccion de la bala
    [SerializeField] private Rigidbody2D bala;
    [SerializeField] private Vector2 balaDireccion;

    void Start()
    {
        bala = GetComponent<Rigidbody2D>();

        GameObject personaje = GameObject.FindGameObjectWithTag("Personaje");
        if(personaje != null)
        {
            balaDireccion = (transform.position - personaje.transform.position).normalized;

        }
        else
        {
            balaDireccion = Vector2.right;
        }

        bala.velocity = balaDireccion * velocidad;


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {
            other.GetComponent<EnemigoLogica>().TomarDaño(daño);
            Destroy(gameObject);
        }


    }
}
