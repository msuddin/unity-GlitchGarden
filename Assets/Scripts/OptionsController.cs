using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.5f;

    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDiffculty = 1f;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPreferenceController.GetMasterVolume();
        difficultySlider.value = PlayerPreferenceController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();

        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music playter found....did you start from splash screen");
            return;
        }
    }

    public void SaveAndExit()
    {
        PlayerPreferenceController.SetMasterVolumn(volumeSlider.value);
        PlayerPreferenceController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDiffculty;
    }
}
