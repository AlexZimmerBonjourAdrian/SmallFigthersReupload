using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CGameManagerNew : MonoBehaviour
{
    public static CGameManagerNew _inst;
    public static CGameManagerNew Inst
    {
        get
        {
            if(CGameManagerNew._inst == null)
            {
                GameObject gameObject = new GameObject("CGameManagerNew");
                return gameObject.AddComponent<CGameManagerNew>();
            }
            return CGameManagerNew._inst;
        }
    }
    // Start is called before the first frame update
  public void Awake()
    {
        CGameManagerNew._inst = this;
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
    public void LoadSceneAsybcAdditive(string name)
    {
        SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
    }
}
