using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{

    [SerializeField] private float SpawnCountdownSeconds = 3;
    [SerializeField] private GameObject Pipes;

    private float heightOffset = 8;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCountdownSeconds -= Time.deltaTime;
        if (SpawnCountdownSeconds < 0)
        {
            SpawnPipe();
            SpawnCountdownSeconds = 3;
        }
    }

    private void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(Pipes, new Vector3(transform.position.x, Random.Range(lowestPoint,highestPoint)), transform.rotation);
    }
}
