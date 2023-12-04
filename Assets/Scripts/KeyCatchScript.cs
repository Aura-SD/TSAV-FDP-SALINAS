using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCatchScript : MonoBehaviour
{
    public float interactionRange = 3f; // Rango de interaccion
    public KeyCode interactionKey = KeyCode.E; // Tecla de interaccion
    public AudioClip keyInteractionSound; // Sonido de interacción

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Agregar AudioSource al GameObject
        audioSource.playOnAwake = false; // Asegurarse de que no se reproduzca al iniciar
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactionKey) && IsPlayerInInteractionRange())
        {
            PlayInteractionSound();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            PerformRaycast();
        }
    }

    private bool IsPlayerInInteractionRange()
    {
        Vector3 playerPosition = Camera.main.transform.position;
        Vector3 keyPosition = transform.position;

        float distance = Vector2.Distance(new Vector2(playerPosition.x, playerPosition.z), new Vector2(keyPosition.x, keyPosition.z));

        return distance <= interactionRange;
    }

    private void PlayInteractionSound()
    {
        if (keyInteractionSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(keyInteractionSound); // Reproducir sonido de interacción
        }
    }

    void PerformRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("llavecita uwu");
        }
    }
}
