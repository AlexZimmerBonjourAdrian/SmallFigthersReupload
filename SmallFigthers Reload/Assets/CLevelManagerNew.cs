using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CLevelManagerNew : MonoBehaviour
{
    private const int ModeNormal = 0;
    private const int ModeRage = 1;
    private const int ModeBossBattle = 3;

    private const int STATE_ROUNDSSTARTING = 0;
    private const int STATE_ROUNDPLAYING = 1;
    private const int STATE_ROUNDENDING = 2;
    //private int _numRoundsToWin = 3;
    private int _state;
    private int _stateGameMode;
    private GameObject _PlayerPrefab;
    public CPlayerManagerNew[] _player;
    //private int _roundNumber = 1;
    private CPlayerManagerNew _roundWinner;
    private CPlayerManagerNew _gameWinner;
    public Text _messageText;
    private float _timeState;
    private int _wins;

    // Start is called before the first frame update

    private void Awake()
    {
        //Todo: Hay que crear un menu de selecion con un modo de preservacion de esenarios
        this._PlayerPrefab = Resources.Load<GameObject>("Player");
    }
    void Start()
    {

    }

    //private void SpawnAllPlayer()
    //{
    //    for(int i=0;i<this._player.Length;i++)
    //    {
    //        if (this._player[i].getPlayerList())
    //        {
    //            this._player[i].getPlayerList().
    //        }
    //    }
    //}
  /*
    public void setState(int aState)
    {
        this._state = aState;
        if(this._state== 0)
        {
            this._roundNumber++;
        }
        else if( this._state == 1)
        {
            this._messageText.text = string.Empty;
        }
        else if(this._state==2)
        {
            this._roundWinner = null;
            this._roundWinner = this.GetRoundWinner();
            if(this._roundWinner != null)
            {
                this._wins = this._wins + 1;
            }
            //this._gameWinner = this.GetGameWinner();
           //string text = this.EndMessage();
           //this._messageText.text = 
        }
    }
    */
    // Update is called once per frame
    void Update()
    {

    }
    /*
    private bool PlayersLeft()
    {
        int num = 0;
        for(int i=0; i<this._player.Length; i++)
        {
            if(this._player[i]._instance.activeSelf)
            {
                num++;
            }
        }
        return num <= 1;
    }
    */
    /*
    private CPlayerManagerNew GetRoundWinner()
    {
        for(int i=0; i< this._player.Length;i++)
        {
            if(this._player[i]._instance.activeSelf)
            {
                return this._player[i];
            }
        }
        return null;
    }
    */
    
    //private CPlayerManagerNew GetGameWinner()
    //{
    //  for(int i =0; i<this._player.Length;i++)
    //    {
    //        if(this._player[i].getWin() == this._numRoundsToWin)
    //        {
    //            return this._player[i];
    //        }
    //    }
    //    return null;
    //}

    //private void ResetAllPlayer()
    //{
    //    for(int i = 0;i < this._player.Length; i++)
    //    {
    //        this._player[i].Reset();
    //    }
    //}
}
