using System;
using System.Collections.Generic;
using UnityEngine;

public class CBulletManager : MonoBehaviour
{
    private List<CBullet> _bulletList;

    private GameObject _bulletAsset;

    public static CBulletManager _inst;

    private int _index;

    private static CBulletManager Inst
    {
        get
        {
            return CBulletManager._inst;
        }
    }

    private void Awake()
    {
        CBulletManager._inst = this;
        this._bulletAsset = Resources.Load<GameObject>("Bullet");
        this._bulletList = new List<CBullet>();
    }

    public void start()
    {
    }

    private void Update()
    {
        for (int i = this._bulletList.Count - 1; i >= 0; i--)
        {
            if (this._bulletList[i] == null)
            {
                this._bulletList.RemoveAt(i);
            }
        }
    }

    public void Spawn(Vector3 pos, Vector3 vel)
    {
        GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this._bulletAsset, pos, Quaternion.identity);
        CBullet component = gameObject.GetComponent<CBullet>();
        component.AddVel(vel);
        UnityEngine.Object.Destroy(gameObject, 8f);
        this._bulletList.Add(component);
        component.SubscribeOnInst(new CBullet.BulletSpawn(this.OnUpdateBulletIndex));
    }

    private void OnUpdateBulletIndex(CBullet bullet)
    {
        int index = this._bulletList.IndexOf(bullet);
        this._index = index;
    }
}
