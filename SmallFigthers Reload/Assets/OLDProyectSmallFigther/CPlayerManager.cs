using System;
using UnityEngine;

[Serializable]
public class CPlayerManager
{
    private int _playerNumber;

    public GameObject _instance;

    private Cplayer _player;

    [HideInInspector]
    public Transform _SpawnPosition;

    private int _wins;

    private AudioSource _Fire;

    public void setPlayerNumber(int aplayerNumber)
    {
        this._playerNumber = aplayerNumber;
    }

    public int getPlayerNumber()
    {
        return this._playerNumber;
    }

    public void setPlayer(Cplayer aPlayer)
    {
        this._player = aPlayer;
    }

    public Cplayer getPlayer()
    {
        return this._player;
    }

    public void setWin(int aWin)
    {
        this._wins = aWin;
    }

    public int getWin()
    {
        return this._wins;
    }

    public void Setup()
    {
        this._player = this._instance.GetComponent<Cplayer>();
        this._player.setPlayerNumber(this._playerNumber);
    }

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void Reset()
    {
        this._instance.transform.position = this._SpawnPosition.position;
        this._instance.transform.rotation = this._SpawnPosition.rotation;
        this._instance.SetActive(false);
        this._instance.SetActive(true);
    }
}
