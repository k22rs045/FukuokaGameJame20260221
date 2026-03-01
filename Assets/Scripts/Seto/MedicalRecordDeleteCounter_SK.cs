using UnityEngine;
using UnityEngine.SceneManagement;

public class MedicalRecordDeleteCounter_SK : MonoBehaviour
{
    int deleteNum = 0;
    [SerializeField] private float waitTimeChangeScene = 1.0f;

    float waitTime = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (deleteNum >= GManager.Instance.personList.Count)
        {
            waitTime += Time.deltaTime;
            if(waitTime < waitTimeChangeScene) { return; }

            SceneManager.LoadScene("Ending_Scene");
        }
    }

    public void CountDelete()
    {
        deleteNum++;
    }
}
