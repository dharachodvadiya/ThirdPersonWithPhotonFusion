using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    public NetworkRunnerHandler networkRunner;

    public GameObject objLoading;

    private void Start()
    {
        objLoading.SetActive(true);
    }
    public void btn_exit()
    {
        networkRunner.exitGame();
        
    }

    public void DisableLoading()
    {
        objLoading.SetActive(false);
    }
}
