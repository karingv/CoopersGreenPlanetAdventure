using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSonido : MonoBehaviour
{

    private AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (audiosource.isPlaying)
            {
                audiosource.Pause();
            }
            else
            {
                audiosource.UnPause();
            }
        }
        
    }
}
