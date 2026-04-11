using UnityEngine;

public class CamaraPersonaje : MonoBehaviour
{
    [Header("Objetivo")]
    public Transform objetivo;         // Arrastra aqui el Jugador

    [Header("Suavizado")]
    public float velocidadSuavizado = 5f;

    [Header("Offset (desplazamiento)")]
    public Vector3 offset = new Vector3(0f, 2f, -10f);

    void LateUpdate()
    {
        // LateUpdate se ejecuta DESPUES de Update, ideal para camaras
        if (objetivo == null) return;

        Vector3 posicionObjetivo = objetivo.position + offset;

        // Mover la camara suavemente hacia el jugador
        transform.position = Vector3.Lerp(transform.position, posicionObjetivo, velocidadSuavizado * Time.deltaTime);
    }
}
