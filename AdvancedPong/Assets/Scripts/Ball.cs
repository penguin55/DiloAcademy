using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D physic;

    public Vector2 initialForce;

    private Vector2 trajectoryOrigin;

    void Start()
    {
        physic = GetComponent<Rigidbody2D>();

        trajectoryOrigin = transform.position;
        RestartGame();
    }

    void ResetBall()
    {
        transform.position = Vector2.zero;
        physic.velocity = Vector2.zero;
    }

    void PushBall()
    {
        float randomVeloY = Random.Range(-initialForce.y, initialForce.y);

        float randomDir = Random.Range(0, 2);

        if (randomDir < 1.0f)
        {
            physic.AddForce(new Vector2(-initialForce.x, randomVeloY));
        }
        else
        {
            physic.AddForce(new Vector2(initialForce.x, randomVeloY));
        }
    }

    void RestartGame()
    {
        ResetBall();

        Invoke("PushBall", 2);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
}
