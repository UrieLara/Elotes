using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Shoot : MonoBehaviour
{
    [Header("Velocidad movimiento")]
    public float speed = 10f;

    [Header("Límite de movimiento")]
    public float minX = -6f;
    public float maxX = 8f;

    float lastMouseX;

    public AudioSource audioSrc;
    public Animator animator;
    SpriteRenderer sp;
    void Start()
    {
        lastMouseX = Input.mousePosition.x;
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (GameManager.Instance.GameTimer <= 30f)
        {
            MouseLimits();
            FireShoot();
        }
    }
    void MouseLimits()
    {
        float currentMouseX = Input.mousePosition.x;
        float deltaX = currentMouseX - lastMouseX;

        Vector2 direction = Vector2.zero;

        if (Mathf.Abs(deltaX) > 0.1f)
        {
            direction = deltaX > 0 ? Vector2.right : Vector2.left;

            sp.flipX = deltaX < 0;
        }

        Vector2 newPos = (Vector2)transform.position + direction * speed * Time.deltaTime;
        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        transform.position = newPos;

        lastMouseX = currentMouseX;
    }

    void FireShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("FireShoot");
            audioSrc?.Play();
        }
    }
}
