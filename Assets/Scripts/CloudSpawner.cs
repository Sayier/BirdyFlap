using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    [SerializeField] private GameObject Clouds;
    [SerializeField] private float SpawnCountdownSeconds = 1;

    private float heightOffset = 9;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCountdownSeconds -= Time.deltaTime;
        if (SpawnCountdownSeconds < 0)
        {
            SpawnCloud();
            SpawnCountdownSeconds = 3;
        }
    }

    private void SpawnCloud() {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(Clouds, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint)), transform.rotation);
    }
}
