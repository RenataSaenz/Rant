using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FunctionalController : MonoBehaviour,  IDamageable
{
    public event Action<float, float> OnHudLife;
    public event Action OnDamge;
    private Model _model;

    private float _life;
    private float _maxLife;
    private float _minLife;
    private Movement _movement;
    public void FunctionalControllerConstructor(Model model, Movement movement)
    {
        _life = model.life;
        _maxLife = model.maxLife;
        _minLife = model.minLife;
        _movement = movement;

    }
    void OnCollisionEnter(Collision collision)
    {
        var collectable = collision.gameObject.GetComponent<ICollectable>();

        if (collectable != null)
        {
            if (collectable != null)
            {
                collectable.Collect();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var obj = other.gameObject.GetComponent<ICollectable>();

        if (obj != null)
        {
            obj.Collect();
        }
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
