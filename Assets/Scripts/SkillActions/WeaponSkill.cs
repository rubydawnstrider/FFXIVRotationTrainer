using UnityEngine;

public class WeaponSkill : SkillAction
{
    private TrainerGcdRecastTimer _recastTimer;
    private TrainerTimer _trainerTimer;
    private bool _recastOkay;
    private bool _gcdOkay;

    public override void Initialize(Skill skill)
    {
        base.Initialize(skill);
        _gcdOkay = true;
        _recastOkay = true;
        
        _recastTimer = GetComponent<TrainerGcdRecastTimer>();
        if (!_recastTimer)
        {
            gameObject.AddComponent<TrainerGcdRecastTimer>();
            _recastTimer = GetComponent<TrainerGcdRecastTimer>();
        }

        _trainerTimer = GetComponent<TrainerTimer>();
        if (!_trainerTimer)
        {
            gameObject.AddComponent<TrainerTimer>();
            _trainerTimer = GetComponent<TrainerTimer>();
        }
    }

    protected override void StartRecastCountdown(string skillName)
    {
        if (_gcdOkay || _canRecast || (_trainerTimer.ElapsedTime <= 0.01f && Skill.Name == skillName))
        {
            TrainerController.Instance.AddSkillLogEntry(Skill.Name, Icon.sprite);
            _recastOkay = false;
            _recastTimer.StartTiming(Skill.RecastTime, EnableRecast);
        }
    }
    protected override void StartGcdCountdown(string skillName)
    {
        if (_gcdOkay)
        {
            if (Mathf.Abs(TrainerController.GcdTime - Skill.RecastTime) <= 0.01f && Skill.Name == skillName)
            {
                TrainerController.Instance.AddSkillLogEntry(Skill.Name, Icon.sprite);
            }

            _recastOkay = false;
            _gcdOkay = false;
            _trainerTimer.StartTiming(TrainerController.GcdTime, EnableRecast);
        }
    }
    protected void EnableGcd()
    {
        _gcdOkay = !_trainerTimer.IsTiming();
    }
    protected override void EnableRecast()
    {
        _gcdOkay = !_trainerTimer.IsTiming();
        _recastOkay = !_recastTimer.IsTiming() && !_trainerTimer.IsTiming();
    }

    public override void TriggerSkill()
    {
        if (_recastOkay && _isOnHotbar)
        {
            EventController.TriggerEvent("GCD", Skill.Name);
            if (Mathf.Abs(TrainerController.GcdTime - Skill.RecastTime) > 0.01f)
            {
                EventController.TriggerEvent(Skill.Name, Skill.Name);
            }

        }
    }

    public override void AddToHotbar()
    {
        base.AddToHotbar();
        EventController.StartListening("GCD", StartGcdCountdown);
    }

}
