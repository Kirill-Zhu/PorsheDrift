using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MenuUIHandler : MonoBehaviour
{
    public VehicleMove vehicle;
    [SerializeField] TextMeshProUGUI DriftCount;
    public float DriftScore;
    public int currentLap;
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public static MenuUIHandler instance;


    private void Start()
    {
      
    }
    void Update()
    {
        if (DriftCount != null)
        {
            DriftCount.text = "DriftCount:" + (int)DriftScore;
            DriftScore = vehicle.driftCount;

        }



    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
        mainMenu.SetActive(false);
    
    }
    
public void GoToSettingsMenu()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

public void GoToMainMenu()
    {
        settingsMenu.SetActive(false );
        mainMenu.SetActive(true);
    }
}
