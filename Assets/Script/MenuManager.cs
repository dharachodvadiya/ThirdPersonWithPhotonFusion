using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SceneChangeManager;

public class MenuManager : MonoBehaviour
{
    
    public void btn_playClick()
    {
        SceneChangeManager.Instance.LoadNextScreen(EnumScene.Play.ToString()) ;
    }
}
