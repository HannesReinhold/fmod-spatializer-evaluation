using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guide : MonoBehaviour
{
    public WindowManager windowManager;
    public List<GameObject> rooms;

    public List<SpatializerSwitch> spatializerObjects;

    public List<ToggleGroup> toggleGroups;

    SubjectiveRoundManager roundManager = new SubjectiveRoundManager();



    // Start is called before the first frame update
    void Start()
    {
        windowManager.OpenPage(0);
        //OpenRoom(0);
        
        roundManager.ShuffleRounds();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCalibarionComplete()
    {
        windowManager.NextPage();
        OpenRoom(0);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("RoomScale",0);
    }


    public void OpenRoom(int index)
    {
        for(int i=0; i<rooms.Count; i++)
        {
            rooms[i].SetActive(i == index);
        }
        SetSpatializer(0);
    }

    public void CloseRoom(int index)
    {
        rooms[index].SetActive(false);
    }

    public void OnSmallRoomComplete()
    {
        OpenRoom(1);
        windowManager.NextPage();
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("RoomScale", 0.3f);
    }

    public void OnMediumRoomComplete()
    {
        OpenRoom(2);
        windowManager.NextPage();
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("RoomScale", 1);
    }

    public void OnLargeRoomComplete()
    {
        CloseRoom(2);
        windowManager.NextPage();
    }

    public void SetSpatializer(int index)
    {
        for(int i=0; i<spatializerObjects.Count; i++)
        {

            for(int j=0; j<3; j++)
            {
                spatializerObjects[i].spatializerObjects[j].SetActive(j == index);
            }

        }
    }

    public void OnToggleChange(int index)
    {
        int value = 0;
        for (int i = 0; i < toggleGroups.Count; i++)
        {
            if (toggleGroups[i].isActiveAndEnabled)
            {
                value = i;
                break;
            }
        }
        SetSpatializer(index);
    }
}

[System.Serializable]
public struct SpatializerSwitch
{
    public List<GameObject> spatializerObjects;
}