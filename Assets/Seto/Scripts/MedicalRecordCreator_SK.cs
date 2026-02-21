using UnityEngine;

public class MedicalRecordCreator_SK : MonoBehaviour
{
    [SerializeField] private MedicalRecord_SK   medicalRecordPrefab = null;
    [SerializeField] private Vector3            createPos           = Vector3.zero;
    [SerializeField] private int                patientNum          = 0;
    [SerializeField] private float              createIntervalTime  = 0.0f;
    
    float createTime = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CreateMedicalRecord();
    }

    void CreateMedicalRecord()
    {
        // 一定周期でカルテのプレハブを生成
        createTime += Time.deltaTime;
        if(createTime > createIntervalTime)
        {
            createTime = 0.0f;
            Instantiate(medicalRecordPrefab, createPos, Quaternion.identity);
        }
    }
}
