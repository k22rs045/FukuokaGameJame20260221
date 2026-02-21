using UnityEngine;

public class SymptomsSuccessGudger_SK : MonoBehaviour
{
    /// <summary>
    /// カルテに対応した対処法を取ることが成功したかを判定する
    /// </summary>
    /// <returns>true : 成功, false : 失敗</returns>
    public bool IsSucceed(string approach, MedicalRecordData_SK medicalRecordData)
    {
        // 仮で成功したかを判定
        // TODO : のちに変更
        if( approach == "0" && medicalRecordData.symptoms == "0" ||
            approach == "1" && medicalRecordData.symptoms == "1" ||
            approach == "2" && medicalRecordData.symptoms == "2")
        {
            return true;
        }

        return false;
    }
}
