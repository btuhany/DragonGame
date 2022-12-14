using Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mechanics;

namespace Controllers
{
    public class PlayerController : MonoBehaviour
    {

   
        bool _isMouseClickedOrSpacePressed;
        bool _isRightMouseClickedOrFPressed;
        Rigidbody2D _rigidbody2D;
        Jump _jump;
        AudioSource _audiosource;
        PcInputController _pcInput;
        LaunchProjectile _launchProjectile;
        Death _isDead;
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _jump = GetComponent<Jump>();
            _isDead = GetComponent<Death>();
            _launchProjectile = GetComponent<LaunchProjectile>();
            _pcInput = new PcInputController();
            _audiosource = GetComponent<AudioSource>();
        }
        void Update()
        {
            if(_isDead.IsDead)
                return;
            if(_pcInput.LeftMouseClick || _pcInput.SpaceButtonPressed)
                _isMouseClickedOrSpacePressed = true;
            if (_pcInput.RightMouseClick || _pcInput.FButtonPressed)
                _launchProjectile.LaunchTheProjectile();


        }

        private void FixedUpdate()
        {
            if (_isMouseClickedOrSpacePressed)
            {
                _audiosource.Play();
                _jump.JumpAction(_rigidbody2D);
                _isMouseClickedOrSpacePressed=false;

            }
        }

        
    }


}
