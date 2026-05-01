using UnityEngine;

public class throwVerdura : MonoBehaviour
{
    LevelConfig config;

    public Rigidbody2D rb;
    Vector2 throwForce;
    void Start()
    {
        config = GameManager.Instance.currentLevelConfig;

        PosAleatX();
        throwIt();

        Destroy(gameObject, 5f);
    }
    void PosAleatX()
    {
        float posX = Random.Range(-5.5f, 8f);
        transform.position = new Vector2(posX, -2.5f);
    }
void throwIt()
    {
        throwForce = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(config.verduraFuerzaMin, config.verduraFuerzaMax));
        rb.AddForce(throwForce, ForceMode2D.Impulse);
        rb.angularVelocity = Random.Range(-360, 360);
    }

}
