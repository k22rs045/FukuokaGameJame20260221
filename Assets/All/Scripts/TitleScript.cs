using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class TitleScript : MonoBehaviour
{
    [SerializeField] GameObject titleButton;
    [SerializeField] AudioClip titleBGM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        titleButton.GetComponent<Button>().onClick.AddListener(TitleButton);
        AudioManager.instance.PlayBGM(titleBGM);
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
