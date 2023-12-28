using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }

    public void Historia()
    {
        SceneManager.LoadScene(2);
    }

    public void Ayuda()
    {
        SceneManager.LoadScene(3);
    }
}
