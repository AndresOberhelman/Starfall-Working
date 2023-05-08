using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyManager : MonoBehaviour
{
    public static int enemiesDestroyed = 0;
    public TextMeshProUGUI enemiesDestroyedText;

    void Update()
    {
    enemiesDestroyedText.text = "Enemies Destroyed: " + enemiesDestroyed;
    }
}
