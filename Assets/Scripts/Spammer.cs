using System.Collections;
using UnityEngine;

public class Spammer : MonoBehaviour
{
    public GameObject[] patoPrefabs;
    public GameObject Verdura;
    public AudioSource audioSrc_elote;
    public AudioSource audioSrc_pato;

    const float tiempoParaIniciar = 30f;

    [Header("Tiempo entre patos")]
    [SerializeField] float tiempoEntrePatos = 5f;

    [Header("Tiempo entre verduras")]
    [SerializeField] float tiempoEntreVerduras = 5f;

    void Start()
    {
        StartCoroutine(SpawnPatos());
        StartCoroutine(SpawnVerduras());
    }

    IEnumerator SpawnVerduras()
    {
        yield return new WaitUntil(() => GameManager.Instance != null && GameManager.Instance.GameTimer <= tiempoParaIniciar);

        yield return new WaitForSeconds(1f);

        while (GameManager.Instance != null && GameManager.Instance.GameTimer > 1f)
        {
            Instantiate(Verdura);
            GameManager.Instance?.AddTargets(1);
            audioSrc_elote?.Play();

            yield return new WaitForSeconds(tiempoEntreVerduras);
        }
    }

    IEnumerator SpawnPatos()
    {
        yield return new WaitUntil(() => GameManager.Instance != null && GameManager.Instance.GameTimer <= tiempoParaIniciar);

        while (GameManager.Instance != null && GameManager.Instance.GameTimer > 1f)
        {
            Instantiate(patoPrefabs[Random.Range(0, patoPrefabs.Length)]);

            GameManager.Instance?.AddTargets(1);
            audioSrc_pato?.Play();

            yield return new WaitForSeconds(tiempoEntrePatos);
        }
    }
}