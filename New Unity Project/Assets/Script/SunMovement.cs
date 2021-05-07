using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMovement : MonoBehaviour
{
    public Transform[] positions;
    int index;

    public void ChangePosition()
    {
        transform.position = positions[index].position;
        index++;
    }
}
