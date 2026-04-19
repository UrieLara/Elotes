using UnityEngine;

public class PatoVuelo : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public float fuerza = 5f;

    Vector2 direccion;

    enum TipoVuelo { Recto, Arriba, Diagonal }
    TipoVuelo tipoVuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        tipoVuelo = (TipoVuelo)Random.Range(0, 3);

        float posX, posY;

        switch (tipoVuelo)
        {
            case TipoVuelo.Recto:
                posY = Random.Range(-1f, 3f);
                direccion = new Vector2(1, 0);
                transform.position = new Vector2(-8f, posY);
                break;

            case TipoVuelo.Arriba:
                posX = Random.Range(-6f, 6f);
                direccion = new Vector2(0, 1);
                transform.position = new Vector2(posX, -8f);
                break;

            case TipoVuelo.Diagonal:
                posY = Random.Range(-1f, 3f);
                posX = Random.Range(-6f, 6f);
                direccion = new Vector2(1, 1);
                transform.position = new Vector2(-8f, posY);
                break;
        }

        anim.SetBool("Arriba", tipoVuelo == TipoVuelo.Arriba);
        anim.SetBool("Diagonal", tipoVuelo == TipoVuelo.Diagonal);

        rb.velocity = direccion.normalized * fuerza;

        if(gameObject == null) return; 
            Destroy(gameObject, 10f);
    }
}