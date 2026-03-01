using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MedicalRecordCreator_SK : MonoBehaviour
{
    [SerializeField] private GameObject medicalRecorePrefab = null;
    [SerializeField] private Text medicalText;
    [SerializeField] private float createInterval = 3.0f;
    [SerializeField] private AudioClip bgm = null;

    private float time = 0f;
    private int listIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.instance.PlayBGM(bgm);

        medicalText.text = "残り：" +
            (GManager.Instance.personList.Count - listIndex).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (GManager.Instance == null) return;

        time += Time.deltaTime;
        if (time >= createInterval)
        {
            Generate();
            time = 0f;
        }
    }

    private void Generate()
    {
        if(listIndex >= GManager.Instance.personList.Count) { return; }

        SickData data = GManager.Instance.personList[listIndex];
        GameObject obj = Instantiate(medicalRecorePrefab, transform.position, Quaternion.identity);
        if(obj == null) { return; }

        MedicalRecord_SK recordScript = obj.GetComponent<MedicalRecord_SK>();

        if (recordScript != null)
        {
            recordScript.DateSet(data);
        }
        listIndex++;

        medicalText.text = "残り：" + (GManager.Instance.personList.Count - listIndex).ToString();
    }

}
