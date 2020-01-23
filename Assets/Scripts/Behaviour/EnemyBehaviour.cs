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
        States.Add(new CircleProjectileState(enemy, arena, handlingRotation));
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
    private Enemy _enemy;
    Arena arena;
    public InitEnemyState(Enemy enemy, Arena arena)
    {
        this._enemy = enemy;
        this.arena = arena;
    }

    public void OnEnter()
    {
        Debug.Log("Entering state: InitEnemyState");
        _enemy.SetPathingAI(false);
        _enemy.FreezePosition(true);
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
    private Enemy _enemy;
    private Arena _arena;
    private GameObject[] _lasers;
    private HandlingRotation _handlingRotation;

    public CrossLaserPatternState(Enemy enemy, Arena arena, HandlingRotation handlingRotation)
    {
        this._enemy = enemy;
        this._arena = arena;
        this._handlingRotation = handlingRotation;
    }

    public void OnEnter()
    {
        Debug.Log("Entered state: CrossBeamPatternState");
        _enemy.FreezePosition(true);
        _enemy.SetPathingAI(false);
        _enemy.ResetEnemyPosition(true);
    }
    public void OnExecute()
    {
        Debug.Log("Executing state: CrossBeamPatternState");

        GameObject Laser1 = Object.Instantiate(_enemy.Laser);
        GameObject Laser2 = Object.Instantiate(_enemy.Laser);
        GameObject Laser3 = Object.Instantiate(_enemy.Laser);
        GameObject Laser4 = Object.Instantiate(_enemy.Laser);
        _lasers = new GameObject[] { Laser1, Laser2, Laser3, Laser4 };

        for (int i=0; i<4; i++)
        {
            _lasers[i].transform.SetParent(_enemy.center.transform);
            _lasers[i].transform.localRotation = Quaternion.Euler(0, 0, (i*90f));
        }

        _lasers[0].transform.localPosition = new Vector3(0, 0.125f);
        _lasers[1].transform.localPosition = new Vector3(-0.125f, 0);
        _lasers[2].transform.localPosition = new Vector3(0, -0.125f);
        _lasers[3].transform.localPosition = new Vector3(0.125f, 0);
        _handlingRotation.StartRotating();
    }
    public void OnExit()
    {
        Debug.Log("Exiting state: CrossBeamPatternState");
        foreach (GameObject Laser in _lasers) GameObject.Destroy(Laser);
        _handlingRotation.StopRotating();
    }
}

public class CircleProjectileState : IState
{
    private Enemy _enemy;
    private Arena _arena;
    private List<GameObject> _beams = new List<GameObject>();
    private HandlingRotation _handlingRotation;
    private bool _executing;
    private int _projectileNumber = 8;
    private float _attackDelay = 1.5f;
    private float _attackTimeLeft = 0;

    public CircleProjectileState(Enemy enemy, Arena arena, HandlingRotation handlingRotation)
    {

        this._enemy = enemy;
        this._arena = arena;
        this._handlingRotation = handlingRotation;
    }

    public void OnEnter()
    {
        Debug.Log("Entered state: CircleProjectileState");
        _enemy.FreezePosition(true);
        _enemy.SetPathingAI(false);
        _enemy.ResetEnemyPosition(true);
    }

    public void OnExecute()
    {
        Debug.Log("Executing state: CircleProjectileState");
        for (int i = 0; i < _projectileNumber; i++)
         {
                    float angle = 0-(i* 360f / _projectileNumber);
                    float theta = i * 2 * Mathf.PI / _projectileNumber;
                    float x = Mathf.Sin(theta)*0.25f;
                    float y = Mathf.Cos(theta)*0.25f;
                    GameObject CurrentBeam = Object.Instantiate(_enemy.Beam);
                    CurrentBeam.transform.SetParent(_enemy.center.transform);
                    CurrentBeam.transform.localRotation = Quaternion.Euler(0, 0, angle);
                    CurrentBeam.transform.localPosition = new Vector3(x, y, 0);
                    CurrentBeam.GetComponent<Rigidbody2D>().AddForce(CurrentBeam.transform.up * 4, ForceMode2D.Impulse);
                    _beams.Add(CurrentBeam);
         }
    
    }

    public void OnExit()
    {
        Debug.Log("Exiting state: CircleProjectileState");
        foreach (GameObject Beam in _beams) GameObject.Destroy(Beam);
        _beams.Clear();
          

    }

}