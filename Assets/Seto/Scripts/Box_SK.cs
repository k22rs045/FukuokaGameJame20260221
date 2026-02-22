using UnityEngine;

public class Box_SK : MonoBehaviour
{
    [SerializeField] private SickState targetState;
    [SerializeField] private float EnlargeTime = 0.2f; 
    [SerializeField] private float ReduceTime = 0.4f;
    [SerializeField] private float maxScale = 1.3f;

    bool isSelecting = false;
    float scaleTime = 0.0f;
    Vector3 initScale = Vector3.zero;

    private void Start()
    {
        initScale = transform.localScale;
    }

    private void Update()
    {
        PlaySelectAnimation();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ボックスが選択されている
        if (collision.gameObject.tag == "SelectTrigger")
        {
            isSelecting = true;
            scaleTime   = 0.0f;
            return; 
        }

        // カルテを入れる
        if (PutMedicalRecord(collision)) { return; }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // ボックスが選択されている
        if (collision.gameObject.tag == "SelectTrigger")
        {
            isSelecting = false;
            scaleTime   = 0.0f;
            return;
        }
    }

    private void AddScore(SickData data)
    {
        if (GManager.Instance == null) return;

        if (data.group == PersonGroup.Senior)
        {
            GManager.Instance.seniorHealthScore++;
        }
        else
        {
            GManager.Instance.juniorHealthScore++;
        }
    }

    bool PutMedicalRecord(Collider2D collision)
    {
        MedicalRecord_SK record = collision.gameObject.GetComponent<MedicalRecord_SK>();
        if (record == null) { return false; }

        SickData data = record.sickData;
        if (data == null) return false;

        if (targetState == data.sickState)
        {
            Debug.Log("正解:");
            AddScore(data);
        }
        else
        {
            Debug.Log("不正解：" + targetState + "-" + data.sickState.ToString());
        }

        Destroy(collision.gameObject);
        MedicalRecordDeleteCounter_SK deleteCounter = GameObject.Find("MedicalRecordDeleteCounter").GetComponent<MedicalRecordDeleteCounter_SK>();
        deleteCounter.CountDelete();

        return true;
    }

    void PlaySelectAnimation()
    {
        scaleTime += Time.deltaTime;
        if (isSelecting)
        {
            var t = Mathf.InverseLerp(0.0f, EnlargeTime, scaleTime);
            gameObject.transform.localScale = Vector3.Lerp(initScale, initScale * maxScale, t);
        }
        else
        {
            var t = Mathf.InverseLerp(0.0f, EnlargeTime, scaleTime);
            gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, initScale, t);
        }
    }
}
