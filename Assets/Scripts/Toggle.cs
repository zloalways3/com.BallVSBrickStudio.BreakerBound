using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController: MonoBehaviour
{
    public Toggle tgl;

    public GameObject gm;

    private void Update()
    {
        if (tgl.isOn)
        {
            gm.transform.localPosition = new Vector3(46, 0, 0);
        }
        else
        {
            gm.transform.localPosition = new Vector3(-46, 0 , 0);
        }
    }
}
