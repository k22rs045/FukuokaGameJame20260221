using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditScript : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] string sceneName = "Title_Scene";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button.GetComponent<Button>().onClick.AddListener(CreditButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreditButton()
    {
        SceneManager.LoadScene(sceneName);
    }
}
