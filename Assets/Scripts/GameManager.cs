using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton: una sola instancia accesible desde cualquier script
    public static GameManager instancia;

    [Header("UI")]
    public Text textoMonedas;          // Arrastra aqui el Text de la UI

    private int monedas = 0;

    void Awake()
    {
        // Configurar singleton
        if (instancia == null)
            instancia = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        ActualizarUI();
    }

    // Llamado desde Recolectable.cs cuando el jugador toca una moneda
    public void AgregarMoneda(int cantidad = 1)
    {
        monedas += cantidad;
        ActualizarUI();
        Debug.Log("Monedas: " + monedas);
    }

    // Reiniciar la escena (llamado por el Enemigo)
    public void ReiniciarJuego()
    {
        monedas = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ActualizarUI()
    {
        if (textoMonedas != null)
            textoMonedas.text = "Monedas: " + monedas;
    }
}
