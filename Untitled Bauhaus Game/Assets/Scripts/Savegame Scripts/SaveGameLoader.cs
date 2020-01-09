using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveGameLoader : MonoBehaviour
{
    public GameObject Open1;
    public GameObject Open2;

    [SerializeField]
    private bool IsSceneLoading = false;

    public bool LoadSaveGame = false;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }

    public void ChangeSceneNew(string sceneName)
    {
        IsSceneLoading = true;

        StartCoroutine(LoadInBackground(sceneName));

        Open1.GetComponentInChildren<Text>().text = "Loading....";
        Open1.GetComponent<Button>().interactable = false;
        Open2.GetComponent<Button>().interactable = false;
    }

    public void ChangeSceneLoad(string sceneName)
    {
        IsSceneLoading = true;

        StartCoroutine(LoadInBackground(sceneName));

        Open2.GetComponentInChildren<Text>().text = "Loading....";
        Open1.GetComponent<Button>().interactable = false;
        Open2.GetComponent<Button>().interactable = false;

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
