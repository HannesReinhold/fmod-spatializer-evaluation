using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubjectiveRoundManager
{

    private List<string> scenes = new List<string>() { "Office Desk", "Living Room", "Church"};
    private List<string> spatializers = new List<string>() {"Oculus", "Resonance", "Steam"};
    private List<(int, int)> availablePairs = new List<(int, int)>() {(0, 1), (1, 0), (0, 2), (2, 0),(1, 2), (2, 1) };

    private List<RoundData2> randomizedRounds = new List<RoundData2>();


    public void ShuffleRounds()
    {
        // generate all pairs
        for (int scene = 0; scene < scenes.Count; scene++)
        {
            for (int j = 0; j < 3; j++) 
            {
                int rand = Random.value >= 0.5f ? 0 : 1;
                (int, int) pair = availablePairs[rand + j * 2];

                randomizedRounds.Add(new RoundData2(scene, pair.Item1, pair.Item2));
                Debug.Log("Scene "+scene + " SpatA "+pair.Item1 + " SpatB "+pair.Item2);
            }
        }
    }

    public RoundData2 GetRound(int index)
    {
        return randomizedRounds[index];
    }


}


public struct RoundData2{

    public RoundData2(int scene, int spatA, int spatB)
    {
        this.sceneID = scene;
        this.spatializerA = spatA;
        this.spatializerB = spatB;
    }

    public int sceneID;
    public int spatializerA;
    public int spatializerB;
}