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

    [SerializeField] private float lifeTime = 5f; // 消滅までの時間
    private float lifeTimer = 0f;
    private bool canDisappear = false;

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
        // 病気進行処理
        if (healthType == HealthType.Sick)
        {
            time += Time.deltaTime;
            if (time > intervalTime)
            {
                ProgressSick();
                time = 0;
            }
        }

        // 消滅判定
        if (ShouldDisappear())
        {
            lifeTimer += Time.deltaTime;

            if (lifeTimer >= lifeTime)
            {
                Destroy(gameObject);
            }
        }
    }

    private bool ShouldDisappear()
    {
        // 健康な人は常に対象
        if (healthType == HealthType.Healthy)
            return true;

        // 病人で最終状態なら対象
        if (pattern == ProgressPattern.PatternA && currentSick == SickState.State3)
            return true;

        if (pattern == ProgressPattern.PatternB && currentSick == SickState.State4)
            return true;

        return false;
    }

    private void ProgressSick()
    {
        if (pattern == ProgressPattern.PatternA)
        {
            if (currentSick == SickState.State2)
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
            Debug.LogWarning("画像が見つかりません: " + path);
            Destroy(gameObject);
        }
    }
}
