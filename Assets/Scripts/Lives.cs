using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    [SerializeField] int lives = 5;
    Text livesDisplay;

    void Start()
    {
        livesDisplay = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        livesDisplay.text = lives.ToString();
    }

    public void TakeLive()
    {
        lives -= 1;
        UpdateDisplay();

        if (lives <= 0)
        {
            FindObjectOfType<LevelLoader>().LoadLoseScreen();
        }
    }
}
