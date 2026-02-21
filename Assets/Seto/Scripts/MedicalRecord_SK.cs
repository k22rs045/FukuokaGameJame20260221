using UnityEngine;

public class MedicalRecord_SK : MonoBehaviour
{
    [SerializeField] private MedicalRecordData_SK   medicalRecordData   = null;
    [SerializeField] private float                  speed               = 0.0f;
    [SerializeField] private Vector3                deletePos           = Vector3.zero;

    Vector3 guide_pos = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        guide_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Delete();
    }

    public void Initialize(MedicalRecordData_SK medicalRecordData)
    {
        this.medicalRecordData = medicalRecordData;
    }

    private void Move()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        //transform.position = guide_pos;
    }

    void Delete()
    {
        if (transform.position.x < deletePos.x)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var box = collision.gameObject.GetComponent<Box_SK>();
        if (box == null) { return; }

        // カルテに対応した対処を取った場合、スコアを増やしカルテを削除
        var gudger = new SymptomsSuccessGudger_SK();
        if (gudger.IsSucceed(box.Approach, medicalRecordData))
        {
            Debug.Log("対処成功");
        }
        else
        {
            Debug.Log("対処失敗");
        }

        Destroy(gameObject);            
    }
}
