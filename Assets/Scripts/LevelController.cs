using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] int currentNumberOfAttackerAlive = 0;
    [SerializeField] bool levelTimerFinished = false;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] GameObject coreGameArea;
    [SerializeField] int delayLoadingConditionScreen = 5;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        Time.timeScale = 0f;
    }

    public void AttackerHasSpawned()
    {
        currentNumberOfAttackerAlive += 1;
    }

    public void AttackedHasBeenKilled()
    {
        currentNumberOfAttackerAlive -= 1;

        if (levelTimerFinished && (currentNumberOfAttackerAlive <= 0))
        {
            Debug.Log("End Level Now");
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(delayLoadingConditionScreen);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void TimerIsZero()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

    public void LoseLevel()
    {
        StartCoroutine(HandleLoseCondition());
    }

    IEnumerator HandleLoseCondition()
    {
        Time.timeScale = 0f;
        coreGameArea.SetActive(false);
        loseLabel.SetActive(true);
        yield return new WaitForSeconds(delayLoadingConditionScreen);
    }
}
