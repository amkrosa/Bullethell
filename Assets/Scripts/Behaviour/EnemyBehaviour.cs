using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Arena")]
    public GameObject ArenaGameObject;
    Enemy enemy;
    Arena arena;
    HandlingRotation handlingRotation;
    StateMachine EnemyStateMachine=new StateMachine();
    List<IState> States=new List<IState>();

    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.GetComponent<Enemy>();
        arena = ArenaGameObject.GetComponent<Arena>();
        handlingRotation = enemy.center.GetComponent<HandlingRotation>();
        States.Add(new ChasePatternState(enemy));
        States.Add(new CrossLaserPatternState(enemy, arena, handlingRotation));
        EnemyStateMachine.ChangeState(new InitEnemyState(enemy, arena));
        EnemyStateMachine.Update();
        StartCoroutine(ChangePhases());
    }

    IEnumerator ChangePhases()
    {
        Debug.Log("Entered ChangePhases()");
        while(true)
        {
            foreach (IState state in States)
            {
                EnemyStateMachine.ChangeState(state);
                yield return new WaitForSecondsRealtime(1.33f);
                EnemyStateMachine.Update();
                yield return new WaitForSecondsRealtime(5f);
            }
        }
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
        Debug.Log("Entering state: InitEnemyState");
        enemy.SetPathingAI(false);
        enemy.FreezePosition(true);
    }
    public void OnExecute()
    {
        Debug.Log("Executing state: InitEnemyState");

    }
    public void OnExit()
    {
        Debug.Log("Exiting state: InitEnemyState");

    }

}

public class ChasePatternState : IState
{
    Enemy enemy;

    public ChasePatternState(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void OnEnter()
    {
        Debug.Log("Entering state: ChasePatternState");
        enemy.SetPathingAI(true);
        enemy.FreezePosition(false);
    }
    public void OnExecute()
    {
        Debug.Log("Executing state: ChasePatternState");

    }
    public void OnExit()
    {
        Debug.Log("Exiting state: ChasePatternState");

    }

}

public class CrossLaserPatternState : IState
{
    Enemy enemy;
    Arena arena;
    GameObject[] Lasers;
    HandlingRotation handlingRotation;

    public CrossLaserPatternState(Enemy enemy, Arena arena, HandlingRotation handlingRotation)
    {
        this.enemy = enemy;
        this.arena = arena;
        this.handlingRotation = handlingRotation;
    }

    public void OnEnter()
    {
        Debug.Log("Entered state: CrossBeamPatternState");
        enemy.FreezePosition(true);
        enemy.SetPathingAI(false);
        enemy.ResetEnemyPosition(true);
    }
    public void OnExecute()
    {
        Debug.Log("Executing state: CrossBeamPatternState");

        GameObject Laser1 = Object.Instantiate(enemy.Laser);
        GameObject Laser2 = Object.Instantiate(enemy.Laser);
        GameObject Laser3 = Object.Instantiate(enemy.Laser);
        GameObject Laser4 = Object.Instantiate(enemy.Laser);
        Lasers = new GameObject[] { Laser1, Laser2, Laser3, Laser4 };

        for (int i=0; i<4; i++)
        {
            Lasers[i].transform.SetParent(enemy.center.transform);
            Lasers[i].transform.localRotation = Quaternion.Euler(0, 0, (i*90f));
        }

        Lasers[0].transform.localPosition = new Vector3(0, 0.125f);
        Lasers[1].transform.localPosition = new Vector3(-0.125f, 0);
        Lasers[2].transform.localPosition = new Vector3(0, -0.125f);
        Lasers[3].transform.localPosition = new Vector3(0.125f, 0);
        handlingRotation.StartRotating();
    }
    public void OnExit()
    {
        Debug.Log("Exiting state: CrossBeamPatternState");
        foreach (GameObject Laser in Lasers) GameObject.Destroy(Laser);
        handlingRotation.StopRotating();
    }
}
