using UnityEngine;

public class HealthAreaScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            bool isDragging = collision.gameObject.GetComponent<MouseDragScript>().isDragging;

            if(!isDragging)
            {
                Debug.Log("aaa");
                Destroy(collision.gameObject);
            }
        }
    }
}
