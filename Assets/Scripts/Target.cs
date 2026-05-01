using UnityEngine;

public enum TargetType
{
    Pato,
    Verdura
}

public class Target : MonoBehaviour
{
    public TargetType type;
    public int points;
    public AudioClip hitSound;
}
