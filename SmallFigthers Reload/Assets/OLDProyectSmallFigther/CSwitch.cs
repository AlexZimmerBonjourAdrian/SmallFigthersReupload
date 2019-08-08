using System;
using UnityEngine;

public class CSwich : MonoBehaviour
{
    private void Update()
    {
        this.Stages();
    }

    public void Switch(string name)
    {
        CGameManager.Inst.LoadSceneAsync(name);
    }

    public void Stages()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CGameManager.Inst.LoadSceneAsync("Menu");
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
