using UnityEngine;

public class PersonGenerateScript : MonoBehaviour
{
    [SerializeField] GameObject personPrefab;
    [SerializeField] float generateInterval = 5f;

    [SerializeField] Vector2 generateSize = new Vector2(10f, 10f);
    [SerializeField] float personSpace = 1.0f;
    
    private float time = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= generateInterval)
        {
            Generate();
            time = 0f;
        }
    }

    private void Generate()
    {
        Vector2 position = GetRandomPosition();
        Collider2D hit = Physics2D.OverlapCircle(position, personSpace);

        if (hit == null)
        {
            GameObject obj = Instantiate(personPrefab, position, Quaternion.identity);
            PersonScript person = obj.GetComponent<PersonScript>();

            person.group = (Random.value < 0.5f) ? PersonGroup.Senior : PersonGroup.Junior;

            person.healthType = (Random.value < 0.5f) ? HealthType.Healthy : HealthType.Sick;

            if (person.healthType == HealthType.Sick)
            {
                person.currentSick = SickState.State2;

                person.pattern = (Random.value < 0.5f) ? ProgressPattern.PatternA : ProgressPattern.PatternB;
            }
        }

        
    }

    private Vector2 GetRandomPosition()
    {
        float rx = Random.Range(-generateSize.x / 2f, generateSize.x / 2f);
        float ry = Random.Range(-generateSize.y / 2f, generateSize.y / 2f);

        return (Vector2)transform.position + new Vector2(rx, ry);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(generateSize.x, generateSize.y, 0.1f));
    }
}
