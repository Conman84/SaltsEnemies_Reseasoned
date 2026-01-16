using SaltsEnemies_Reseasoned;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Start()
        {
            //Debug.Log("Hi");
            _time = 0.5f;
            //Debug.Log(Gibs.name);
        }

        public Vector3[] Positions;
        
        public void Update()
        {
            if (_time > 0f)
            {
                _time -= Time.deltaTime;
                return;
            }

            _time = 0.1f;

            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[Gibs.main.maxParticles];

            List<Vector3> newpositions = new List<Vector3>();
            int count = Gibs.GetParticles(particles);
            //Debug.Log(Gibs.name + " triggering once, particles found: " + count.ToString());

            List<ParticleSystem.Particle> triggerOn = [];
            List<int> checkBack = [];

            for (int i = 0; i < count; i++)
            {
                //Vector3 velocity = particles[i].totalVelocity;
                Vector3 position = particles[i].position;
                newpositions.Add(position);

                if (Positions == null) continue;
                if (Positions.Length <= i) continue;

                //Debug.Log(velocity);
                if (Math.Abs(Positions[i].x - position.x) < 0.1f && Math.Abs(Positions[i].y - position.y) < 0.2f && Math.Abs(Positions[i].z - position.z) < 0.1f)
                {
                    //if (particles[i].position.y > 0.1f) continue;
                    triggerOn.Add(particles[i]);
                    checkBack.Add(i);
                    //particles[i].remainingLifetime = 0;
                }
            }

            Positions = newpositions.ToArray();

            if (triggerOn.Count <= 0) return;

            if (SaltsReseasoned.Testing) Debug.Log("sub emitting for " + triggerOn.Count.ToString() + "particles");

            Gibs.TriggerSubEmitter(0, triggerOn);

            foreach (int index in checkBack) particles[index].remainingLifetime = 0;

            Gibs.SetParticles(particles);
        }
    }
    public class HeadGibsManager : MonoBehaviour
    {
        public ParticleSystem Gibs;

        public void SetTargetSystem(ParticleSystem set)
        {
            Gibs = set;
        }

        public void Update()
        {
            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[Gibs.main.maxParticles];

            List<Vector3> newpositions = new List<Vector3>();
            int count = Gibs.GetParticles(particles);
            //Debug.Log(Gibs.name + " triggering once, particles found: " + count.ToString());

            List<ParticleSystem.Particle> triggerOn = [];
            List<int> checkBack = [];

            for (int i = 0; i < count; i++)
            {
                //Vector3 velocity = particles[i].totalVelocity;
                Vector3 position = particles[i].position;
                newpositions.Add(position);


                //Debug.Log(velocity);
                if (position.y <= 0.03)
                {
                    //if (particles[i].position.y > 0.1f) continue;
                    triggerOn.Add(particles[i]);
                    checkBack.Add(i);
                    //particles[i].remainingLifetime = 0;
                }
            }

            if (triggerOn.Count <= 0) return;

            if (SaltsReseasoned.Testing) Debug.Log("sub emitting for " + triggerOn.Count.ToString() + "particles");

            Gibs.TriggerSubEmitter(0, triggerOn);

            foreach (int index in checkBack) particles[index].remainingLifetime = 0;

            Gibs.SetParticles(particles);
        }
    }

    public static class HeadHandler
    {
        public static void Setup() => NotificationHook.AddAction(NotifCheck);
        public static void NotifCheck(string name, object sender, object args)
        {
            if (sender is IUnit unit && unit.UnitTypes != null && unit.UnitTypes.Contains("SkeletonHead_EN"))
            {
                if (name == TriggerCalls.OnDamaged.ToString() && unit.CurrentHealth <= 0)
                {
                    CombatManager.Instance.AddUIAction(new SetUnitAnimationParameterUIAction(unit.ID, unit.IsUnitCharacter, "AllowDie", 1));
                }
                if (name == TriggerCalls.OnHealed.ToString() && unit.CurrentHealth > 0)
                {
                    CombatManager.Instance.AddUIAction(new SetUnitAnimationParameterUIAction(unit.ID, unit.IsUnitCharacter, "AllowDie", 0));
                }
            }
        }
    }
}
