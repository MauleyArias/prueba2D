using UnityEngine;

public class a : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 12f;

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
        movimientoHorizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
            enSuelo = false;
        }

        // Voltear sprite segun direccion
        if (movimientoHorizontal > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (movimientoHorizontal < 0) transform.localScale = new Vector3(-1, 1, 1);

        // Animaciones
        anim.SetFloat("velocidadX", Mathf.Abs(movimientoHorizontal));
        anim.SetBool("enSuelo", enSuelo);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movimientoHorizontal * velocidad, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground")) enSuelo = true;
    }
}
