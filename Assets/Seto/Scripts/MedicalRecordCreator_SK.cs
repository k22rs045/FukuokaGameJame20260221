using UnityEngine;

public class MedicalRecordCreator_SK : MonoBehaviour
{
    [SerializeField] private MedicalRecord_SK medicalRecordPrefab = null;
    [SerializeField] private int patientNum = 0;
    [SerializeField] private float createIntervalTime = 0.0f;
    [SerializeField] private float createTime = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateMedicalReord()
    {
        createTime += Time.deltaTime;
        if(createTime > createIntervalTime)
        {
            createTime = 0.0f;
        }
    }
}
