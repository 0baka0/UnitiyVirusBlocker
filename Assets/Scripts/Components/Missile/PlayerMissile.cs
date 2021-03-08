using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 캐릭터가 발사하는 미사일을 나타내기 위함
[RequireComponent(typeof(ProjectileMovement))]
public class PlayerMissile : MonoBehaviour
{
    [SerializeField] private Transform _MissileMeshTransform;



    // 함께 사용되는 projectileMovement Component 를 나타냅니다.
    public ProjectileMovement projrctileMovement { get; private set; }

    private void Awake()
    {
        projrctileMovement = GetComponent<ProjectileMovement>();
    }

    private void Update()
    {
        RotatingMissileMesh();
    }

    // 미사일 Yaw 회전을 구현합니다.
    private void RotatingMissileMesh() =>
        _MissileMeshTransform.eulerAngles += Vector3.up * 1440.0f * Time.deltaTime;


    // 미사일을 발사시킵니다.
    /// - initialPosition : 미사일 오브젝트의 초기 위치를 전달합니다.
    /// - direction : 투사체 방향을 전달합니다.
    /// - speed : 투사체 속력을 전달합니다.
    public void Fire(Vector3 initialPosition, Vector3 direction, float speed)
    {
        // 오브젝트 위치를 초기 위치로 설정합니다.
        transform.position = initialPosition;

        // 투사체 이동 컴포넌트의 내용을 초기화합니다.
        projrctileMovement.projectileDirection = direction;
        projrctileMovement.projectileSpeed = speed;
    }



}
