using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    public GameObject character;
       

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject character in characters)
        {
            character.SetActive(false);
        }
    }

        public void SelectCharacter (int characterIndex)//selección personajes
    {
        for(int i = 0; i < characters.Length;i++)
        {
            if (i == characterIndex)
            {
                characters[i].SetActive(true);
            } else
            {
                characters[i].SetActive(false);
            }
        }
        SceneManager.LoadScene("MainScene");
        Debug.Log("ya entra a otra scena");

    } 
    public void ChangeScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
