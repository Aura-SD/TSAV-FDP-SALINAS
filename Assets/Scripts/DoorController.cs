using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float anguloMaximoApertura = 90f;
    public float velocidadApertura = 2f;
    public float distanciaMaxima = 3f;
    public AudioClip doorSound; // Nuevo AudioClip para el sonido de la puerta

    private bool abierta = false;
    private Quaternion rotacionInicial;
    private Quaternion rotacionAbierta;
    private AudioSource audioSource; // Nuevo AudioSource para reproducir el sonido

    void Start()
    {
        rotacionInicial = transform.rotation;
        rotacionAbierta = rotacionInicial * Quaternion.Euler(0, anguloMaximoApertura, 0);

        // Agregar AudioSource al GameObject
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // Asegurarse de que no se reproduzca al iniciar
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanciaMaxima))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    if (abierta)
                        CerrarPuerta();
                    else
                        AbrirPuerta();

                    ReproducirSonidoPuerta(); // Llamar a la función para reproducir el sonido de la puerta
                }
            }
        }
    }

    void AbrirPuerta()
    {
        abierta = true;
    }

    void CerrarPuerta()
    {
        abierta = false;
    }

    void FixedUpdate()
    {
        if (abierta)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotacionAbierta, Time.fixedDeltaTime * velocidadApertura);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rotacionInicial, Time.fixedDeltaTime * velocidadApertura);
        }
    }

    void ReproducirSonidoPuerta()
    {
        if (doorSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(doorSound); // Reproducir sonido de la puerta
        }
    }
}
