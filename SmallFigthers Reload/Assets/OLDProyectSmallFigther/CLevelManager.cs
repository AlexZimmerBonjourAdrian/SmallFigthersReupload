using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CLevelManager : MonoBehaviour
{
    private const int STATE_ROUNDSTARTIG = 0;

    private const int STATE_ROUNDPLAYING = 1;

    private const int STATE_ROUNDENDING = 2;

    private int _numRoundsToWin = 3;

    private int _state;

    private GameObject _playerPrefab;

    public CPlayerManager[] _player;

    private Camera _camera;

    private int _roundNumber = 1;

    private CPlayerManager _roundWinner;

    private CPlayerManager _gameWinner;

    public Text _messageText;

    private float _timeState;

    public void Awake()
    {
        this._playerPrefab = Resources.Load<GameObject>("Player");
        this._camera = Camera.main;
    }

    public void Start()
    {
        this.SpawnAllPlayers();
    }

    private void SpawnAllPlayers()
    {
        for (int i = 0; i < this._player.Length; i++)
        {
            this._player[i].setPlayerNumber(i + 1);
            if (this._player[i].getPlayerNumber() == 1)
            {
                this._player[i]._SpawnPosition.rotation = Quaternion.Euler(0f, -90f, 0f);
            }
            if (this._player[i].getPlayerNumber() == 2)
            {
                this._player[i]._SpawnPosition.rotation = Quaternion.Euler(0f, 90f, 0f);
            }
            this._player[i]._instance = (UnityEngine.Object.Instantiate(this._playerPrefab, this._player[i]._SpawnPosition.position, this._player[i]._SpawnPosition.rotation) as GameObject);
            this._player[i].Setup();
        }
    }

    public void setState(int aState)
    {
        this._state = aState;
        if (this._state == 0)
        {
            this.ResetAllPalyer();
            this._roundNumber++;
        }
        else if (this._state == 1)
        {
            this._messageText.text = string.Empty;
        }
        else if (this._state == 2)
        {
            this._roundWinner = null;
            this._roundWinner = this.GetRoundWinner();
            if (this._roundWinner != null)
            {
                this._roundWinner.setWin(this._roundWinner.getWin() + 1);
            }
            this._gameWinner = this.GetGameWinner();
            string text = this.EndMessage();
            this._messageText.text = text;
        }
    }

    private string EndMessage()
    {
        string text = "DRAW! ";
        if (this._roundWinner != null)
        {
            text = "Player " + this._roundWinner.getPlayerNumber() + " WIN THE ROUND!";
        }
        text += "\n\n\n\n";
        for (int i = 0; i < this._player.Length; i++)
        {
            string text2 = text;
            text = string.Concat(new object[]
            {
                text2,
                "Player ",
                this._player[i].getPlayerNumber(),
                ": ",
                this._player[i].getWin(),
                " WINS\n"
            });
        }
        if (this._gameWinner != null)
        {
            text = "Player " + this._roundWinner.getPlayerNumber() + " WIN THE GAME!";
        }
        return text;
    }

    private bool PlayersLeft()
    {
        int num = 0;
        for (int i = 0; i < this._player.Length; i++)
        {
            if (this._player[i]._instance.activeSelf)
            {
                num++;
            }
        }
        return num <= 1;
    }

    private CPlayerManager GetRoundWinner()
    {
        for (int i = 0; i < this._player.Length; i++)
        {
            if (this._player[i]._instance.activeSelf)
            {
                return this._player[i];
            }
        }
        return null;
    }

    private CPlayerManager GetGameWinner()
    {
        for (int i = 0; i < this._player.Length; i++)
        {
            if (this._player[i].getWin() == this._numRoundsToWin)
            {
                return this._player[i];
            }
        }
        return null;
    }

    private void ResetAllPalyer()
    {
        for (int i = 0; i < this._player.Length; i++)
        {
            this._player[i].Reset();
        }
    }

    public void Update()
    {
        if (this._gameWinner != null)
        {
            SceneManager.LoadSceneAsync("Menu");
        }
        if (this._state == 0)
        {
            this._messageText.text = "ROUND " + this._roundNumber;
            this._timeState += 0.5f * Time.deltaTime;
            if (this._timeState >= 1f)
            {
                this._timeState = 0f;
                this.setState(1);
                return;
            }
        }
        else if (this._state == 1)
        {
            if (this.PlayersLeft())
            {
                this._timeState += 0.5f * Time.deltaTime;
                if (this._timeState >= 1f)
                {
                    this._timeState = 0f;
                    this.setState(2);
                    return;
                }
            }
        }
        else if (this._state == 2)
        {
            this._timeState += 0.5f * Time.deltaTime;
            if ((double)this._timeState >= 1.5)
            {
                this._timeState = 0f;
                this.setState(0);
            }
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (!this._camera.orthographic)
            {
                this._camera.transform.position = new Vector3(0f, 11f, 0.4f);
                this._camera.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
                this._camera.orthographic = true;
            }
            else
            {
                this._camera.transform.position = new Vector3(0f, 8.2f, -4.1f);
                this._camera.transform.rotation = Quaternion.Euler(60f, 0f, 0f);
                this._camera.orthographic = false;
            }
        }
    }
}
