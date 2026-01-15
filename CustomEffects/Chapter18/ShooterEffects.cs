using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltEnemies_Reseasoned
{
    public class DamageByCasterHealthEffect : DamageEffect
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            return base.PerformEffect(stats, caster, targets, areTargetSlots, caster.CurrentHealth * entryVariable, out exitAmount);
        }
    }

    public class ShooterGibsManager : MonoBehaviour
    {
        public ParticleSystem Gibs;
        public float _time;

        public void SetTargetSystem(ParticleSystem set)
        {
            Gibs = set;
        }
        
        public void Update()
        {
            if (_time > 0f)
            {
                _time -= Time.deltaTime;
                return;
            }

            _time = 0.1f;

            ParticleSystem.Particle[] particles = [];

            int count = Gibs.GetParticles(particles);

            List<ParticleSystem.Particle> triggerOn = [];
            List<int> checkBack = [];

            for (int i = 0; i < count; i++)
            {
                Vector3 velocity = particles[i].velocity;
                if (Math.Abs(velocity.x) < 0.1f & Math.Abs(velocity.y) < 0.1f && Math.Abs(velocity.z) < 0.1f)
                {
                    if (particles[i].position.y > 0.1f) continue;
                    triggerOn.Add(particles[i]);
                    checkBack.Add(i);
                    //particles[i].remainingLifetime = 0;
                }
            }

            Gibs.TriggerSubEmitter(0, triggerOn);

            foreach (int index in checkBack) particles[index].remainingLifetime = 0;

            Gibs.SetParticles(particles);
        }
    }
}
