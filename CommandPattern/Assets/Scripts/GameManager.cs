using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class Const
{
    public static int MAX_ROW = 10;
    public static int MAX_COL = 10;
}
public class GameManager : MonoBehaviour
{
    
    [SerializeField]
    private Unit player, npc;
    [SerializeField]
    private InputReceiver inputReceiver;
    [SerializeField]
    private GridManager gridManager;
    
    private enum Turn
    {
        Player, NPC
    }

    private Turn _gameTurn;
    private void Start()
    {
        _gameTurn = Turn.Player;
        inputReceiver = GetComponent<InputReceiver>();
        inputReceiver.allowInput = true;
        inputReceiver.DirectionAction += OnReceiveInput;
        player.Init();
        npc.Init();
        gridManager.Init();
    }

    private void OnReceiveInput(MoveDirection direction)
    {
        if(player.CheckMoveInRange((UnitDirection)direction))
        {
            player.Move((UnitDirection) direction);
            _gameTurn = Turn.NPC;
            Debug.Log("Player Position: " + player.CurrentPosition);
        }
    }
    private void AIMove()
    {
        int direction = UnityEngine.Random.Range(0, 3);
        if(npc.CheckMoveInRange((UnitDirection)direction))
        {
            npc.Move((UnitDirection) direction);
            Debug.Log("AI Position: " + npc.CurrentPosition);
            _gameTurn = Turn.Player;
        }
    }
    private void Update()
    {
        if(_gameTurn == Turn.NPC)
        {
            AIMove();
        }
    }    
}
