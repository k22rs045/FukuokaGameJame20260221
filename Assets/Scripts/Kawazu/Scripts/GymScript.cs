using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GymScript : MonoBehaviour
{
    [SerializeField] GameObject textPrefab;
    [SerializeField] Slider timeSlider; 

    [SerializeField] AudioClip stage1BGM;

    public float time = 30f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.instance.PlayBGM(stage1BGM);
        textPrefab.SetActive(false);

        timeSlider.minValue = 0f;
        timeSlider.maxValue = time;
        timeSlider.value = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0f)
        {
            time -= Time.deltaTime;
            timeSlider.value = time;
        }
        else
        {
            time = 0f;
            timeSlider.value = 0f;
            Debug.Log("ŠÔØ‚ê");
            textPrefab.SetActive(true);
        }
    }
}
