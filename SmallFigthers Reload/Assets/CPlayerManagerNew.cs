using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CPlayerManagerNew : MonoBehaviour
{
    public static CPlayerManagerNew _inst;
    private int _index;

    private static CPlayerManagerNew Inst
    {
        get
        {
            return CPlayerManagerNew._inst;
        }
    }

   
    //private int _playerNumber;
    //public GameObject _instance;
    private List<CPlayerNew> _PlayerList;
    private GameObject _playerAsset;
    public Transform _SpawnPosition;
    private AudioSource _Fire;
    private CPlayerNew _player;
    public int getIndex()
    {
        return this._index;
    }

    //public void setplayernumber(int aplayernumber)
    //{
    //    this._playernumber = aplayernumber;
    //}
    //public int getPlayerNumber()
    //{
    //    return this._playerNumber;
    //}

   
    //public int getWin()
    //{
    //    return this._wins;
    //}

    public void Setup()
    {
        //this._player = this._instance.GetComponent<CPlayerNew>();
        //this._player.set


    }


    public void Awake()
    {

        CPlayerManagerNew._inst = this;
        this._playerAsset = Resources.Load<GameObject>("Player");
        this._PlayerList = new List<CPlayerNew>();
    }
    //Asigna el Los Resoruces y el script al cual estos son creados
    private void Start()
    {
        

    }
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        //Elimina los elementos de la lista que se hn eliminado
        for (int i = this._PlayerList.Count - 1; i >= 0; i--)
        {
            if (this._PlayerList[i] == null)
            {
                this._PlayerList.RemoveAt(i);
            }
        }
    }

    public void Spawn(Vector3 pos)
    {
        Debug.Log("Entra");
       //instanciael objeto en e la posicion actual asignandole el playerAsset
        GameObject gameobject = (GameObject)UnityEngine.Object.Instantiate(this._playerAsset, pos, Quaternion.identity);
        //Sele asigna a componente la clase CPlayerNew por si este no a sido cargado
        CPlayerNew component = gameObject.GetComponent<CPlayerNew>();
        //Se agrega el elemento a la lista de players
        this._PlayerList.Add(component);
        //Actualiza el indise a la hora de crearlo en la lista
        component.SubscribeOnInst(new CPlayerNew.PlayerSpawn(this.OnUpdatePlayerIndex));
    }
    //Actalizar el indixe  de la lista de players
    private void OnUpdatePlayerIndex(CPlayerNew player)
    {
        int index = this._PlayerList.IndexOf(player);
        this._index = index;
    }
    
    //Resetea la posicion y rotacion del objeto ademas de activarlo 
    //public void Reset()
    //{
    //    this._instance.transform.position = this._SpawnPosition.position;
    //    this._instance.transform.rotation = this._SpawnPosition.rotation;
    //    this._instance.SetActive(true);
    //}
    //Devuelve La lista de Players
    //Tener cuidado no funciona tam bien
    public List<CPlayerNew> getPlayerList()
    {
        return this._PlayerList;
    }
    public void SetUp()
    {
        
    }
}
