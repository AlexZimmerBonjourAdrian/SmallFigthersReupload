using System;
using System.Collections.Generic;
using UnityEngine;

public class CParticleManager : MonoBehaviour
{
    private List<CParticuleSystem> _ParticleList;

    private GameObject _ParticuleAsset;

    public static CParticleManager _inst;

    private static CParticleManager Inst
    {
        get
        {
            return CParticleManager._inst;
        }
    }

    private void Awake()
    {
        CParticleManager._inst = this;
        this._ParticuleAsset = Resources.Load<GameObject>("Explosion");
        this._ParticleList = new List<CParticuleSystem>();
    }

    public void start()
    {
    }

    private void Update()
    {
        for (int i = this._ParticleList.Count - 1; i >= 0; i--)
        {
            if (this._ParticleList[i] == null)
            {
                this._ParticleList.RemoveAt(i);
            }
        }
    }

    public void Spawn(Vector3 pos)
    {
        this._ParticuleAsset = Resources.Load<GameObject>("Explosion");
        GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this._ParticuleAsset, pos, Quaternion.identity);
        CParticuleSystem component = gameObject.GetComponent<CParticuleSystem>();
        this._ParticleList.Add(component);
    }

    public void SpawnSparks(Vector3 pos)
    {
        this._ParticuleAsset = Resources.Load<GameObject>("Sparks");
        GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this._ParticuleAsset, pos, Quaternion.identity);
        CParticuleSystem component = gameObject.GetComponent<CParticuleSystem>();
        this._ParticleList.Add(component);
    }
}
