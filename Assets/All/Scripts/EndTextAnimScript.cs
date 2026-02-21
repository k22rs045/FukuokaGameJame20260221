using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTextAnimScript : MonoBehaviour
{
    [SerializeField] string sceneName;
    public void AnimEnd()
    {
        Invoke("SceneChange", 2);
    }

    private void SceneChange()
    {
        SceneManager.LoadScene(sceneName);
    }
}
