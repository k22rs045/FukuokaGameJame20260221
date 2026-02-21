using UnityEngine;

[System.Serializable]
public class SickData 
{
    public PersonGroup group;
    public SickState sickState;
    public ProgressPattern pattern;

    public SickData(PersonScript person)
    {
        group = person.group;
        sickState = person.currentSick;
        pattern = person.pattern;
    }
}
