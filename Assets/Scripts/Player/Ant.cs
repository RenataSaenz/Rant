using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour, IDamageable, IObservable
{

    public bool isDead;

    public float _speed;
    private float _swipeSpeed = 1;
    [SerializeField]
    private float _jumpForce;
    public float life = 100;
    public float maxLife = 100;
    [SerializeField]
    private float minLife;

    public ManagerUI managerUI;

    Control _control;
    Movement _movement;

    private Rigidbody _rb;

    private Vector2 _startPosition;
    Vector2 _endPosition;
    Vector2 _direction;
    int _swipePositionCount = 0;

    float swipePowerUp;

    private Vector3 posLeft;
    private Vector3 posCenter;
    private Vector3 posRight;
    

    List<IObserver> _allObservers = new List<IObserver>();

    void Awake()
    {
        EventManager.Subscribe("GameOver", Dead);
        EventManager.Subscribe("FasterPowerUp", PowerUpMovement);

        _rb = GetComponent<Rigidbody>();
        _movement = new Movement(transform, _swipeSpeed, _jumpForce, _rb);
        _control = new Control(this, _movement);
    }

    private void Start()
    {
        
        
        SwipeManager2.instance.OnStartTouch += StartTouch;
        SwipeManager2.instance.OnEndTouch += EndTouch;

        _speed = 0;
        EventManager.Subscribe("FastPowerUp", SpeedPowerUp);
        EventManager.Subscribe("EndPowerUp", SpeedPowerUp);
        StartLifeFunc(life);

        swipePowerUp = -4.7f;
        
        transform.position = new Vector3(0, 0.063f, gameObject.transform.position.z);
        posLeft = new Vector3(-1, gameObject.transform.position.y, gameObject.transform.position.z);
        posCenter = new Vector3(0, gameObject.transform.position.y, gameObject.transform.position.z);
        posRight = new Vector3(0, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    void FixedUpdate()
    {
        ForwardMovemnt(_speed);

        _control.OnUpdate();
    
#if UNITY_ANDROID && !UNITY_EDITOR
        CalculateSwipePosition();
#endif
    }

    void StartTouch(Vector2 position)
    {
        _startPosition = position;
    }
    void EndTouch(Vector2 position)
    {
        _endPosition = position;
    }

    void CalculateSwipePosition()
    {
        /*Vector3 pos = new Vector3();
        pos.x = gameObject.transform.position.x;
        pos.z = gameObject.transform.position.z;*/
        
        float step = _swipeSpeed * Time.deltaTime;
        float dist = _endPosition.x - _startPosition.x;

        Vector3 distLeft = posLeft - transform.position;
        Vector3 distCenter = posCenter - transform.position;
        Vector3 distRight = posRight - transform.position;

        if (_startPosition.x <= _endPosition.x) //swipe derecha
        { 
            _swipePositionCount +=1;
            if (_swipePositionCount >= 1)
                _swipePositionCount = 1; 
            
            // transform.position += new Vector3(1 * step, 0.063f, gameObject.transform.position.z);
            if (transform.position.x <= posRight.x)
                transform.position += transform.right * step;
            

            if (Vector3.Distance(posCenter, transform.position) < 0.001f || Vector3.Distance(posRight, transform.position) < 0.001f)
            {
                _swipeSpeed = 0;
                return;
            }
        }
        if (_startPosition.x >= _endPosition.x) //swipe izq
        {  
            _swipePositionCount -=1;
            
            if (_swipePositionCount <= -1)
                _swipePositionCount = -1;
            
            if (transform.position.x >= posLeft.x)
                transform.position += -transform.right * step;
            
            // transform.position += new Vector3(-1 * step, 0.063f, gameObject.transform.position.z);
            
           if (Vector3.Distance(  posCenter, transform.position) < 0.001f || Vector3.Distance(posLeft, transform.position) < 0.001f)
            {
                _swipeSpeed = 0;
                return;
            } 
        }
        _swipeSpeed = 1;
        /*
        if (_swipePositionCount == 0)
        {   
           transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0.063f, pos.z), _swipeSpeed * Time.deltaTime);
        }
        if (_swipePositionCount == 1)
        {
           transform.position = Vector3.MoveTowards(transform.position, new Vector3(1, 0.063f, pos.z), _swipeSpeed * Time.deltaTime);
        }
        if (_swipePositionCount == -1)
        {
           transform.position = Vector3.MoveTowards(transform.position, new Vector3(-1, 0.063f, pos.z), _swipeSpeed * Time.deltaTime);
        }*/
    }
    public void SpeedPowerUp(params object[] n1)
    {
        swipePowerUp = swipePowerUp + 1;
        _speed += (float)n1[0];
    }

    public void ForwardMovemnt(float _speed)
    {
        transform.position += Vector3.forward * _speed * Time.deltaTime;
    }

    public void PowerUpMovement(params object[] parameters)
    {
        transform.position += Vector3.forward * _speed * Time.deltaTime;
    }


    void OnCollisionEnter(Collision collision)
    {
        var collectable = collision.gameObject.GetComponent<ICollectable>();

        if (collectable != null)
        {
            if (isDead == false & collectable != null)
            {
                collectable.Collect();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.gameObject.GetComponent<ICollectable>();

        if (isDead == false & obj != null)
        {
            obj.Collect();
        }
    }
    public void StartLifeFunc(float life)
    {
        life = maxLife;
        NotifyToObservers(life, maxLife);
    }

    public void AddLifeFunc(float dmg)
    {
        life += dmg;
        if (life > maxLife)
            life = maxLife;
        NotifyToObservers(life, maxLife);
    }

    public void SubtractLifeFunc(float dmg)
    {
        life -= dmg;
        NotifyToObservers(life, maxLife);
        SoundManager.instance.Play(SoundManager.Types.Damage);
        if (life < minLife)
        {
            EventManager.Trigger("GameOver");
        }
    }

    public void Dead(params object[] parameters)
    {
        //SaveGame.instance.gameData.collectPointInt = PointsContoller.totalScore;
        _speed = 0;
        isDead = true;
        SoundManager.instance.Play(SoundManager.Types.Dead);
        life = minLife;
    }

    public void Subscribe(IObserver obs)
    {
        if (!_allObservers.Contains(obs))
            _allObservers.Add(obs);

    }

    public void Unsubscribe(IObserver obs)
    {
        if (_allObservers.Contains(obs))
            _allObservers.Remove(obs);
    }

    public void NotifyToObservers(float life, float maxLife)
    {
        for (int i = 0; i < _allObservers.Count; i++)
            _allObservers[i].Notify(life, maxLife);
    }

    
}
