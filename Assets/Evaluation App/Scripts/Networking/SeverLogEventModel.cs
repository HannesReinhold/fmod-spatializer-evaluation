using Normal.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RealtimeModel]
public partial class ServerLogEventModel
{
    [RealtimeProperty(4, true)] private int _trigger;
    [RealtimeProperty(5, true)] private int _senderID;
    [RealtimeProperty(6, true)] private int _pageNum;
    [RealtimeProperty(7, true)] private string _eventLog;

    // Used to fire an event on all clients
    public void FireEvent(int senderID, int pageNum, string eventLog)
    {
        this.trigger++;
        this.senderID = senderID;
        this._pageNum = pageNum;
        this._eventLog = eventLog;
        Debug.Log("Page Fire: " + pageNum);
    }

    // An event that consumers of this model can subscribe to in order to respond to the event
    public delegate void EventHandler(int senderID, int pageNum, string eventLog);
    public event EventHandler eventDidFire;

    // A RealtimeCallback method that fires whenever we read any values from the server
    [RealtimeCallback(RealtimeModelEvent.OnDidRead)]
    private void DidRead()
    {
        if (eventDidFire != null && trigger != 0)
            eventDidFire(senderID, pageNum, eventLog);
    }

}
