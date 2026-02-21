using UnityEngine;
using UnityEngine.UI;

public class GymScript : MonoBehaviour
{
    [SerializeField] GameObject textPrefab;

    [SerializeField] Text timeText;
    [SerializeField] float time = 30f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            textPrefab.SetActive(true);
        }
    }
}
