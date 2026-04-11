using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [Header("Patrulla")]
    public float velocidad = 2f;
    public float distanciaPatrulla = 3f;   // Cuanto se mueve de su punto inicial

    private Vector3 posicionInicial;
    private int direccion = 1;             // 1 = derecha, -1 = izquierda

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Mover al enemigo
        transform.Translate(Vector2.right * direccion * velocidad * Time.deltaTime);

        // Voltear al llegar al limite de patrulla
        float distancia = transform.position.x - posicionInicial.x;

        if (distancia > distanciaPatrulla)
            direccion = -1;
        else if (distancia < -distanciaPatrulla)
            direccion = 1;

        // Voltear el sprite segun la direccion
        transform.localScale = new Vector3(direccion, 1, 1);
    }

    // Colision con el jugador
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("El jugador fue golpeado. Reiniciando...");
            GameManager.instancia.ReiniciarJuego();
        }
    }

    // Si prefieres usar Trigger en lugar de Collider solido:
    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            Debug.Log("El jugador toco al enemigo. Reiniciando...");
            GameManager.instancia.ReiniciarJuego();
        }
    }
}
