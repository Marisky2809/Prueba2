using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu);
    }
}