using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooted : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D col;
    public Animator animator;
    public AudioSource audio_popcorn;
    public AudioSource audio_duck;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        rb.freezeRotation = true;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        col.enabled = false;

        animator.SetTrigger("Shooted");
        rb.drag = 5f;

        if (CompareTag("elote"))
        {
            audio_popcorn?.Play();
        }

        if (CompareTag("pato"))
        {
            audio_duck?.Play();
        }

        GameManager.Instance?.AddScore(1);
        rb.gravityScale = 1f;


        if (CompareTag("elote") || CompareTag("pato"))
        {
            if (gameObject != null)
                Destroy(gameObject, 10f);

        }
        
    }

}
