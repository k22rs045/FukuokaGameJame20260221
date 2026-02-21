using UnityEngine;

public class PersonScript : MonoBehaviour
{
    public PersonGroup group;
    public HealthType healthType;

    public SickState currentSick;
    public ProgressPattern pattern;

    public float intervalTime;
    private float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 0;
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

        Debug.Log(name + " ÇÃåªç›èÛë‘: " + currentSick);
    }
}
