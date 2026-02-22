using UnityEngine;
using UnityEngine.SceneManagement;

public class MedicalRecordDeleteCounter_SK : MonoBehaviour
{
    int deleteNum = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (deleteNum >= GManager.Instance.personList.Count)
        {
            SceneManager.LoadScene("Ending_Scene");
            return;
        }
    }

    public void CountDelete()
    {
        deleteNum++;
    }
}
