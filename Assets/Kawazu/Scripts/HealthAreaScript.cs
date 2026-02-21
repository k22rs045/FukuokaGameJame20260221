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
        if (collision == null) return;

        MouseDragScript mouse = collision.GetComponent<MouseDragScript>();
        PersonScript person = collision.GetComponent<PersonScript>();

        if (mouse == null || person == null) return;

        if (!mouse.isDragging )
        {
            if (person.healthType == HealthType.Sick)
            {
                GManager.Instance.SavePerson(person);
            }
            Destroy(collision.gameObject);
        }

    }
}
