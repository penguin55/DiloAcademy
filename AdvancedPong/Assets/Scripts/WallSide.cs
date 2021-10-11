using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSide : MonoBehaviour
{
    [SerializeField] private PaddleControl owner;
    [SerializeField] private GameManager gm;

    void OnTriggerEnter2D(Collider2D anotherCollider)
    {
        if (anotherCollider.CompareTag("Ball"))
        {
            owner.AddScore(1);

            if (owner.Score < gm.MaxScore)
            {
                anotherCollider.gameObject.SendMessage("RestartGame", 2.0f, SendMessageOptions.RequireReceiver);
            }
        }
    }
}
