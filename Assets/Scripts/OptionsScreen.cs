using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class OptionsScreen : MonoBehaviour
{

    public Toggle fullscreenToggle, vSyncToggle;




    // Start is called before the first frame update
    void Start()
    {
        fullscreenToggle.isOn = Screen.fullScreen;


        if(QualitySettings.vSyncCount == 0)
        {
            vSyncToggle.isOn = false;
        } else
        {
            vSyncToggle.isOn = true;
        }

    }




    // Update is called once per frame
    void Update()
    {
        
    }


    public void ApplyGraphics()
    {
        Screen.fullScreen = fullscreenToggle.isOn;

        if(vSyncToggle.isOn){
            QualitySettings.vSyncCount = 1;
        } else
        {
            QualitySettings.vSyncCount = 0;
        }

    }



}
