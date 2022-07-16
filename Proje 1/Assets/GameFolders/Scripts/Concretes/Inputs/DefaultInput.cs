using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject1.inputs
{
    public class DefaultInput
    {
        private DefaultAction _input;

        public bool IsForceUp { get; private set; }
        public float Rotation { get; private set; }
        public DefaultInput()
        {
            _input = new DefaultAction();

            _input.Rocket.ForceUp.performed += context => IsForceUp = context.ReadValueAsButton();
            _input.Rocket.Rotation.performed += context => Rotation = context.ReadValue<float>();
            _input.Enable();
        }
    }

}
