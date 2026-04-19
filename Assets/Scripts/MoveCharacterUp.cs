using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacterUp : MonoBehaviour
{
    public float duracion = 3f;
    public float yInicial = -6f;
    public float yFinal = -3f;

    void Start()
    {
        StartCoroutine(Subir());
    }

    IEnumerator Subir()
    {
        float tiempo = 0f;
        Vector3 posicionInicial = new Vector3(transform.position.x, yInicial, transform.position.z);
        Vector3 posicionFinal = new Vector3(transform.position.x, yFinal, transform.position.z);

        while (tiempo < duracion)
        {
            float t = tiempo / duracion;
            transform.position = Vector3.Lerp(posicionInicial, posicionFinal, t);
            tiempo += Time.deltaTime;
            yield return null;
        }

        // Asegura que llegue exactamente al final
        transform.position = posicionFinal;
    }
}
