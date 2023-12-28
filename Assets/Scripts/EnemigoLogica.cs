using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoLogica : MonoBehaviour
{
    //variables de movimiento 
    [SerializeField] private float velocidad = 5f;

    //variables para perseguir al personaje
    [SerializeField] private Transform personaje;
    [SerializeField] private PersonajeLogica personajeVida;
    [SerializeField] private float distanciaPerseguir = 8f;


    //variables para que camine de un lado a otro
    [SerializeField] private float tiempoDeMovimiento = 2f;
    [SerializeField] private float tiempoPasado;
    [SerializeField] private bool moviendoseHaciaDerecha = true;

    //variables de vida y muerte del enemigo
    [SerializeField] private float vida;


    //variable para que aparezca animaciones - audio
    [SerializeField] private Animator animacion;
    [SerializeField] private bool objetivoEstaVivo = true;





    void Start()
    {
        animacion = GetComponent<Animator>();

        personaje = GameObject.FindGameObjectWithTag("Personaje").transform;
        personajeVida = personaje.GetComponent<PersonajeLogica>();
    }

    void Update()
    {
  
        if (objetivoEstaVivo)
        {           
                // Verificar si el personaje está dentro de la distancia para perseguirlo
                if (Vector2.Distance(transform.position, personaje.position) > distanciaPerseguir)
                {
                    MoverHaciaAdelante();

                }
                else
                {
                    PerseguirObjetivo();
                    
                }

                // Actualizar el tiempo pasado
                tiempoPasado += Time.deltaTime;

                // Verificar si ha pasado el tiempo de movimiento
                if (tiempoPasado >= tiempoDeMovimiento)
                {
                    // Cambiar la dirección y reiniciar el tiempo
                    moviendoseHaciaDerecha = !moviendoseHaciaDerecha;
                    tiempoPasado = 0f;

                    // Voltear la dirección del enemigo
                    Voltear();
                }
        }
        else
        {
            objetivoEstaVivo=false;
        }

      
    }
    void Voltear()
    {
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }




    public void MoverHaciaAdelante()
     {
        Vector3 direccion;

        if (moviendoseHaciaDerecha)
         {
             direccion = Vector3.right;
         }
         else
         {
             direccion = Vector3.left;
         }

         transform.Translate(direccion * velocidad * Time.deltaTime);

     }

     public void PerseguirObjetivo()
     {

        float vidaActualPersonaje = personajeVida.obtenerVidaActual();

        if (vidaActualPersonaje > 0)
        {
            
            Vector3 direccion = (personaje.position - transform.position).normalized;
            transform.Translate(direccion * velocidad * Time.deltaTime);

            animacion.SetBool("attack", true);

        }
        else
        {
            objetivoEstaVivo = false;
            animacion.SetBool("attack", false);

        }

    }

    public void TomarDaño(float daño)
    {
        vida = vida - daño;

        if(vida <= 0)
        {
            animacion.SetBool("isDead", true);  //animacion del enemigo muere - play
            Destroy(gameObject, 1f);
        }
        else
        {
            animacion.SetBool("isDead", false);  //animacion del enemigo muere - stop
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
            if (other.CompareTag("Personaje"))
            {
                other.GetComponent<PersonajeLogica>().tomarDaño(20);
            }
 
    }




}
