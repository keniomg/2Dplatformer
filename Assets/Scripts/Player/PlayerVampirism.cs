public class PlayerVampirism : Vampirism
{
    private void Update()
    {
        if (IsActive)
        {
            TargetSearcher.GetTarget<BearHealth>();
        }
    }
}