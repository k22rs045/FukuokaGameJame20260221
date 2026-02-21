using UnityEngine;

public class Box_SK : MonoBehaviour
{
    [SerializeField] private SickState targetState;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("aaaaa");
        MedicalRecord_SK record = collision.gameObject.GetComponent<MedicalRecord_SK>();
        if (record == null) return;

        SickData data = record.sickData;
        if (data == null) return;

        if (targetState == data.sickState)
        {
            Debug.Log("ê≥â:");
            AddScore(data);
        }
        else
        {
            Debug.Log("ïsê≥âÅF" + targetState + "-" + data.sickState.ToString());
        }
        Destroy(collision.gameObject);
    }

    private void AddScore(SickData data)
    {
        if (GManager.Instance == null) return;

        if (data.group == PersonGroup.Senior)
        {
            GManager.Instance.seniorHealthScore++;
        }
        else
        {
            GManager.Instance.juniorHealthScore++;
        }
    }

}
