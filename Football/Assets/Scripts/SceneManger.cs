using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManger : MonoBehaviour
{
    public Button level2Button;
    public Button level3Button;

    private static bool hasExecuted = false;

    private void Start()
    {
        if (!hasExecuted)
        {
            PlayerPrefs.SetInt("Level1", 0);
            PlayerPrefs.SetInt("Level2", 0);
            PlayerPrefs.Save();

            // Set the hasExecuted flag to true
            hasExecuted = true;
        }

        if (PlayerPrefs.GetInt("Level1", 0) == 1)
        {
            level2Button.interactable = true;
        }
        if (PlayerPrefs.GetInt("Level2", 0) == 1)
        {
            level3Button.interactable = true;
        }
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
