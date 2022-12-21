using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 2;
    private float offscreenPoistion = -20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeftEveryTick();

        if(transform.position.x < offscreenPoistion)
        {
            Destroy(gameObject);
        }
    }

    private void MoveLeftEveryTick()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed * Time.deltaTime);
    }
}
