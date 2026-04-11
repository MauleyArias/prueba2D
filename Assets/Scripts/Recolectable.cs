using UnityEngine;

public class Recolectable : MonoBehaviour
{
    [Header("Valor")]
    public int valorMoneda = 1;

    [Header("Efecto visual (opcional)")]
    public float velocidadRotacion = 90f;  // Grados por segundo

    void Update()
    {
        // Rotar el objeto para que se vea animado
        transform.Rotate(0, 0, velocidadRotacion * Time.deltaTime);
    }

    // Se activa cuando el jugador toca el objeto
    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            // Avisar al GameManager que se recogió una moneda
            GameManager.instancia.AgregarMoneda(valorMoneda);

            // Destruir este objeto de la escena
            Destroy(gameObject);
        }
    }
}
