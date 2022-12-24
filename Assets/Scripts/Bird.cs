using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    [SerializeField] private Rigidbody2D thisRigidBody;
    [SerializeField] private float VelocityCoefficient = 6;
    [SerializeField] private AudioManager audioManager;
    private GameManager gameManager;

    private static int topOfScreen = 10;
    private static int bottomOfScreen = -10;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        FlapWhenSpacePressed();

        SetBirdRotation();

        CheckIfOffScreen();
    }

    private void CheckIfOffScreen()
    {
        if (transform.position.y > topOfScreen || transform.position.y < bottomOfScreen)
        {
            gameManager.gameOver();
        }
    }

    private void SetBirdRotation()
    {
        Vector2 birdVelocity = thisRigidBody.velocity;
        if (birdVelocity.y > 5f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        else
        {
            if (thisRigidBody.rotation >= -65f)
            {
                transform.Rotate(new Vector3(0, 0, -1) * 100f * Time.deltaTime);
            }
        }
    }

    private void FlapWhenSpacePressed()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameManager.isBirdAlive())
        {
            thisRigidBody.velocity = Vector2.up * VelocityCoefficient;
            audioManager.Play("FlapSound");
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.gameOver();
    }
}
