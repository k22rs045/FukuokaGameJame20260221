using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager Instance { get; private set; }

    public int seniorScore = 0;
    public int juniorScore = 0;
    public int seniorHealthScore = 0;
    public int juniorHealthScore = 0;

    public List<SickData> personList = new List<SickData>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Initialize();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Initialize()
    {
        Application.targetFrameRate = 60;
    }

    public void SavePerson(PersonScript person)
    {
        if (person.healthType != HealthType.Sick) return;

        SickData data = new SickData(person);
        personList.Add(data);

        Debug.Log("•Û‘¶");
    }
}
