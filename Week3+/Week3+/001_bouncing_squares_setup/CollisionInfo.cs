using GXPEngine; // For GameObject

public class CollisionInfo {
	public readonly Vec2 normal;
	public readonly GameObject other;
	public readonly float timeOfImpact;
	public readonly Vec2 oldVelocity;

	public CollisionInfo(Vec2 pNormal, GameObject pOther, float pTimeOfImpact, Vec2 pOldVelocity) {
		normal = pNormal;
		other = pOther;
		timeOfImpact = pTimeOfImpact;
		oldVelocity = pOldVelocity;
	}


}
