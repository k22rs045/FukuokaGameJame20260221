using System;
using UnityEngine;
[Serializable]

public class MedicalRecordData_SK
{
    public string gender;
    public string grade;
    public string symptoms;

    public MedicalRecordData_SK(string gender, string grade, string symptoms)
    {
        this.gender     = gender;
        this.grade      = grade;
        this.symptoms   = symptoms;
    }
}
