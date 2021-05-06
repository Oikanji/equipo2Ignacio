using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform transformDelPlayer;
    public float velocidadSeguimiento;

    void Update()
    {
        Vector3 objetivo = new Vector3(transformDelPlayer.position.x, transformDelPlayer.position.y, -10);
        transform.position = Vector3.Lerp(transform.position, objetivo, velocidadSeguimiento * Time.deltaTime);

    }
}
