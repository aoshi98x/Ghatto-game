using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    CharacterSelection selectionScript;
    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        selectionScript = GetComponent<CharacterSelection>();

    }
    void Update()
    {
     
        if(SceneManager.GetActiveScene().name == "MainScene")
        {
            selectionScript.enabled = false;
        }
    }

   
}
