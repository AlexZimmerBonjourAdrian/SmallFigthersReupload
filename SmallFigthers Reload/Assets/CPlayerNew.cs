using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CPlayerNew : MonoBehaviour
{
    private const int STATE_STAND = 0;
    private const int STATE_MOVING = 1;
    public delegate void PlayerSpawn(CPlayerNew _inst);
    private CPlayerNew.PlayerSpawn Inst;
    private float _spawnOffset = 1.3f;
    private int _state;
    private CFireNew _Fire;
    private Rigidbody _rigidbody;
    MoveValue Vector;
    private CPlayerManagerNew _PlayerManager;
    private CPlayerNew _inst;
    //private int _playerNumber;
     private struct MoveValue
    {
        public Vector3 _VectSpeed;
        public float _getMaxVelocity;
        
    };

   

    
    public void setVector(Vector3 vector)
    {
        this.Vector._VectSpeed = vector;
        
        
    }
    
    public void SubscribeOnInst(CPlayerNew.PlayerSpawn action)
    {
        this.Inst = (CPlayerNew.PlayerSpawn)Delegate.Combine(this.Inst, action);
    }
    public void UnSubscribeOnInst(CPlayerNew.PlayerSpawn action)
    {
        this.Inst = (CPlayerNew.PlayerSpawn)Delegate.Remove(this.Inst, action);
    }
    
    public Vector3 getVector()
    {
        return this.Vector._VectSpeed;
    }
    public void SetGetMaxVelocty(float Vel)
    {
        this.Vector._getMaxVelocity = Vel;
    }
    public float GetMaxVelocity()
    {
        return this.Vector._getMaxVelocity;
    }
    private void Awake()
    {
       
        this._inst = this;
        this._PlayerManager = GetComponent<CPlayerManagerNew>();
        this._Fire = GetComponent<CFireNew>();

    }
    // Start is called before the first frame update
    void Start()
    {
        this._rigidbody = base.GetComponent<Rigidbody>();
        this.SetGetMaxVelocty(10f);
    }

    // Update is called once per frame
    void Update()
    {
        Controller(); 
    }

    private void Controller()
    {
        if (_PlayerManager.getPlayerList().IndexOf(_inst) == 0)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                this.setVector(-Vector3.right);
            }

            else if (Input.GetKeyDown(KeyCode.S))
            {

                this.setVector(Vector3.right);
            }
            if (Input.GetKey(KeyCode.W))
            {

                setState(1);
            }
            else if (Input.GetKey(KeyCode.S))
            {

                setState(1);
            }

            else
            {
                setState(0);
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                this._Fire.Fire();
            }


        }
        else if (_PlayerManager.getPlayerList().IndexOf(_inst)==1)
        {
            if(Input.GetKey(KeyCode.Joystick1Button7)|| Input.GetKey(KeyCode.UpArrow))
            {
                this.setVector(Vector3.right);
            }
            else if (Input.GetKey(KeyCode.Joystick1Button7) || Input.GetKey(KeyCode.DownArrow))
            {
                this.setVector(-Vector3.right);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {

                setState(1);
            }
            else if(Input.GetKey(KeyCode.DownArrow))
            {

                setState(1);
            }

            else
            {
                setState(0);
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button0)||Input.GetKeyDown(KeyCode.Space))
            {

            }
            

            
         }



    }
    public void setState(int aState)
    {
        this._state = aState;


        if (this._state == 0)
        {
            this.setVector(Vector3.zero);
            _rigidbody.velocity = getVector();
        }
        else if (this._state == 1)
        {
            if (_PlayerManager.getPlayerList().IndexOf(_inst) == 0)
            {
                if (Input.GetKey(KeyCode.W))
                {

                    _rigidbody.velocity = this.getVector() * this.GetMaxVelocity();
                }

                else if (Input.GetKey(KeyCode.S))
                {
                    _rigidbody.velocity = this.getVector() * this.GetMaxVelocity();

                }

            }
            else if (_PlayerManager.getPlayerList().IndexOf(_inst) == 1)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {

                    _rigidbody.velocity = this.getVector() * this.GetMaxVelocity();
                }

                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    _rigidbody.velocity = this.getVector() * this.GetMaxVelocity();

                }
            }
        }
    }

    //SetSpawnObject 
        

    public void setSpawnOffset(float aspawnOffset)
    {
        this._spawnOffset = aspawnOffset;
    }
    public float getSpawnOffset()
    {
        return this._spawnOffset;
    }

   
}
