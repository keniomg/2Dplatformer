public class PlayerVampirism : Vampirism
{
    private void Update()
    {
        if (IsAbilityActive)
        {
            TargetSearcher.GetTarget<BearHealth>();
        }
    }
}