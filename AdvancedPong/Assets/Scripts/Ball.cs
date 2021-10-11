using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D physic;

    public float force;

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
        float angle = Random.Range(-45f, 45f);
        Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        physic.AddForce(dir * force);
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
