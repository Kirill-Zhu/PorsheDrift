using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    
    void Start()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        
        DontDestroyOnLoad(gameObject);
       
        QualitySettings.vSyncCount = 1;


    }

    // Update is called once per frame
    void Update()
    {
        QuitApplication();
      
    }


   
private void QuitApplication()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_STANDALONE
            Application.Quit();
#endif
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }

}
