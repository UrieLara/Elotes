using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    public float speed = 1.5f;
    public float duration = 1f;
    private float timer;

    private void Awake()
    {
        tmp = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Init(int value)
    {
        tmp.text = $"+{value}";
        timer = duration;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        transform.position += Vector3.up * speed * Time.deltaTime;
        tmp.alpha = timer / duration;
        if (timer <= 0) Destroy(gameObject);
    }
}