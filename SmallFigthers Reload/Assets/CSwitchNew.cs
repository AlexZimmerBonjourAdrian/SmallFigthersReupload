using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSwitchNew : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    private void Update()
    {
        this.Stages();
    }

    public void Switch(string name)
    {
        CGameManagerNew.Inst.LoadSceneAsync(name);
    }

    public void Stages()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CGameManagerNew.Inst.LoadSceneAsync("Menu");
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
