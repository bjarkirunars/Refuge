using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    
    public void changePanel()
    {
        Debug.Log("Changing");
        panel1.SetActive(false);
        panel2.SetActive(true);
        Debug.Log("Changed");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
