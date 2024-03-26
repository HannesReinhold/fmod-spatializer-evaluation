using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    public WindowManager windowManager;
    public List<GameObject> rooms;



    // Start is called before the first frame update
    void Start()
    {
        windowManager.OpenPage(0);
        //OpenRoom(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCalibarionComplete()
    {
        windowManager.NextPage();
        OpenRoom(0);
    }

    public void OpenRoom(int index)
    {
        for(int i=0; i<rooms.Count; i++)
        {
            rooms[i].SetActive(i == index);
        }
    }

    public void CloseRoom(int index)
    {
        rooms[index].SetActive(false);
    }

    public void OnSmallRoomComplete()
    {
        OpenRoom(1);
        windowManager.NextPage();
    }

    public void OnMediumRoomComplete()
    {
        OpenRoom(2);
        windowManager.NextPage();
    }

    public void OnLargeRoomComplete()
    {
        CloseRoom(2);
        windowManager.NextPage();
    }
}
