using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    [SerializeField] private int score;

    [Header("Properties")]
    [SerializeField] private KeyCode moveUp;
    [SerializeField] private KeyCode moveDown;
    [SerializeField] private BoundaryMove boundary;
    [SerializeField] private float movementSpeed;

    private Vector2 lastPoint;
    private Rigidbody2D physic;
    private ContactPoint2D lastContactPoint;

    private void Start()
    {
        physic = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float calculatedSpeed = 0f;

        if (Input.GetKey(moveUp))
        {
            calculatedSpeed += movementSpeed;
        }

        if (Input.GetKey(moveDown))
        {
            calculatedSpeed -= movementSpeed;
        }

        physic.velocity = new Vector2(0f, calculatedSpeed);

        lastPoint = transform.position;
        boundary.RestrictMove(ref lastPoint);
        transform.position = lastPoint;
    }

    public void AddScore(int score)
    {
        this.score += score;
    }

    public void ResetScore()
    {
        score = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }

    public int Score
    {
        get { return score; }
    }

    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }
}
