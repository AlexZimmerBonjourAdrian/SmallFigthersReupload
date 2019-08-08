using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CGameManager : MonoBehaviour
{
    public static CGameManager _inst;

    public static CGameManager Inst
    {
        get
        {
            if (CGameManager._inst == null)
            {
                GameObject gameObject = new GameObject("CGameManager");
                return gameObject.AddComponent<CGameManager>();
            }
            return CGameManager._inst;
        }
    }

    public void Awake()
    {
        CGameManager._inst = this;
    }

    public void LateUpdate()
    {
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadScene(string index)
    {
        SceneManager.LoadScene(base.name);
    }

    public void LoadSceneAsync(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }

    public void lOadSceneAsyncAdditive(string name)
    {
        SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
    }
}

