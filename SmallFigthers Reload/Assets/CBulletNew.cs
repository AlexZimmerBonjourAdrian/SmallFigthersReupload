using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CBulletNew : MonoBehaviour
{

    public delegate void BulletSpawn(CBulletNew _inst);
    // Update is called once per frame
    
    private Rigidbody _rigidbody;

    private CBulletNew.BulletSpawn Inst;


    //private CBulletNew.BulletSpawn
    // Start is called before the first frame update
    private void Awake()
    {
        this._rigidbody = base.GetComponent<Rigidbody>();
    }
    void Start()
    {
       
    }
    

    public void AddVel(Vector3 vel)
    {
        Vector3 force = new Vector3(vel.x, 0f, 0f);
        this._rigidbody.AddForce(force, ForceMode.Impulse);

    }
   
    public void SubscribOnInst(CBulletNew.BulletSpawn action)
    {
        this.Inst = (CBulletNew.BulletSpawn)Delegate.Remove(this.Inst, action);
    }
    public void UnSubscribOnInst(CBulletNew.BulletSpawn action)
    {
        this.Inst = (CBulletNew.BulletSpawn)Delegate.Remove(this.Inst, action);
    }
    private void OnCollisionEnter(Collision gameobject)
    {

        if (gameobject.collider.tag == "Player")
        {
            UnityEngine.Object.Destroy(base.gameObject);
        }

        if (gameobject.collider.tag == "Obstacule")
        {
            UnityEngine.Object.Destroy(base.gameObject);
        }
    }
}
