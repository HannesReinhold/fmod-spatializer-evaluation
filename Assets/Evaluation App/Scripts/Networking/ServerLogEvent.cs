using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerLogEvent : RealtimeComponent<ServerLogEventModel>
{
    [SerializeField]
    public ServerGUI _serverGUI = default;
    public List<WindowManager> windowManagers;
    private int currentWindowManager = 0;

    // When we connect to a room server, we'll be given an instance of our model to work with.
    protected override void OnRealtimeModelReplaced(ServerLogEventModel previousModel, ServerLogEventModel currentModel)
    {
        if (previousModel != null)
        {
            // Unsubscribe from events on the old model.
            previousModel.eventDidFire -= EventDidFire;
        }
        if (currentModel != null)
        {
            // Subscribe to events on the new model
            currentModel.eventDidFire += EventDidFire;
        }
    }

    // A public method we can use to fire the event
    public void LogAll(int currentWindowManager, string additionalEvent)
    {
        this.currentWindowManager = currentWindowManager;
        int pageNum = windowManagers[currentWindowManager].currentWindowIndex;
        model.FireEvent(realtime.clientID, pageNum, additionalEvent);
    }

    public void LogEvent(string additionalEvent)
    {
        int pageNum = windowManagers[currentWindowManager].currentWindowIndex;
        model.FireEvent(realtime.clientID, pageNum, additionalEvent);
    }

    // Called whenever our event fires
    private void EventDidFire(int senderID, int pageNum, string eventLog)
    {
        // Tell the particle system to trigger an explosion in response to the event
        Debug.Log("didFIre: "+pageNum);
        _serverGUI.UpdateLog(pageNum, eventLog);
    }

    public void SetWindowManager(int index)
    {
        currentWindowManager = index;
    }

    public void Reset()
    {
        currentWindowManager = 0;
    }
}
