using UnityEngine;

public class PersonScript : MonoBehaviour
{
    public enum Gender
    {
        boy,
        girl
    }

    public PersonGroup group;
    public HealthType healthType;

    public SickState currentSick;
    public ProgressPattern pattern;

    public Gender gender;

    public float intervalTime;
    private float time;

    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gender = (Random.value < 0.5f) ? Gender.boy : Gender.girl;

        time = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthType == HealthType.Healthy) return;

        time += Time.deltaTime;
        if (time > intervalTime)
        {
            ProgressSick();
            time = 0;
        }
    }

    private void ProgressSick()
    {
        if (pattern == ProgressPattern.PatternA)
        {
            if (currentSick == SickState.State1)
            {
                currentSick = SickState.State2;
            }  
            else if (currentSick == SickState.State2)
            {
                currentSick = SickState.State3;
            }
                
        }
        else if (pattern == ProgressPattern.PatternB)
        {
            if (currentSick == SickState.State1)
            {
                currentSick = SickState.State4;
            }
                
        }

        ChangeSprite();

    }

    private void ChangeSprite()
    {
        string groupStr = (group == PersonGroup.Junior) ? "junior" : "senior";
        string genderStr = (gender == Gender.girl) ? "Girl" : "Boy";

        int stateNum = 1;
        if (healthType == HealthType.Sick)
        {
            stateNum = (int)currentSick + 1; 
        }

        string path = $"Pesons/{groupStr}{genderStr}{stateNum}";

        Sprite sp = Resources.Load<Sprite>(path);
        if (sp != null)
        {
            spriteRenderer.sprite = sp;
        }
        else
        {
            Debug.LogWarning("‰æ‘œ‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ: " + path);
            Destroy(gameObject);
        }
    }
}
