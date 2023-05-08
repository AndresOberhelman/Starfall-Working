using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;
    public HealthBar healthBar; 
    // Start is called before the first frame update
    void Start()
    {
       pauseMenu.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                ResumeGame();
                Debug.Log("unpause");
            }
            else{
                PauseGame();
                Debug.Log("pause");
            }
        }
    }

    public void PauseGame(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Debug.Log("Paused");
        if (healthBar != null) { 
        healthBar.gameObject.SetActive(false);
    } 
    }

    public void ResumeGame(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Debug.Log("Resumed");
        healthBar.gameObject.SetActive(true);
    }
}
