using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyManager : MonoBehaviour
{
    public static int enemiesDestroyed = 0;
    public TextMeshProUGUI enemiesDestroyedText;
    public GameObject wall;
    public int requiredKills = 19;

    void Update()
    {
        enemiesDestroyedText.text = "Enemies Destroyed: " + enemiesDestroyed;

        // Check if the required number of kills has been reached
        if (enemiesDestroyed >= requiredKills)
        {
            Debug.Log("Final Door Opened"); // Disable the wall GameObject
            wall.SetActive(false);
        }
    }
}

