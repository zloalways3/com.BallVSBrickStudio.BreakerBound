using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButt : MonoBehaviour
{
    public int id;
    public TextMeshProUGUI txt;
    public MenuManager mm;

    private void Update()
    {
        txt.text = "Level" + id;

        if(mm.LevelMax >= id)
        {
            Color c = GetComponent<Image>().color;
            GetComponent<Image>().color = new Color(c.r, c.g, c.b, 1);
        }
        else
        {
            Color c = GetComponent<Image>().color;
            GetComponent<Image>().color = new Color(c.r, c.g, c.b, 0.6f);
        }
    }

    public void Button()
    {
        mm.LevelLoad(id);
    }
}
