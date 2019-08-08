using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFoo : MonoBehaviour
{
    public Transform _position;



    private CPlayerManagerNew _PlayerManager;
    //private CPlayerNew _Player;

    // Start is called before the first frame update
    private void Awake()
    {
        _PlayerManager = GetComponent<CPlayerManagerNew>();
     
    }
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnPlayer()
    {
        Debug.Log("Entra");
        this._PlayerManager.Spawn(_position.position);
       /* for (int i = 0; i < _PlayerManager.getPlayerList().Count; i++)
        {

            //if(this._PlayerManager.getPlayerList().IndexOf(_Player)==0)
            if (this._PlayerManager.getPlayerList()[0])
            {
                
            }
            else if (this._PlayerManager.getPlayerList()[1])
            {
                this._PlayerManager.Spawn(_position.position);
            }
            // PlayerManagerNew._inst.Spawn(_position.position);
        }

    */
    }
}
