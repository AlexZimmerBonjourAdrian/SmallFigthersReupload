using System;
using UnityEngine;
using UnityEngine.UI;

public class Cplayer : MonoBehaviour
{
    private const int STATE_STAND = 0;

    private const int STATE_MOVING = 1;

    private int _playerNumber;

    private CParticuleSystem _Particule;

    public float _maxVelocity = 100f;

    public float _spawnOffset = 1.3f;

    public Canvas _canvas;

    private int _state;

    public Slider _slider;

    public Image _fillImage;

    private Color _fullHearthColor = Color.green;

    private Color _zeroHearthColor = Color.red;

    private float _StartigLife = 100f;

    private float _currentHealth;

    public Vector3 _inputVel;

    private Transform _transform;
    //Carga la clase de movimiento del player
    private CMoved _moved;
    //Carga la clase de disparo
    private CFire _fire;
    
    //Carga los rigidbody
    private Rigidbody _rigidBody;

    public Rigidbody getRigidbody()
    {
        return this._rigidBody;
    }
    //cargar posicion
    public void setTransform(Transform aTransform)
    {
        this._transform = aTransform;
    }
    //Devuelve la posicion
    public Transform getTransform()
    {
        return this._transform;
    }
    //Devuelve a velcidad maxima
    public float getmaxVelocity()
    {
        return this._maxVelocity;
    }
    //este codigo observar que diablos es esto
    public void setspawnOffset(float aspawnOffset)
    {
        this._spawnOffset = aspawnOffset;
    }

    public float getspawnOffset()
    {
        return this._spawnOffset;
    }
    //setea el numero del jugador sabiendo si es jugador 1 o jugador 2
    public void setPlayerNumber(int aPlayerNumber)
    {
        this._playerNumber = aPlayerNumber;
    }
    //Devolver el numero del player
    public int getPlayerNumber()
    {
        return this._playerNumber;
    }
    //sete el estado 
    
    public void setState(int aState)
    {
        this._state = aState;
        if (this._state != 0)
        {
            if (this._state == 1)
            {
            }
        }
    }
    
    public void Awake()
    {
        this._transform = base.GetComponent<Transform>();
        this._Particule = base.GetComponentInChildren<CParticuleSystem>();
        this._moved = base.GetComponent<CMoved>();
        this._fire = base.GetComponent<CFire>();
    }

    private void Start()
    {
        this._currentHealth = this._StartigLife;
        this.SetHealthUI();
        this._rigidBody = base.GetComponent<Rigidbody>();
    }

    private void SetHealthUI()
    {
        this._slider.value = this._currentHealth;
        this._fillImage.color = Color.Lerp(this._zeroHearthColor, this._fullHearthColor, this._currentHealth / this._StartigLife);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this._inputVel = Vector3.forward * getmaxVelocity();
        }
        if(Input.GetKey(KeyCode.S))
        {
            this._inputVel = Vector3.forward * -getmaxVelocity();
        }

        
        //Control de movimiento de players asignados por las rondas
        this._moved.MovedPlayer();
        if (this._state == 0)
        {
            //estado sin moverse
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                this.setState(1);
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                this._fire.Fire();
            }
        }
        else if (this._state == 1)
        {
            //Estado  moviendose
            if (!Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.S) || !Input.GetKey(KeyCode.UpArrow) || !Input.GetKey(KeyCode.DownArrow))
            {
                this.setState(0);
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                this._fire.Fire();
            }
        }
        

    }
    public void MovedPlayer()
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
        private void FixedUpdate()
    {
        this.SetHealthUI();
    }

    //Control de coliciones
    private void OnCollisionEnter(Collision gameObjects)
    {
        //Codigo de coliciones de la ballas
        if (gameObjects.collider.tag == "Bullet")
        {
            //Codigo para quitar salud
            this._currentHealth -= 40f;
            //Cargarlo en la interfaz
            //this.SetHealthUI();
            //codigo de muerte
            if (this._currentHealth <= 0f)
            {
                //setea la vida en 100
                this._currentHealth = 100f;
                //Crea un spawn de particulas en la posicion del jugador
                CParticleManager._inst.Spawn(base.transform.position);
                //Desactiva a el jugador
                base.gameObject.SetActive(false);
            }
        }
        //detecta la colicion de la pared
        if (gameObjects.collider.tag == "Well")
        {
            this.setState(0);
        }
    }


}
