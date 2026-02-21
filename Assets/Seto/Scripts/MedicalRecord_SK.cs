using UnityEngine;

public class MedicalRecord_SK : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 deletePos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Delete();
    }

    private void Move()
    {
        transform.position -= new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
    }

    void Delete()
    {
        if (transform.position.x < deletePos.x)
        {
            Destroy(gameObject);
        }
    }
}
