using System;
using UnityEngine;

public class CBullet : MonoBehaviour
{
    public delegate void BulletSpawn(CBullet _inst);

    private Rigidbody _rigidbody;

    private CBullet.BulletSpawn Inst;

    public void SubscribeOnInst(CBullet.BulletSpawn action)
    {
        this.Inst = (CBullet.BulletSpawn)Delegate.Combine(this.Inst, action);
    }

    public void UnSuscribeOnInst(CBullet.BulletSpawn action)
    {
        this.Inst = (CBullet.BulletSpawn)Delegate.Remove(this.Inst, action);
    }

    private void Awake()
    {
        this._rigidbody = base.GetComponent<Rigidbody>();
    }

    public void AddVel(Vector3 vel)
    {
        Vector3 force = new Vector3(vel.x, 0f, 0f);
        this._rigidbody.AddForce(force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision gameObejcts)
    {
        if (this.Inst != null)
        {
            this.Inst(this);
        }
        if (gameObejcts.collider.tag == "Player")
        {
            CParticleManager._inst.SpawnSparks(base.transform.position);
            UnityEngine.Object.Destroy(base.gameObject);
        }
    }
}

