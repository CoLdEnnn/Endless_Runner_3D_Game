using TMPro;
using UnityEditorInternal;
using UnityEngine;

public class MasterInfo : MonoBehaviour
{
    public static int coinCount = 0;
    [SerializeField] GameObject coinDisplay;
    void Update()
    {
        coinDisplay.GetComponent<TMP_Text>().text = "COINS: " + coinCount;
    }
}
