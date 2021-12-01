using System;
using UnityEngine;

public class FunctionalController : MonoBehaviour,  IDamageable, IPowerUp 
{
    public event Action<float, float> OnHudLife;
    public event Action OnDamge;
    
    private float _life;
    private float _maxLife;
    private float _minLife;
    
    
    private PlayerModel _playerModel;
    private View _view;
    private InputController _inputController;
    private Movement _movement;
    private void Awake()
    {
        _playerModel = GetComponent<PlayerModel>();
        _view = GetComponent<View>();
        
        _life = _playerModel.life;
        _maxLife = _playerModel.maxLife;
        _minLife = _playerModel.minLife;
        
        _movement = new Movement(_playerModel);
        _inputController = new InputController( _playerModel, _movement);
        
        transform.position = _playerModel.InitialPosition;

        EventManager.Subscribe("GameOver", Dead);
    }

    private void Start()
    {
        OnHudLife += _view.UpdateHudLife;
        OnDamge += _view.TakeDamage;
        
        SwipeManager2.instance.OnStartTouch += _inputController.StartTouch;
        SwipeManager2.instance.OnEndTouch += _inputController.EndTouch;
    }

    private void FixedUpdate()
    {
        _inputController.OnUpdate();
    }
    void OnCollisionEnter(Collision collision)
    {
        var collectable = collision.gameObject.GetComponent<ICollectable>();

        if (collectable != null)
        {
            collectable.Collect();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var obj = other.gameObject.GetComponent<ICollectable>();

        if (obj != null) obj.Collect();
    }

    public void ChangePower(float maxDistanceUnits)
    {
       _movement.MoveForward(maxDistanceUnits);
    }

    public void AddLifeFunc(float dmg)
    {
        _life += dmg;
        if (_life > _maxLife) _life = _maxLife;
        OnHudLife?.Invoke(_life, _maxLife);
    }
    public void SubtractLifeFunc(float dmg)
    { 
        _life -= dmg;
        OnHudLife?.Invoke(_life, _maxLife);
        SoundManager.instance.Play(SoundManager.Types.Damage);
      if (_life < _minLife) EventManager.Trigger("GameOver");
        OnDamge?.Invoke();
    }
    public void Dead(params object[] parameters)
    {
        _movement._forwardSpeed = 0;
        _movement._swipeSpeed = 0;
        SoundManager.instance.Play(SoundManager.Types.Dead);
        _life = _minLife;
    }
    
}
