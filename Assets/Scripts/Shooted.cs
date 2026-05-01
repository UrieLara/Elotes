using UnityEngine;
using UnityEngine.EventSystems;

public class Shooted : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D col;
    public Animator animator;
    private AudioSource audioSrc;

    private Target target;

    public FloatingText floatingTextPrefab;

    private void Awake()
    {
        target = GetComponent<Target>();
        audioSrc = GetComponent<AudioSource>();

    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.IsGameOver) return;

        if (EventSystem.current.IsPointerOverGameObject()) return;

        col.enabled = false;
        animator.SetTrigger("Shooted");

        HandlePhysics();

        if (target.hitSound != null)
            audioSrc.PlayOneShot(target.hitSound);

        FloatingTextShow();

        GameManager.Instance.AddScore(target.type, target.points);
        Destroy(gameObject, 5f);
        
    }

    private void FloatingTextShow()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0f;

        FloatingText ft = Instantiate(floatingTextPrefab, worldPos, Quaternion.identity);
        ft.Init(target.points);
    }

    private void HandlePhysics()
    {
        rb.freezeRotation = true;
        transform.rotation = Quaternion.identity; //Quaternion.Euler(0, 0, 0);
        rb.drag = 5f;
        rb.gravityScale = 1f;
    }

}
