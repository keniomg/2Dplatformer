using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Mover : MonoBehaviour
{
    [SerializeField] protected float Speed;

    public Vector2 MoveDirection { get; protected set; }
}