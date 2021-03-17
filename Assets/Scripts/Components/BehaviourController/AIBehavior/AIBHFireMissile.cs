using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStartUpFramework.Util;

public sealed class AIBHFireMissile : 
    AIBehaviorBase
{
    [Header("발사시킬 미사일 개수")]
    [Range(1, 20)]
    [SerializeField] private int _MissileCount = 8;

    public Transform _MissileFirePosition;

    private ObjectPool<EnemyMissile> _MissilePool = new ObjectPool<EnemyMissile>();

    private EnemyMissile _EnemyMissilePrefabs;

    /*[Header("미사일 발사 위치")]
    [SerializeField] private Transform _MissileFirePos1;
    [SerializeField] private Transform _MissileFirePos2;
    [SerializeField] private Transform _MissileFirePos3;
    [SerializeField] private Transform _MissileFirePos4;
    [SerializeField] private Transform _MissileFirePos5;
    [SerializeField] private Transform _MissileFirePos6;
    [SerializeField] private Transform _MissileFirePos7;
    [SerializeField] private Transform _MissileFirePos8;

    [Header("미사일 발사 딜레이")]
    [SerializeField] private float _MissileDelay = 0.5f;

    private float _LastFiredTime;

    [Header("미사일 개수")]
    [SerializeField] private int _MissileCount = 40;*/

    private ObjectPool<EnemyMissile> _EnemyMissile = new ObjectPool<EnemyMissile>();

    private EnemyMissile _EnemyMissilePrefab;

    protected override void Awake()
    {
        base.Awake();

        ResourceManager.Instance.LoadResource<GameObject>(
            "EnemyMissile",
            "Prefabs/Missile/EnemyMissile").GetComponent<EnemyMissile>();
        /*_EnemyMissilePrefab = ResourceManager.Instance.LoadResource<GameObject>(
            "PlayerMissile",
            "Prefabs/Missile/EnemyMissile").GetComponent<EnemyMissile>();*/
    }

    private void Update()
    {
        Run();
    }

    public override void Run()
    {
        void FireMissile()
        {
            _MissileFirePosition.localEulerAngles = Vector3.zero;

            float addYawAngle = 360.0f / _MissileCount;

            for(int i = 0; i< _MissileCount; ++i)
            {
                // 미사일 생성
                var enemyMissile = _MissilePool.GetRecycleObject() ??
                    _MissilePool.RegisterRecyclableObject(Instantiate(_EnemyMissilePrefabs));

                _MissileFirePosition.localEulerAngles = Vector3.up * (addYawAngle * i);

                // 미사일 발사
                enemyMissile.Fire(_MissileFirePosition.position, _MissileFirePosition.forward);
            }
        }

        FireMissile();

        // 이 메서드가 호출되었을 경우
        // EnemyMissile 을 오브젝트 시작으로 8 방향으로 발사되게 해주세요
        // 발사되는 EnemyMissile 은 풀링이 되어야 합니다.

        /*EnemyMissile CreateMissileObject() =>
            _EnemyMissile.GetRecycleObject() ??
            _EnemyMissile.RegisterRecyclableObject(Instantiate(_EnemyMissilePrefab));

        if (Time.time - _LastFiredTime <= _MissileDelay) return;
        _LastFiredTime = Time.time;

        for (int i = 0; i < _MissileCount; ++i)
        {
            var newEnemyMissile1 = CreateMissileObject();
            var newEnemyMissile2 = CreateMissileObject();
            var newEnemyMissile3 = CreateMissileObject();
            var newEnemyMissile4 = CreateMissileObject();
            var newEnemyMissile5 = CreateMissileObject();
            var newEnemyMissile6 = CreateMissileObject();
            var newEnemyMissile7 = CreateMissileObject();
            var newEnemyMissile8 = CreateMissileObject();

            newEnemyMissile1.Fire(_MissileFirePos1.position,
                _MissileFirePos1.forward, 5);
            newEnemyMissile2.Fire(_MissileFirePos2.position,
                _MissileFirePos2.forward, 5);
            newEnemyMissile3.Fire(_MissileFirePos3.position,
                _MissileFirePos3.forward, 5);
            newEnemyMissile4.Fire(_MissileFirePos4.position,
                _MissileFirePos4.forward, 5);
            newEnemyMissile5.Fire(_MissileFirePos5.position,
                _MissileFirePos5.forward, 5);
            newEnemyMissile6.Fire(_MissileFirePos6.position,
                _MissileFirePos6.forward, 5);
            newEnemyMissile7.Fire(_MissileFirePos7.position,
                _MissileFirePos7.forward, 5);
            newEnemyMissile8.Fire(_MissileFirePos8.position,
                _MissileFirePos8.forward, 5);

        }*/

        behaviorFinished = true;
    }
}
