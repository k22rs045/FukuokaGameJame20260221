using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    [SerializeField] GameObject titleButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        titleButton.GetComponent<Button>().onClick.AddListener(TitleButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TitleButton()
    {
        SceneManager.LoadScene("Gym_Scene");
    }
}
