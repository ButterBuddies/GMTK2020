using UnityEngine;

public class Food : Item
{
    [Range(0, 1)]
    public float ConsumeRate = 0.1f;
    public float DelayTime = 2.0f;
    public int BiteCrunch = 3;  // this will help determine how much cat can eat before it get scared or something.. while eating in this condition?
    // or we might just replenish the cat right on the spot without waiting... 

    public void feed(Cat cat )
    {
        // hmm.... huh...
        cat.Feed(this);
        // then dispose this from the manager?
        Destroy(this);  // Pretty sure sarah hates this function but it's a game jam oh well...
    }
}
