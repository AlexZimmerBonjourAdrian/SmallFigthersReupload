using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CParticuleSystemNew : MonoBehaviour
{
    private ParticleSystem _system;
    private float _elapsedTime;

    private void Awake()
    {
        this._system = base.GetComponent<ParticleSystem>();
    }
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(!this._system.main.loop && this._system.isPlaying)
        {
            this._elapsedTime += Time.deltaTime;
            if(this._elapsedTime > this._system.main.startLifetimeMultiplier)
            {
                UnityEngine.Object.Destroy(base.gameObject);
            }
        }
    }
    public void StartSystem()
    {
        this._system.Play();
    }
}
