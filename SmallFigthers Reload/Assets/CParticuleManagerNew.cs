using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CParticuleManagerNew : MonoBehaviour
{
    private List<CParticuleSystemNew> _ParticleList;
    private GameObject _ParticuleAsset;
    public static CParticuleManagerNew _inst;
    private static CParticuleManagerNew Inst
    {
        get
        {
            return CParticuleManagerNew._inst;
        }
    }
    private void Awake()
    {
        CParticuleManagerNew._inst = this;
        //Modificar Si hay problemas
        this._ParticuleAsset = Resources.Load<GameObject>("Explosion");
        this._ParticleList = new List<CParticuleSystemNew>();
    }
    private void Update()
    {
        for(int i = this._ParticleList.Count-1; i>=0;i--)
        {
            if(this._ParticleList[i] == null)
            {
                this._ParticleList.RemoveAt(i);
            }
        }
    }
    public void Spawn(Vector3 pos)
    {
        this._ParticuleAsset = Resources.Load<GameObject>("Explosion");
        GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this._ParticuleAsset, pos, Quaternion.identity);
        CParticuleSystemNew component = gameObject.GetComponent<CParticuleSystemNew>();
        this._ParticleList.Add(component);
    }

}
