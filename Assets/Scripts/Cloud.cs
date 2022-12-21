using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float offscreenPoistion = -20;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeftEveryTick();

        if (transform.position.x < offscreenPoistion)
        {
            Destroy(gameObject);
        }
    }

    private void MoveLeftEveryTick()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed * Time.deltaTime);
    }
}
