using System;
using UnityEngine;

public class CMoved : MonoBehaviour
{
    private Cplayer _player;

    private void Awake()
    {
    }

    private void Start()
    {
        this._player = base.GetComponent<Cplayer>();
    }

    public void FixedUpdate()
    {
        Debug.Log(this._player._inputVel);
        this._player.getRigidbody().velocity = this._player._inputVel;
    }

    public void Update()
    {
    }

    public void MovedPlayer()
    {
        if (this._player.getPlayerNumber() <= 1)
        {
            if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)) || (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)))
            {
                this._player._inputVel = Vector3.zero;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                this._player._inputVel = Vector3.forward * this._player.getmaxVelocity();
            }
            else if (Input.GetKey(KeyCode.S))
            {
                this._player._inputVel = Vector3.forward * -this._player.getmaxVelocity();
            }
            else
            {
                this._player._inputVel = Vector3.zero;
            }
        }
        else if (this._player.getPlayerNumber() > 1)
        {
            if ((Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow)) || (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)))
            {
                this._player._inputVel = Vector3.zero;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                this._player._inputVel = Vector3.forward * this._player.getmaxVelocity();
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                this._player._inputVel = Vector3.forward * -this._player.getmaxVelocity();
            }
        }
    }
}