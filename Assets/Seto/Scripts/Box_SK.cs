using UnityEngine;

public class Box_SK : MonoBehaviour
{
    [SerializeField] private string approach = "";

    public string Approach
    {
        get
        {
            return approach;
        }
        private set
        {
            approach = value;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
