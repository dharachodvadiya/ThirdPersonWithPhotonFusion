using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public enum EnumScene
    {
        Init,
        Menu,
        Play
    }
    string currentScene = null;
    public static SceneChangeManager Instance;
    protected void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void Start()
    {
        StartCoroutine(Initialise());
    }

    private IEnumerator Initialise()
    {
        //yield return CreateLoadingScreen();

        yield return LoadScene(EnumScene.Menu.ToString(), 0f, 1f);
        yield return SetActiveScene(EnumScene.Menu.ToString());

       // yield return DestroyLoadingScreen();
    }

    private static IEnumerator LoadNextScreenCoroutine(string currScreen, string NextScreen)
    {
        yield return LoadScene(NextScreen, 0.5f, 1f);
        yield return SetActiveScene(NextScreen);

    }
    private static IEnumerator ReLoadCoroutine(string currScreen)
    {
        
        yield return LoadScene(currScreen, 0.5f, 1f);
        yield return SetActiveScene(currScreen);
    }

    #region Scene Management Utils

    private static IEnumerator LoadScene(string name, float loaderMin, float loaderMax)
    {
        var asyncOp = SceneManager.LoadSceneAsync(name);
        while (!asyncOp.isDone)
        {
            yield return null;
        }
    }
    private static IEnumerator UnloadScene(string name, float loaderMin, float loaderMax)
    {
        var asyncOp = SceneManager.UnloadSceneAsync(name, UnloadSceneOptions.None);
        while (!asyncOp.isDone)
        {
            yield return null;
        }
    }
    private static IEnumerator SetActiveScene(string name)
    {
        var scene = SceneManager.GetSceneByName(name);
        Instance.currentScene = name;
        while (!scene.isLoaded)
        {
            yield return null;
        }

        SceneManager.SetActiveScene(scene);
    }

    #endregion

    #region Loading Screen Utils

    #endregion

    public void LoadNextScreen(string nextScreen)
    {
        StartCoroutine(LoadNextScreenCoroutine(Instance.currentScene, nextScreen));
    }
    public void ReloadScreen()
    {
        StartCoroutine(ReLoadCoroutine(Instance.currentScene));
    }

    protected void OnDisable()
    {
        StopAllCoroutines();
    }
    protected void OnDestroy()
    {
        StopAllCoroutines();
    }
}
