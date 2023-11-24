using System;
using Scripts.Abstarct;
using UnityEngine;

namespace Pickable
{
    [Serializable]
    public class PickableSoundPattern : IPickable
    {
        private AudioSource _source;
        private AudioClip _pickSound;

        public PickableSoundPattern(AudioSource source, AudioClip pickSound)
        {
            _source = source;
            _pickSound = pickSound;
        }

        public void PickUp(GameObject picked)
        {
            _source.PlayOneShot(_pickSound);
            GameObject.Destroy(picked);
        }
    }
}