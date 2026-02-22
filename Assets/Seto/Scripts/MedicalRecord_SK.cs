using UnityEngine;

public class MedicalRecord_SK : MonoBehaviour
{
    //[SerializeField] private MedicalRecordData_SK   medicalRecordData   = null;
    [SerializeField] private float speed = 0.0f;
    [SerializeField] private Vector3 deletePos = Vector3.zero;

    public SickData sickData;
    Vector3 guide_pos = Vector3.zero;
    MouseDragScript mouseDrag = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mouseDrag = GetComponent<MouseDragScript>();
        guide_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Delete();
    }

    public void DateSet(SickData data)
    {
        sickData = data;
    }
    //public void Initialize(MedicalRecordData_SK medicalRecordData)
    //{
    //    this.medicalRecordData = medicalRecordData;
    //}

    private void Move()
    {
        guide_pos -= new Vector3(speed * Time.deltaTime, 0f, 0f);

        if (!mouseDrag.isDragging)
        {
            transform.position = guide_pos;
        }
    }

    void Delete()
    {
        if (transform.position.x < deletePos.x)
        {
            Destroy(gameObject);

            MedicalRecordDeleteCounter_SK deleteCounter = GameObject.Find("MedicalRecordDeleteCounter").GetComponent<MedicalRecordDeleteCounter_SK>();
            deleteCounter.CountDelete();
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    var box = collision.gameObject.GetComponent<Box_SK>();
    //    if (box == null) { return; }

    //    // カルテに対応した対処を取った場合、スコアを増やしカルテを削除
    //    var gudger = new SymptomsSuccessGudger_SK();
    //    if (gudger.IsSucceed(box.Approach, medicalRecordData))
    //    {
    //        Debug.Log("対処成功");
    //    }
    //    else
    //    {
    //        Debug.Log("対処失敗");
    //    }

    //    Destroy(gameObject);            
    //}
}
