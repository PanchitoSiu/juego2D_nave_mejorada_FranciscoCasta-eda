using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionDo : MonoBehaviour
{
    // --- (Variables que ya tenías) ---
    public string tagDeLaBala = "Bala"; 
    public GameObject prefabDeExplosion; 
    public AudioClip sonidoDeExplosion; 

    // --- 1. AÑADE ESTA LÍNEA (PARA EL VOLUMEN) ---
    // 1.0 = 100% volumen, 0.5 = 50% volumen
    [Range(0.0f, 1.0f)]
    public float volumenDeExplosion = 1.0f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagDeLaBala))
        {
            // ... (Destruye la bala) ...
            Destroy(collision.gameObject);

            // ... (Crea la explosión) ...
            if (prefabDeExplosion != null)
            {
                Instantiate(prefabDeExplosion, transform.position, Quaternion.identity);
            }

            // --- 2. MODIFICA ESTA LÍNEA (AÑADE EL VOLUMEN) ---
            if (sonidoDeExplosion != null) //Buena práctica comprobar si existe
            {
                AudioSource.PlayClipAtPoint(sonidoDeExplosion, transform.position, volumenDeExplosion);
            }

            // ... (Destruye al enemigo) ...
            Destroy(gameObject); 
        }
    }
}