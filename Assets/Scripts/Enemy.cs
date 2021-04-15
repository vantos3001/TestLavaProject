using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Collider _collider;

    public Vector3 CenterPosition => _collider.bounds.center;
}