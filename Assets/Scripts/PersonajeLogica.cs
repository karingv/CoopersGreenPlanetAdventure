using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeLogica : MonoBehaviour
{
    //variables de movimiento
    [SerializeField] public float velocidad;
    [SerializeField] public Rigidbody2D personajeBody;
    [SerializeField] private bool mirandoIzquierda = true;

    //variables de vida del personaje
    [SerializeField] public float vida;
    [SerializeField] public float maximoVida;
    [SerializeField] private BarraDeVida barraDeVida;
    [SerializeField] private bool estaVivo = true;

    //variable para que aparezca animaciones
    [SerializeField] private Animator animacion;

    //variables de la bala
    [SerializeField] public Transform bulletControlador;  
    [SerializeField] public GameObject bulletPrefabs;
    [SerializeField] public AudioSource shootSound;

    
    void Start()
    {
        personajeBody = GetComponent<Rigidbody2D>();
        animacion = GetComponent<Animator>();
        shootSound = GetComponent<AudioSource>();

        vida = maximoVida;
        barraDeVida.inicializarBarraDeVida(vida);
        
    }

    void Update()
    {
        if (estaVivo)
        {
            //Movimiento y direccion del jugador
            float horizontal = Input.GetAxis("Horizontal");
            ControlarMovimiento(horizontal);
            Voltear(horizontal);

            //Si el personaje dispara
            if (Input.GetButtonDown("Fire1"))
            {
                
                personajeShooting();
            }
            
            else if (Input.GetButtonUp("Fire1"))
            {
                animacion.SetBool("isShooting", false);  //animacion del personaje disparando- stop
            }
        }
        else
        {
            estaVivo = false;
        }

    }

    public void ControlarMovimiento(float horizontal)
    {
        if (estaVivo)
        {
            personajeBody.velocity = new Vector2(horizontal * velocidad, personajeBody.velocity.y);
            animacion.SetFloat("velocidad", Mathf.Abs(horizontal));
        }
    }


    public void Voltear(float horizontal)
    {
        if(horizontal > 0 && mirandoIzquierda || horizontal<0 && !mirandoIzquierda)
        {
            mirandoIzquierda = !mirandoIzquierda;   
            Vector3 escala = transform.localScale;
            escala.x *= -1;
            transform.localScale = escala;

        }
    }

    public void personajeShooting()
    {
        shootSound.Play();
        animacion.SetBool("isShooting", true);  //animacion del personaje diaparando- play
        //crea un nuevo objeto de la bala  
        Instantiate(bulletPrefabs, bulletControlador.position, bulletControlador.rotation); 
        
    }

    public void tomarDaño(float daño)
    {
        vida = vida - daño;
        barraDeVida.cambiarVidaActual(vida);

        if(vida <= 0)
        {
            estaVivo = false;
            animacion.SetBool("isDead", true);  //animacion del personaje muere - play
            Destroy(gameObject, 1f);
        }
        else
        {
            animacion.SetBool("isDead", false);  //animacion del personaje muere - stop
        }
    }

    public float obtenerVidaActual()
    {
        return vida;
    }

    public void tomarPlantas()
    {
        vida = vida + 10;
        barraDeVida.cambiarVidaActual(vida);
    }


}
