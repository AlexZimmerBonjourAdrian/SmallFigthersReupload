using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBulletManageNew : MonoBehaviour
{
    private List<CBulletNew> _bulletList;
    private GameObject _bulletAsset;
    public static CBulletManageNew _inst;
    private int _index;
    private static CBulletManageNew Inst
    {
        get
        {
            return CBulletManageNew._inst;
        }
    }
    private void Awake()
    {
        CBulletManageNew._inst = this;
        this._bulletAsset = Resources.Load<GameObject>("Bullet");
        this._bulletList = new List<CBulletNew>();
    }


    private void start()
    {

    }
    // Update is called once per frame
    void Update()
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
        CBulletNew component = gameObject.GetComponent<CBulletNew>();
        component.AddVel(vel);
        UnityEngine.Object.Destroy(gameObject, 8f);
        this._bulletList.Add(component);
        component.SubscribOnInst(new CBulletNew.BulletSpawn(this.OnUpdateBulletIndex));
    }

    private void OnUpdateBulletIndex(CBulletNew bullet)
    {
        int index = this._bulletList.IndexOf(bullet);
        this._index = index;
    }
}