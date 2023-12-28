using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Vector2 velocidad;
    [SerializeField] private Vector2 offset;
    [SerializeField] private Material material;
    [SerializeField] private Rigidbody2D personaje;
    private void Awake()
    {
        material = GetComponent<Material>();
        personaje = GameObject.FindGameObjectWithTag("Personaje").GetComponent<Rigidbody2D>(); 
        
    }


    private void Update()
    {
        offset = (personaje.velocity.x * 0.1f) * velocidad * Time.deltaTime;
        material.mainTextureOffset += offset;
    }

    
}
