using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Level;

    public float time;
    public int balls;

    public bool timeOn;

    public List<TextMeshProUGUI> timetxt;
    public List<TextMeshProUGUI> ballstxt;

    public GameObject pr;
    public List<GameObject> Blocks;
    public GameObject bls;

    public List<int> MaxLives;
    public List<GameObject> gms;
    public GameObject PanelWin;
    public GameObject PanelLose;

    public GameObject PanelPause;
    private Vector3 vball;

    public AudioSource sound;
    public AudioSource music;

    public Slider soundS;
    public Slider musicS;

    private void Awake()
    {
        Level = PlayerPrefs.GetInt("lvl");
        soundS.value = PlayerPrefs.GetFloat("sound");
        musicS.value = PlayerPrefs.GetFloat("music");

        balls = Level + 2;
        if(Level % 2 == 0)
        {
            bls = Instantiate(Blocks[1]);
        }
        else
        {
            bls = Instantiate(Blocks[0]);
        }
        gms.Add(bls);

        for (int i = 0; bls.transform.childCount > i; i++)
        {
            bls.transform.GetChild(i).gameObject.GetComponent<BlockController>().lives = Random.Range(2, MaxLives[Level - 1] + 1);
        }
        
    }


    private void Update()
    {
        foreach(TextMeshProUGUI txt in timetxt)
        {
            txt.text = "Timer : " + Mathf.Round(time) + "sec";
        }
        foreach (TextMeshProUGUI txt in ballstxt)
        {
            txt.text = "BALLS : " + balls;
        }

        music.volume = musicS.value;
        sound.volume = soundS.value;

        if (timeOn)
        {
            time -= Time.deltaTime;
        }

        if((balls == 0 || time <= 0) && timeOn)
        {
            Lose();
        }

        Debug.Log(bls.transform.childCount);
        if(bls.transform.childCount == 0 && timeOn)
        {
            Win();
        }

        if(Input.GetKeyDown(KeyCode.W)) 
        {
            GameObject a = Instantiate(pr);
        }
    }

    public void Pause()
    {
        timeOn = false;
        UnActiveGms();
        PanelPause.SetActive(true);
    }
    public void UnPause()
    {
        timeOn = true;
        ActiveGms();
        PanelPause.SetActive(false);
    }

    public void DeadBall()
    {
        if (timeOn) 
        {
            GameObject a = Instantiate(pr);
            gms[1] = a;
            sound = a.GetComponent<AudioSource>();
            balls--;
        }
    }

    public void UnActiveGms()
    {
        if (gms[1] != null)
        {
            vball = gms[1].GetComponent<Rigidbody2D>().velocity;
        }
        foreach (GameObject gm in gms)
        {
            if(gm != null)
            {
                gm.SetActive(false);
            }
        }
        
    }

    public void ActiveGms()
    {
        foreach (GameObject gm in gms)
        {
            if (gm != null)
            {
                gm.SetActive(true);
            }
        }
        gms[1].GetComponent<Rigidbody2D>().velocity = vball;
    }

    public void Win()
    {
        if(Level == PlayerPrefs.GetInt("maxlvl") && Level != 10)
        {
            PlayerPrefs.SetInt("maxlvl", Level + 1);
        }
        timeOn = false;
        UnActiveGms();
        PanelWin.SetActive(true);
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("music", musicS.value);
        PlayerPrefs.SetFloat("sound", soundS.value);
    }

    public void Lose()
    {
        timeOn = false;
        UnActiveGms();
        PanelLose.SetActive(true);
    }

    public void Retry()
    {
        Save();
        PlayerPrefs.SetInt("lvl", Level);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        Save();
        if (Level != 10)
        {
            PlayerPrefs.SetInt("lvl", Level + 1);
        }
        else
        {
            PlayerPrefs.SetInt("lvl", Level);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Save();
        SceneManager.LoadScene(0);
    }

}
