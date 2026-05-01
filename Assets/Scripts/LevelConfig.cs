using UnityEngine;

[CreateAssetMenu(menuName = "Game/Level Config")]
public class LevelConfig : ScriptableObject
{
    [Header("Patos")]
    public GameObject[] patoPrefabs;
    public float patoFuerza = 5f;

    [Header("Verduras")]
    public GameObject[] verduraPrefab;
    public float verduraFuerzaMin = 2f;
    public float verduraFuerzaMax = 3f;

    [Header("Spawning")]
    public float tiempoEntrePatos;
    public float tiempoEntreVerduras;
}