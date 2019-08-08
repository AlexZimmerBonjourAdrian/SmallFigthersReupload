using System;
using UnityEngine;

public class CParticuleSystem : MonoBehaviour
{
    private ParticleSystem _systemExplocion;

    private float _elapsedTime;

    private void Awake()
    {
        this._systemExplocion = base.GetComponent<ParticleSystem>();
    }

    public void Update()
    {
        if (!this._systemExplocion.main.loop && this._systemExplocion.isPlaying)
        {
            this._elapsedTime += Time.deltaTime;
            if (this._elapsedTime > this._systemExplocion.main.startLifetimeMultiplier)
            {
                UnityEngine.Object.Destroy(base.gameObject);
            }
        }
    }

    public void StartSystem()
    {
        this._systemExplocion.Play();
    }
}

