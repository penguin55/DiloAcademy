using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private KeyCode moveUp;
    [SerializeField] private KeyCode moveDown;
    [SerializeField] private BoundaryMove boundary;
    [SerializeField] private float movementSpeed;

    private Vector2 lastPoint;
    private Rigidbody2D physic;

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
}
