using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour, IDamageable, IObservable
{

    public bool isDead;

    public float _speed;
    [SerializeField]
    private float _swipeSpeed;
    [SerializeField]
    private float _jumpForce;
    public float life = 100;
    [SerializeField]
    public float maxLife = 100;
    [SerializeField]
    private float minLife;

    public ManagerUI managerUI;

    Control _control;
    Movement _movement;

    private Rigidbody _rb;

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
        StartLifeFunc(life);
    }

    void FixedUpdate()
    {
        _control.OnUpdate();
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
        NotifyToObservers("StartLife", life, maxLife);
    }

    public void AddLifeFunc(float dmg)
    {
           life += dmg;
        if (life > maxLife)
            life = maxLife;
        NotifyToObservers("AddLife", life, maxLife);
    }

    public void SubtractLifeFunc(float dmg)
    {
        life -= dmg;
        NotifyToObservers("SubtractLife", life, maxLife);
        SoundManager.instance.Play(SoundManager.Types.Damage);
        if (life < minLife)
        {
            Dead();
        }
    }

    public void Dead(params object[] parameters)
    {
        _speed = 0;
        isDead = true;
        EventManager.Trigger("GameOver");
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

    public void NotifyToObservers(string action, float life, float maxLife)
    {
        for (int i = 0; i < _allObservers.Count; i++)
            _allObservers[i].Notify(action, life, maxLife);
    }

    
}
