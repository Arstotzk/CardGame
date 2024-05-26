using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public List<AudioClip> SoundBattle;
    public List<AudioClip> SoundSlavic;
    public List<AudioClip> SoundReptilian;
    public AudioClip SoundShutUp;
    public bool isShutUpPlayed;
    public AudioSource audioSfx;
    public AudioSource audioSlavic;
    public AudioSource audioReptilian;
    public AudioMixer audioMixer;
    public GameObject settings;
    public GameObject saves;

    public Scrollbar master;
    public Scrollbar music;
    public Scrollbar sfx;
    public Scrollbar slavic;
    public Scrollbar reptilian;
    public TMP_Dropdown resolutionSetting;
    public Toggle fullScreenSetting;

    public float masterValue;
    public float musicValue;
    public float sfxValue;
    public float slavicValue;
    public float reptilianValue;

    private string currentSave = "CurrentScene.dat";
    public SaveSerializer saveSerializer;
    public List<LoadTestData> loadTestDatas;
    private bool isValueFromSetting;
    // Start is called before the first frame update
    void Start()
    {
        isShutUpPlayed = false;
        masterValue = PlayerPrefs.GetFloat("Master");
        musicValue = PlayerPrefs.GetFloat("Music");
        sfxValue = PlayerPrefs.GetFloat("Sfx");
        slavicValue = PlayerPrefs.GetFloat("Slavic");
        reptilianValue = PlayerPrefs.GetFloat("Reptilian");
        
        //Первый запуск игры нет данных в PlayerPrefs
        if (masterValue == 0 && musicValue == 0 && sfxValue == 0 && slavicValue == 0 && reptilianValue == 0)
            masterValue = musicValue = sfxValue = slavicValue = reptilianValue = 1;

        master.value = masterValue;
        music.value = musicValue;
        sfx.value = sfxValue;
        slavic.value = slavicValue;
        reptilian.value = reptilianValue;

        audioSfx.volume = 0;
        audioSlavic.volume = 0;
        audioReptilian.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ShowSaves()
    {
        saves.SetActive(true);
        saves.GetComponentInChildren<SaveFilesUI>().RedrawSaveFilesUI(saveSerializer.GetSaveFiles());

        if (settings.activeSelf == true)
            CancelSettings();
    }
    public void CloseSaves()
    {
        saves.SetActive(false);
    }
    public void Setting() 
    {
        masterValue = PlayerPrefs.GetFloat("Master");
        musicValue = PlayerPrefs.GetFloat("Music");
        sfxValue = PlayerPrefs.GetFloat("Sfx");
        slavicValue = PlayerPrefs.GetFloat("Slavic");
        reptilianValue = PlayerPrefs.GetFloat("Reptilian");

        settings.SetActive(true);
        audioSfx.volume = 1;
        audioSlavic.volume = 1;
        audioReptilian.volume = 1;

        SetSettingResolution();

        if (saves.activeSelf == true)
            CloseSaves();
    }
    public void Continue()
    {
        //SceneManager.LoadScene("SampleScene");
    }

    public void StartBattleScene(string sceneName)
    {
        CreateSaveToLoad(sceneName, SceneType.battle);
        PlayerPrefs.SetString("SaveFile", currentSave);
        SceneManager.LoadScene("BattleScene");
    }
    private void CreateSaveToLoad(string sceneName, SceneType sceneType)
    {
        saveSerializer.Save("CurrentScene.dat", sceneName, sceneType, loadTestDatas.Where(ltd => ltd.sceneName.Equals(sceneName)).FirstOrDefault().cards, new List<int>());
    }

    public void NewGame() 
    {
        saveSerializer.Save("Проснись.dat", "NewGameStart", SceneType.novel, new List<string>(), new List<int>());
        saveSerializer.CreateCurrentSave("Проснись.dat");
        SceneManager.LoadScene("VisualNovelScene");
    }
    public void MasterValueChanged(float value)
    {
        if (value == 0)
            value = 0.0001f;
        audioMixer.SetFloat("Master", Mathf.Log10(value) * 20);
    }
    public void MusicValueChanged(float value) 
    {
        if (value == 0)
            value = 0.0001f;
        audioMixer.SetFloat("Music", Mathf.Log10(value) * 20);
    }
    public void SfxValueChanged(float value)
    {
        if (value == 0)
            value = 0.0001f;
        audioMixer.SetFloat("Sfx", Mathf.Log10(value) * 20);
        if (!audioSfx.isPlaying)
        {
            var clip = SoundBattle[Random.Range(0, SoundBattle.Count)];
            audioSfx.clip = clip;
            audioSfx.Play();
        }
    }
    public void SlavicValueChanged(float value)
    {
        if (value == 0)
            value = 0.0001f;
        audioMixer.SetFloat("Slavic", Mathf.Log10(value) * 20);
        if (!audioSlavic.isPlaying)
        {
            var clip = SoundSlavic[Random.Range(0, SoundSlavic.Count)];
            audioSlavic.clip = clip;
            audioSlavic.Play();
        }
    }
    public void ReptilianValueChanged(float value)
    {
        if (value == 0)
        {
            value = 0.0001f;
            audioMixer.SetFloat("Reptilian", Mathf.Log10(value) * 20);
            audioSlavic.clip = SoundShutUp;
            audioSlavic.Play();
        }
        else
        {
            audioMixer.SetFloat("Reptilian", Mathf.Log10(value) * 20);
            if (!audioReptilian.isPlaying)
            {
                var clip = SoundReptilian[Random.Range(0, SoundReptilian.Count)];
                audioReptilian.clip = clip;
                audioReptilian.Play();
            }
        }
    }

    public void SaveSettings() 
    {
        PlayerPrefs.SetFloat("Master", master.value);
        PlayerPrefs.SetFloat("Music", music.value);
        PlayerPrefs.SetFloat("Sfx", sfx.value);
        PlayerPrefs.SetFloat("Slavic", slavic.value);
        PlayerPrefs.SetFloat("Reptilian", reptilian.value);
        PlayerPrefs.Save();
        settings.SetActive(false);

        audioSfx.volume = 0;
        audioSlavic.volume = 0;
        audioReptilian.volume = 0;

        SetScreenResolution();
    }

    public void CancelSettings() 
    {
        MasterValueChanged(masterValue);
        MusicValueChanged(musicValue);

        var value = sfxValue;
        if (sfxValue == 0)
            value = 0.0001f;
        audioMixer.SetFloat("Sfx", Mathf.Log10(value) * 20);

        value = slavicValue;
        if (slavicValue == 0)
            value = 0.0001f;
        audioMixer.SetFloat("Slavic", Mathf.Log10(value) * 20);

        value = reptilianValue;
        if (reptilianValue == 0)
            value = 0.0001f;
        audioMixer.SetFloat("Reptilian", Mathf.Log10(value) * 20);
        settings.SetActive(false);

        audioSfx.volume = 0;
        audioSlavic.volume = 0;
        audioReptilian.volume = 0;
    }

    public void SetScreenResolution()
    {
        var resolution = Screen.resolutions[resolutionSetting.value];
        var screenMode = FullScreenMode.Windowed;
        if (fullScreenSetting.isOn)
            screenMode = FullScreenMode.FullScreenWindow;
        Screen.SetResolution(resolution.width, resolution.height, screenMode, resolution.refreshRate);
    }
    public void SetSettingResolution()
    {
        resolutionSetting.options.Clear();

        foreach (var res in Screen.resolutions)
        {
            TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData();
            optionData.text = res.ToString();
            resolutionSetting.options.Add(optionData);
        }

        resolutionSetting.value = Screen.resolutions.ToList().IndexOf(Screen.currentResolution);
        isValueFromSetting = true;
    }
}
