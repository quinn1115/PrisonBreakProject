using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class PlayerProfile : MonoBehaviour
{
    public TMP_Text TxtPoints;

    private int points;

    public void AddPoints(int newPoints)
    {
        points += newPoints;
        TxtPoints.text = "Points: " + points;
    }

    //Not in Use 
    public void RemovePoints(int minPoints)
    {
        points -= minPoints;
        TxtPoints.text = "Points: " + points;
    }
}
