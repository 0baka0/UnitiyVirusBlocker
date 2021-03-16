using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStartUpFramework.Util;

public sealed class GameSceneInstance : 
	SceneInstance
{
	[SerializeField] private TrackingMovement _TrackingCamera;

	public TrackingMovement trackingCamera => _TrackingCamera;

	public ObjectPool<ParticeInstance> particlePool { get; private set; } = new ObjectPool<ParticeInstance>();

	public ParticeInstance GetParticeInstance(ParticleInstanceType particleInstType)
    {
		return particlePool.GetRecycleObject(
			(obj) => obj.particleInstanceType == particleInstType);
    }
}
