using UnityEngine;
using UnityEngine.Audio;

public class HealthAreaScript : MonoBehaviour
{
    [SerializeField] private AudioClip correctSE;
    [SerializeField] private AudioClip badSE;
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
                AudioManager.instance.PlaySE(correctSE);
            }
            else
            {
                AudioManager.instance.PlaySE(badSE);
            }
            Destroy(collision.gameObject);
        }

    }
}
