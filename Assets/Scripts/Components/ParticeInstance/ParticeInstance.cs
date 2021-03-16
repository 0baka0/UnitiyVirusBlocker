using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStartUpFramework;

[RequireComponent(typeof(ParticleSystem))]
public sealed class ParticeInstance : 
    MonoBehaviour, IObjectPoolable
{
    public ParticleInstanceType particleInstanceType { get; set; }

    public bool canRecyclable { get; set; }
    public Action onRecycleStartEvent { get; set; }

    public new ParticleSystem particleSystem { get; private set; }

    private WaitUntil _WaitParticePlayFin;

    private void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
        _WaitParticePlayFin = new WaitUntil(() => particleSystem.isPlaying);
    }

    // 파티클을 재생 시킵니다.
    public void PlayerPartice()
    {
        particleSystem.Play();

        StartCoroutine(WaitParticePlayFin());
    }

    //  파티클 재생 끝을 대기합니다.
    private IEnumerator WaitParticePlayFin()
    {
        // 파티클 재생이 끝날 때 까지 대기합니다.
        yield return _WaitParticePlayFin;

        // 재사용 가능한 상태로 변경합니다.
        canRecyclable = true;
    }
}
