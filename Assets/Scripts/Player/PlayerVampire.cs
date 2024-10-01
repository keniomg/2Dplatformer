public class PlayerVampire : Vampire
{
    private void Update()
    {
        if (IsAbilityActive)
        {
            TargetSearcher.ChooseNearestTarget<BearHealth>();
        }
    }
}