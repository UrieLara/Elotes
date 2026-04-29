using UnityEngine;

public class PatoVuelo : MonoBehaviour
{
    public Rigidbody2D rb;
     Animator anim;
     SpriteRenderer sr;

    public float fuerza = 5f;

    Vector2 direccion;

    enum TipoVuelo { Recto, Arriba, Diagonal }
    TipoVuelo tipoVuelo;

    enum TipoPato { Rojo, Azul, Negro }
    TipoPato tipoPato;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        tipoVuelo = (TipoVuelo)Random.Range(0, 3);
        tipoPato = (TipoPato)Random.Range(0, 3);

        float posX = 0, posY = 0;
        float rd = 0;

        switch (tipoVuelo)
        {
            case TipoVuelo.Recto:
                rd = (Random.value > 0.5f) ? 1 : -1;
                direccion = new Vector2(rd, 0);

                if (rd > 0)
                {
                    posX = -10f;
                }
                else
                {
                    posX = 10f;
                    sr.flipX = true;
                }

                posY = Random.Range(0f, 3f);      
                break;

            case TipoVuelo.Arriba:
                direccion = new Vector2(0, 1);

                posX = Random.Range(-6f, 6f);
                posY = -3f;
                break;

            case TipoVuelo.Diagonal:
                rd = (Random.value > 0.5f) ? 1 : -1;
                direccion = new Vector2(rd, 1);

                posX = Random.Range(-6f, 6f);
                posY = -3f;

                if (rd < 0)
                {
                    sr.flipX = true;
                }
                break;
        }

        transform.position = new Vector2(posX, posY);

        anim.SetInteger("TipoVuelo", (int)tipoVuelo);

        rb.velocity = direccion.normalized * fuerza;

        if(GameManager.Instance != null && GameManager.Instance.GameTimer > 0f)
                Destroy(gameObject, 10f);
    }

}