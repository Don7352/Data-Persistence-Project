using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInput;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.username != null) {
            nameInput.text = GameManager.Instance.username;
        }
    }

    public void StartNew()
    {
        GameManager.Instance.username = nameInput.text;
        SceneManager.LoadScene(1);
    }

    public void Exit() {
        GameManager.Instance.SaveGameData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
