using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSpawner : MonoBehaviour
{
    public GameObject columnPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnColumn();   
    }

    void SpawnColumn()
    {
        if (!GameManager.deadPlayer)
        {
            transform.position = new Vector2(12, Random.Range(0f, -2.4f));
            Instantiate(columnPrefab, transform.position, transform.rotation);
            Invoke("SpawnColumn", Random.Range(1f, 2f));
        }

    }
}
