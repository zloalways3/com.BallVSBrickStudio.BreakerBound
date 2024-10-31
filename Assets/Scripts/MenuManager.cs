using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int LevelMax;

    public List<GameObject> Panels;

    public List<Toggle> Toggles;


    public Slider music;
    public Slider sound;



    private void Start()
    {
        Load();
    }
    private void Update()
    {
        Save();

        GetComponent<AudioSource>().volume = music.value;
    }

    public void Save()
    {
        PlayerPrefs.SetInt("lvlmax", LevelMax);
        PlayerPrefs.SetFloat("music", music.value);
        PlayerPrefs.SetFloat("sound", sound.value);
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("lvlmax"))
        {
            LevelMax = PlayerPrefs.GetInt("lvlmax");
            music.value = PlayerPrefs.GetFloat("music");
            sound.value = PlayerPrefs.GetFloat("sound");
        }
    }

    public void OpenPanel(int i)
    {
       for (int j = 0; j < Panels.Count; j++) 
       {
            if(j != i)
            {
                Panels[j].SetActive(false);
            }
            else
            {
                Panels[j].SetActive(true);
            }
       }
    }

    public void LevelLoad(int level)
    {
        bool a = false;
        for (int i = 0; i < Toggles.Count; i++)
        {
            if (Toggles[i].isOn)
            {
                PlayerPrefs.SetInt("x", i);
                a = true;
            }
            else if(i + 1 ==  Toggles.Count && !a)
            {
                PlayerPrefs.SetInt("x", -1);
            }
        }
        PlayerPrefs.SetInt("lvl", level);
        SceneManager.LoadScene(1);
    }

    public void OpenLvls()
    {
        LevelMax = 10;
    }

    public void DeleteLevelProgress()
    {
        LevelMax = 1;
    }
}
