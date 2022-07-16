using System.Collections;
using System.Collections.Generic;
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

        bool _isForceUp;
        float _rotation;

        public float TurnSpeed => _turnSpeed;
        public float Force => _force;

        private void Awake()
        {
            _input = new DefaultInput(); 
            _mover = new Mover(playerController:this);
            _rotator = new Rotator(playerController:this);
        }

        private void Update()
        {
            if (_input.IsForceUp)
            {
                _isForceUp = true;
            }
            else
            {
                _isForceUp = false;
            }

            _rotation = _input.Rotation;
        }

        private void FixedUpdate()
        {
            if (_isForceUp)
            {
                _mover.FixedTick();
            }

            _rotator.FixedTick(_rotation);
        }
    }

}
