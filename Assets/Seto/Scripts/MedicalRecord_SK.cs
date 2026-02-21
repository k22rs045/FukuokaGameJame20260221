using UnityEngine;

public class MedicalRecord_SK : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 createPos;
    [SerializeField] private Vector3 deletePos;

    bool isHold = false;
    bool shouldDelete = false;

    public bool ShouldDelete
    {
        get
        {
            return transform.position.x < deletePos.x;
        }
        private set
        {
            shouldDelete = value;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = createPos;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (isHold) { return; }

        transform.position -= new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
    }
}
