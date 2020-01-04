using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Enemy enemy;
    Arena arena;
    StateMachine EnemyStateMachine;
    List<IState> States;

    // Start is called before the first frame update
    void Start()
    {
        States.Add(new InitEnemyState(enemy, arena));
        States.Add(new CrossBeamPatternState(enemy, arena));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class InitEnemyState : IState
{
    Enemy enemy;
    Arena arena;
    public InitEnemyState(Enemy enemy, Arena arena)
    {
        this.enemy = enemy;
        this.arena = arena;
    }

    public void OnEnter()
    {
        enemy.Pathing.canMove = false;
        enemy.Pathing.canSearch = false;
    }
    public void OnExecute()
    {

    }
    public void OnExit()
    {

    }

}

public class CrossBeamPatternState : IState
{
    Enemy enemy;
    Arena arena;
    public CrossBeamPatternState(Enemy enemy, Arena arena)
    {
        this.enemy = enemy;
        this.arena = arena;
    }

    public void OnEnter()
    {
        enemy.Pathing.canMove = false;
        enemy.Pathing.canSearch = false;
    }
    public void OnExecute()
    {

    }
    public void OnExit()
    {

    }

}
