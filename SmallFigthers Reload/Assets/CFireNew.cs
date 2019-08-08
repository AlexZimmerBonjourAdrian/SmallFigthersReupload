using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFireNew : MonoBehaviour
{
    private CPlayerNew _player;

    private void Awake()
    {
        this._player = base.GetComponent<CPlayerNew>();
    }
    // Start is called before the first frame update
   

    // Update is called once per frame
   public void Fire()
    {
        CBulletManageNew._inst.Spawn(base.transform.position + -base.transform.right * this._player.getSpawnOffset(), base.transform.forward * -this._player.GetMaxVelocity());
    }
    
}
