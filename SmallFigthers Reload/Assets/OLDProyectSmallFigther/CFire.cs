using System;
using UnityEngine;

public class CFire : MonoBehaviour
{
    private Cplayer _player;

    private void Awake()
    {
        this._player = base.GetComponent<Cplayer>();
    }

    private void Start()
    {
    }

    public void Fire()
    {
        if (this._player.getPlayerNumber() <= 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CBulletManager._inst.Spawn(base.transform.position - base.transform.forward * this._player.getspawnOffset(), base.transform.forward * -this._player.getmaxVelocity());
            }
        }
        else if (this._player.getPlayerNumber() > 1 && Input.GetKeyDown(KeyCode.Return))
        {
            CBulletManager._inst.Spawn(base.transform.position + -base.transform.forward * this._player.getspawnOffset(), base.transform.forward * -this._player.getmaxVelocity());
        }
    }
}

