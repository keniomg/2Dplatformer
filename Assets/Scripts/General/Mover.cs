using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Mover : MonoBehaviour
{
    [SerializeField] protected float Speed;

    public Vector2 Direction {get; protected set; }
}