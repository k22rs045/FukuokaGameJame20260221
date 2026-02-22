using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class TitleScript : MonoBehaviour
{
    [SerializeField] GameObject titleButton;
    [SerializeField] GameObject creditButton;
    [SerializeField] AudioClip titleBGM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GManager.Instance.juniorHealthScore = 0;
        GManager.Instance.seniorHealthScore = 0;
        GManager.Instance.personList.Clear();
        titleButton.GetComponent<Button>().onClick.AddListener(TitleButton);
        creditButton.GetComponent<Button>().onClick.AddListener(CreditButton);
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
    private void CreditButton()
    {
        SceneManager.LoadScene("Credit_Scene");
    }
}
