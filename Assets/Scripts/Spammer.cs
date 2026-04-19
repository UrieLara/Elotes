using System.Collections;
using UnityEngine;

public class Spammer : MonoBehaviour
{
    public GameObject[] bolsaDePatos;
    public GameObject Verdura;
    public AudioSource audioSrc_elote;
    public AudioSource audioSrc_pato;

    [Header("Tiempo entre patos")]
    [SerializeField] float tiempoEntrePatos = 2f;

    [Header("Tiempo entre verduras")]
    [SerializeField] float tiempoEntreVerduras = 1f;

    void Start()
    {
        StartCoroutine(SpawnPatos());
        StartCoroutine(SpawnVerduras());
    }

    IEnumerator SpawnVerduras()
    {
        yield return new WaitForSeconds(6f);

        while (GameManager.Instance != null && GameManager.Instance.GameTimer > 0f)
        {
            Instantiate(Verdura);
            GameManager.Instance?.AddElotes(1);
            audioSrc_elote?.Play();

            yield return new WaitForSeconds(tiempoEntreVerduras);
        }
    }

    IEnumerator SpawnPatos()
    {
        yield return new WaitForSeconds(5f);

        while (GameManager.Instance != null && GameManager.Instance.GameTimer > 0f)
        {
            Instantiate(bolsaDePatos[Random.Range(0, bolsaDePatos.Length)]);
            GameManager.Instance?.AddPatos(1);
            audioSrc_pato?.Play();

            yield return new WaitForSeconds(tiempoEntrePatos);
        }
    }
}