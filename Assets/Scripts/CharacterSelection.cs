using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] GameObject character;
    SkinnedMeshRenderer catSkin;
    [SerializeField] List<Material> nekoMaterial;

    private void Start()
    {
        catSkin = character.transform.GetChild(2).GetComponent<SkinnedMeshRenderer>();
    }

    public void SelectCharacter(int characterIndex)//selección personajes
    {
        switch (characterIndex)
        {
            case 0:
                catSkin.material = nekoMaterial[0];
                break;

            case 1: 
                catSkin.material = nekoMaterial[1];  
                break;
        }

    }  
    public void ChangeScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
