using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] protected float _speed;

    public Vector2 Direction {get; protected set; }
}