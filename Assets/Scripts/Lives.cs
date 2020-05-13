using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    [SerializeField] float baseLives = 3;
    float lives;
    Text livesDisplay;

    void Start()
    {
        lives = baseLives - PlayerPreferenceController.GetDifficulty();
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
            FindObjectOfType<LevelController>().LoseLevel();
        }
    }
}
