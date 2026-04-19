using System.Collections;
using UnityEngine;

public class Spammer : MonoBehaviour
{
    public GameObject[] patoPrefabs;
    public GameObject Verdura;
    public AudioSource audioSrc_elote;
    public AudioSource audioSrc_pato;

    [Header("Tiempo entre patos")]
    [SerializeField] float tiempoEntrePatos = 3f;

    [Header("Tiempo entre verduras")]
    [SerializeField] float tiempoEntreVerduras = 2f;

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
            GameManager.Instance?.AddTargets(1);
            audioSrc_elote?.Play();

            yield return new WaitForSeconds(tiempoEntreVerduras);
        }
    }

    IEnumerator SpawnPatos()
    {
        yield return new WaitForSeconds(5f);

        while (GameManager.Instance != null && GameManager.Instance.GameTimer > 0f)
        {
            Instantiate(patoPrefabs[Random.Range(0, patoPrefabs.Length)]);

            GameManager.Instance?.AddTargets(1);
            audioSrc_pato?.Play();

            yield return new WaitForSeconds(tiempoEntrePatos);
        }
    }
}