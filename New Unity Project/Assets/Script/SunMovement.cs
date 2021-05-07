using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SunMovement : MonoBehaviour
{
    public Transform[] positions;
    int index;
    public float duration;

    public void ChangePosition()
    {
        transform.DOMove(positions[index].position, duration);
        index++;
    }
}
