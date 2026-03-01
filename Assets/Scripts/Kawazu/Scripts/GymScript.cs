using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GymScript : MonoBehaviour
{
    [SerializeField] GameObject textPrefab;
    [SerializeField] Slider timeSlider; 

    [SerializeField] AudioClip stage1BGM;

    public float time = 30f;
    private bool isFinished = false;
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
        if (isFinished) return;

        if (time > 0f)
        {
            time -= Time.deltaTime;
            timeSlider.value = time;
        }
        else
        {
            time = 0f;
            timeSlider.value = 0f;

            isFinished = true;
            if (GManager.Instance.personList != null && GManager.Instance.personList.Count > 1)
            {
                ShuffleList(GManager.Instance.personList);
            }

            textPrefab.SetActive(true);
        }
    }

    private void ShuffleList(List<SickData> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            SickData temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
