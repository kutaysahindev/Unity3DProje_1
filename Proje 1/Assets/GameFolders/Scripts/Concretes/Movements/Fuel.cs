using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Udemy3DPoject1.Movements
{
    public class Fuel : MonoBehaviour
    {
        [SerializeField] float _maxFuel = 100f;
        [SerializeField] float _currentFuel;
        [SerializeField] ParticleSystem _particle;

        public bool IsEmpty => _currentFuel < 1f;
        private void Awake()
        {
            _currentFuel = _maxFuel;
        }

        public void FuelIncrease(float increase)
        {
            _currentFuel += increase;
            _currentFuel = Mathf.Min(a: _currentFuel, b: _maxFuel);

            if(_particle.isPlaying)
            {
                _particle.Stop();
            }

        }

        public void FuelDecrease(float decrease)
        {
            _currentFuel -= decrease;
            _currentFuel = Mathf.Max(a: _currentFuel, b: 0f);

            if (_particle.isStopped)
            {
                _particle.Play();
            }
        }
    }

}
