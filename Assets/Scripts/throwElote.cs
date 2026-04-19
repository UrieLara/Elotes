using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwElote : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 throwForce;
    void Start()
    {
        PosAleatX();
        throwIt();

        if(gameObject!=null)
        {
            Destroy(gameObject, 5f);
        }
    }
    void Update()
    {
        
    }

    void PosAleatX()
    {
        float posX = Random.Range(-5.5f, 8f);
        transform.position = new Vector2(posX, -2.5f);
    }
void throwIt()
    {
        throwForce = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(2f, 3f));
        rb.AddForce(throwForce, ForceMode2D.Impulse);
        rb.angularVelocity = Random.Range(-360, 360);
    }

}
