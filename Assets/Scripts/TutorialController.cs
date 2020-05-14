using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public void StartGameplay()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
