using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HideUi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            foreach (Image i in GetComponentsInChildren<Image>())
            {
                i.enabled = !i.enabled;
            }

            foreach (TMP_Text t in GetComponentsInChildren<TMP_Text>())
            {
                t.enabled = !t.enabled;
            }
        }
    }
}
