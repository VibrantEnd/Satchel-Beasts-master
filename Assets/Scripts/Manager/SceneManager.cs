using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CharSelectScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CharacterPicker");
    }
    public void Ready()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("BattleScene");
    }
}
