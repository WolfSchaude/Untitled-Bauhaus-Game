using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveGameLoader : MonoBehaviour
{
    public GameObject LoadingOverlay;

    [SerializeField] private bool IsSceneLoading = false;

    public bool LoadSaveGame = false;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }

    public void ChangeSceneNormal(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeSceneNew(string sceneName)
    {
        IsSceneLoading = true;
        LoadingOverlay.SetActive(true);

        StartCoroutine(LoadInBackground(sceneName));
    }

    public void ChangeSceneLoad(string sceneName)
    {
        IsSceneLoading = true;
        LoadingOverlay.SetActive(true);

        StartCoroutine(LoadInBackground(sceneName));

        LoadSaveGame = true;
    }
    private IEnumerator LoadInBackground(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);

        while (!async.isDone)
        {
            yield return null;
        }
    }
}
