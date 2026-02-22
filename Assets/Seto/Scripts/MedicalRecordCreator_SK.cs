using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MedicalRecordCreator_SK : MonoBehaviour
{
    //[SerializeField] private MedicalRecord_SK   medicalRecordPrefab = null;
    //[SerializeField] private Vector3            createPos           = Vector3.zero;
    ////[SerializeField] private int                patientNum          = 0;
    //[SerializeField] private float              createIntervalTime  = 0.0f;

    //float createTime = 0.0f;

    [SerializeField] private GameObject medicalRecorePrefab = null;
    [SerializeField] private float createInterval = 3.0f;

    private float time = 0f;
    private int listIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //CreateMedicalRecord();
        if (GManager.Instance == null) return;

        //if (listIndex >= GManager.Instance.personList.Count)
        //{
        //    SceneManager.LoadScene("Ending_Scene");
        //    return;
        //}

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
    }

    //void CreateMedicalRecord()
    //{
    //    // 一定周期でカルテのプレハブを生成
    //    createTime += Time.deltaTime;
    //    if(createTime > createIntervalTime)
    //    {
    //        createTime = 0.0f;
    //        var instance = Instantiate(medicalRecordPrefab, createPos, Quaternion.identity);

    //        // 仮で生成するカルテを設定
    //        // TODO : のちに変更
    //        var rand = Random.Range(0, 3);
    //        var medicalRecordData = new MedicalRecordData_SK("", "", rand.ToString());
    //        instance.Initialize(medicalRecordData);
    //    }
    //}
}
