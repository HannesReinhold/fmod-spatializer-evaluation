using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ServerGUI : MonoBehaviour
{
    public TextMeshProUGUI pageNumText;
    public TextMeshProUGUI eventLogText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLog(int pageNum, string eventLog)
    {

        pageNumText.text = pageNum.ToString();
        if(eventLog!="") eventLogText.text = eventLog;
        Debug.Log("Update Log");
    }
}
