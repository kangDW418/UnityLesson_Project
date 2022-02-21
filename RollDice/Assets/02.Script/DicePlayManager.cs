using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePlayManager : MonoBehaviour
{
    private int currentTileIndex;
    private int diceNum;
    private int goldenDiceNum;
    private int diceNumInit;
    private int goldenDiceNumInit;

    public List<Transform> list_MapTile;

    public int RollADice()
    {
        int diceValue = Random.Range(1, 7);
        return diceValue;
    }

    private void MovePlayer(int tileIndex)
    {

    }

    private Vector3 CalcTilePosition(int tileIndex)
    {
        Vector3 pos = list_MapTile[tileIndex].position; 
        return pos;
    }
}
