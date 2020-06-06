public class AbilitySkill : SkillAction
{
    private TrainerLongRecastTimer _trainerTimer;

    public override void Initialize(Skill skill)
    {
        base.Initialize(skill);
        _trainerTimer = GetComponent<TrainerLongRecastTimer>();
        if (!_trainerTimer)
        {
            gameObject.AddComponent<TrainerLongRecastTimer>();
            _trainerTimer = GetComponent<TrainerLongRecastTimer>();
        }
    }

    protected override void StartRecastCountdown(string skillName)
    {
        if (_canRecast)
        {
            _canRecast = false;
            TrainerController.Instance.AddSkillLogEntry(Skill.Name, Icon.sprite);
            _trainerTimer.StartTiming(Skill.RecastTime, EnableRecast);
        }
    }
    protected override void EnableRecast()
    {
        _canRecast = true;
    }

    public override void TriggerSkill()
    {
        EventController.TriggerEvent(Skill.Name, Skill.Name);
    }


}
