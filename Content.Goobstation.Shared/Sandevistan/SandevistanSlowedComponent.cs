using System.Numerics;
using Robust.Shared.GameStates;

namespace Content.Goobstation.Shared.Sandevistan;

/// <summary>
/// Applied to entities affected by a sandevistan slowfield.
/// </summary>
[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public sealed partial class SandevistanSlowedComponent : Component
{
    [DataField, AutoNetworkedField]
    public EntityUid Source { get; set; }

    /// <summary>
    /// Whether this entity is a mob.
    /// </summary>
    [DataField, AutoNetworkedField]
    public bool IsMob { get; set; } = false;

    /// <summary>
    /// Whether this entity is a thrown item.
    /// </summary>
    [DataField, AutoNetworkedField]
    public bool IsThrown { get; set; } = false;

    /// <summary>
    /// Whether this entity is a projectile (bullet).
    /// </summary>
    [DataField, AutoNetworkedField]
    public bool IsProjectile { get; set; } = false;

    [DataField, AutoNetworkedField]
    public float SpeedMultiplier { get; set; } = 1f;

    [DataField, AutoNetworkedField]
    public Vector2 OriginalLinearVelocity { get; set; }

    /// <summary>
    /// Whether this entity is currently actively slowed.
    /// False means the slowdown was removed but the component is pending cleanup.
    /// </summary>
    [DataField, AutoNetworkedField]
    public bool IsSlowed { get; set; } = true;

    [DataField, AutoNetworkedField]
    public bool HadDogVision { get; set; } = false;
}
