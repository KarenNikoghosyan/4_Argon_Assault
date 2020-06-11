using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstScene", 2f);
    }

    private void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
      
    }
    
}
