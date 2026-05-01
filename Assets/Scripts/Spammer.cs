using System.Collections;
using UnityEngine;

public class Spammer : MonoBehaviour
{
    LevelConfig config;

    public AudioSource audioSrc_verdura;
    public AudioSource audioSrc_pato;

    void Start()
    {
        StartCoroutine(WaitForConfig());

    }

    IEnumerator WaitForConfig()
    {
        yield return new WaitUntil(() => GameManager.Instance !=null && GameManager.Instance.currentLevelConfig != null);

        config = GameManager.Instance.currentLevelConfig;
        StartCoroutine(SpawnPatos());
        StartCoroutine(SpawnVerduras());
    }

    IEnumerator SpawnVerduras()
    {
        yield return new WaitUntil(() => GameManager.Instance.State == GameState.Playing);


        while (GameManager.Instance.State == GameState.Playing)
        {
            Instantiate(config.verduraPrefab[Random.Range(0, config.verduraPrefab.Length)]);
            GameManager.Instance?.AddTargets(1);
            audioSrc_verdura?.Play();

            yield return new WaitForSeconds(config.tiempoEntreVerduras);
        }
    }

    IEnumerator SpawnPatos()
    {
        yield return new WaitUntil(() => GameManager.Instance.State == GameState.Playing);

        while (GameManager.Instance.State == GameState.Playing)
        {
            Instantiate(config.patoPrefabs[Random.Range(0, config.patoPrefabs.Length)]);

            GameManager.Instance?.AddTargets(1);
            audioSrc_pato?.Play();

            yield return new WaitForSeconds(config.tiempoEntrePatos);
        }
    }
}