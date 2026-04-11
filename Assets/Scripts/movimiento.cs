using UnityEngine;

public class movimiento : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 5f;
    public float fuerzaSalto = 12f;

    [Header("Deteccion de Suelo")]
    public Transform puntoSuelo;       // Objeto hijo vacio en los pies del personaje
    public float radioSuelo = 0.2f;
    public LayerMask capaSuelo;        // Asignar en Inspector: la capa del Tilemap

    private Rigidbody2D rb;
    private Animator anim;
    private float movimientoHorizontal;
    private bool enSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Leer input horizontal (-1, 0, 1)
        movimientoHorizontal = Input.GetAxisRaw("Horizontal");

        // Detectar si esta en el suelo con un circulo invisible en los pies
        enSuelo = Physics2D.OverlapCircle(puntoSuelo.position, radioSuelo, capaSuelo);

        // Salto: solo si esta en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
        }

        // Voltear el sprite segun la direccion de movimiento
        if (movimientoHorizontal > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (movimientoHorizontal < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // Actualizar parametros del Animator
        anim.SetFloat("velocidadX", Mathf.Abs(movimientoHorizontal));
        anim.SetBool("enSuelo", enSuelo);
    }

    void FixedUpdate()
    {
        // Mover el personaje horizontalmente (en FixedUpdate para fisicas suaves)
        rb.linearVelocity = new Vector2(movimientoHorizontal * velocidad, rb.linearVelocity.y);
    }

    // Dibujar el circulo de deteccion de suelo en el editor (solo visual)
    void OnDrawGizmosSelected()
    {
        if (puntoSuelo != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(puntoSuelo.position, radioSuelo);
        }
    }
}
