using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStartUpFramework;

[RequireComponent(typeof(ProjectileMovement))]
public class EnemyMissile : MonoBehaviour,
    IObjectPoolable
{
    private float _MissileSpeed;

    private ProjectileMovement _ProjectileMovement;

    // 초기 위치를 나타냅니다.
    private Vector3 _InitialPosition;

    public bool canRecyclable { get; set; }
    public System.Action onRecycleStartEvent { get; set; }

    private void Awake()
    {
        _ProjectileMovement = GetComponent<ProjectileMovement>();
    }

    private void Update()
    {
        if (Vector3.Distance(_InitialPosition, transform.position) > 10.0f)
            DisibleMissile();
    }

    private void DisibleMissile()
    {
        canRecyclable = true;

        gameObject.SetActive(false);
    }

    public void Fire(Vector3 initialPosition, Vector3 direction)
    {
        transform.position = _InitialPosition = initialPosition;

        gameObject.SetActive(true);

        _ProjectileMovement.projectileDirection = direction;
        _ProjectileMovement.projectileSpeed = _MissileSpeed;
    }

}
