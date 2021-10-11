using UnityEngine;

public class BoundaryMove : MonoBehaviour
{
    [SerializeField] private Transform boundaryUp;
    [SerializeField] private Transform boundaryDown;

    public void RestrictMove(ref Vector2 movementPoint)
    {
        movementPoint.y = Mathf.Clamp(movementPoint.y, boundaryDown.position.y, boundaryUp.position.y);
    }
}
