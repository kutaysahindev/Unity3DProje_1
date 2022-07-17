using System.Collections;
using System.Collections.Generic;
using Udemy3DPoject1.Movements;
using UdemyProject1.inputs;
using UdemyProject1.Movements;
using UnityEngine;

namespace Udemy3DPoject1.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _turnSpeed = 10f;
        [SerializeField] float _force = 55f;
        Mover _mover;
        DefaultInput _input;
        Rotator _rotator;
        Fuel _fuel;

        bool _canForceUp;
        float _rotation;

        public float TurnSpeed => _turnSpeed;
        public float Force => _force;

        private void Awake()
        {
            _input = new DefaultInput(); 
            _mover = new Mover(playerController:this);
            _rotator = new Rotator(playerController:this);
            _fuel = GetComponent<Fuel>();

        }

        private void Update()
        {
            if (_input.IsForceUp && !_fuel.IsEmpty)
            {
                _canForceUp = true;
            }
            else
            {
                _canForceUp = false;
                _fuel.FuelIncrease(increase: 0.01f);
            }

            _rotation = _input.Rotation;
        }

        private void FixedUpdate()
        {
            if (_canForceUp)
            {
                _mover.FixedTick();
                _fuel.FuelDecrease(0.2f);
            }

            _rotator.FixedTick(_rotation);
        }
    }

}
