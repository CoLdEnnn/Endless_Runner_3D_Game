using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadToStage : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadStage", 3f);
    }

    void LoadStage()
    {
        SceneManager.LoadScene(StageControls.selectedStage);
    }
}