using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingScript : MonoBehaviour
{
    [SerializeField] Text text;

    [System.Serializable]
    public class ParentGroup
    {
        public Transform parent;
        public int selectCount;
        public Sprite sprite1;
        public Sprite sprite2;
    }

    public ParentGroup parentA;
    public ParentGroup parentB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parentA.selectCount = GManager.Instance.seniorHealthScore;
        parentB.selectCount = GManager.Instance.juniorHealthScore;

        SelectFromParent(parentA);
        SelectFromParent(parentB);
    }

    void SelectFromParent(ParentGroup group)
    {
        List<Image> images = new List<Image>();

        foreach (Transform child in group.parent)
        {
            Image img = child.GetComponent<Image>();
            if (img != null)
                images.Add(img);
        }

        int max = images.Count;
        int count = Mathf.Min(group.selectCount, max);

        // シャッフル
        for (int i = 0; i < images.Count; i++)
        {
            int rand = Random.Range(i, images.Count);
            (images[i], images[rand]) = (images[rand], images[i]);
        }

        // 選ばれたものに2種類ランダムで割り当て
        for (int i = 0; i < count; i++)
        {
            if (Random.value < 0.5f)
                images[i].sprite = group.sprite1;
            else
                images[i].sprite = group.sprite2;
        }
    }
}
