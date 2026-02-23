using UnityEngine;

public class MedicalRecord_SK : MonoBehaviour
{
    //[SerializeField] private MedicalRecordData_SK   medicalRecordData   = null;
    [SerializeField] private float speed = 0.0f;
    [SerializeField] private Vector3 deletePos = Vector3.zero;
    [SerializeField] private AudioClip hold = null;
    [SerializeField] private AudioClip release = null;

    public SickData sickData;
    Vector3 guide_pos = Vector3.zero;
    MouseDragScript mouseDrag = null;
    bool wasDragging = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mouseDrag = GetComponent<MouseDragScript>();
        guide_pos = transform.position;

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sickData.sickState == SickState.State2)
        {
            sprite.sprite = Resources.Load<Sprite>("Tool/karute2");
        }
        else if(sickData.sickState == SickState.State3)
        {
            sprite.sprite = Resources.Load<Sprite>("Tool/karute3");
        }
        else if (sickData.sickState == SickState.State4)
        {
            sprite.sprite = Resources.Load<Sprite>("Tool/karute4");
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlaySound();
        Move();
        Delete();

        wasDragging = mouseDrag.isDragging;
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

    void PlaySound()
    {
        // éùÇ¬
        if(!wasDragging && mouseDrag.isDragging)
        {
            AudioManager.instance.PlaySE(hold);
        }
        // ó£Ç∑
        else if(wasDragging && !mouseDrag.isDragging)
        {
            AudioManager.instance.PlaySE(release);
        }
    }
}
